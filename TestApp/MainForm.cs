#region System
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

#region SharpRambo
using SharpRambo.DiskpartLib;
using SharpRambo.ExtensionsLib;
#endregion

namespace TestApp
{
    public partial class MainForm : Form
    {
        public const string TableLineSeparator = "<![separator]>";
        public const string DoubleTableLineSeparator = TableLineSeparator + TableLineSeparator;

        public Diskpart DP => new(Path.GetFullPath(Path.Combine(Application.StartupPath, "dps")));

        private string[] TableColumnSpecifier { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await DP.ListVolumes().ForEachAsync(async volume => {
                if (!volume.Trim().StartsWith("Volume ###")) {
#if DEBUG
                    MessageBox.Show(volume  + Environment.NewLine + Environment.NewLine + await parseTableLineSeparator(volume));
#endif

                    string[] volumeInfo = await parseTableLine(volume);
                    ListViewItem volItem = new();

                    await volumeInfo.ForEachAsync(volI => {
                        if (!volI.IsNull()) {
                            if (volI.StartsWith("Volume"))
                                volItem.Text = volI.Split(' ')?.LastOrDefault();
                            else
                                volItem.SubItems.Add(volI);
                        }

                        return Task.CompletedTask;
                    });

                    volumesListView.Items.Add(volItem);
                }
                
                //return Task.CompletedTask;
            });
        }

        private async Task<string[]> parseTableLine(string line)
        {
            if (line.IsNull())
                throw new ArgumentNullException(nameof(line));

            if (line.Contains("---")) {
                TableColumnSpecifier = (await parseTableLineSeparator(line)).Split(TableLineSeparator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                return Array.Empty<string>();
            } else {
                line = await parseTableLineSeparator(line);
                return line.Split(TableLineSeparator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            }
        }

        private async Task<string> parseTableLineSeparator(string line)
        {
            if (!TableColumnSpecifier.IsNull<string>()) {
                int stringIndex = 0;
                string newline = string.Empty;

                await TableColumnSpecifier.ForEachAsync(tcs => {
                    //MessageBox.Show(tcs + Environment.NewLine + line + Environment.NewLine + Environment.NewLine + newline, stringIndex.ToString());

                    //TODO:
                    if (tcs.Length <= line.Length && stringIndex < line.Length && stringIndex + tcs.Length <= line.Length) {
                        newline += line.Substring(stringIndex, tcs.Length).Trim() + (tcs != TableColumnSpecifier.Last() ? TableLineSeparator : string.Empty);
                        stringIndex = stringIndex + tcs.Length + 1;
                    }

                    return Task.CompletedTask;
                });

                line = !newline.IsNull() ? newline : line;
            } else {
                line = line.Replace("  ", TableLineSeparator)
                           .Replace(TableLineSeparator.PadLeft(TableLineSeparator.Length + 1), TableLineSeparator)
                           .Replace(TableLineSeparator.PadRight(TableLineSeparator.Length + 1), TableLineSeparator)
                           .Replace(DoubleTableLineSeparator, TableLineSeparator);

                bool lineCond = line.Contains("  ") ||
                            line.Contains(DoubleTableLineSeparator) ||
                            line.Contains(TableLineSeparator.PadLeft(TableLineSeparator.Length + 1)) ||
                            line.Contains(TableLineSeparator.PadRight(TableLineSeparator.Length + 1));

                if (lineCond)
                    line = await parseTableLineSeparator(line);
            }

            return line;
        }
    }
}
