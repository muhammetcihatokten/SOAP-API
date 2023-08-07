using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HALL.N11CategoryService;
using System.Data.SqlClient;


namespace HALL
{

    public partial class KategorileriListele : Form
    {




        string apiKey = "";
        string apiSecret = "";



        int n11kat1id = 0;
        int n11kat2id = 0;
        int n11kat3id = 0;
        int n11kat4id = 0;
        int n11Attid = 0;
        int AttDegerid = 0;


        string n11kat1adi = "";
        string n11kat2adi = "";
        string n11kat3adi = "";
        string n11kat4adi = "";


        string n11AttAdi = "";
        string AttDegerAdi = "";





        public KategorileriListele()
        {
            InitializeComponent();
        }

        public void KategorileriListele_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            ServicePointManager.SecurityProtocol = (SecurityProtocolType).3072;


            N11Kategori1Getir();
        }




        //----------------------------------------------------------------------- Kategori 1 -------------------------------------------------------------------


        public void N11Kategori1Getir()
        {
            CategoryServicePortService service = new CategoryServicePortService();
            N11CategoryService.Authentication authentication = new N11CategoryService.Authentication();
            GetTopLevelCategoriesRequest request = new GetTopLevelCategoriesRequest();
            authentication.appKey = apiKey;
            authentication.appSecret = apiSecret;


            request.auth = authentication;

            GetTopLevelCategoriesResponse response = service.GetTopLevelCategories(request);

            //SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HM8Q7CR\\MSSQL;Initial Catalog=N11CategoryList;Integrated Security=True");



            //foreach (var item in response.categoryList)
            //{
            //    baglanti.Open();

            //    SqlCommand aktar = new SqlCommand("insert into TopCategory (id,name) values (@id,@name)");

            //    aktar.Parameters.AddWithValue("@id", item.id);
            //    aktar.Parameters.AddWithValue("@name", item.name);
            //    aktar.ExecuteNonQuery();

            //    baglanti.Close();


            //List<SubCategory> kat1List = response.categoryList.ToList();
            //CmbKategori1.DataSource = kat1List;
            //CmbKategori1.DisplayMember = "name";
            //CmbKategori1.ValueMember = "id";





            if (response.result.status == "success")
            {
                if (response.categoryList != null && response.categoryList.Count() > 0)
                {

                    CmbKategori1.Enabled = true;


                    SubCategory[] N11Kat1list = response.categoryList;


                    SubCategory c = new SubCategory();

                    c.id = 0;
                    c.name = "Seçiniz";
                    N11Kat1list[0] = c;

                    CmbKategori1.DataSource = N11Kat1list;
                    CmbKategori1.DisplayMember = "name";
                    CmbKategori1.ValueMember = "id";

                }
                else
                {
                    MessageBox.Show("Kategori Bulunmadı");
                }
            }
            else
            {
                MessageBox.Show(response.result.errorMessage);
            }

        }






        //----------------------------------------------------------------------- Kategori 1 -------------------------------------------------------------------






        private void CmbKategori1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbKategori2.DataSource = null;
            CmbKategori2.Enabled = false;


            CmbKategori3.DataSource = null;
            CmbKategori3.Enabled = false;

            CmbKategori4.DataSource = null;
            CmbKategori4.Enabled = false;




            if (CmbKategori1.SelectedItem != null && CmbKategori1.SelectedIndex > 0)
            {
                CategoryServicePortService service = new CategoryServicePortService();

                SubCategory secilikat = CmbKategori1.SelectedItem as SubCategory;
                n11kat1adi = secilikat.name;
                n11kat1id = Convert.ToInt32(secilikat.id);

                Authentication authentication = new Authentication();
                authentication.appKey = apiKey;
                authentication.appSecret = apiSecret;

                GetSubCategoriesRequest request = new GetSubCategoriesRequest();
                request.auth = authentication;
                request.categoryId = n11kat1id;

                GetSubCategoriesResponse response = service.GetSubCategories(request);

                if (response.result.status == "success")
                {
                    if (response.category != null && response.category.Count() > 0)
                    {
                        foreach (SubCategoryData item in response.category)
                        {


                            SubCategory[] N11Kat1list = item.subCategoryList;


                            if (N11Kat1list != null)
                            {
                                CmbKategori2.Enabled = true;

                                SubCategory c = new SubCategory();

                                c.id = 0;
                                c.name = "Seçiniz";
                                N11Kat1list[0] = c;

                                CmbKategori2.DataSource = N11Kat1list; //Alt kategorileri getirir
                                CmbKategori2.DisplayMember = "name";
                                CmbKategori2.ValueMember = "id";
                            }

                            else
                            {

                                LblCategoryId.Text = n11kat1adi;
                                LblCategoryAdi.Text = n11kat1id.ToString();


                                GetCategoryAttributesIdRequest req2 = new GetCategoryAttributesIdRequest();
                                req2.auth = authentication;
                                req2.categoryId = n11kat1id;        //Kategori[0]'ın alt özellikleri varsa onları getirsin yoksa özelliklerini getirsin.

                                CategoryServicePortService Src2 = new CategoryServicePortService();
                                GetCategoryAttributesIdResponse res2 = Src2.GetCategoryAttributesId(req2);
                                List<CategoryProductAttributeData> attributler = res2.categoryProductAttributeList.ToList();

                                CmbOzellik.DataSource = null;
                                CmbOzellik.Enabled = false;
                                CmbDeger.DataSource = null;
                                CmbDeger.Enabled = false;

                                if (attributler != null)
                                {
                                    CmbOzellik.Enabled = true;

                                    var att = (from x in attributler
                                               select new
                                               {
                                                   x.id,
                                                   x.name,
                                                   x.mandatory,
                                                   DisplayField = string.Format("{0} ({1})", x.name, (x.mandatory == true ? "Zorunlu" : "Zorunlu Değil"
                                               ))


                                               }).ToArray();
                                    CmbOzellik.DataSource = att;
                                    CmbOzellik.DisplayMember = "DisplayField";
                                    CmbOzellik.ValueMember = "id";

                                }
                            }
                        }
                    }
                }
            }
        }







        //----------------------------------------------------------------------- Kategori 2 -------------------------------------------------------------------




        private void CmbKategori2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbKategori3.DataSource = null;
            CmbKategori3.Enabled = false;

            CmbKategori4.DataSource = null;
            CmbKategori4.Enabled = false;

            if (CmbKategori2.SelectedItem != null && CmbKategori2.SelectedIndex > 0)
            {
                CategoryServicePortService Src = new CategoryServicePortService();

                SubCategory secilikat = CmbKategori2.SelectedItem as SubCategory;
                n11kat2adi = secilikat.name;
                n11kat2id = Convert.ToInt32(secilikat.id);

                Authentication auth = new Authentication();
                auth.appKey = apiKey;
                auth.appSecret = apiSecret;

                GetSubCategoriesRequest req = new GetSubCategoriesRequest();
                req.auth = auth;
                req.categoryId = n11kat2id;

                GetSubCategoriesResponse res = Src.GetSubCategories(req);



                if (res.result.status == "success")
                {
                    if (res.category != null && res.category.Count() > 0)
                    {
                        foreach (SubCategoryData item in res.category)
                        {
                            SubCategory[] N11Kat2list = item.subCategoryList;

                            if (item.subCategoryList != null)
                            {
                                CmbKategori3.Enabled = true;

                                SubCategory c = new SubCategory();

                                c.id = 0;
                                c.name = "Seçiniz";
                                N11Kat2list[0] = c;

                                CmbKategori3.DataSource = N11Kat2list; //Alt kategorileri getirir
                                CmbKategori3.DisplayMember = "name";
                                CmbKategori3.ValueMember = "id";




                            }
                            else
                            {

                                LblKategoriAdi.Text = n11kat2adi;
                                LblKategoriId.Text = n11kat2id.ToString();

                                GetCategoryAttributesIdRequest req2 = new GetCategoryAttributesIdRequest();
                                req2.auth = auth;
                                req2.categoryId = n11kat1id;        //Kategori[0]'ın alt özellikleri varsa onları getirsin yoksa özelliklerini getirsin.

                                CategoryServicePortService Src2 = new CategoryServicePortService();
                                GetCategoryAttributesIdResponse res2 = Src2.GetCategoryAttributesId(req2);
                                List<CategoryProductAttributeData> attributler = res2.categoryProductAttributeList.ToList();

                                CmbOzellik.DataSource = null;
                                CmbOzellik.Enabled = false;
                                CmbDeger.DataSource = null;
                                CmbDeger.Enabled = false;

                                if (attributler != null)
                                {
                                    CmbOzellik.Enabled = true;

                                    var att = (from x in attributler
                                               select new
                                               {
                                                   x.id,
                                                   x.name,
                                                   x.mandatory,
                                                   DisplayField = string.Format("{0} ({1})", x.name, (x.mandatory == true ? "Zorunlu" : "Zorunlu Değil"
                                               ))


                                               }).ToArray();
                                    CmbOzellik.DataSource = att;
                                    CmbOzellik.DisplayMember = "DisplayField";
                                    CmbOzellik.ValueMember = "id";

                                }
                            }
                        }
                    }
                }
            }
        }


        //----------------------------------------------------------------------- Kategori 3 -------------------------------------------------------------------


        private void CmbKategori3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbKategori4.DataSource = null;
            CmbKategori4.Enabled = false;

            if (CmbKategori3.SelectedItem != null && CmbKategori3.SelectedIndex > 0)
            {
                CategoryServicePortService Src = new CategoryServicePortService();

                SubCategory secilikat = CmbKategori3.SelectedItem as SubCategory;
                n11kat3adi = secilikat.name;
                n11kat3id = Convert.ToInt32(secilikat.id);

                Authentication auth = new Authentication();
                auth.appKey = apiKey;
                auth.appSecret = apiSecret;

                GetSubCategoriesRequest req = new GetSubCategoriesRequest();
                req.auth = auth;
                req.categoryId = n11kat3id;

                GetSubCategoriesResponse res = Src.GetSubCategories(req);



                if (res.result.status == "success")
                {
                    if (res.category != null && res.category.Count() > 0)
                    {
                        foreach (SubCategoryData item in res.category)
                        {
                            SubCategory[] N11Kat3list = item.subCategoryList;

                            if (item.subCategoryList != null)
                            {
                                CmbKategori4.Enabled = true;

                                SubCategory c = new SubCategory();

                                c.id = 0;
                                c.name = "Seçiniz";
                                N11Kat3list[0] = c;

                                CmbKategori4.DataSource = N11Kat3list; //Alt kategorileri getirir
                                CmbKategori4.DisplayMember = "name";
                                CmbKategori4.ValueMember = "id";


                            }
                            else
                            {

                                LblKategoriAdi.Text = n11kat3adi;
                                LblKategoriId.Text = n11kat3id.ToString();

                                GetCategoryAttributesIdRequest req2 = new GetCategoryAttributesIdRequest();
                                req2.auth = auth;
                                req2.categoryId = n11kat3id;        //Kategori[0]'ın alt özellikleri varsa onları getirsin yoksa özelliklerini getirsin.

                                CategoryServicePortService Src2 = new CategoryServicePortService();
                                GetCategoryAttributesIdResponse res2 = Src2.GetCategoryAttributesId(req2);
                                List<CategoryProductAttributeData> attributler = res2.categoryProductAttributeList.ToList();

                                CmbOzellik.DataSource = null;
                                CmbOzellik.Enabled = false;
                                CmbDeger.DataSource = null;
                                CmbDeger.Enabled = false;

                                if (attributler != null)
                                {
                                    CmbOzellik.Enabled = true;

                                    var att = (from x in attributler
                                               select new
                                               {
                                                   x.id,
                                                   x.name,
                                                   x.mandatory,
                                                   DisplayField = string.Format("{0} ({1})", x.name, (x.mandatory == true ? "Zorunlu" : "Zorunlu Değil"
                                               ))


                                               }).ToArray();
                                    CmbOzellik.DataSource = att;
                                    CmbOzellik.DisplayMember = "DisplayField";
                                    CmbOzellik.ValueMember = "id";

                                }
                            }
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------- Kategori 4 -------------------------------------------------------------------

        private void CmbKategori4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbKategori4.SelectedItem != null && CmbKategori4.SelectedIndex > 0)
            {
                CategoryServicePortService Src = new CategoryServicePortService();

                SubCategory secilikat = CmbKategori4.SelectedItem as SubCategory;
                n11kat4adi = secilikat.name;
                n11kat4id = Convert.ToInt32(secilikat.id);

                Authentication auth = new Authentication();
                auth.appKey = apiKey;
                auth.appSecret = apiSecret;

                GetSubCategoriesRequest req = new GetSubCategoriesRequest();
                req.auth = auth;
                req.categoryId = n11kat4id;

                GetCategoryAttributesIdRequest req2 = new GetCategoryAttributesIdRequest();
                req2.auth = auth;
                req2.categoryId = n11kat4id;        //Kategori[0]'ın alt özellikleri varsa onları getirsin yoksa özelliklerini getirsin.

                CategoryServicePortService Src2 = new CategoryServicePortService();
                GetCategoryAttributesIdResponse res2 = Src2.GetCategoryAttributesId(req2);
                List<CategoryProductAttributeData> attributler = res2.categoryProductAttributeList.ToList();

                CmbOzellik.DataSource = null;
                CmbOzellik.Enabled = false;
                CmbDeger.DataSource = null;
                CmbDeger.Enabled = false;

                if (attributler != null)
                {

                    LblKategoriAdi.Text = n11kat4adi;
                    LblKategoriId.Text = n11kat4id.ToString();

                    CmbOzellik.Enabled = true;

                    var att = (from x in attributler
                               select new
                               {
                                   x.id,
                                   x.name,
                                   x.mandatory,
                                   DisplayField = string.Format("{0} ({1})", x.name, (x.mandatory == true ? "Zorunlu" : "Zorunlu Değil"
                               ))


                               }).ToArray();
                    CmbOzellik.DataSource = att;
                    CmbOzellik.DisplayMember = "DisplayField";
                    CmbOzellik.ValueMember = "id";


                }
            }
        }

        private void CmbOzellik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbOzellik.SelectedItem != null)
            {
                dynamic s = CmbOzellik.SelectedItem;

                n11Attid = 0;
                n11AttAdi = "";

                if (s != null)
                {
                    long seciliAttid = s.id;
                    n11Attid = Convert.ToInt32(seciliAttid);
                    n11AttAdi = s.name;


                    CategoryServicePortService service = new CategoryServicePortService();

                    Authentication authentication = new Authentication();
                    authentication.appKey = apiKey;
                    authentication.appSecret = apiSecret;

                    GetCategoryAttributeValueRequest request = new GetCategoryAttributeValueRequest();
                    request.auth = authentication;
                    request.categoryProductAttributeId = n11Attid;



                    GetCategoryAttributeValueResponse response = service.GetCategoryAttributeValue(request);

                    CmbDeger.DataSource = null;
                    CmbDeger.Enabled = false;

                    if (response.result.status == "success")
                    {
                        if (response.categoryProductAttributeValueList != null && response.categoryProductAttributeValueList.Count() > 0)
                        {
                            CmbDeger.Enabled = true;
                            CmbDeger.DataSource = response.categoryProductAttributeValueList;
                            CmbDeger.DisplayMember = "name";
                            CmbDeger.ValueMember = "id";
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.result.errorMessage);
                    }
                }
            }
        }
    }
}


