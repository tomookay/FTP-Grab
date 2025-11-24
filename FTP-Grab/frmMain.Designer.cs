namespace FTP_Grab
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            clbIPAddresses = new CheckedListBox();
            button1 = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            grpBoxIPs = new GroupBox();
            statusStrip1 = new StatusStrip();
            lblLocalPath = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            selectLocalPathToolStripMenuItem = new ToolStripMenuItem();
            selectRemotePathToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            authToolStripMenuItem = new ToolStripMenuItem();
            setToolStripMenuItem = new ToolStripMenuItem();
            nudInterval = new NumericUpDown();
            lblIntervalTitle = new Label();
            label1 = new Label();
            fbdSelectPath = new FolderBrowserDialog();
            progressBar1 = new ProgressBar();
            btnStart = new Button();
            btnStop = new Button();
            timerDownloadFTP = new System.Windows.Forms.Timer(components);
            statusStrip2 = new StatusStrip();
            lblRemotePath = new ToolStripStatusLabel();
            txbFTPLog = new TextBox();
            grpBoxIPs.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudInterval).BeginInit();
            statusStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // clbIPAddresses
            // 
            clbIPAddresses.FormattingEnabled = true;
            clbIPAddresses.Items.AddRange(new object[] { "192.168.0.26" });
            clbIPAddresses.Location = new Point(6, 24);
            clbIPAddresses.Name = "clbIPAddresses";
            clbIPAddresses.Size = new Size(426, 94);
            clbIPAddresses.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(6, 124);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Select All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(276, 124);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(357, 124);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += button3_Click;
            // 
            // grpBoxIPs
            // 
            grpBoxIPs.Controls.Add(btnRemove);
            grpBoxIPs.Controls.Add(btnAdd);
            grpBoxIPs.Controls.Add(button1);
            grpBoxIPs.Controls.Add(clbIPAddresses);
            grpBoxIPs.Location = new Point(12, 27);
            grpBoxIPs.Name = "grpBoxIPs";
            grpBoxIPs.Size = new Size(438, 181);
            grpBoxIPs.TabIndex = 4;
            grpBoxIPs.TabStop = false;
            grpBoxIPs.Text = "IP Addresses";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblLocalPath });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(462, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblLocalPath
            // 
            lblLocalPath.Name = "lblLocalPath";
            lblLocalPath.Size = new Size(106, 17);
            lblLocalPath.Text = "No Path Selected...";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, authToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(462, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectLocalPathToolStripMenuItem, selectRemotePathToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // selectLocalPathToolStripMenuItem
            // 
            selectLocalPathToolStripMenuItem.Name = "selectLocalPathToolStripMenuItem";
            selectLocalPathToolStripMenuItem.Size = new Size(176, 22);
            selectLocalPathToolStripMenuItem.Text = "Select Local Path";
            selectLocalPathToolStripMenuItem.Click += selectLocalPathToolStripMenuItem_Click;
            // 
            // selectRemotePathToolStripMenuItem
            // 
            selectRemotePathToolStripMenuItem.Name = "selectRemotePathToolStripMenuItem";
            selectRemotePathToolStripMenuItem.Size = new Size(176, 22);
            selectRemotePathToolStripMenuItem.Text = "Select Remote Path";
            selectRemotePathToolStripMenuItem.Click += selectRemotePathToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(176, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // authToolStripMenuItem
            // 
            authToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setToolStripMenuItem });
            authToolStripMenuItem.Name = "authToolStripMenuItem";
            authToolStripMenuItem.Size = new Size(45, 20);
            authToolStripMenuItem.Text = "Auth";
            // 
            // setToolStripMenuItem
            // 
            setToolStripMenuItem.Name = "setToolStripMenuItem";
            setToolStripMenuItem.Size = new Size(90, 22);
            setToolStripMenuItem.Text = "Set";
            // 
            // nudInterval
            // 
            nudInterval.Location = new Point(288, 225);
            nudInterval.Maximum = new decimal(new int[] { 36000, 0, 0, 0 });
            nudInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudInterval.Name = "nudInterval";
            nudInterval.Size = new Size(63, 23);
            nudInterval.TabIndex = 8;
            nudInterval.TextAlign = HorizontalAlignment.Center;
            nudInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblIntervalTitle
            // 
            lblIntervalTitle.AutoSize = true;
            lblIntervalTitle.Location = new Point(198, 227);
            lblIntervalTitle.Name = "lblIntervalTitle";
            lblIntervalTitle.Size = new Size(84, 15);
            lblIntervalTitle.TabIndex = 9;
            lblIntervalTitle.Text = "Search Interval";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(357, 227);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 10;
            label1.Text = "second";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 366);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(438, 23);
            progressBar1.TabIndex = 11;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(18, 223);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 12;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(99, 223);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 13;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // timerDownloadFTP
            // 
            timerDownloadFTP.Interval = 100000;
            // 
            // statusStrip2
            // 
            statusStrip2.Items.AddRange(new ToolStripItem[] { lblRemotePath });
            statusStrip2.Location = new Point(0, 406);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new Size(462, 22);
            statusStrip2.TabIndex = 14;
            statusStrip2.Text = "statusStrip2";
            // 
            // lblRemotePath
            // 
            lblRemotePath.Name = "lblRemotePath";
            lblRemotePath.Size = new Size(150, 17);
            lblRemotePath.Text = "No Remote Path Selected...";
            // 
            // txbFTPLog
            // 
            txbFTPLog.Location = new Point(12, 266);
            txbFTPLog.Multiline = true;
            txbFTPLog.Name = "txbFTPLog";
            txbFTPLog.Size = new Size(438, 94);
            txbFTPLog.TabIndex = 15;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 450);
            Controls.Add(txbFTPLog);
            Controls.Add(statusStrip2);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(lblIntervalTitle);
            Controls.Add(nudInterval);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(grpBoxIPs);
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "FTP-Grab";
            grpBoxIPs.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudInterval).EndInit();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox clbIPAddresses;
        private Button button1;
        private Button btnAdd;
        private Button btnRemove;
        private GroupBox grpBoxIPs;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblLocalPath;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem selectLocalPathToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private NumericUpDown nudInterval;
        private Label lblIntervalTitle;
        private Label label1;
        private FolderBrowserDialog fbdSelectPath;
        private ProgressBar progressBar1;
        private ToolStripMenuItem authToolStripMenuItem;
        private ToolStripMenuItem setToolStripMenuItem;
        private ToolStripMenuItem selectRemotePathToolStripMenuItem;
        private Button btnStart;
        private Button btnStop;
        private System.Windows.Forms.Timer timerDownloadFTP;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel lblRemotePath;
        private TextBox txbFTPLog;
    }
}
