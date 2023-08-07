namespace HALL
{
    partial class AnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaMenüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategorileriListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kargoİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kargolarıListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaMenüToolStripMenuItem,
            this.ürünİşlemleriToolStripMenuItem,
            this.kategoriİşlemleriToolStripMenuItem,
            this.siparişİşlemleriToolStripMenuItem,
            this.kargoİşlemleriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2534, 53);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaMenüToolStripMenuItem
            // 
            this.anaMenüToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.anaMenüToolStripMenuItem.Name = "anaMenüToolStripMenuItem";
            this.anaMenüToolStripMenuItem.Size = new System.Drawing.Size(199, 49);
            this.anaMenüToolStripMenuItem.Text = "Ana Menü";
            // 
            // ürünİşlemleriToolStripMenuItem
            // 
            this.ürünİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünListeleToolStripMenuItem});
            this.ürünİşlemleriToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ürünİşlemleriToolStripMenuItem.Name = "ürünİşlemleriToolStripMenuItem";
            this.ürünİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(258, 49);
            this.ürünİşlemleriToolStripMenuItem.Text = "Ürün İşlemleri";
            // 
            // ürünListeleToolStripMenuItem
            // 
            this.ürünListeleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.ürünListeleToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ürünListeleToolStripMenuItem.Name = "ürünListeleToolStripMenuItem";
            this.ürünListeleToolStripMenuItem.Size = new System.Drawing.Size(359, 54);
            this.ürünListeleToolStripMenuItem.Text = "Ürün Listele";
            this.ürünListeleToolStripMenuItem.Click += new System.EventHandler(this.ürünListeleToolStripMenuItem_Click);
            // 
            // kategoriİşlemleriToolStripMenuItem
            // 
            this.kategoriİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategorileriListeleToolStripMenuItem});
            this.kategoriİşlemleriToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.kategoriİşlemleriToolStripMenuItem.Name = "kategoriİşlemleriToolStripMenuItem";
            this.kategoriİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(311, 49);
            this.kategoriİşlemleriToolStripMenuItem.Text = "Kategori İşlemleri";
            // 
            // kategorileriListeleToolStripMenuItem
            // 
            this.kategorileriListeleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.kategorileriListeleToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.kategorileriListeleToolStripMenuItem.Name = "kategorileriListeleToolStripMenuItem";
            this.kategorileriListeleToolStripMenuItem.Size = new System.Drawing.Size(447, 54);
            this.kategorileriListeleToolStripMenuItem.Text = "Kategorileri Listele";
            this.kategorileriListeleToolStripMenuItem.Click += new System.EventHandler(this.kategorileriListeleToolStripMenuItem_Click);
            // 
            // siparişİşlemleriToolStripMenuItem
            // 
            this.siparişİşlemleriToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.siparişİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siparişListeleToolStripMenuItem});
            this.siparişİşlemleriToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.siparişİşlemleriToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.siparişİşlemleriToolStripMenuItem.Name = "siparişİşlemleriToolStripMenuItem";
            this.siparişİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(282, 49);
            this.siparişİşlemleriToolStripMenuItem.Text = "Sipariş İşlemleri";
            // 
            // siparişListeleToolStripMenuItem
            // 
            this.siparişListeleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.siparişListeleToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.siparişListeleToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.siparişListeleToolStripMenuItem.Name = "siparişListeleToolStripMenuItem";
            this.siparişListeleToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.siparişListeleToolStripMenuItem.Size = new System.Drawing.Size(418, 54);
            this.siparişListeleToolStripMenuItem.Text = "Siparişleri Listele";
            this.siparişListeleToolStripMenuItem.Click += new System.EventHandler(this.siparişListeleToolStripMenuItem_Click);
            // 
            // kargoİşlemleriToolStripMenuItem
            // 
            this.kargoİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kargolarıListeleToolStripMenuItem});
            this.kargoİşlemleriToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.kargoİşlemleriToolStripMenuItem.Name = "kargoİşlemleriToolStripMenuItem";
            this.kargoİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(270, 49);
            this.kargoİşlemleriToolStripMenuItem.Text = "Kargo İşlemleri";
            // 
            // kargolarıListeleToolStripMenuItem
            // 
            this.kargolarıListeleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(51)))), ((int)(((byte)(77)))));
            this.kargolarıListeleToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.kargolarıListeleToolStripMenuItem.Name = "kargolarıListeleToolStripMenuItem";
            this.kargolarıListeleToolStripMenuItem.Size = new System.Drawing.Size(405, 54);
            this.kargolarıListeleToolStripMenuItem.Text = "Kargoları Listele";
            this.kargolarıListeleToolStripMenuItem.Click += new System.EventHandler(this.kargolarıListeleToolStripMenuItem_Click);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2534, 1529);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anaMenüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategoriİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategorileriListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kargoİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kargolarıListeleToolStripMenuItem;
    }
}

