namespace lightshot
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seçiliAlanıYazıyaDönüştürToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iptalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.notify1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ekranGörüntsüAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIKeyEkleDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cms1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cms2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.cms1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(686, 357);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // cms1
            // 
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem,
            this.yükleToolStripMenuItem,
            this.seçiliAlanıYazıyaDönüştürToolStripMenuItem,
            this.iptalToolStripMenuItem});
            this.cms1.Name = "cms1";
            this.cms1.Size = new System.Drawing.Size(216, 92);
            this.cms1.Opened += new System.EventHandler(this.cms1_Opened);
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.kaydetToolStripMenuItem_Click);
            // 
            // yükleToolStripMenuItem
            // 
            this.yükleToolStripMenuItem.Name = "yükleToolStripMenuItem";
            this.yükleToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.yükleToolStripMenuItem.Text = "Yükle";
            this.yükleToolStripMenuItem.Click += new System.EventHandler(this.yükleToolStripMenuItem_Click);
            // 
            // seçiliAlanıYazıyaDönüştürToolStripMenuItem
            // 
            this.seçiliAlanıYazıyaDönüştürToolStripMenuItem.Name = "seçiliAlanıYazıyaDönüştürToolStripMenuItem";
            this.seçiliAlanıYazıyaDönüştürToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.seçiliAlanıYazıyaDönüştürToolStripMenuItem.Text = "Seçili alanı yazıya dönüştür";
            this.seçiliAlanıYazıyaDönüştürToolStripMenuItem.Click += new System.EventHandler(this.seçiliAlanıYazıyaDönüştürToolStripMenuItem_Click);
            // 
            // iptalToolStripMenuItem
            // 
            this.iptalToolStripMenuItem.Name = "iptalToolStripMenuItem";
            this.iptalToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.iptalToolStripMenuItem.Text = "İptal";
            this.iptalToolStripMenuItem.Click += new System.EventHandler(this.iptalToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(503, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 57);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // notify1
            // 
            this.notify1.ContextMenuStrip = this.cms2;
            this.notify1.Icon = ((System.Drawing.Icon)(resources.GetObject("notify1.Icon")));
            this.notify1.Visible = true;
            this.notify1.BalloonTipClicked += new System.EventHandler(this.notify1_BalloonTipClicked);
            // 
            // cms2
            // 
            this.cms2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekranGörüntsüAlToolStripMenuItem,
            this.aPIKeyEkleDeğiştirToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.cms2.Name = "cms2";
            this.cms2.Size = new System.Drawing.Size(184, 92);
            // 
            // ekranGörüntsüAlToolStripMenuItem
            // 
            this.ekranGörüntsüAlToolStripMenuItem.Name = "ekranGörüntsüAlToolStripMenuItem";
            this.ekranGörüntsüAlToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.ekranGörüntsüAlToolStripMenuItem.Text = "Ekran Görüntsü Al";
            this.ekranGörüntsüAlToolStripMenuItem.Click += new System.EventHandler(this.ekranGörüntsüAlToolStripMenuItem_Click);
            // 
            // aPIKeyEkleDeğiştirToolStripMenuItem
            // 
            this.aPIKeyEkleDeğiştirToolStripMenuItem.Name = "aPIKeyEkleDeğiştirToolStripMenuItem";
            this.aPIKeyEkleDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.aPIKeyEkleDeğiştirToolStripMenuItem.Text = "API Key Ekle/Değiştir";
            this.aPIKeyEkleDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.aPIKeyEkleDeğiştirToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(477, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 30);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(477, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 30);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(451, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 30);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(451, 271);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 30);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(447, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lütfen Bekleyiniz...";
            this.label1.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 357);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cms1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cms2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cms1;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yükleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iptalToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notify1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cms2;
        private System.Windows.Forms.ToolStripMenuItem aPIKeyEkleDeğiştirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekranGörüntsüAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seçiliAlanıYazıyaDönüştürToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
    }
}

