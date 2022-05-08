using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

#if NET35_OR_GREATER || NETSTANDARD2_0_OR_GREATER || NETCOREAPP2_1_OR_GREATER || NET5_0_OR_GREATER 
using SharpRambo.ExtensionsLib;
#endif

using DiskpartLib.Properties;

namespace SharpRambo.DiskpartLib
{
    public class Diskpart
    {
        #region Events
        public class ExecutingEventArgs
        {

        }

        public delegate void ExecutingEventHandler(object sender, ExecutingEventArgs e);
        public event ExecutingEventHandler Executing;
        #endregion

        private readonly ProcessStartInfo _DpPSI = null;
        private FileInfo _Script = null;
        private FileInfo _ScriptTpl = null;
        private string _ScriptName = string.Empty;
        private string _ScriptWriteDirectory = string.Empty;

        public DirectoryInfo ScriptDirectory { get; set; }
        public DirectoryInfo TempScriptDirectory { get; set; }

        public string ScriptName
        {
            get => _ScriptName;
            set
            {
#if !NET20
                _ScriptName = !value.IsNull() ? value : string.Empty;
#else
                _ScriptName = value != null && value.Trim() != string.Empty ? value : string.Empty;
#endif
                _Script = new FileInfo(Path.GetFullPath(_ScriptWriteDirectory + "\\" + _ScriptName + ".dps"));
                _ScriptTpl = new FileInfo(Path.GetFullPath(_ScriptWriteDirectory + "\\" + _ScriptName + ".dpst"));
            }
        }

        public Diskpart(string scriptDirectoryPath, string tempDirectoryPath = null, bool redirectError = false)
        {
#if !NET20
            if (scriptDirectoryPath.IsNull())
#else
            if (scriptDirectoryPath == null || scriptDirectoryPath.Trim() == string.Empty)
#endif
                throw new ArgumentNullException(nameof(scriptDirectoryPath));

            ScriptDirectory = new DirectoryInfo(scriptDirectoryPath);
            TempScriptDirectory =
#if !NET20
            !tempDirectoryPath.IsNull() ? new DirectoryInfo(tempDirectoryPath) : null;

            if (TempScriptDirectory != null)
                TempScriptDirectory.CreateAnyway();
            else
                ScriptDirectory.CreateAnyway();
#else
            scriptDirectoryPath != null && scriptDirectoryPath.Trim() != string.Empty ? new DirectoryInfo(scriptDirectoryPath) : null;
            Directory.CreateDirectory(Path.GetFullPath(ScriptDirectory.FullName));
            if (TempScriptDirectory != null) Directory.CreateDirectory(Path.GetFullPath(TempScriptDirectory.FullName));
#endif

            _ScriptWriteDirectory = TempScriptDirectory != null && TempScriptDirectory.Exists
                ? Path.GetFullPath(TempScriptDirectory.FullName)
                : Path.GetFullPath(ScriptDirectory.FullName);

            File.WriteAllBytes(_ScriptWriteDirectory + "\\clean-disk.dpst", Resources.clean_disk_tpl);
            File.WriteAllBytes(_ScriptWriteDirectory + "\\disk-info.dpst", Resources.disk_info_tpl);
            File.WriteAllBytes(_ScriptWriteDirectory + "\\list-disks.dps", Resources.list_disks);
            File.WriteAllBytes(_ScriptWriteDirectory + "\\list-volumes.dps", Resources.list_volumes);

            _DpPSI = new ProcessStartInfo() {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = redirectError,
#if NET35
                FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "diskpart.exe")
#else
                FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "diskpart.exe")
#endif
            };
        }

        public Process Start(Dictionary<string, string> keyValuePairs = null)
        {
            int attempts = 50;
            Process dpP =
#if NET5_0_OR_GREATER
                new()
#else
                new Process()
#endif
            { StartInfo = _DpPSI };

            if (_ScriptTpl.Exists)
                parseScriptTpl(keyValuePairs);

            while ((!_Script.Exists || _Script.ReadAllText().IsNull()) && attempts > 0) {
                attempts--;
                System.Threading.Thread.Sleep(10);
            }

            if (_Script.Exists) {
                _DpPSI.Arguments = "/s \"" + Path.GetFullPath(_Script.FullName) + "\"";
                return dpP.Start() ? dpP : null;
            } else
                return null;
        }

        public List<string> ListVolumes(string writePrefix = null, bool trimLines = true)
        {
            ScriptName = "list-volumes";
            Process p = Start();

            return p != null ? readDpStream(p.StandardOutput, writePrefix, trimLines) : new List<string>();
        }

        public List<string> DiskInfo(uint diskID = 0, string writePrefix = null, bool trimLines = true)
        {
            ScriptName = "disk-info";
            Process p = Start(new Dictionary<string, string>() { { "disk", diskID.ToString() } });

            return p != null ? readDpStream(p.StandardOutput, writePrefix, trimLines) : new List<string>();
        }

        public List<string> ListDisks(string writePrefix = null, bool trimLines = true)
        {
            ScriptName = "list-disks";
            Process p = Start();

            return p != null ? readDpStream(Start().StandardOutput, writePrefix, trimLines) : new List<string>();
        }

        public List<string> CleanDisk(uint diskID = 0)
        {
            ScriptName = "clean-disk";
            Process p = Start(new Dictionary<string, string>() { { "disk", diskID.ToString() } });

            return p != null ? readDpStream(p.StandardOutput) : new List<string>();
        }

        private void parseScriptTpl(Dictionary<string, string> keyValuePairs)
        {
            if (_Script.Exists)
                _Script.Delete();

            string template = File.ReadAllText(Path.GetFullPath(_ScriptTpl.FullName));

#if !NET20
            if (!keyValuePairs.IsNull())
#else
            if (keyValuePairs != null && keyValuePairs.Count > 0)
#endif
                foreach (KeyValuePair<string, string> valuePair in keyValuePairs)
#if !NET20
                    if (!valuePair.Key.IsNull())
#else
                    if (valuePair.Key.Trim() != string.Empty)
#endif
                        template = template.Replace("%" + valuePair.Key + "%", valuePair.Value);

            File.WriteAllText(_Script.FullName, template);
        }

        private List<string> readDpStream(StreamReader stream, string writePrefix = null, bool trimLines = true)
        {
#if NET5_0_OR_GREATER
            List<string> lines = new();
#else
            List<string> lines = new List<string>();
#endif
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            while (!stream.EndOfStream)
            {
                string line = readDpLine(stream, trimLines);
#if !NET20
                if (!line.IsNull())
                    lines.Add((!writePrefix.IsNull() ? writePrefix : string.Empty) + line);
#else
                if (line != null && line.Trim() != string.Empty)
                    lines.Add((writePrefix != null && writePrefix.Trim() != string.Empty ? writePrefix : string.Empty) + line);
#endif

            }

            stream.Close();
            return lines;
        }

        private string readDpLine(StreamReader stream, bool trimLine = true)
        {
            if (stream != null)
            {
                string l = stream.ReadLine();

#if !NET20
                if (!l.IsNull())
#else
                if (l != null && l.Trim() != string.Empty)
#endif
                {
                    if (!(
                        new Regex("^Microsoft DiskPart-Version .*$").IsMatch(l) ||
                        new Regex(@"^Copyright \(C\) Microsoft Corporation\.$").IsMatch(l) ||
                        new Regex("^.+: " + Environment.MachineName + "$").IsMatch(l)
                    ))
                        return trimLine ? l.Trim() : l;
                }
            }

            return string.Empty;
        }
    }
}
