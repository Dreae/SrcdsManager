namespace SrcdsManager
{
    partial class InstallServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.servAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.servPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.servDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.servId = new System.Windows.Forms.TextBox();
            this.servName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.servParams = new System.Windows.Forms.TextBox();
            this.installButton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP Address:";
            // 
            // servAddr
            // 
            this.servAddr.Location = new System.Drawing.Point(15, 110);
            this.servAddr.Name = "servAddr";
            this.servAddr.Size = new System.Drawing.Size(119, 20);
            this.servAddr.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Port:";
            // 
            // servPort
            // 
            this.servPort.Location = new System.Drawing.Point(175, 110);
            this.servPort.Name = "servPort";
            this.servPort.Size = new System.Drawing.Size(82, 20);
            this.servPort.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Server Directory:";
            // 
            // servDir
            // 
            this.servDir.Location = new System.Drawing.Point(15, 149);
            this.servDir.Name = "servDir";
            this.servDir.Size = new System.Drawing.Size(242, 20);
            this.servDir.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // servId
            // 
            this.servId.Location = new System.Drawing.Point(73, 6);
            this.servId.Name = "servId";
            this.servId.Size = new System.Drawing.Size(184, 20);
            this.servId.TabIndex = 9;
            // 
            // servName
            // 
            this.servName.Location = new System.Drawing.Point(93, 30);
            this.servName.Name = "servName";
            this.servName.Size = new System.Drawing.Size(164, 20);
            this.servName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Server Parameters:";
            // 
            // servParams
            // 
            this.servParams.Location = new System.Drawing.Point(15, 201);
            this.servParams.Name = "servParams";
            this.servParams.Size = new System.Drawing.Size(242, 20);
            this.servParams.TabIndex = 12;
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(182, 227);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 13;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(101, 227);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 14;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Game:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Counter-Strike",
            "Counter-Strike: Global Offensive",
            "Counter-Strike: Condition Zero",
            "Counter-Strike: Source",
            "Day of Defeat: Source",
            "Deathmatch Classic",
            "Garry\'s Mod",
            "Half-Life",
            "Left 4 Dead 2",
            "Team Fortress 2"});
            this.comboBox1.Location = new System.Drawing.Point(56, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // InstallServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 262);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.servParams);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.servName);
            this.Controls.Add(this.servId);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.servDir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.servPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.servAddr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InstallServer";
            this.Text = "Install Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox servAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox servPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox servDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox servId;
        private System.Windows.Forms.TextBox servName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox servParams;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}