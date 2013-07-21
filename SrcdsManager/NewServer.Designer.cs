namespace SrcdsManager
{
    partial class NewServer
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
            this.label4 = new System.Windows.Forms.Label();
            this.servID = new System.Windows.Forms.TextBox();
            this.servName = new System.Windows.Forms.TextBox();
            this.servExe = new System.Windows.Forms.TextBox();
            this.servParams = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.ipAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.iPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Server Executable:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server Parameters:";
            // 
            // servID
            // 
            this.servID.Location = new System.Drawing.Point(73, 6);
            this.servID.Name = "servID";
            this.servID.Size = new System.Drawing.Size(159, 20);
            this.servID.TabIndex = 4;
            // 
            // servName
            // 
            this.servName.Location = new System.Drawing.Point(90, 32);
            this.servName.Name = "servName";
            this.servName.Size = new System.Drawing.Size(142, 20);
            this.servName.TabIndex = 5;
            // 
            // servExe
            // 
            this.servExe.Location = new System.Drawing.Point(15, 109);
            this.servExe.Name = "servExe";
            this.servExe.Size = new System.Drawing.Size(217, 20);
            this.servExe.TabIndex = 6;
            // 
            // servParams
            // 
            this.servParams.Location = new System.Drawing.Point(15, 164);
            this.servParams.Name = "servParams";
            this.servParams.Size = new System.Drawing.Size(217, 20);
            this.servParams.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(73, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "IP Address:";
            // 
            // ipAddr
            // 
            this.ipAddr.Location = new System.Drawing.Point(15, 70);
            this.ipAddr.Name = "ipAddr";
            this.ipAddr.Size = new System.Drawing.Size(97, 20);
            this.ipAddr.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Port:";
            // 
            // iPort
            // 
            this.iPort.Location = new System.Drawing.Point(154, 70);
            this.iPort.Name = "iPort";
            this.iPort.Size = new System.Drawing.Size(75, 20);
            this.iPort.TabIndex = 14;
            // 
            // NewServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 227);
            this.Controls.Add(this.iPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ipAddr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.servParams);
            this.Controls.Add(this.servExe);
            this.Controls.Add(this.servName);
            this.Controls.Add(this.servID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewServer";
            this.Text = "NewServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox servID;
        private System.Windows.Forms.TextBox servName;
        private System.Windows.Forms.TextBox servExe;
        private System.Windows.Forms.TextBox servParams;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ipAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox iPort;
    }
}