using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace lightshot
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/TrOwX99");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
