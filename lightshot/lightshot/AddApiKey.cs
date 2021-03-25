using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace lightshot
{
    public partial class AddApiKey : Form
    {
        public AddApiKey()
        {
            InitializeComponent();
        }

        private void AddApiKey_Load(object sender, EventArgs e)
        {
            string api = Properties.Settings.Default.api_key;
            if (api != "" && api != null) { textBox1.Text = api; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox1.Text != null){
                Properties.Settings.Default["api_key"] = textBox1.Text;
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://api.imgbb.com/");
        }
    }
}
