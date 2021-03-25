using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lightshot
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        bool isRunning = true;
        string tmp = Path.GetTempPath();

        private static readonly HttpClient client = new HttpClient();

        string last_path = null;

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        private void TakeSS()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = bitmap.Clone(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    PixelFormat.DontCare);

                Bitmap new2 = MakeGrayscale3(bitmap);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = new2.Clone(
                    new Rectangle(0, 0, new2.Width, new2.Height),
                    PixelFormat.DontCare);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //notify1.Icon = new Icon(SystemIcons.Application, 40, 40);
            notify1.MouseClick += NotifyIconInteracted;
            notify1.Text = "\"Print Scrn\" tuşuna basarak ekran görüntüsü yakalıyabilirsiniz.";

            label1.BackColor = Color.Transparent;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            //button2.BackColor = Color.Transparent;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            init();
        }

        private void NotifyIconInteracted(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ShowGUI();
        }

        private void init()
        {
            Thread TH = new Thread(KeyboardListener);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();
        }

        private void ShowGUI()
        {
            TakeSS();
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            Opacity = 100;
            Show();

            Rect.Location = new Point(Math.Min(0, 0), Math.Min(0, 0));
            Rect.Size = new Size(Math.Abs(0 - 0), Math.Abs(0 - 0));
            pictureBox1.Invalidate();
        }

        private void KeyboardListener()
        {
            while (isRunning)
            {
                Thread.Sleep(40);
                if (System.Windows.Input.Keyboard.GetKeyStates(System.Windows.Input.Key.PrintScreen) > 0)
                {
                    ShowGUI();
                    break;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Hide();
                init();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
            Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));

            button1.Visible = true;
            button1.Location = PointToClient(Rect.Location);

            button2.Visible = true;
            button2.Location = PointToClient(new Point(Rect.Location.X + 25, Rect.Location.Y));

            button3.Visible = true;
            button3.Location = PointToClient(new Point(Rect.Location.X + 50, Rect.Location.Y));

            button4.Visible = true;
            button4.Location = PointToClient(new Point(Rect.Location.X + 72, Rect.Location.Y));

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }

        private void SaveSS()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "Screenshot1.png";
            sf.Filter = "PNG Files | *.png";

            if (sf.ShowDialog() == DialogResult.OK){
                try{
                    //string savePath = Path.GetDirectoryName(sf.FileName);
                    Image img = cropImage(pictureBox2.Image, Rect);
                    img.Save(sf.FileName, ImageFormat.Png);
                    Hide();
                    init();
                    notify1.ShowBalloonTip(1000, "lightshot", "Ekran görüntüsü şuraya kaydedildi: " + sf.FileName, ToolTipIcon.Info);
                    last_path = sf.FileName;
                }catch (Exception a){
                    MessageBox.Show(a.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSS();
        }

        private void iptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            init();
        }

        private void yükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(yükleToolStripMenuItem.Text != "Yükle"){
                AddApiKey addApi = new AddApiKey();
                addApi.Show();
            }
            else{
                if (IsNetworkAvailable(0) != false)
                {
                    Image img = cropImage(pictureBox2.Image, Rect);
                    img.Save(tmp + "\\tmp.png", ImageFormat.Png);
                    string data = Png2Base64(tmp + "\\tmp.png");
                    Hide();
                    string api = Properties.Settings.Default.api_key;
                    PostImage("https://api.imgbb.com/1/upload?key=" + api, data);
                }else{
                    MessageBox.Show("İnternete bağlı değilsiniz.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void PostImage(string url, string base64)
        {
            var resp = "";
            try
            {
                var values = new Dictionary<string, string>
                {
                    { "image", base64 }
                };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                resp = responseString;
                File.Delete(tmp + "\\tmp.png");

                dynamic d = JObject.Parse(responseString);
                FileUpload fl_up = new FileUpload();
                fl_up.textBox1.Text = d.data.url_viewer;
                fl_up.del_url = d.data.delete_url;
                fl_up.Show();
            }
            catch (Exception e) {
                    FileUpload fl_up = new FileUpload();
                    fl_up.Text = "Yüklenemedi!";
                    fl_up.textBox1.Text = e.Message;
                    fl_up.del_url = null;
                    fl_up.Show();
            }
        }

        private string Png2Base64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            init();
        }

        private void cms1_Opened(object sender, EventArgs e)
        {
            string api = Properties.Settings.Default.api_key;
            if (api != "" && api != null) { yükleToolStripMenuItem.Text = "Yükle"; } else { yükleToolStripMenuItem.Text = "Yükle (Önce bir api key girin!)"; }
        }

        private void aPIKeyEkleDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddApiKey addApi = new AddApiKey();
            addApi.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ekranGörüntsüAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSS();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(IsNetworkAvailable(0) != false) {
                string api = Properties.Settings.Default.api_key;
                if (api != "" && api != null) { yükleToolStripMenuItem.Text = "Yükle"; } else { yükleToolStripMenuItem.Text = "Yükle (Önce bir api key girin!)"; }

                if(yükleToolStripMenuItem.Text != "Yükle"){
                    AddApiKey addApi = new AddApiKey();
                    addApi.Show();
                }else{
                    Image img = cropImage(pictureBox2.Image, Rect);
                    img.Save(tmp + "\\tmp.png", ImageFormat.Png);
                    string data = Png2Base64(tmp + "\\tmp.png");
                    Hide();
                    PostImage("https://api.imgbb.com/1/upload?key=" + api, data);
                }
            }else {
                MessageBox.Show("Internete bağlı değilsiniz.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsNetworkAvailable(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                    continue;

                if (ni.Speed < minimumSpeed)
                    continue;

                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                    continue;

                return true;
            }
            return false;
        }

        private void seçiliAlanıYazıyaDönüştürToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image2Text();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image2Text();
        }

        private async void Image2Text()
        {
            if (File.Exists("ocr.exe")){
                label1.Location = new Point(Cursor.Position.X - 50, Cursor.Position.Y);
                Cursor.Hide();
                label1.Visible = true;
                await Task.Delay(1000);
                try
                {
                    Image img = cropImage(pictureBox2.Image, Rect);
                    img.Save(tmp + "\\tmp.png", ImageFormat.Png);

                    var proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "ocr.exe",
                            Arguments = tmp + "\\tmp.png",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };

                    proc.Start();
                    while (!proc.StandardOutput.EndOfStream)
                    {
                        Cursor.Show();
                        label1.Visible = false;

                        string line = proc.StandardOutput.ReadLine();
                        if(line == "No text !-!") { MessageBox.Show("NO TEXT.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else if(line == "No file dropped !-!") {
                            MessageBox.Show("NO FILE DROPPED.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else{
                            CopyImageText ımageText = new CopyImageText();
                            ımageText.data = line;
                            ımageText.Show();
                        }
                    }
                }
                catch(Exception c){
                    MessageBox.Show(c.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }finally{
                    File.Delete(tmp + "\\tmp.png");
                }
            }
            else{
                MessageBox.Show("Bazı ana bileşenler eksik lütfen lightshot programını kaldırıp tekrar kurunuz.", "lightshot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void notify1_BalloonTipClicked(object sender, EventArgs e)
        {
            if(last_path != null) {
                Process.Start("explorer.exe", string.Format("/select, \"{0}\"", last_path));
            }
        }
    }
}
