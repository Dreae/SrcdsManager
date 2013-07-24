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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.newServ = new System.Windows.Forms.Button();
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
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logBox = new System.Windows.Forms.TextBox();
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
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(553, 288);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(553, 328);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(60, 23);
            this.stopButton.TabIndex = 12;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
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
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(553, 367);
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
            this.settingsToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.settings_gear;
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
            this.toolsToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.settings_wrench;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // updateServerToolStripMenuItem
            // 
            this.updateServerToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.updateicon;
            this.updateServerToolStripMenuItem.Name = "updateServerToolStripMenuItem";
            this.updateServerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.updateServerToolStripMenuItem.Text = "Update Server";
            this.updateServerToolStripMenuItem.Click += new System.EventHandler(this.updateServerToolStripMenuItem_Click);
            // 
            // installServerToolStripMenuItem
            // 
            this.installServerToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.update_icon;
            this.installServerToolStripMenuItem.Name = "installServerToolStripMenuItem";
            this.installServerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.installServerToolStripMenuItem.Text = "Install Server";
            this.installServerToolStripMenuItem.Click += new System.EventHandler(this.installServerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.infoicon;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServerList.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgContextUpdate,
            this.configurationToolStripMenuItem});
            this.dataGridContext.Name = "contextMenuStrip1";
            this.dataGridContext.Size = new System.Drawing.Size(149, 114);
            // 
            // dgContextStart
            // 
            this.dgContextStart.Image = global::SrcdsManager.Properties.Resources.online;
            this.dgContextStart.Name = "dgContextStart";
            this.dgContextStart.Size = new System.Drawing.Size(148, 22);
            this.dgContextStart.Text = "Start";
            this.dgContextStart.Click += new System.EventHandler(this.dgContextStart_Click);
            // 
            // dgContextStop
            // 
            this.dgContextStop.Image = global::SrcdsManager.Properties.Resources.offline;
            this.dgContextStop.Name = "dgContextStop";
            this.dgContextStop.Size = new System.Drawing.Size(148, 22);
            this.dgContextStop.Text = "Stop";
            this.dgContextStop.Click += new System.EventHandler(this.dgContextStop_Click);
            // 
            // dgContextRestart
            // 
            this.dgContextRestart.Image = global::SrcdsManager.Properties.Resources.restart;
            this.dgContextRestart.Name = "dgContextRestart";
            this.dgContextRestart.Size = new System.Drawing.Size(148, 22);
            this.dgContextRestart.Text = "Restart";
            this.dgContextRestart.Click += new System.EventHandler(this.dgContextRestart_Click);
            // 
            // dgContextUpdate
            // 
            this.dgContextUpdate.Image = global::SrcdsManager.Properties.Resources.updateicon;
            this.dgContextUpdate.Name = "dgContextUpdate";
            this.dgContextUpdate.Size = new System.Drawing.Size(148, 22);
            this.dgContextUpdate.Text = "Update";
            this.dgContextUpdate.Click += new System.EventHandler(this.dgContextUpdate_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Image = global::SrcdsManager.Properties.Resources.settings_gear;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(106, 290);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(441, 100);
            this.logBox.TabIndex = 29;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(625, 402);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.ServerList);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.newServ);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
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
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button newServ;
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
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;

    }
}

