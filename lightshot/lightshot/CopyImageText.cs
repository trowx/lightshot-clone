using System;
using System.Windows.Forms;

namespace lightshot
{
    public partial class CopyImageText : Form
    {
        public CopyImageText()
        {
            InitializeComponent();
        }

        public string data;

        private void CopyImageText_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = data;
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }
    }
}
