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
using Microsoft.Win32;
using System.Security.Principal;
using System.Text.RegularExpressions;


/*
 * I swear to comment all of this later.
 * But for right now, proceed at your own risk >.>
 */

namespace SrcdsManager
{
    enum SrcdsStatus
    {
        NoReply,
        Updating,
        Installing,
        Online,
        Offline
    }
    public partial class Manager : Form
    {
        private List<SrcdsMonitor> monArray = new List<SrcdsMonitor>();
        public String steamCmd = "invalid";
        public static readonly Regex regexBinary = new Regex("^[01]{1,32}$", RegexOptions.Compiled);

        public Manager()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ServerList.ClearSelection();

            startButton.Enabled = false;
            restart.Enabled = false;
            stopButton.Enabled = false;

            ReadXml();
            RegistryKey rkApp;
            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey rkCurrentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                rkApp = rkCurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
            }
            else
            {
                rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
            }
            if (rkApp.GetValue("SrcdsManager") != null)
            {
                runOnStartToolStripMenuItem.Image = SrcdsManager.Properties.Resources.bluecheck;
            }
            else
            {
                runOnStartToolStripMenuItem.Image = SrcdsManager.Properties.Resources.deleteicon;
            }
            RegistryKey rkSrcdsManager = Registry.CurrentUser.OpenSubKey("Software\\SrcdsManager", true);

            if (rkSrcdsManager == null)
            {
                Registry.CurrentUser.CreateSubKey("Software\\SrcdsManager");
            }
            else
            {
                steamCmd = (string)rkSrcdsManager.GetValue("steamcmd");
                if (steamCmd == "")
                {
                    steamCmd = "invalid";
                }
            }

            if(!System.IO.Directory.Exists("logs"))
            {
                System.IO.Directory.CreateDirectory("logs");
            }
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
        private void ServerList_NewRow(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count == 0)
            {
                ServerList.Rows[ServerList.Rows.Count - 1].Selected = true;
            }
        }
        private void ServerList_SelectionChanged(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count > 0 && ServerList.SelectedRows[0].Index >= 0 && ServerList.SelectedRows[0].Index < monArray.Count)
            {
                logBox.Text = monArray[ServerList.SelectedRows[0].Index].Log;
            }
        }
        private void ServerList_Clicked(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = ServerList.HitTest(e.X, e.Y);
                if (hti.Type != DataGridViewHitTestType.None)
                {
                    ServerList.Rows[hti.RowIndex].Selected = true;
                    switch(monArray[hti.RowIndex].Status)
                    {
                        case SrcdsStatus.Online:
                            dgContextStart.Enabled = false;
                            dgContextStop.Enabled = true;
                            dgContextRestart.Enabled = true;
                            dgContextUpdate.Enabled = false;
                            break;
                        case SrcdsStatus.Offline:
                            dgContextStart.Enabled = true;
                            dgContextStop.Enabled = false;
                            dgContextRestart.Enabled = false;
                            dgContextUpdate.Enabled = true;
                            break;
                        case SrcdsStatus.Updating:
                            dgContextStart.Enabled = false;
                            dgContextStop.Enabled = false;
                            dgContextRestart.Enabled = false;
                            dgContextUpdate.Enabled = false;
                            break;
                        case SrcdsStatus.Installing:
                            dgContextStart.Enabled = false;
                            dgContextStop.Enabled = false;
                            dgContextRestart.Enabled = false;
                            dgContextUpdate.Enabled = false;
                            break;
                        case SrcdsStatus.NoReply:
                            dgContextStart.Enabled = false;
                            dgContextStop.Enabled = true;
                            dgContextRestart.Enabled = true;
                            dgContextUpdate.Enabled = false;
                            break;
                    }
                    dataGridContext.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
            }
        }
        private void ReadXml()
        {
            String sName, sExe, sCmd, sID, sAddr, sPort, sAffn;
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
                    sExe = @reader.ReadElementContentAsString();

                    reader.ReadToFollowing("params");
                    sCmd = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("autostart");
                    string autoStart = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("affinity");
                    sAffn = reader.ReadElementContentAsString();

                    SrcdsMonitor mon = new SrcdsMonitor(sExe, sCmd, sName, sID, sAddr, sPort, this);
                    mon.AffinityMask = sAffn;

                    monArray.Add(mon);
                    monArray[monArray.Count - 1].Log += 
                        (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + "Server info loaded \r\n");

                    ServerList.Rows.Add();
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[0].Value = SrcdsManager.Properties.Resources.offline;
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[1].Value = sName;
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[5].Value = sAddr;
                    ServerList.Rows[ServerList.Rows.Count - 1].Cells[6].Value = sPort;

                    if (bool.Parse(autoStart))
                    {
                        mon.Start();
                        mon.isAutoStart = true;
                    }
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
                    logBox.Text = monArray[ServerList.SelectedRows[0].Index].Log;
                    if (autoScroll.Checked)
                    {
                        logBox.SelectionStart = logBox.Text.Length - 1;
                        logBox.ScrollToCaret();
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
                            case 1:
                                cell.Value = monArray[row.Index].getName();
                                break;
                            case 2:
                                switch(monArray[row.Index].Status)
                                {
                                    case SrcdsStatus.Online:
                                        cell.Value = "Online";
                                        cell.Style.ForeColor = Color.Green;
                                        cell.Style.SelectionForeColor = Color.Green;
                                        break;
                                    case SrcdsStatus.Offline:
                                        cell.Value = "Offline";
                                        cell.Style.ForeColor = Color.Red;
                                        cell.Style.SelectionForeColor = Color.Red;
                                        break;
                                    case SrcdsStatus.NoReply:
                                        cell.Value = "No Reply";
                                        cell.Style.ForeColor = Color.Red;
                                        cell.Style.SelectionForeColor = Color.Red;
                                        break;
                                    case SrcdsStatus.Updating:
                                        cell.Value = "Updating";
                                        cell.Style.ForeColor = Color.Blue;
                                        cell.Style.SelectionForeColor = Color.Blue;
                                        break;
                                    case SrcdsStatus.Installing:
                                        cell.Value = "Installing";
                                        cell.Style.ForeColor = Color.Blue;
                                        cell.Style.SelectionForeColor = Color.Blue;
                                        break;
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
                StartServer();
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                monArray[ServerList.SelectedRows[0].Index].Stop();
                ServerList.SelectedRows[0].Cells[0].Value = SrcdsManager.Properties.Resources.offline;
                monArray[ServerList.SelectedRows[0].Index].LogMessage("Server stopped");
                stopButton.Enabled = false;
                restart.Enabled = false;
                startButton.Enabled = true;
            }
        }
        private void restart_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                RestartServer();
            }
        }
        private void RestartServer()
        {
            monArray[ServerList.SelectedRows[0].Index].Stop();
            System.Threading.Thread.Sleep(100);
            monArray[ServerList.SelectedRows[0].Index].Start();
            monArray[ServerList.SelectedRows[0].Index].LogMessage("Server restarted");
        }
        private void newServ_Click(object sender, EventArgs e)
        {
            NewServer window = new NewServer(this);
            window.Show();
        }
        internal void addMonitor(SrcdsMonitor mon)
        {
            monArray.Add(mon);
            monArray[monArray.Count - 1].Log +=
                        (DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + "Server created \r\n");
            ServerList.Rows.Add();
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[0].Value = SrcdsManager.Properties.Resources.offline;
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[1].Value = mon.getName();
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[5].Value = mon.getAddr();
            ServerList.Rows[ServerList.Rows.Count - 1].Cells[6].Value = mon.getPort();
        }
        internal void DeleteServer(SrcdsMonitor mon)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("servers.xml");
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode serv = root.SelectSingleNode(String.Format("descendant::server[@id='{0}']", monArray[ServerList.SelectedRows[0].Index].getId()));
            root.RemoveChild(serv);
            xmlDoc.Save("servers.xml");

            int i = monArray.IndexOf(mon);
            monArray.Remove(mon);
            ServerList.Rows.RemoveAt(i);
        }
        private void steamCmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubForms.SteamCmd cmd = new SubForms.SteamCmd(this);
            cmd.Show();
        }

        private void updateServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select a server","Select a server");
                return;
            }
            UpdateServer();
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
        private void StartServer()
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            restart.Enabled = true;
            ServerList.SelectedRows[0].Cells[0].Value = SrcdsManager.Properties.Resources.online;
            monArray[ServerList.SelectedRows[0].Index].Start();
            monArray[ServerList.SelectedRows[0].Index].LogMessage("Server started");
        }
        private void UpdateServer()
        {
            if (ServerList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You must select a server");
                return;
            }

            if (monArray[ServerList.SelectedRows[0].Index].isRunning())
            {
                MessageBox.Show("The selected server is running, you must stop it to update", "Server is running");
                return;
            }

            string app_id = "";

            try
            {
                app_id =
                    System.IO.File.ReadAllText(new System.IO.FileInfo(monArray[ServerList.SelectedRows[0].Index].getExe()).Directory.FullName + "/steam_appid.txt");
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.IO.FileNotFoundException) || ex.GetType() == typeof(System.IO.DirectoryNotFoundException))
                {
                    MessageBox.Show("Could not find an installation of SRCDS, please check the directory in server configuration");
                    return;
                }
                else
                {
                    throw ex;
                }
            }
            
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
                if (ex.GetType() == typeof(System.ComponentModel.Win32Exception) || ex.GetType() == typeof(InvalidOperationException))
                {
                    MessageBox.Show("The path to the steamcmd executable was invalid", "SteamCMD not foud");
                    return;
                }
                else
                {
                    throw ex;
                }
            }
            monArray[ServerList.SelectedRows[0].Index].WaitForUpdate(proc);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
        private void installServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewServer newServer = new NewServer(this);
            newServ.Show();
        }
        private void dgContextStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        private void dgContextUpdate_Click(object sender, EventArgs e)
        {
            UpdateServer();
        }

        private void dgContextRestart_Click(object sender, EventArgs e)
        {
            RestartServer();
        }

        private void dgContextStop_Click(object sender, EventArgs e)
        {
            monArray[ServerList.SelectedRows[0].Index].Stop();
            ServerList.SelectedRows[0].Cells[0].Value = SrcdsManager.Properties.Resources.offline;
        }

        private void runOnStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey rkApp;
            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey rkCurrentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                rkApp = rkCurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            }
            else
            {
                rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            }
            if (rkApp.GetValue("SrcdsManager") == null)
            {
                rkApp.SetValue("SrcdsManager", Application.ExecutablePath.ToString());
                runOnStartToolStripMenuItem.Image = SrcdsManager.Properties.Resources.bluecheck;
            }
            else
            {
                rkApp.DeleteValue("SrcdsManager", false);
                runOnStartToolStripMenuItem.Image = SrcdsManager.Properties.Resources.deleteicon;
            }
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServConfig cfg = new ServConfig(this, monArray[ServerList.SelectedRows[0].Index]);
            cfg.Show();
        }
        

        private void ServerList_MouseDown(object sender, MouseEventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                if (monArray[ServerList.SelectedRows[0].Index].isRunning())
                {
                    startButton.Enabled = false;
                    stopButton.Enabled = true;
                    restart.Enabled = true;
                }
                else
                {
                    startButton.Enabled = true;
                    stopButton.Enabled = false;
                    restart.Enabled = false;
                }
                logBox.Text = monArray[ServerList.SelectedRows[0].Index].Log;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                if (!System.IO.File.Exists(@"logs\serv_" + monArray[ServerList.SelectedRows[0].Index].getId() + ".log"))
                {
                    MessageBox.Show("No log file exists for this server", "No Log File");
                    return;
                }
                System.Diagnostics.Process.Start(@"logs\serv_" + monArray[ServerList.SelectedRows[0].Index].getId() + ".log");
            }
        }

        private void clearConsole_Click(object sender, EventArgs e)
        {
            if (ServerList.SelectedRows.Count != 0)
            {
                monArray[ServerList.SelectedRows[0].Index].Log = "";
                monArray[ServerList.SelectedRows[0].Index].LogMessage("Log console cleared");
            }
        }
    }
}
