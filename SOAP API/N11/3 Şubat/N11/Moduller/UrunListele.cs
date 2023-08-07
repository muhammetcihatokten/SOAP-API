using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HALL.N11ProductService;
using System.Data.SqlClient;    


namespace HALL.Moduller
{
    public partial class UrunListele : Form
    {
        string apiKey = "";
        string apiSecret = "";



        private int pageSize ;
        private int gelenSayfaNo = 1;
        private int toplamSayfa = 1;
        private int toplamUrunAdet = 0;

        public UrunListele()
        {
            InitializeComponent();
        }

        //SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-HM8Q7CR\\MSSQL;Initial Catalog=N11UrunListelemeDeneme;Integrated Security=True");
        //DataSet ds = new DataSet(); 
        

        private void UrunListele_Load(object sender, EventArgs e)
        {

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            //pageSize = ;
            gelenSayfaNo = 1;
            toplamSayfa = 1;
            toplamUrunAdet = 0;

            lbSayfaNo.Text = "1";
            lbToplamSayfa.Text = "1";
            lbToplamUrun.Text = "0";


            string name = "";
            string gtin = ""; // N11 için tanımlanan barkod
            string mpn = "";  // Ürün barkodu ( bizdeki )

            bool? bundle = null;
            string UrunDurum = "";


            if (!string.IsNullOrEmpty(tbUrunAdi.Text))
            {
                name = tbUrunAdi.Text;
            }
            if (!string.IsNullOrEmpty(tbGtin.Text))
            {
                gtin = tbGtin.Text;
            }
            if (!string.IsNullOrEmpty(tbMpn.Text))
            {
                mpn = tbMpn.Text;
            }
            if (cmbBundle.SelectedItem != null && cmbBundle.SelectedIndex > 0)
            {
                if (cmbBundle.SelectedIndex == 1) bundle = true;
                if (cmbBundle.SelectedIndex == 2) bundle = false;
            }
            if (cmbUrunDurum.SelectedItem != null && cmbUrunDurum.SelectedIndex > 0)
            {
                if (cmbUrunDurum.SelectedIndex == 1) UrunDurum = "1"; // Aktif
                if (cmbUrunDurum.SelectedIndex == 2) UrunDurum = "2"; // Yasak
                if (cmbUrunDurum.SelectedIndex == 3) UrunDurum = "3"; // Askıya alınmış

            }



            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gtin) && string.IsNullOrEmpty(mpn) && bundle == null && string.IsNullOrEmpty(UrunDurum) )
            {
                N11TumUrunleriGetir(gelenSayfaNo);
            }
            else
            {
                N11UrunArama(name, gtin, mpn, bundle, UrunDurum, gelenSayfaNo);
            }
        }


        private void N11UrunArama(string name, string mpn, string gtin, bool? bundle, string urunDurum, int gelenSayfaNo)
        {
         
            dgwUrunListesi.DataSource = null;
            N11Services N11Src = new N11Services();
          
            toplamUrunAdet = 0;

            Tuple<string, int, ProductBasic[]> gelenData = N11Src.N11ArananUrunGetir(name, gtin, mpn, urunDurum, bundle, gelenSayfaNo, pageSize);

            if (gelenData != null)
            {
                if (!string.IsNullOrEmpty(gelenData.Item1)) // Hatayı sorgulattığımız kısım,
                {
                    MessageBox.Show(gelenData.Item1);
                }
                else // Hata olmazsa buradan devam edecektir.
                {
                    if (gelenData.Item2 != null)
                    {
                        toplamUrunAdet = gelenData.Item2;

                        lbToplamUrun.Text = toplamUrunAdet.ToString();
                    }
                    if (gelenData.Item3 != null && gelenData.Item3.Count() > 0)
                    {
                        ProductBasic[] gelenN11Urunler = gelenData.Item3; //// ?

                  


                        dgwUrunListesi.DataSource = (from d in gelenN11Urunler
                                                     select new
                                                     {
                                                         d.id,
                                                         MağazaKodu = d.productSellerCode,
                                                         Durum_1 = (d.saleStatus != null && d.saleStatus == "1" ? "Satış Öncesi" :
                                                                    d.saleStatus != null && d.saleStatus == "2" ? "Satışta" :
                                                                    d.saleStatus != null && d.saleStatus == "3" ? "Stok yok" :
                                                                    d.saleStatus != null && d.saleStatus == "4" ? "Satışa Kapalı" : "Tanımsız"
                                                                    ),

                                                         Durum_2 = (d.approvalStatus != null && d.approvalStatus == "1" ? "Aktif" :
                                                                    d.approvalStatus != null && d.approvalStatus == "2" ? "Yasaklı" :
                                                                    d.approvalStatus != null && d.approvalStatus == "3" ? "Askıya alındı" : "Tanımsız"
                                                                    ),
                                                        
                                                        Eski_Fiyat= d.oldPrice,
                                                        Fiyat=d.price,
                                                        d.displayPrice,

                                                        Urun_adi = d.title,
                                                        Urun_altbaslik = d.subtitle


                                                     }).ToArray();























                        /*
                        if (gelenN11Urunler != null && gelenN11Urunler.Count() > 0)
                        {
                            int toplamSayfa = 0;


                            toplamSayfa = toplamUrunAdet / pageSize;

                            if (toplamUrunAdet % pageSize > 0)
                            {
                                toplamSayfa = toplamSayfa + 1;
                            }

                            lbToplamSayfa.Text = toplamSayfa.ToString();
                            dgwUrunListesi.DataSource = gelenN11Urunler;

                        }
                        */
                    }
                }
            }
            else
            {
                MessageBox.Show("N11 Ürün Listesi Bulunamadı");
            }
        }

        private void N11TumUrunleriGetir(int gelenSayfaNo)
        {
            dgwUrunListesi.DataSource = null;
            N11Services N11Src = new N11Services();

            toplamUrunAdet = 0;

            Tuple<string, int, ProductBasic[]> gelenData = N11Src.N11TumUrunleriGetir(gelenSayfaNo, pageSize);

            if (gelenData != null)
            {
                if (!string.IsNullOrEmpty(gelenData.Item1))
                {
                    MessageBox.Show(gelenData.Item1);
                }
                else
                {
                    if (gelenData.Item2 != null)
                    {
                        toplamUrunAdet = gelenData.Item2;

                        lbToplamUrun.Text = toplamUrunAdet.ToString();
                    }
                    if (gelenData.Item3 != null && gelenData.Item3.Count() > 0)
                    {
                        ProductBasic[] gelenN11Urunler = gelenData.Item3; //// ?

                        dgwUrunListesi.DataSource = (from u in gelenN11Urunler
                                                     select new
                                                     {
                                                         u.id,
                                                         Mağaza_Kodu = u.productSellerCode,

                                                         Durum_1 = (u.saleStatus != null && u.saleStatus == "1" ? "Satış Öncesi" :
                                                                    u.saleStatus != null && u.saleStatus == "2" ? "Satışta" :
                                                                    u.saleStatus != null && u.saleStatus == "3" ? "Stok yok" :
                                                                    u.saleStatus != null && u.saleStatus == "4" ? "Satışa Kapalı" : "Tanımsız"
                                                                    ),


                                                         Durum_2 = (u.approvalStatus != null && u.approvalStatus == "1" ? "Aktif" :
                                                                    u.approvalStatus != null && u.approvalStatus == "2" ? "Yasaklı" :
                                                                    u.approvalStatus != null && u.approvalStatus == "3" ? "Askıya alındı" : "Tanımsız"
                                                                    ),


                                                         u.oldPrice,
                                                         u.price,
                                                         u.displayPrice,
                                                         Ürün_Adı = u.title,
                                                         Ürün_altBaşlık = u.subtitle

                                                     }).ToArray();

                        /*
                        if (gelenN11Urunler != null && gelenN11Urunler.Count() > 0)
                        {
                            int toplamSayfa = 0;


                            toplamSayfa = toplamUrunAdet / pageSize;

                            if (toplamUrunAdet % pageSize > 0)
                            {
                                toplamSayfa = toplamSayfa + 1;
                            }

                            lbToplamSayfa.Text = toplamSayfa.ToString();
                            dgwUrunListesi.DataSource = gelenN11Urunler;
                        }
                        */
                    }
                }
            }
            else
            {
                MessageBox.Show("N11 Ürün Listesi Bulunamadı");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dgwUrunListesi.Rows.Count - 1; i++)
            //{
            //    Connection.Open();
            //    SqlCommand command = new SqlCommand("insert into N11UrunlerDeneme(id,productSellerCode,title,subtitle,oldPrice,price,displayPrice,isDomestic,saleStatus,approvalStatus,stockItems,currencyAmount,currencyType) values(@id,@productSellerCode,@title,@subtitle,@oldPrice,@price,@displayPrice,@isDomestic,@saleStatus,@approvalStatus,@stockItems,@currencyAmount,@currencyType)", Connection);

            //    command.Parameters.AddWithValue("@id", int.Parse(dgwUrunListesi.Rows[i].Cells["id"].Value.ToString()));
            //    command.Parameters.AddWithValue("@productSellerCode", dgwUrunListesi.Rows[i].Cells["productSellerCode"].Value.ToString());
            //    command.Parameters.AddWithValue("@title", dgwUrunListesi.Rows[i].Cells["title"].Value.ToString());
            //    command.Parameters.AddWithValue("@subtitle", dgwUrunListesi.Rows[i].Cells["subtitle"].Value.ToString());
            //    command.Parameters.AddWithValue("@oldPrice", int.Parse(dgwUrunListesi.Rows[i].Cells["oldPrice"].Value.ToString()));
            //    command.Parameters.AddWithValue("@price", dgwUrunListesi.Rows[i].Cells["price"].Value);
            //    command.Parameters.AddWithValue("@displayPrice", dgwUrunListesi.Rows[i].Cells["displayPrice"].Value);
            //    command.Parameters.AddWithValue("@isDomestic", dgwUrunListesi.Rows[i].Cells["isDomestic"].Value.ToString());
            //    command.Parameters.AddWithValue("@saleStatus", dgwUrunListesi.Rows[i].Cells["saleStatus"].Value);
            //    command.Parameters.AddWithValue("@approvalStatus", dgwUrunListesi.Rows[i].Cells["approvalStatus"].Value);
            //    command.Parameters.AddWithValue("@stockItems", dgwUrunListesi.Rows[i].Cells["stockItems"].Value.ToString());
            //    command.Parameters.AddWithValue("@currencyAmount", dgwUrunListesi.Rows[i].Cells["currencyAmount"].Value);
            //    command.Parameters.AddWithValue("@currencyType", dgwUrunListesi.Rows[i].Cells["currencyType"].Value);
            //  //command.Parameters.AddWithValue("@productStatusDetail", dgwUrunListesi.Rows[i].Cells["productStatusDetail"].Value.ToString();
            //    command.ExecuteNonQuery();

            //    Connection.Close();

            //}
        }
    }
}
