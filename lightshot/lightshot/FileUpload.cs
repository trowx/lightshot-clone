using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace lightshot
{
    public partial class FileUpload : Form
    {
        public FileUpload()
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        public string del_url;

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(textBox1.Text);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(del_url);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            Hide();
        }

        private void FileUpload_Load(object sender, EventArgs e)
        {
            if(del_url == null){
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else {
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}
