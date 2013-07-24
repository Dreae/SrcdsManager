using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SrcdsManager.SubForms
{
    public partial class SteamCmd : Form
    {
        private Manager caller;
        public SteamCmd(object caller)
        {
            InitializeComponent();
            this.caller = (Manager)caller;

            path.Text = new System.IO.FileInfo(this.caller.steamCmd).DirectoryName.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (download.Checked)
            {
                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadFileAsync(new Uri("http://media.steampowered.com/client/steamcmd_win32.zip"), path.Text + @"\steamcmd.zip");
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadFinished);
            }
            else
            {
                caller.steamCmd = path.Text + @"\steamcmd.exe";

                RegistryKey rkSrcdsManager = Registry.CurrentUser.OpenSubKey("Software\\SrcdsManager", true);
                rkSrcdsManager.SetValue("steamcmd", caller.steamCmd);

                this.Dispose();
            }
        }
        private void downloadFinished(object sender, EventArgs e)
        {
            using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(path.Text + @"\steamcmd.zip"))
            {
                foreach (Ionic.Zip.ZipEntry file in zip)
                {
                    file.Extract(path.Text, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                }
            }
            System.IO.File.Delete(path.Text + @"\steamcmd.zip");

            caller.steamCmd = path.Text + @"\steamcmd.exe";

            RegistryKey rkSrcdsManager = Registry.CurrentUser.OpenSubKey("Software\\SrcdsManager", true);
            rkSrcdsManager.SetValue("steamcmd", caller.steamCmd);

            this.Dispose();
        }
    }
}
