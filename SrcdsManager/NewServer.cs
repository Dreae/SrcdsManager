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
            xmlDoc.Load("servers/servers.xml");
            XmlAttribute id = xmlDoc.CreateAttribute("id");
            XmlAttribute name = xmlDoc.CreateAttribute("name");
            XmlNode root = xmlDoc.DocumentElement;

            name.Value = servName.Text;
            id.Value = servID.Text;

            XmlNode executable = xmlDoc.CreateElement("executable");
            executable.InnerText = servExe.Text;

            XmlNode param = xmlDoc.CreateElement("params");
            param.InnerText = servParams.Text;
            
            XmlNode serv = xmlDoc.CreateElement("server");
            serv.Attributes.Append(id);
            serv.Attributes.Append(name);
            serv.AppendChild(executable);
            serv.AppendChild(param);

            root.AppendChild(serv);

            xmlDoc.Save("servers/servers.xml");

            SrcdsMonitor mon = new SrcdsMonitor(servExe.Text, servParams.Text, servName.Text, servID.Text);
            this.sender.addMonitor(mon);
            this.Dispose();
        }
    }
}
