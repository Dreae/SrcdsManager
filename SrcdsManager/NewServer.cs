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
    public partial class NewServer : Form
    {
        Manager sender;

        public NewServer(object sender)
        {
            InitializeComponent();
            this.sender = (Manager)sender;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            servExe.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
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

            XmlNode executable = xmlDoc.CreateElement("executable");
            executable.InnerText = servExe.Text;

            XmlNode param = xmlDoc.CreateElement("params");
            param.InnerText = servParams.Text;

            XmlNode autostart = xmlDoc.CreateElement("autostart");
            autostart.InnerText = checkBox1.Checked.ToString();
            

            XmlNode serv = xmlDoc.CreateElement("server");
            serv.Attributes.Append(id);
            serv.Attributes.Append(name);
            serv.Attributes.Append(addr);
            serv.Attributes.Append(port);
            serv.AppendChild(executable);
            serv.AppendChild(param);
            serv.AppendChild(autostart);

            root.AppendChild(serv);

            xmlDoc.Save("servers.xml");

            SrcdsMonitor mon = new SrcdsMonitor(servExe.Text, servParams.Text, servName.Text, servID.Text, ipAddr.Text, iPort.Text, this.sender);
            this.sender.addMonitor(mon);
            this.Dispose();
        }
    }
}
