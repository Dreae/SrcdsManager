using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class Form1 : Form
    {

        private List<SrcdsMonitor> monArray = new List<SrcdsMonitor>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadXml();
        }

        private void ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            parms.Text = monArray[ServerList.SelectedIndex].getCmd();
            executable.Text = monArray[ServerList.SelectedIndex].getExe();
            name.Text = monArray[ServerList.SelectedIndex].getName();
            crashes.Text = monArray[ServerList.SelectedIndex].getCrashes();
            uptime.Text = monArray[ServerList.SelectedIndex].getUptime();

            if (monArray[ServerList.SelectedIndex].isRunning())
            {
                name.ReadOnly = true;
                executable.ReadOnly = true;
                parms.ReadOnly = true;

                browseExe.Enabled = false;
                startButton.Enabled = false;
                saveButton.Enabled = false;
                stopButton.Enabled = true;

                status.Text = "Running";
                status.ForeColor = Color.Chartreuse;
            }
            else
            {
                name.ReadOnly = false;
                executable.ReadOnly = false;
                parms.ReadOnly = false;

                browseExe.Enabled = true;
                startButton.Enabled = true;
                saveButton.Enabled = true;
                stopButton.Enabled = false;

                status.Text = "Offline";
                status.ForeColor = Color.Red;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            executable.Text = openFileDialog1.FileName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("servers/servers.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", monArray[ServerList.SelectedIndex].getId()));
            ((XmlElement)serv).SetAttribute("name", name.Text);
            serv.SelectSingleNode("descendant::executable").InnerText = executable.Text;
            serv.SelectSingleNode("descendant::params").InnerText = parms.Text;
            xmlDoc.Save("servers/servers.xml");

            monArray[ServerList.SelectedIndex].setCmd(parms.Text);
            monArray[ServerList.SelectedIndex].setExe(executable.Text);
            monArray[ServerList.SelectedIndex].setName(name.Text);
        }
  
        private void ReadXml()
        {
            String sName, sExe, sCmd, sID;
            using(XmlReader reader = new XmlTextReader("servers/servers.xml"))
            {
                while(reader.ReadToFollowing("server"))
                {
                    reader.MoveToFirstAttribute();
                    sID = reader.Value;

                    reader.MoveToNextAttribute();
                    sName = reader.Value;

                    reader.ReadToFollowing("executable");
                    sExe = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("params");
                    sCmd = reader.ReadElementContentAsString();

                    SrcdsMonitor mon = new SrcdsMonitor(sExe, sCmd, sName, sID);

                    monArray.Add(mon);

                    ServerList.Items.Add(mon.getName());
                }
            }

            System.Timers.Timer status = new System.Timers.Timer(1000);
            status.SynchronizingObject = this;
            status.Elapsed += new System.Timers.ElapsedEventHandler(sUpdateStatus);
            status.AutoReset = true;
            status.Enabled = true;
            status.Start();
           
            
        }
        private void sUpdateStatus(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ServerList.SelectedItems.Count != 0)
            {
                crashes.Text = monArray[ServerList.SelectedIndex].getCrashes();
                uptime.Text = monArray[ServerList.SelectedIndex].getUptime();

                if (monArray[ServerList.SelectedIndex].isRunning())
                {
                    name.ReadOnly = true;
                    executable.ReadOnly = true;
                    parms.ReadOnly = true;

                    browseExe.Enabled = false;
                    startButton.Enabled = false;
                    saveButton.Enabled = false;
                    stopButton.Enabled = true;

                    status.Text = "Running";
                    status.ForeColor = Color.Chartreuse;
                }
                else
                {
                    name.ReadOnly = false;
                    executable.ReadOnly = false;
                    parms.ReadOnly = false;

                    browseExe.Enabled = true;
                    startButton.Enabled = true;
                    saveButton.Enabled = true;
                    stopButton.Enabled = false;

                    status.Text = "Offline";
                    status.ForeColor = Color.Red;
                }
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            monArray[ServerList.SelectedIndex].Start();
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            monArray[ServerList.SelectedIndex].Stop();
        }
    }
}
