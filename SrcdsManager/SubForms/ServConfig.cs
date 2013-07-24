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
    public partial class ServConfig : Form
    {
        private Manager caller;
        private SrcdsMonitor mon;
        public ServConfig(object caller, object mon)
        {
            InitializeComponent();
            this.caller = (Manager)caller;
            this.mon = (SrcdsMonitor)mon;

            autoStart.Checked = this.mon.isAutoStart;

            this.Text = this.mon.getName() + " - Configuration";

            addr.Text = this.mon.getAddr();
            parms.Text = this.mon.getCmd();
            executable.Text = this.mon.getExe();
            name.Text = this.mon.getName();
            port.Text = this.mon.getPort();

        }
        private void SaveServer()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("servers.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", mon.getId()));
            ((XmlElement)serv).SetAttribute("name", name.Text);
            ((XmlElement)serv).SetAttribute("address", addr.Text);
            ((XmlElement)serv).SetAttribute("port", port.Text);
            serv.SelectSingleNode("descendant::executable").InnerText = executable.Text;
            serv.SelectSingleNode("descendant::params").InnerText = parms.Text;
            serv.SelectSingleNode("descendant::autostart").InnerText = autoStart.Checked.ToString();
            xmlDoc.Save("servers.xml");

            System.Net.IPAddress ip;
            if (!System.Net.IPAddress.TryParse(addr.Text, out ip))
            {
                MessageBox.Show("The value enetered in the IP field is invalid", "Invalid IP");
                return;
            }
            uint _port;
            if (!uint.TryParse(port.Text, out _port))
            {
                MessageBox.Show("The value enetered in the port field is invalid", "Invalid port");
                return;
            }

            mon.isAutoStart = autoStart.Checked;
            mon.setCmd(parms.Text);
            mon.setExe(executable.Text);
            mon.setName(name.Text);
            mon.setIPAddr(addr.Text);
            mon.setPort(port.Text);

            mon.LogMessage("Server details updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveServer();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this server", "Delete server", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                caller.DeleteServer(mon);
            }
        }
    }
}
