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
    public partial class Manager : Form
    {

        private List<SrcdsMonitor> monArray = new List<SrcdsMonitor>();

        public Manager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadXml();
        }
        private void ManagerClosing(object sender, EventArgs e)
        {

            foreach (SrcdsMonitor mon in monArray)
            {
                if (mon.isRunning())
                {
                    mon.Stop();
                }
            }
        }
        private void ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServerList.SelectedIndex >= 0 && ServerList.SelectedIndex < monArray.Count)
            {
                parms.Text = monArray[ServerList.SelectedIndex].getCmd();
                executable.Text = monArray[ServerList.SelectedIndex].getExe();
                name.Text = monArray[ServerList.SelectedIndex].getName();
                crashes.Text = monArray[ServerList.SelectedIndex].getCrashes();
                uptime.Text = monArray[ServerList.SelectedIndex].getUptime();
                addr.Text = monArray[ServerList.SelectedIndex].getAddr();
                port.Text = monArray[ServerList.SelectedIndex].getPort();

                if (monArray[ServerList.SelectedIndex].isRunning())
                {
                    name.ReadOnly = true;
                    executable.ReadOnly = true;
                    parms.ReadOnly = true;
                    addr.ReadOnly = true;
                    port.ReadOnly = true;

                    browseExe.Enabled = false;
                    startButton.Enabled = false;
                    saveButton.Enabled = false;
                    stopButton.Enabled = true;
                    deleteServ.Enabled = false;
                    restart.Enabled = true;

                    status.Text = "Running";
                    status.ForeColor = Color.Chartreuse;
                }
                else
                {
                    name.ReadOnly = false;
                    executable.ReadOnly = false;
                    parms.ReadOnly = false;
                    port.ReadOnly = false;
                    addr.ReadOnly = false;

                    browseExe.Enabled = true;
                    startButton.Enabled = true;
                    saveButton.Enabled = true;
                    stopButton.Enabled = false;
                    deleteServ.Enabled = true;
                    restart.Enabled = false;

                    status.Text = "Offline";
                    status.ForeColor = Color.Red;
                }
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
            xmlDoc.Load("servers.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", monArray[ServerList.SelectedIndex].getId()));
            ((XmlElement)serv).SetAttribute("name", name.Text);
            ((XmlElement)serv).SetAttribute("address", addr.Text);
            ((XmlElement)serv).SetAttribute("port", port.Text);
            serv.SelectSingleNode("descendant::executable").InnerText = executable.Text;
            serv.SelectSingleNode("descendant::params").InnerText = parms.Text;
            xmlDoc.Save("servers.xml");

            monArray[ServerList.SelectedIndex].setCmd(parms.Text);
            monArray[ServerList.SelectedIndex].setExe(executable.Text);
            monArray[ServerList.SelectedIndex].setName(name.Text);
            monArray[ServerList.SelectedIndex].setIPAddr(addr.Text);
            monArray[ServerList.SelectedIndex].setPort(port.Text);
        }
  
        private void ReadXml()
        {
            String sName, sExe, sCmd, sID, sAddr, sPort;
            if (!System.IO.File.Exists("servers.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("servers");

                xmlDoc.AppendChild(root);

                xmlDoc.Save("servers.xml");
            }

            using(XmlReader reader = new XmlTextReader("servers.xml"))
            {
                while(reader.ReadToFollowing("server"))
                {
                    reader.MoveToFirstAttribute();
                    sID = reader.Value;

                    reader.MoveToNextAttribute();
                    sName = reader.Value;

                    reader.MoveToNextAttribute();
                    sAddr = reader.Value;

                    reader.MoveToNextAttribute();
                    sPort = reader.Value;

                    reader.ReadToFollowing("executable");
                    sExe = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("params");
                    sCmd = reader.ReadElementContentAsString();

                    SrcdsMonitor mon = new SrcdsMonitor(sExe, sCmd, sName, sID, sAddr, sPort);

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
                try
                {
                    crashes.Text = monArray[ServerList.SelectedIndex].getCrashes();
                    uptime.Text = monArray[ServerList.SelectedIndex].getUptime();

                    if (monArray[ServerList.SelectedIndex].isRunning())
                    {
                        name.ReadOnly = true;
                        executable.ReadOnly = true;
                        parms.ReadOnly = true;
                        port.ReadOnly = true;
                        addr.ReadOnly = true;

                        browseExe.Enabled = false;
                        startButton.Enabled = false;
                        saveButton.Enabled = false;
                        stopButton.Enabled = true;
                        deleteServ.Enabled = false;
                        restart.Enabled = true;

                        status.Text = "Running";
                        status.ForeColor = Color.Chartreuse;
                    }
                    else
                    {
                        name.ReadOnly = false;
                        executable.ReadOnly = false;
                        parms.ReadOnly = false;
                        addr.ReadOnly = false;
                        port.ReadOnly = false;

                        browseExe.Enabled = true;
                        startButton.Enabled = true;
                        saveButton.Enabled = true;
                        stopButton.Enabled = false;
                        deleteServ.Enabled = true;
                        restart.Enabled = false;

                        status.Text = "Offline";
                        status.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(ObjectDisposedException))
                    {
                        ((System.Timers.Timer)sender).Dispose();
                    }
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
        private void restart_Click(object sender, EventArgs e)
        {
            monArray[ServerList.SelectedIndex].Stop();
            System.Threading.Thread.Sleep(100);
            monArray[ServerList.SelectedIndex].Start();
        }
        private void newServ_Click(object sender, EventArgs e)
        {
            NewServer window = new NewServer(this);
            window.Show();
        }

        internal void addMonitor(SrcdsMonitor mon)
        {
            monArray.Add(mon);
            ServerList.Items.Add(mon.getName());
        }

        private void deleteServ_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this server","Delete server", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("servers.xml");
                XmlNode root = xmlDoc.DocumentElement;
                XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", monArray[ServerList.SelectedIndex].getId()));
                root.RemoveChild(serv);
                xmlDoc.Save("servers.xml");

                monArray.Remove(monArray[ServerList.SelectedIndex]);
                ServerList.Items.RemoveAt(ServerList.SelectedIndex);
            }
        }
    }
}
