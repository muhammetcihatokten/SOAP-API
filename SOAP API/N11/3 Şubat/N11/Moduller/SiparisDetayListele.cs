using HALL.N11OrderService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALL.Moduller
{
    public partial class SiparisDetayListele : Form
    {
        public SiparisDetayListele()
        {
            InitializeComponent();
        }

        static public long id;
        public void SiparisDetayListele_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;



            string apiKey = "fbbcbfb5-0122-4e64-b66d-1dd5a26366fa";
            string apiSecret = "olYhqNMLzQcVkd5I";

            string taxfullname = "";
            string tel= "";

            long orderIdValue = id;

            N11OrderService.Authentication authentication = new N11OrderService.Authentication();
            authentication.appKey = apiKey;
            authentication.appSecret = apiSecret;

            //BuyerWithTaxFields buyerWithTaxFields = new BuyerWithTaxFields();
            //buyerWithTaxFields.fullName = taxfullname.ToString();
            //buyerWithTaxFields.email = tel;

            OrderDataRequest orderDataRequest = new OrderDataRequest();
            orderDataRequest.id = id;
            

            OrderDetailRequest request = new OrderDetailRequest();
            request.auth = authentication;
            request.orderRequest = orderDataRequest;


            N11OrderService.OrderServicePortService port = new OrderServicePortService();
            OrderDetailResponse orderDetailResponse = port.OrderDetail(request);
            
            OrderDetailData orderDetail = orderDetailResponse.orderDetail;


            List<OrderSearchData> orderItemList = orderDetail.itemList.ToList();


            foreach (OrderSearchData sampleItem in orderItemList)
            {

                dgvKampanyaKod.DataSource = (from kampanyakod in orderItemList
                                             select new
                                             {

                                                 KampanyaKodu = kampanyakod.shipmentInfo.campaignNumber,

                                             }).ToArray();
            }





            //foreach (BuyerWithTaxFields sampleitem in buyerWithTaxFields)
            //{

            //    dgvGondericiBilgileri.DataSource = (from gonderici in buyerWithTaxFields
            //                                        select new
            //                                        {

            //                                            ŞirketAdı = sampleItem.taxOffice.
            //                                            ŞirketTelefonu =

            //                                        }).ToArray();
            //}



            foreach (OrderSearchData sampleItem in orderItemList)
            {

                dgvAliciBilgileri.DataSource = (from alicibilgileri in orderItemList
                                                select new
                                                {
                                                    AlıcıAdı = orderDetail.buyer.fullName,
                                                    TC = orderDetail.buyer.tcId,
                                                    AdresAdSoyad = orderDetail.shippingAddress.fullName,
                                                    Adres = orderDetail.shippingAddress.address,
                                                    Semt = orderDetail.shippingAddress.district,
                                                    Şehir = orderDetail.shippingAddress.city,
                                                    PostaKodu = orderDetail.shippingAddress.postalCode,
                                                    GSM = orderDetail.shippingAddress.gsm,
                                                    ÖdemeYöntemi =

                                                      (orderDetail.paymentType != null && orderDetail.paymentType == "1" ? "Kredi Kartı" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "2" ? "BKMEXPRESS" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "3" ? "AKBANKDIREKT" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "4" ? "PAYPAL" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "5" ? "MallPoint" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "6" ? "GARANTIPAY" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "7" ? "GarantiLoan" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "8" ? "MasterPass" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "9" ? "ISBANKPAY" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "10" ? "PAYCELL" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "11" ? "COMPAY" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "12" ? "YKBPAY" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "13" ? "FIBABANK" :
                                                       orderDetail.paymentType != null && orderDetail.paymentType == "14" ? "Other" : "Tanımsız"
                                                      ),
                                                }).ToArray();
            }



            foreach (OrderSearchData sampleItem in orderItemList)
            {

                dgvSiparisBilgileri.DataSource = (from siparisbilgileri in orderItemList
                                                  select new
                                                  {

                                                      SiparisID =orderDetail.id,
                                                      SiparişNumarası = orderDetail.orderNumber,
                                                      SiparisOluşturmaTarihi = orderDetail.createDate,
                                                      TakipNumarası = siparisbilgileri.shipmentInfo.trackingNumber.ToString(),
                                                      KargoFirması = siparisbilgileri.shipmentInfo.shipmentCompany.name.ToString(),
                                                      
                                                  }).ToArray();


            }




            foreach (OrderSearchData sampleItem in orderItemList)
            {

                dgvUrunbilgileri.DataSource = (from ürünbilgileri in orderItemList
                                                  select new
                                                  {


                                                      ÜrünAdı = ürünbilgileri.productName,
                                                      ÜrünNo = ürünbilgileri.productId,
                                                      ÜrünSatıcıKodu = ürünbilgileri.productSellerCode,

                                                     
                                                  }
                                             ).ToArray();


            }
        }
    }
}