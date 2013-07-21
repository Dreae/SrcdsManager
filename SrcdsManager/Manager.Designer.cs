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
            this.ServerList = new System.Windows.Forms.ListBox();
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
            this.SuspendLayout();
            // 
            // ServerList
            // 
            this.ServerList.FormattingEnabled = true;
            this.ServerList.Location = new System.Drawing.Point(12, 23);
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(76, 238);
            this.ServerList.TabIndex = 1;
            this.ServerList.SelectedIndexChanged += new System.EventHandler(this.ServerList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Servers:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(183, 123);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 20);
            this.name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // parms
            // 
            this.parms.Location = new System.Drawing.Point(94, 149);
            this.parms.Name = "parms";
            this.parms.Size = new System.Drawing.Size(189, 20);
            this.parms.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Params:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Executable:";
            // 
            // executable
            // 
            this.executable.Location = new System.Drawing.Point(94, 188);
            this.executable.Name = "executable";
            this.executable.Size = new System.Drawing.Size(189, 20);
            this.executable.TabIndex = 8;
            // 
            // browseExe
            // 
            this.browseExe.Location = new System.Drawing.Point(223, 214);
            this.browseExe.Name = "browseExe";
            this.browseExe.Size = new System.Drawing.Size(60, 20);
            this.browseExe.TabIndex = 9;
            this.browseExe.Text = "Browse";
            this.browseExe.UseVisualStyleBackColor = true;
            this.browseExe.Click += new System.EventHandler(this.button1_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(223, 260);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(158, 260);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(60, 23);
            this.stopButton.TabIndex = 12;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(94, 260);
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
            this.label5.Location = new System.Drawing.Point(94, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.Chartreuse;
            this.status.Location = new System.Drawing.Point(140, 23);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(47, 13);
            this.status.TabIndex = 15;
            this.status.Text = "Running";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Crashes: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Uptime: ";
            // 
            // crashes
            // 
            this.crashes.AutoSize = true;
            this.crashes.Location = new System.Drawing.Point(140, 47);
            this.crashes.Name = "crashes";
            this.crashes.Size = new System.Drawing.Size(13, 13);
            this.crashes.TabIndex = 18;
            this.crashes.Text = "0";
            // 
            // uptime
            // 
            this.uptime.AutoSize = true;
            this.uptime.Location = new System.Drawing.Point(140, 70);
            this.uptime.Name = "uptime";
            this.uptime.Size = new System.Drawing.Size(31, 13);
            this.uptime.TabIndex = 19;
            this.uptime.Text = "0:0:0";
            // 
            // newServ
            // 
            this.newServ.Location = new System.Drawing.Point(12, 267);
            this.newServ.Name = "newServ";
            this.newServ.Size = new System.Drawing.Size(75, 23);
            this.newServ.TabIndex = 20;
            this.newServ.Text = "New Server";
            this.newServ.UseVisualStyleBackColor = true;
            this.newServ.Click += new System.EventHandler(this.newServ_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 294);
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
            this.Controls.Add(this.ServerList);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Manager";
            this.Text = "SrcdsManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ServerList;
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

    }
}

