using HALL.Moduller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALL
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void kategorileriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild==null)
            {
                KategorileriListele frm = new KategorileriListele();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                this.ActiveMdiChild.Close();
                KategorileriListele frm = new KategorileriListele();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void ürünListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                UrunListele frm = new UrunListele();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                this.ActiveMdiChild.Close();
                UrunListele frm = new UrunListele();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void siparişListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                SiparisListeleme frm = new SiparisListeleme();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                this.ActiveMdiChild.Close();
                SiparisListeleme frm = new SiparisListeleme();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void kargolarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                KargolarıListele frm = new KargolarıListele();
                frm.MdiParent= this;
                frm.Show();
            }
            else
            {
                this.ActiveMdiChild.Close();
                KargolarıListele frm = new KargolarıListele();
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
