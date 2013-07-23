namespace SrcdsManager
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.parms = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.executable = new System.Windows.Forms.TextBox();
            this.browseExe = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.crashes = new System.Windows.Forms.Label();
            this.uptime = new System.Windows.Forms.Label();
            this.newServ = new System.Windows.Forms.Button();
            this.deleteServ = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.addr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.restart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steamCmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runOnStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.ServerList = new System.Windows.Forms.DataGridView();
            this.state = new System.Windows.Forms.DataGridViewImageColumn();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUptime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCrashes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIPAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgContextStart = new System.Windows.Forms.ToolStripMenuItem();
            this.dgContextStop = new System.Windows.Forms.ToolStripMenuItem();
            this.dgContextRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.dgContextUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerList)).BeginInit();
            this.dataGridContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Servers:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(106, 308);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 20);
            this.name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // parms
            // 
            this.parms.Location = new System.Drawing.Point(314, 308);
            this.parms.Name = "parms";
            this.parms.Size = new System.Drawing.Size(181, 20);
            this.parms.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Params:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Executable:";
            // 
            // executable
            // 
            this.executable.Location = new System.Drawing.Point(314, 347);
            this.executable.Name = "executable";
            this.executable.Size = new System.Drawing.Size(181, 20);
            this.executable.TabIndex = 5;
            // 
            // browseExe
            // 
            this.browseExe.Location = new System.Drawing.Point(314, 373);
            this.browseExe.Name = "browseExe";
            this.browseExe.Size = new System.Drawing.Size(60, 20);
            this.browseExe.TabIndex = 9;
            this.browseExe.Text = "Browse";
            this.browseExe.UseVisualStyleBackColor = true;
            this.browseExe.Click += new System.EventHandler(this.button1_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(557, 373);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(492, 373);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(60, 23);
            this.stopButton.TabIndex = 12;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(106, 371);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(58, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.Chartreuse;
            this.status.Location = new System.Drawing.Point(547, 315);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(47, 13);
            this.status.TabIndex = 15;
            this.status.Text = "Running";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Crashes: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Uptime: ";
            // 
            // crashes
            // 
            this.crashes.AutoSize = true;
            this.crashes.Location = new System.Drawing.Point(547, 331);
            this.crashes.Name = "crashes";
            this.crashes.Size = new System.Drawing.Size(13, 13);
            this.crashes.TabIndex = 18;
            this.crashes.Text = "0";
            // 
            // uptime
            // 
            this.uptime.AutoSize = true;
            this.uptime.Location = new System.Drawing.Point(547, 354);
            this.uptime.Name = "uptime";
            this.uptime.Size = new System.Drawing.Size(31, 13);
            this.uptime.TabIndex = 19;
            this.uptime.Text = "0:0:0";
            // 
            // newServ
            // 
            this.newServ.Location = new System.Drawing.Point(15, 288);
            this.newServ.Name = "newServ";
            this.newServ.Size = new System.Drawing.Size(75, 23);
            this.newServ.TabIndex = 20;
            this.newServ.Text = "New Server";
            this.newServ.UseVisualStyleBackColor = true;
            this.newServ.Click += new System.EventHandler(this.newServ_Click);
            // 
            // deleteServ
            // 
            this.deleteServ.Location = new System.Drawing.Point(170, 371);
            this.deleteServ.Name = "deleteServ";
            this.deleteServ.Size = new System.Drawing.Size(56, 23);
            this.deleteServ.TabIndex = 21;
            this.deleteServ.Text = "Delete";
            this.deleteServ.UseVisualStyleBackColor = true;
            this.deleteServ.Click += new System.EventHandler(this.deleteServ_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "IP Address:";
            // 
            // addr
            // 
            this.addr.Location = new System.Drawing.Point(106, 347);
            this.addr.Name = "addr";
            this.addr.Size = new System.Drawing.Size(90, 20);
            this.addr.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Port:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(202, 347);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(90, 20);
            this.port.TabIndex = 3;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(428, 373);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(59, 23);
            this.restart.TabIndex = 26;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steamCmdToolStripMenuItem,
            this.runOnStartToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.Visualpharm_Ios7_Settings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // steamCmdToolStripMenuItem
            // 
            this.steamCmdToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.steam;
            this.steamCmdToolStripMenuItem.Name = "steamCmdToolStripMenuItem";
            this.steamCmdToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.steamCmdToolStripMenuItem.Text = "SteamCmd";
            this.steamCmdToolStripMenuItem.Click += new System.EventHandler(this.steamCmdToolStripMenuItem_Click);
            // 
            // runOnStartToolStripMenuItem
            // 
            this.runOnStartToolStripMenuItem.Name = "runOnStartToolStripMenuItem";
            this.runOnStartToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.runOnStartToolStripMenuItem.Text = "Run on Start";
            this.runOnStartToolStripMenuItem.Click += new System.EventHandler(this.runOnStartToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateServerToolStripMenuItem,
            this.installServerToolStripMenuItem});
            this.toolsToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.Visualpharm_Ios7_Settings_2;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // updateServerToolStripMenuItem
            // 
            this.updateServerToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.Custom_Icon_Design_Pretty_Office_4_Upload;
            this.updateServerToolStripMenuItem.Name = "updateServerToolStripMenuItem";
            this.updateServerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.updateServerToolStripMenuItem.Text = "Update Server";
            this.updateServerToolStripMenuItem.Click += new System.EventHandler(this.updateServerToolStripMenuItem_Click);
            // 
            // installServerToolStripMenuItem
            // 
            this.installServerToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.download_icon;
            this.installServerToolStripMenuItem.Name = "installServerToolStripMenuItem";
            this.installServerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.installServerToolStripMenuItem.Text = "Install Server";
            this.installServerToolStripMenuItem.Click += new System.EventHandler(this.installServerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.Kyo_Tux_Delikate_Info;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "steamCmdDialog";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // ServerList
            // 
            this.ServerList.AllowUserToAddRows = false;
            this.ServerList.AllowUserToDeleteRows = false;
            this.ServerList.AllowUserToResizeColumns = false;
            this.ServerList.AllowUserToResizeRows = false;
            this.ServerList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ServerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ServerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.state,
            this.ServerName,
            this.dgStatus,
            this.dgUptime,
            this.dgCrashes,
            this.dgIPAddr,
            this.dgPort});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServerList.DefaultCellStyle = dataGridViewCellStyle2;
            this.ServerList.EnableHeadersVisualStyles = false;
            this.ServerList.Location = new System.Drawing.Point(12, 51);
            this.ServerList.MultiSelect = false;
            this.ServerList.Name = "ServerList";
            this.ServerList.ReadOnly = true;
            this.ServerList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ServerList.RowHeadersVisible = false;
            this.ServerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServerList.Size = new System.Drawing.Size(601, 231);
            this.ServerList.TabIndex = 28;
            this.ServerList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ServerList_NewRow);
            this.ServerList.SelectionChanged += new System.EventHandler(this.ServerList_SelectionChanged);
            this.ServerList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServerList_Clicked);
            // 
            // state
            // 
            this.state.HeaderText = "";
            this.state.Image = global::SrcdsManager.Properties.Resources.offline;
            this.state.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Width = 35;
            // 
            // ServerName
            // 
            this.ServerName.HeaderText = "Server Name";
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            // 
            // dgStatus
            // 
            this.dgStatus.HeaderText = "Status";
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            this.dgStatus.Width = 75;
            // 
            // dgUptime
            // 
            this.dgUptime.HeaderText = "Uptime";
            this.dgUptime.Name = "dgUptime";
            this.dgUptime.ReadOnly = true;
            // 
            // dgCrashes
            // 
            this.dgCrashes.HeaderText = "Crashes";
            this.dgCrashes.Name = "dgCrashes";
            this.dgCrashes.ReadOnly = true;
            // 
            // dgIPAddr
            // 
            this.dgIPAddr.HeaderText = "IP Address";
            this.dgIPAddr.Name = "dgIPAddr";
            this.dgIPAddr.ReadOnly = true;
            // 
            // dgPort
            // 
            this.dgPort.HeaderText = "Port";
            this.dgPort.Name = "dgPort";
            this.dgPort.ReadOnly = true;
            this.dgPort.Width = 85;
            // 
            // dataGridContext
            // 
            this.dataGridContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dgContextStart,
            this.dgContextStop,
            this.dgContextRestart,
            this.dgContextUpdate});
            this.dataGridContext.Name = "contextMenuStrip1";
            this.dataGridContext.Size = new System.Drawing.Size(113, 92);
            // 
            // dgContextStart
            // 
            this.dgContextStart.Image = global::SrcdsManager.Properties.Resources.online;
            this.dgContextStart.Name = "dgContextStart";
            this.dgContextStart.Size = new System.Drawing.Size(112, 22);
            this.dgContextStart.Text = "Start";
            this.dgContextStart.Click += new System.EventHandler(this.dgContextStart_Click);
            // 
            // dgContextStop
            // 
            this.dgContextStop.Image = global::SrcdsManager.Properties.Resources.offline;
            this.dgContextStop.Name = "dgContextStop";
            this.dgContextStop.Size = new System.Drawing.Size(112, 22);
            this.dgContextStop.Text = "Stop";
            this.dgContextStop.Click += new System.EventHandler(this.dgContextStop_Click);
            // 
            // dgContextRestart
            // 
            this.dgContextRestart.Image = global::SrcdsManager.Properties.Resources.restart_icon_0016057b8f364cd6cbee64b83ac281de_Medium;
            this.dgContextRestart.Name = "dgContextRestart";
            this.dgContextRestart.Size = new System.Drawing.Size(112, 22);
            this.dgContextRestart.Text = "Restart";
            this.dgContextRestart.Click += new System.EventHandler(this.dgContextRestart_Click);
            // 
            // dgContextUpdate
            // 
            this.dgContextUpdate.Image = global::SrcdsManager.Properties.Resources.Custom_Icon_Design_Pretty_Office_4_Upload;
            this.dgContextUpdate.Name = "dgContextUpdate";
            this.dgContextUpdate.Size = new System.Drawing.Size(112, 22);
            this.dgContextUpdate.Text = "Update";
            this.dgContextUpdate.Click += new System.EventHandler(this.dgContextUpdate_Click);
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.autoStart.Location = new System.Drawing.Point(212, 310);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(95, 17);
            this.autoStart.TabIndex = 29;
            this.autoStart.Text = "AutomaticStart";
            this.autoStart.UseVisualStyleBackColor = true;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(625, 407);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.ServerList);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.addr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.deleteServ);
            this.Controls.Add(this.newServ);
            this.Controls.Add(this.uptime);
            this.Controls.Add(this.crashes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.browseExe);
            this.Controls.Add(this.executable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.parms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Manager";
            this.Text = "SrcdsManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerList)).EndInit();
            this.dataGridContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox parms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox executable;
        private System.Windows.Forms.Button browseExe;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label crashes;
        private System.Windows.Forms.Label uptime;
        private System.Windows.Forms.Button newServ;
        private System.Windows.Forms.Button deleteServ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox addr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem steamCmdToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installServerToolStripMenuItem;
        private System.Windows.Forms.DataGridView ServerList;
        private System.Windows.Forms.ContextMenuStrip dataGridContext;
        private System.Windows.Forms.ToolStripMenuItem dgContextStart;
        private System.Windows.Forms.ToolStripMenuItem dgContextStop;
        private System.Windows.Forms.ToolStripMenuItem dgContextRestart;
        private System.Windows.Forms.ToolStripMenuItem dgContextUpdate;
        private System.Windows.Forms.DataGridViewImageColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUptime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCrashes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIPAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPort;
        private System.Windows.Forms.ToolStripMenuItem runOnStartToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoStart;

    }
}

