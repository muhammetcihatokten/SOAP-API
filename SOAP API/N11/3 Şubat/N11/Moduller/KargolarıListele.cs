using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HALL.N11ShipmentCompanyService;
using HALL.N11ShipmentService;

namespace HALL.Moduller
{
    public partial class KargolarıListele : Form
    {
        
        public KargolarıListele()
        {
            InitializeComponent();
        }

        private void KargolarıListele_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            KargosirketleriniListele();

        }


        public void KargosirketleriniListele()
        {
            string apiKey = "";
            string apiSecret = "";

            N11ShipmentCompanyService.Authentication authentication = new N11ShipmentCompanyService.Authentication();
            authentication.appSecret = apiSecret;
            authentication.appKey = apiKey;

            ShipmentCompanyServicePortService service = new ShipmentCompanyServicePortService();

            GetShipmentCompaniesRequest request = new GetShipmentCompaniesRequest();
            request.auth = authentication;

            GetShipmentCompaniesResponse response = service.GetShipmentCompanies(request);

            List<ShipmentCompanyData> CompanyList = response.shipmentCompanies.ToList();
            


            foreach (ShipmentCompanyData item in CompanyList)
            {
                cmbKargoSirketleri.Items.Add(item.name);
            }
        }


        public void KargoSemasiListesi()
        {
            string apiKey = "";
            string apiSecret = "";

            N11ShipmentService.Authentication authentication = new N11ShipmentService.Authentication();
            authentication.appSecret = apiSecret;
            authentication.appKey = apiKey;

            ShipmentServicePortService service= new ShipmentServicePortService();

            GetShipmentTemplateListRequest request= new GetShipmentTemplateListRequest();
            request.auth = authentication;


            GetShipmentTemplateListResponse response= service.GetShipmentTemplateList(request);


            List<ShipmentApiModel> shipmentTemplateList = response.shipmentTemplates.ToList();


            foreach (ShipmentApiModel sampleitem in shipmentTemplateList)
            {
                dgvKargoSablonlari.Rows.Add(sampleitem.claimShipmentCompany.ToString());

                //dgvKargoSablonlari.DataSource = shipmentTemplateList;
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            KargoSemasiListesi();
        }
    }
}

