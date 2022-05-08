
namespace TestApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.volumesListView = new System.Windows.Forms.ListView();
            this.chVolID = new System.Windows.Forms.ColumnHeader();
            this.chVolLetter = new System.Windows.Forms.ColumnHeader();
            this.chVolLabel = new System.Windows.Forms.ColumnHeader();
            this.chVolFormat = new System.Windows.Forms.ColumnHeader();
            this.chVolType = new System.Windows.Forms.ColumnHeader();
            this.partitionsListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.disksListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(848, 98);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diskpart Script:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(848, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Execute Script";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 170);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Script";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.volumesListView);
            this.groupBox2.Controls.Add(this.partitionsListView);
            this.groupBox2.Controls.Add(this.disksListView);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1215, 205);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Common Features";
            // 
            // volumesListView
            // 
            this.volumesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVolID,
            this.chVolLetter,
            this.chVolLabel,
            this.chVolFormat,
            this.chVolType});
            this.volumesListView.FullRowSelect = true;
            this.volumesListView.HideSelection = false;
            this.volumesListView.Location = new System.Drawing.Point(812, 37);
            this.volumesListView.Name = "volumesListView";
            this.volumesListView.Size = new System.Drawing.Size(397, 97);
            this.volumesListView.TabIndex = 7;
            this.volumesListView.UseCompatibleStateImageBehavior = false;
            this.volumesListView.View = System.Windows.Forms.View.Details;
            // 
            // chVolID
            // 
            this.chVolID.Text = "ID";
            this.chVolID.Width = 25;
            // 
            // chVolLetter
            // 
            this.chVolLetter.Text = "Letter";
            this.chVolLetter.Width = 42;
            // 
            // chVolLabel
            // 
            this.chVolLabel.Text = "Label";
            this.chVolLabel.Width = 100;
            // 
            // chVolFormat
            // 
            this.chVolFormat.Text = "Format";
            this.chVolFormat.Width = 100;
            // 
            // chVolType
            // 
            this.chVolType.Text = "Type";
            this.chVolType.Width = 100;
            // 
            // partitionsListView
            // 
            this.partitionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.partitionsListView.HideSelection = false;
            this.partitionsListView.Location = new System.Drawing.Point(409, 37);
            this.partitionsListView.Name = "partitionsListView";
            this.partitionsListView.Size = new System.Drawing.Size(397, 97);
            this.partitionsListView.TabIndex = 6;
            this.partitionsListView.UseCompatibleStateImageBehavior = false;
            this.partitionsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            // 
            // disksListView
            // 
            this.disksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.disksListView.HideSelection = false;
            this.disksListView.Location = new System.Drawing.Point(6, 37);
            this.disksListView.Name = "disksListView";
            this.disksListView.Size = new System.Drawing.Size(397, 97);
            this.disksListView.TabIndex = 5;
            this.disksListView.UseCompatibleStateImageBehavior = false;
            this.disksListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Detected Partitions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Detected Disks:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(575, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detected Volumes:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 549);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(860, 126);
            this.textBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Console Output:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 687);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "DiskPartLib TestApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView volumesListView;
        private System.Windows.Forms.ListView partitionsListView;
        private System.Windows.Forms.ListView disksListView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader chVolID;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader chVolLetter;
        private System.Windows.Forms.ColumnHeader chVolLabel;
        private System.Windows.Forms.ColumnHeader chVolType;
        private System.Windows.Forms.ColumnHeader chVolFormat;
    }
}

