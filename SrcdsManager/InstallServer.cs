using System;
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
    public partial class InstallServer : Form
    {
        private Manager caller;

        public InstallServer(object caller)
        {
            InitializeComponent();
            this.caller = (Manager)caller;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                servDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("servers.xml");
            XmlAttribute id = xmlDoc.CreateAttribute("id");
            XmlAttribute name = xmlDoc.CreateAttribute("name");
            XmlAttribute addr = xmlDoc.CreateAttribute("address");
            XmlAttribute port = xmlDoc.CreateAttribute("port");
            XmlNode root = xmlDoc.DocumentElement;

            System.Net.IPAddress ip;
            if (!System.Net.IPAddress.TryParse(servAddr.Text, out ip))
            {
                MessageBox.Show("The value enetered in the IP field is invalid", "Invalid IP");
                return;
            }
            uint _port;
            if (!uint.TryParse(servPort.Text, out _port))
            {
                MessageBox.Show("The value enetered in the port field is invalid", "Invalid port");
                return;
            }

            name.Value = servName.Text;
            id.Value = servId.Text;
            addr.Value = servAddr.Text;
            port.Value = servPort.Text;

            XmlNode executable = xmlDoc.CreateElement("executable");
            executable.InnerText = servDir.Text + "\\srcds.exe";
            XmlNode param = xmlDoc.CreateElement("params");
            param.InnerText = servParams.Text;


            XmlNode serv = xmlDoc.CreateElement("server");
            serv.Attributes.Append(id);
            serv.Attributes.Append(name);
            serv.Attributes.Append(addr);
            serv.Attributes.Append(port);
            serv.AppendChild(executable);
            serv.AppendChild(param);

            root.AppendChild(serv);

            xmlDoc.Save("servers.xml");

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

            SrcdsMonitor mon = new SrcdsMonitor(servDir.Text + "\\" + exe, servParams.Text, servName.Text, servId.Text, servAddr.Text, servPort.Text, this.caller);
            this.caller.addMonitor(mon);

           
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.FileName = caller.getSteamCmd();
            startinfo.Arguments = String.Format("+login anonymous +force_install_dir {0} +app_update {1} validate +quit", servDir.Text, app);
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
            this.Dispose();
        }
    }
}
