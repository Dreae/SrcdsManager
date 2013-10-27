using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SrcdsManager
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:penitenttangentt@gmail.com");
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.ComponentModel.Win32Exception))
                {
                    MessageBox.Show("No default email program is set", "No Email Program");
                }
                else
                {
                    throw ex;
                }
            }
        }

        private void About_Load(object sender, EventArgs e)
        {
            version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
