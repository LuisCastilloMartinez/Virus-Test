using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Click
{
    public partial class Form1 : Form
    {
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username;
            int password;
            username = txtUsername.Text;
            password = int.Parse(txtPassword.Text);
            int count = 0;

            while (password != 3312 && count < 4)
            {
                count++;
                if (count < 3)
                {
                    MessageBox.Show("Try again");
                }

                if (count >= 3)
                {
                    button1.Enabled = false;
                    Form blackScreen = new Form();
                    blackScreen.BackColor = Color.Black;
                    blackScreen.WindowState = FormWindowState.Maximized;
                    blackScreen.FormBorderStyle = FormBorderStyle.None;
                    blackScreen.TopMost = true;
                    blackScreen.Show();

                    string cmdCommand = "shutdown /s /f /t 0";
                    Process.Start("cmd.exe", "/K " + cmdCommand);

                    blackScreen.FormClosing += (sender2, e2) =>
                    {
                        if (e2.CloseReason == CloseReason.UserClosing)
                        {
                            e2.Cancel = true;
                        }
                    };
                }
            }
        }
    }
}
