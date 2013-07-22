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
        private String steamCmd = "";

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
        private void ServerList_Clicked(object sender, MouseEventArgs e)
        {
            if (ServerList.SelectedRows.Count > 0 && ServerList.SelectedRows[0].Index >= 0 && ServerList.SelectedRows[0].Index < monArray.Count)
            {
                parms.Text = monArray[ServerList.SelectedRows[0].Index].getCmd();
                executable.Text = monArray[ServerList.SelectedRows[0].Index].getExe();
                name.Text = monArray[ServerList.SelectedRows[0].Index].getName();
                crashes.Text = monArray[ServerList.SelectedRows[0].Index].getCrashes();
                uptime.Text = monArray[ServerList.SelectedRows[0].Index].getUptime();
                addr.Text = monArray[ServerList.SelectedRows[0].Index].getAddr();
                port.Text = monArray[ServerList.SelectedRows[0].Index].getPort();

                if (monArray[ServerList.SelectedRows[0].Index].isRunning())
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
            if (ServerList.SelectedRows.Count != 0)
            {
                SaveServer();
            }
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
            if (!System.IO.File.Exists("settings.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("settings");

                xmlDoc.AppendChild(root);

                xmlDoc.Save("settings.xml");
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

                    SrcdsMonitor mon = new SrcdsMonitor(sExe, sCmd, sName, sID, sAddr, sPort, this);

                    monArray.Add(mon);

                    ServerList.Rows.Add();
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[0].Value = SrcdsManager.Properties.Resources.offline;
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[1].Value = sName;
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[5].Value = sAddr;
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[6].Value = sPort;
                }
            }
            using (XmlReader reader = new XmlTextReader("settings.xml"))
            {
                if (reader.ReadToFollowing("steamcmd"))
                {
                    steamCmd = reader.ReadElementContentAsString();
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
            if (ServerList.SelectedRows.Count != 0)
            {
                try
                {
                    crashes.Text = monArray[ServerList.SelectedRows[0].Index].getCrashes();
                    uptime.Text = monArray[ServerList.SelectedRows[0].Index].getUptime();

                    if (monArray[ServerList.SelectedRows[0].Index].isRunning())
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
            try
            {
                foreach (DataGridViewRow row in ServerList.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        switch (cell.ColumnIndex)
                        {
                            case 0:
                                if (monArray[row.Index].isRunning())
                                {
                                    if (cell.Value != SrcdsManager.Properties.Resources.online)
                                    {
                                        cell.Value = SrcdsManager.Properties.Resources.online;
                                    }
                                }
                                else if(cell.Value != SrcdsManager.Properties.Resources.offline)
                                {
                                    cell.Value = SrcdsManager.Properties.Resources.offline;
                                }
                                break;
                            case 1:
                                cell.Value = monArray[row.Index].getName();
                                break;
                            case 2:
                                if (monArray[row.Index].isRunning())
                                {
                                    cell.Value = "Online";
                                    cell.Style.ForeColor = Color.Green;
                                    cell.Style.SelectionForeColor = Color.Green;
                                }
                                else
                                {
                                    cell.Value = "Offline";
                                    cell.Style.ForeColor = Color.Red;
                                    cell.Style.SelectionForeColor = Color.Red;
                                }
                                break;
                            case 3:
                                cell.Value = monArray[row.Index].getUptime();
                                break;
                            case 4:
                                cell.Value = monArray[row.Index].getCrashes();
                                break;
                            case 5:
                                cell.Value = monArray[row.Index].getAddr();
                                break;
                            case 6:
                                cell.Value = monArray[row.Index].getPort();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ObjectDisposedException))
                {
                    ((System.Timers.Timer)sender).Dispose();
                }
                else
                {
                    throw ex;
                }
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                if (addr.Text != monArray[ServerList.SelectedRows[0].Index].getAddr() || port.Text != monArray[ServerList.SelectedRows[0].Index].getPort()
                    || name.Text != monArray[ServerList.SelectedRows[0].Index].getName() || parms.Text != monArray[ServerList.SelectedRows[0].Index].getCmd()
                    || executable.Text != monArray[ServerList.SelectedRows[0].Index].getExe())
                {
                    if (MessageBox.Show("Save changes to selected server?", "Server Modified", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveServer();
                    }
                    else
                    {
                        addr.Text = monArray[ServerList.SelectedRows[0].Index].getAddr();
                        port.Text = monArray[ServerList.SelectedRows[0].Index].getPort();
                        name.Text = monArray[ServerList.SelectedRows[0].Index].getName();
                        parms.Text = monArray[ServerList.SelectedRows[0].Index].getCmd();
                        executable.Text = monArray[ServerList.SelectedRows[0].Index].getExe();
                    }
                }
                monArray[ServerList.SelectedRows[0].Index].Start();
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                monArray[ServerList.SelectedRows[0].Index].Stop();
            }
        }
        private void restart_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                monArray[ServerList.SelectedRows[0].Index].Stop();
                System.Threading.Thread.Sleep(100);
                monArray[ServerList.SelectedRows[0].Index].Start();
            }
        }
        private void newServ_Click(object sender, EventArgs e)
        {
            NewServer window = new NewServer(this);
            window.Show();
        }
        private void SaveServer()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("servers.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", monArray[ServerList.SelectedRows[0].Index].getId()));
            ((XmlElement)serv).SetAttribute("name", name.Text);
            ((XmlElement)serv).SetAttribute("address", addr.Text);
            ((XmlElement)serv).SetAttribute("port", port.Text);
            serv.SelectSingleNode("descendant::executable").InnerText = executable.Text;
            serv.SelectSingleNode("descendant::params").InnerText = parms.Text;
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

            monArray[ServerList.SelectedRows[0].Index].setCmd(parms.Text);
            monArray[ServerList.SelectedRows[0].Index].setExe(executable.Text);
            monArray[ServerList.SelectedRows[0].Index].setName(name.Text);
            monArray[ServerList.SelectedRows[0].Index].setIPAddr(addr.Text);
            monArray[ServerList.SelectedRows[0].Index].setPort(port.Text);
        }
        internal void addMonitor(SrcdsMonitor mon)
        {
            monArray.Add(mon);
            ServerList.Rows.Add();
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[0].Value = SrcdsManager.Properties.Resources.offline;
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[1].Value = mon.getName();
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[5].Value = mon.getAddr();
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[6].Value = mon.getPort();
        }

        private void deleteServ_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this server", "Delete server", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("servers.xml");
                    XmlNode root = xmlDoc.DocumentElement;
                    XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", monArray[ServerList.SelectedRows[0].Index].getId()));
                    root.RemoveChild(serv);
                    xmlDoc.Save("servers.xml");

                    monArray[ServerList.SelectedRows[0].Index].Dispose();
                    monArray.Remove(monArray[ServerList.SelectedRows[0].Index]);
                    ServerList.Rows.RemoveAt(ServerList.SelectedRows[0].Index);
                }
            }
        }

        private void steamCmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            steamCmd = openFileDialog2.FileName;
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("settings.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode path = root.SelectSingleNode("descendant::steamcmd");
            //There's probably a better way of doing this
            try
            {
                path.InnerText = steamCmd;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NullReferenceException))
                {
                    path = xmlDoc.CreateElement("steamcmd");
                    path.InnerText = steamCmd;
                    root.AppendChild(path);
                }
            }
            xmlDoc.Save("settings.xml");
        }

        private void updateServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select a server","Select a server");
                return;
            }
            if (monArray[ServerList.SelectedRows[0].Index].isRunning())
            {
                MessageBox.Show("The selected server is running, you must stop it to update","Server is running");
                return;
            }
            string app_id = System.IO.File.ReadAllText(new System.IO.FileInfo(monArray[ServerList.SelectedRows[0].Index].getExe()).Directory.FullName + "/steam_appid.txt");
            int id = 0;
            if (!int.TryParse(app_id, out id))
            {
                UnknownApp uApp = new UnknownApp(this);
                uApp.Show();
                return;
            }
            String app = "";
            switch (id)
            {
                case 240:
                    app = "232330";
                    break;
                case 440:
                    app = "232250";
                    break;
                case 300:
                    app = "232290";
                    break;
                case 550:
                    app = "222860";
                    break;
                case 10:
                    app = "90";
                    break;
                case 70:
                    app = "90";
                    break;
                case 40:
                    app = "90 +app_set_config \"90 mod dmc\"";
                    break;
                case 80:
                    app = "90 +app_set_config \"90 mod czero\"";
                    break;
                case 4000:
                    app = "4020";
                    break;
                case 730:
                    app = "740";
                    break;
                default:
                    app = "unknown";
                    break;
            }
            if (app == "unknown")
            {
                UnknownApp uApp = new UnknownApp(this);
                uApp.Show();
                return;
            }
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo();
            startinfo.FileName = steamCmd;
            startinfo.Arguments = String.Format("+login anonymous +force_install_dir {0} +app_update {1} validate +quit",
                new System.IO.FileInfo(monArray[ServerList.SelectedRows[0].Index].getExe()).Directory.FullName, app);
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
        }
        public String getSteamCmd()
        {
            return steamCmd;
        }
        internal SrcdsMonitor getSelectedMon()
        {
            return monArray[ServerList.SelectedRows[0].Index];
        }
        public void ErrorBox(int id)
        {
            if (id == 1)
            {
                MessageBox.Show("The path to the server executable was invalid", "Server path Invalid");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void installServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallServer install = new InstallServer(this);
            install.Show();
        }
    }
}
