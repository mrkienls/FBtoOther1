using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }



        private void ReadSettings()
        {
            txtUserXenzuu.Text = Properties.Settings.Default.UserXen;
            txtPassXenzuu.Text = Properties.Settings.Default.PassXen;
            txtKey.Text = Properties.Settings.Default.key;

        }
        private void SaveSettings()
        {

            Properties.Settings.Default.UserXen = this.txtUserXenzuu.Text;
            Properties.Settings.Default.PassXen = this.txtPassXenzuu.Text;
            Properties.Settings.Default.key = this.txtKey.Text;
            Properties.Settings.Default.Save();

        }


        void dangnhap()
        {
            bool isOK = false;
            isOK = Class_Login.ProcessLogin(txtKey.Text, txtUserXenzuu.Text, txtPassXenzuu.Text);

            if (isOK)
            {
                SaveSettings();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Sai key");
            }
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            dangnhap();



        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
