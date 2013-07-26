﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SrcdsManager
{
    public partial class NewServer : Form
    {
        private Manager sender;
        private List<CheckBox> cpuList = new List<CheckBox>();

        public NewServer(object sender)
        {
            InitializeComponent();
            this.sender = (Manager)sender;

            cpuList.Add(cpu1);
            cpuList.Add(cpu2);
            cpuList.Add(cpu3);
            cpuList.Add(cpu4);
            cpuList.Add(cpu5);
            cpuList.Add(cpu6);
            cpuList.Add(cpu7);
            cpuList.Add(cpu8);
            cpuList.Add(cpu9);
            cpuList.Add(cpu10);
            cpuList.Add(cpu12);
            cpuList.Add(cpu13);
            cpuList.Add(cpu14);
            cpuList.Add(cpu15);
            cpuList.Add(cpu16);
            foreach (CheckBox box in cpuList)
            {
                box.CheckStateChanged += new EventHandler(cpu_CheckedChanged);
            }
            for (int c = 0; c < Environment.ProcessorCount; c++)
            {
                cpuList[c].Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                servExe.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("servers.xml");
            XmlAttribute id = xmlDoc.CreateAttribute("id");
            XmlAttribute name = xmlDoc.CreateAttribute("name");
            XmlAttribute addr = xmlDoc.CreateAttribute("address");
            XmlAttribute port = xmlDoc.CreateAttribute("port");
            XmlAttribute auto = xmlDoc.CreateAttribute("autostart");
            XmlNode root = xmlDoc.DocumentElement;

            System.Net.IPAddress ip;
            if (!System.Net.IPAddress.TryParse(ipAddr.Text, out ip))
            {
                MessageBox.Show("The value enetered in the IP field is invalid", "Invalid IP");
                return;
            }
            uint _port;
            if (!uint.TryParse(iPort.Text, out _port))
            {
                MessageBox.Show("The value enetered in the port field is invalid", "Invalid port");
                return;
            }

            name.Value = servName.Text;
            id.Value = servID.Text;
            addr.Value = ipAddr.Text;
            port.Value = iPort.Text;

            String exe = "srcds.exe";
            String app = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    app = "90";
                    exe = "hlds.exe";
                    break;
                case 1:
                    app = "740";
                    break;
                case 2:
                    app = "90 +app_set_config \"90 mod czero\"";
                    exe = "hlds.exe";
                    break;
                case 3:
                    app = "232330";
                    break;
                case 4:
                    app = "232290";
                    break;
                case 5:
                    app = "90 +app_set_config \"90 mod dmc\"";
                    exe = "hlds.exe";
                    break;
                case 6:
                    app = "4020";
                    break;
                case 7:
                    app = "90";
                    exe = "hlds.exe";
                    break;
                case 8:
                    app = "222860";
                    break;
                case 9:
                    app = "232250";
                    break;
            }

            XmlNode executable = xmlDoc.CreateElement("executable");
            executable.InnerText = servExe.Text + @"\" + exe;

            XmlNode param = xmlDoc.CreateElement("params");
            param.InnerText = servParams.Text;

            XmlNode autostart = xmlDoc.CreateElement("autostart");
            autostart.InnerText = checkBox1.Checked.ToString();

            XmlNode affn = xmlDoc.CreateElement("affinity");
            affn.InnerText = BuildAffinityString();

            XmlNode serv = xmlDoc.CreateElement("server");
            serv.Attributes.Append(id);
            serv.Attributes.Append(name);
            serv.Attributes.Append(addr);
            serv.Attributes.Append(port);
            serv.AppendChild(executable);
            serv.AppendChild(param);
            serv.AppendChild(autostart);
            serv.AppendChild(affn);

            root.AppendChild(serv);

            xmlDoc.Save("servers.xml");

            SrcdsMonitor mon = new SrcdsMonitor(servExe.Text, servParams.Text, servName.Text, servID.Text, ipAddr.Text, iPort.Text, this.sender);
            this.sender.addMonitor(mon);
            if (download.Checked)
            {
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
                startinfo.FileName = this.sender.getSteamCmd();
                startinfo.Arguments = String.Format("+login anonymous +force_install_dir {0} +app_update {1} validate +quit", servExe.Text, app);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = startinfo;
                try
                {
                    proc.Start();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(System.ComponentModel.Win32Exception))
                    {
                        MessageBox.Show("The path to the steamcmd executable was invalid", "SteamCMD not foud");
                        return;
                    }
                    else
                    {
                        throw ex;
                    }
                }
                mon.WaitForInstall(proc);
            }
            this.Dispose();
        }

        private void cpuAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cpuAll.Checked)
            {
                foreach (CheckBox box in cpuList)
                {
                    box.CheckStateChanged -= new EventHandler(cpu_CheckedChanged);
                }
                foreach (CheckBox box in cpuList)
                {
                    box.Checked = cpuAll.Checked;
                }
                foreach (CheckBox box in cpuList)
                {
                    box.CheckStateChanged += new EventHandler(cpu_CheckedChanged);
                }
            }
        }
        private void cpu_CheckedChanged(object sender, EventArgs e)
        {
            if (cpuAll.Checked)
            {
                cpuAll.Checked = false;
            }
        }
        private string BuildAffinityString()
        {
            if (cpuAll.Checked)
            {
                return new String('1', Environment.ProcessorCount);
            }
            else
            {
                StringBuilder mask = new StringBuilder(new String('0', Environment.ProcessorCount));
                for (int c = 0; c < Environment.ProcessorCount; c++)
                {
                    if (cpuList[c].Checked)
                    {
                        mask[c] = '1';
                    }
                }
                return mask.ToString();
            }
        }
    }
}
