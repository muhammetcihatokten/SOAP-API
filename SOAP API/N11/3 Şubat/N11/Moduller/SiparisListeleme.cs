using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using HALL.N11OrderService;
using HALL.N11ProductService;
using HALL.N11ShipmentCompanyService;
using Newtonsoft.Json.Converters;
using RestSharp;

namespace HALL.Moduller
{
    public partial class SiparisListeleme : Form
    {
        dbN11EntityDatabaseEntities db = new dbN11EntityDatabaseEntities();

        string StartDate = "01/01/2023";
        string EndDate = "31/12/2023";

        public SiparisListeleme()
        {
            InitializeComponent();
        }
        private void SiparisListeleme_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            DateTime simdi = DateTime.Now;
            lbTarih.Text = simdi.ToString("dd'/'MM'/'yyyy");

            cmbSiparisDurum.DataSource = null;

            string[] siparisdurum = { "New", "Approved", "Rejected", "Shipped", "Delivered", "Completed", "Claimed", "LATE_SHIPMENT" };

            cmbSiparisDurum.Items.Add(siparisdurum[0]);
            cmbSiparisDurum.Items.Add(siparisdurum[1]);
            cmbSiparisDurum.Items.Add(siparisdurum[2]);
            cmbSiparisDurum.Items.Add(siparisdurum[3]);
            cmbSiparisDurum.Items.Add(siparisdurum[4]);
            cmbSiparisDurum.Items.Add(siparisdurum[5]);
            cmbSiparisDurum.Items.Add(siparisdurum[6]);
            cmbSiparisDurum.Items.Add(siparisdurum[7]);


            
           
        }
        public void TumSiparisleriGetir()
        {



            string apiKey = "";
            string apiSecret = "";


            string OrderStatus = "";
            string Recipient = "";
            string BuyerName = "";
            string OrderNumber = "";
            string ProductSellerCode = "";
            string ProductName = "";

            string UrunId = tbArama.Text;
            int productIdValue = 0;
            bool tryParse = Int32.TryParse(UrunId, out productIdValue);

            int currentPageValue = 0;
            int pageSizeValue = 0;

            N11OrderService.Authentication authentication = new N11OrderService.Authentication();
            authentication.appKey = apiKey;
            authentication.appSecret = apiSecret;

            OrderSearchPeriod orderSearchPeriod = new OrderSearchPeriod();
            orderSearchPeriod.startDate = StartDate;
            orderSearchPeriod.endDate = EndDate;


            if (!string.IsNullOrEmpty(cmbSiparisDurum.Text))
            {
                OrderStatus = cmbSiparisDurum.Text;
            }

            //if (!string.IsNullOrEmpty(tbAliciAdi.Text))
            //{
            //    BuyerName = tbAliciAdi.Text;

            //}
            //if (!string.IsNullOrEmpty(tbTeslimAlanınAdı.Text))
            //{
            //    Recipient = tbTeslimAlanınAdı.Text;

            //}
            //if (!string.IsNullOrEmpty(tbSiparisNo.Text))
            //{
            //    OrderNumber = tbSiparisNo.Text;

            //}
            //if (!string.IsNullOrEmpty(tbUrunMagazaKodu.Text))
            //{
            //    ProductSellerCode = tbUrunMagazaKodu.Text;

            //}
            //if (!string.IsNullOrEmpty(tbUrunID.Text))
            //{
            //    UrunId = tbUrunID.Text;
            //}



            if (cmbSiparisArama.Text == "Ürün Mağaza Kodu")
            {
                ProductSellerCode = tbArama.Text;
            }

            if (cmbSiparisArama.Text == "Alıcının Adı")
            {
                BuyerName = tbArama.Text;
            }

            if (cmbSiparisArama.Text == "Teslim Alanın Adı")
            {
                Recipient = tbArama.Text;
            }

            if (cmbSiparisArama.Text == "Sipariş Numarası")
            {
                OrderNumber = tbArama.Text;
            }

            if (cmbSiparisArama.Text == "Ürün Id")
            {
                UrunId = tbArama.Text;
            }

          






            OrderDataListRequest orderDataListRequest = new OrderDataListRequest();
            orderDataListRequest.productSellerCode = ProductSellerCode;
            orderDataListRequest.recipient = Recipient;
            orderDataListRequest.period = orderSearchPeriod;
            orderDataListRequest.buyerName = BuyerName;
            orderDataListRequest.productId = productIdValue;
            orderDataListRequest.orderNumber = OrderNumber;
            orderDataListRequest.status = OrderStatus;
            

            N11OrderService.RequestPagingData pagingData = new N11OrderService.RequestPagingData();
            pagingData.currentPage = currentPageValue;
            pagingData.pageSize = pageSizeValue;

            OrderListRequest request = new OrderListRequest();
            request.auth = authentication;
            request.pagingData = pagingData;
            request.searchData = orderDataListRequest;

            OrderServicePortService service = new OrderServicePortService();

            OrderListResponse response = service.OrderList(request);

            List<OrderData> OrderDataList = response.orderList.ToList();

            lblTumSiparisler.Text = OrderDataList.Count.ToString();

            if (response.result.status == "success")
            {
                if (response.orderList != null && response.orderList.Count() > 0)
                {
                    foreach (OrderData sampleOrder in OrderDataList)
                    {
                        dgvSiparisler.DataSource = (from siparisler in OrderDataList
                                                    select new
                                                    {

                                                        
                                                        
                                                        SiparişId = siparisler.id,
                                                        SiparişNo = siparisler.orderNumber,
                                                        OluşturmaTarihi = siparisler.createDate,
                                                        TC = siparisler.citizenshipId,

                                                        ÖdemeYöntemi =
                                                        (
                                                        siparisler.paymentType != null && siparisler.paymentType == "1" ? "Kredi Kartı" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "2" ? "BKMEXPRESS" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "3" ? "AKBANKDIREKT" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "4" ? "PAYPAL" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "5" ? "GARANTIPAY" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "6" ? "GarantiLoan" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "7" ? "MasterPass" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "8" ? "ISBANKPAY" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "9" ? "PAYCELL" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "10" ? "COMPAY" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "11" ? "YKBPAY" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "12" ? "FIBABANK" :
                                                        siparisler.paymentType != null && siparisler.paymentType == "13" ? "Other" : "Tanımsız"
                                                        ),
                                                        SiparisDurum =
                                                        (




                                                        orderDataListRequest.status != null && orderDataListRequest.status == "New" ? "Yeni Sipariş" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "Approved" ? "Onaylanmış Sipariş" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "Rejected" ? "İptal Edilmiş Sipariş" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "Shipped" ? "Kargolanmış Sipariş" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "Delivered" ? "Teslim Edilen Sipariş" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "Completed" ? "Tamamlanmış Sipariş" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "Claimed" ? "İptal/İade/Değişim Durumundaki Siparişler" :
                                                        orderDataListRequest.status != null && orderDataListRequest.status == "LATE_SHIPMENT" ? "Kargolanması Geciken Sipariş" : "Tanımsız"
                                                        ),

                                                    }
                                                    ).ToArray();

                    }

                }
                else
                {
                    MessageBox.Show("Sipariş Bulunamadı");
                }
            }
            else
            {
                MessageBox.Show(response.result.errorMessage);
            }


        }
        public void SiparisDetayiniGetir(int id)
        {

            dgvDetayUrun.DataSource = null;

            lbAliciAdi.Text = null;
            lbAliciAdres.Text = null;
            lbAliciFirmaAdi.Text = null;
            lbAliciFirmaAdres.Text = null;
            lbAliciGSM.Text = null;
            lbAliciSemt.Text = null;
            lbAliciTC.Text = null;
            lbAliciTeslim.Text = null;
            lbAliciVergi.Text = null;
            lbAliciSehir.Text = null;
            lbKargoTarih.Text = null;
            lbKargoAdi.Text = null;
            lbKargoTakipNo.Text = null;




            string apiKey = "";
            string apiSecret = "";

            long orderIdValue = 316899886;

            N11OrderService.Authentication authentication = new N11OrderService.Authentication();
            authentication.appKey = apiKey;
            authentication.appSecret = apiSecret;

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
               
                lbAliciAdi.Text = orderDetail.buyer.fullName;
                lbAliciAdres.Text = orderDetail.shippingAddress.address;
                lbAliciFirmaAdi.Text = orderDetail.buyer.taxOffice;
                lbAliciFirmaAdres.Text = orderDetail.billingAddress.fullName;
                lbAliciGSM.Text = orderDetail.shippingAddress.gsm;
                lbAliciSemt.Text = orderDetail.shippingAddress.district;
                lbAliciTC.Text = orderDetail.buyer.tcId;
                lbAliciTeslim.Text = orderDetail.shippingAddress.fullName;
                lbAliciVergi.Text = orderDetail.buyer.taxId;
                lbAliciSehir.Text = orderDetail.shippingAddress.city;


                lbitemid.Text = sampleItem.id.ToString();
                //lbSCompanyid.Text = sampleItem.shipmentInfo.shipmentCompany.id.ToString();
                //lbSMethod.Text= sampleItem.shipmentInfo.shipmentMethod.ToString(); 
                //lbCampaing.Text=sampleItem.shipmentInfo.campaignNumber.ToString();
                //lbtracking.Text=sampleItem.shipmentInfo.trackingNumber.ToString();


                
                lbKargoAdi.Text = sampleItem.shipmentInfo.shipmentCompany.name;
                lbKargoTakipNo.Text = sampleItem.shipmentInfo.trackingNumber;
                lbKargoTarih.Text = sampleItem.shippingDate;

                dgvDetayUrun.DataSource = (from urunbilgi in orderItemList
                                           select new
                                           {

                                               Adı = urunbilgi.productName,
                                               Fiyatı = urunbilgi.price,
                                               ÜrünId = urunbilgi.productId,
                                               SatıcıStokKodu = urunbilgi.sellerStockCode,
                                               Adet = urunbilgi.quantity,
                                               

                                           }
                                              ).ToArray();
            }
        }
        private void UrunImage()
        {
            string apiKey = "";
            string apiSecret = "";

            string dgvProductId = lbImgProductId.Text;
            int productIdValue = 0;
            bool tryParse = Int32.TryParse(dgvProductId, out productIdValue);
            


            N11ProductService.Authentication productauth = new N11ProductService.Authentication();
            productauth.appKey = apiKey;
            productauth.appSecret = apiSecret;

            GetProductByProductIdRequest productrequest = new GetProductByProductIdRequest();
            productrequest.auth = productauth;
            productrequest.productId = productIdValue;

            N11ProductService.ProductServicePortService productport = new N11ProductService.ProductServicePortService();

            GetProductByProductIdResponse productresponse = productport.GetProductByProductId(productrequest);

            Product sampleProduct = productresponse.product;


            tbImgUrl.Text = sampleProduct.images[0].url;


            WebRequest urlrequest = WebRequest.Create(tbImgUrl.Text);

            using (var urlresponse = urlrequest.GetResponse())
            {
                using (var str = urlresponse.GetResponseStream())
                {
                    pbProductImg.Image = Bitmap.FromStream(str);
                }
            }



        }

        //        private void Detay(int id)
        //        {

        //            var url = "https://api.n11.com/ws/OrderService.wsdl";
        //            var client = new RestClient(url);
        //            long orderid = id;


        //            var request = new RestRequest();
        //            request.Timeout = -1;
        //            request.Method = Method.Post;
        //            request.AddHeader("Content-Type", "text/xml");
        //            request.AddHeader("Cookie", "e2f9affc532f36c6aec1c8bd433e2a59=dce7a9f6f217939d449167a06506a34f");
        //            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.n11.com/ws/schemas"">
        //" + "\n" +
        //            @"   <soapenv:Header/>
        //" + "\n" +
        //            @"   <soapenv:Body>
        //" + "\n" +
        //            @"      <sch:OrderDetailRequest>
        //" + "\n" +
        //            @"         <auth>
        //" + "\n" +
        //            @"            <appKey>fbbcbfb5-0122-4e64-b66d-1dd5a26366fa</appKey>
        //" + "\n" +
        //            @"            <appSecret>olYhqNMLzQcVkd5I</appSecret>
        //" + "\n" +
        //            @"         </auth>
        //" + "\n" +
        //            @"         <orderRequest>
        //" + "\n" +
        //            @"            <id>" + orderid + @"</id>
        //" + "\n" +
        //            @"         </orderRequest>
        //" + "\n" +
        //            @"      </sch:OrderDetailRequest>
        //" + "\n" +
        //            @"   </soapenv:Body>
        //" + "\n" +
        //            @"</soapenv:Envelope>
        //" + "\n" +
        //            @"";

        //            request.RequestFormat = DataFormat.Xml;
        //            //var XmlSerializer = new RestSharp.Serializers.Xml.DotNetXmlSerializer();
        //            request.AddParameter("text/xml", /*XmlSerializer.Serialize(body)*/ body, ParameterType.RequestBody);



        //            var response = client.Execute(request) ;


        //            MessageBox.Show(response.Content);



        //        }

        private void Onayla()
        {


            var url = "https://api.n11.com/ws/OrderService.wsdl";

            var client = new RestClient(url);

            string orderid = lbitemid.Text;
           
            var request = new RestRequest();
            request.Timeout = -1;
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "text/xml");
            request.AddHeader("Cookie", "e2f9affc532f36c6aec1c8bd433e2a59=461ed866871abe0888a638103517e7a9");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.n11.com/ws/schemas"">
" + "\n" +
            @"   <soapenv:Header/>
" + "\n" +
            @"   <soapenv:Body>
" + "\n" +
            @"      <sch:OrderItemAcceptRequest>
" + "\n" +
            @"         <auth>
" + "\n" +
            @"            <appKey>fbbcbfb5-0122-4e64-b66d-1dd5a26366fa</appKey>
" + "\n" +
            @"            <appSecret>olYhqNMLzQcVkd5I</appSecret>
" + "\n" +
            @"         </auth>
" + "\n" +
            @"         <orderItemList>
" + "\n" +
            @"            <orderItem>
" + "\n" +
            @"               <id>" + orderid + @"</id>
" + "\n" +
            @"            </orderItem>
" + "\n" +
            @"         </orderItemList>
" + "\n" +
            @"	<numberOfPackages>1</numberOfPackages>
" + "\n" +
            @"      </sch:OrderItemAcceptRequest>
" + "\n" +
            @"   </soapenv:Body>
" + "\n" +
            @"</soapenv:Envelope>
" + "\n" +
            @"";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            var response = client.Execute(request);



            MessageBox.Show(response.Content);


        }


        private void Reddet()
        {
            var url = "https://api.n11.com/ws/OrderService.wsdl";

            var client = new RestClient(url);
            

            string orderid = lbitemid.Text;

            var request = new RestRequest();
            request.Timeout = -1;
            request.Method = Method.Post;
            
            request.AddHeader("Content-Type", "text/xml");
            request.AddHeader("Cookie", "e2f9affc532f36c6aec1c8bd433e2a59=9bc9b1479156c60c013ad7e66f995452");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.n11.com/ws/schemas"">
" + "\n" +
            @"   <soapenv:Header/>
" + "\n" +
            @"   <soapenv:Body>
" + "\n" +
            @"      <sch:OrderItemRejectRequest>
" + "\n" +
            @"         <auth>
" + "\n" +
            @"            <appKey>fbbcbfb5-0122-4e64-b66d-1dd5a26366fa</appKey>
" + "\n" +
            @"            <appSecret>olYhqNMLzQcVkd5I</appSecret>
" + "\n" +
            @"         </auth>
" + "\n" +
            @"         <orderItemList>
" + "\n" +
            @"            <!--1 or more repetitions:-->
" + "\n" +
            @"            <orderItem>
" + "\n" +
            @"               <id>" + orderid + @"</id>
" + "\n" +
            @"            </orderItem>
" + "\n" +
            @"         </orderItemList>
" + "\n" +
            @"         <rejectReason>Ürün stoklarımızda bulunmamaktadır.</rejectReason>
" + "\n" +
            @"         <rejectReasonType>OUT_OF_STOCK</rejectReasonType>
" + "\n" +
            @"      </sch:OrderItemRejectRequest>
" + "\n" +
            @"   </soapenv:Body>
" + "\n" +
            @"</soapenv:Envelope>
" + "\n" +
            @"";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            MessageBox.Show(response.Content);
        }


        private void Kargola()
        {
            var url = "https://api.n11.com/ws/OrderService.wsdl";

            var client = new RestClient(url);


            string itemid = lbitemid.Text;
            string shipmentcompanyid = lbSCompanyid.Text;
            string campaingnumber = lbCampaing.Text;
            string trackingnumber = lbtracking.Text;
            string shipmentmethod = lbSMethod.Text;

            var request = new RestRequest();
            request.Timeout = -1;
            request.Method = Method.Post;

            request.AddHeader("Content-Type", "text/xml");
            request.AddHeader("Cookie", "e2f9affc532f36c6aec1c8bd433e2a59=9bc9b1479156c60c013ad7e66f995452");
            var body = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.n11.com/ws/schemas"">
" + "\n" +
            @"   <soapenv:Header/>
" + "\n" +
            @"   <soapenv:Body>
" + "\n" +
            @"      <sch:MakeOrderItemShipmentRequest>
" + "\n" +
            @"         <auth>
" + "\n" +
            @"            <appKey>fbbcbfb5-0122-4e64-b66d-1dd5a26366fa</appKey>
" + "\n" +
            @"            <appSecret>olYhqNMLzQcVkd5I</appSecret>
" + "\n" +
            @"         </auth>
" + "\n" +
            @"         <orderItemList>
" + "\n" +
            @"            <!--1 or more repetitions:-->
" + "\n" +
            @"            <orderItem>
" + "\n" +
            @"               <id>" + itemid + @"</id>
" + "\n" +
            @"               <shipmentInfo>
" + "\n" +
            @"                  <shipmentCompany>
" + "\n" +
            @"                     <id>" + shipmentcompanyid + @"</id>
" + "\n" +
            @"                  </shipmentCompany>
" + "\n" +
            @"                  <campaignNumber>" + campaingnumber + @"</campaignNumber>
" + "\n" +
            @"                  <trackingNumber>" + trackingnumber + @"</trackingNumber>
" + "\n" +
            @"                  <shipmentMethod>" + shipmentmethod + @"</shipmentMethod>
" + "\n" +
            @"               </shipmentInfo>
" + "\n" +
            @"            </orderItem>
" + "\n" +
            @"         </orderItemList>
" + "\n" +
            @"      </sch:MakeOrderItemShipmentRequest>
" + "\n" +
            @"   </soapenv:Body>
" + "\n" +
            @"</soapenv:Envelope>
" + "\n" +
            @"
" + "\n" +
            @"";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            MessageBox.Show(response.Content);
        }

        private void btnSiparisFiltrele_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Checked == true)
            {
                StartDate = dtpStartDate.Text;
            }
            else
            {
                StartDate = null;
            }
            if (dtpEndDate.Checked == true)
            {
                EndDate = dtpEndDate.Text;
            }
            else
            {
                EndDate = null;
            }
        }
        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            dgvSiparisler.DataSource = null;
            //dgvSiparisler.Columns.Clear();
            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            //checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvSiparisler.Columns.Insert(0, checkBoxColumn);

            TumSiparisleriGetir();
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            string apiKey = "";
            string apiSecret = "";


            string OrderStatus = "";
            string Recipient = "";
            string BuyerName = "";
            string OrderNumber = "";
            string ProductSellerCode = "";
            string ProductName = "";

            ////string UrunId = tbUrunID.Text;
            //int productIdValue = 0;
            //bool tryParse = Int32.TryParse(UrunId, out productIdValue);

            int currentPageValue = 0;
            int pageSizeValue = 0;

            N11OrderService.Authentication authentication = new N11OrderService.Authentication();
            authentication.appKey = apiKey;
            authentication.appSecret = apiSecret;

            OrderSearchPeriod orderSearchPeriod = new OrderSearchPeriod();
            orderSearchPeriod.startDate = StartDate;
            orderSearchPeriod.endDate = EndDate;

            //if (!string.IsNullOrEmpty(cmbSiparisDurum.Text))
            //{
            //    OrderStatus = cmbSiparisDurum.Text;
            //}
            //if (!string.IsNullOrEmpty(tbAliciAdi.Text))
            //{
            //    BuyerName = tbAliciAdi.Text;
            //}
            //if (!string.IsNullOrEmpty(tbTeslimAlanınAdı.Text))
            //{
            //    Recipient = tbTeslimAlanınAdı.Text;
            //}
            //if (!string.IsNullOrEmpty(tbSiparisNo.Text))
            //{
            //    OrderNumber = tbSiparisNo.Text;
            //}
            //if (!string.IsNullOrEmpty(tbUrunMagazaKodu.Text))
            //{
            //    ProductSellerCode = tbUrunMagazaKodu.Text;
            //}
            //if (!string.IsNullOrEmpty(tbUrunID.Text))
            //{
            //    UrunId = tbUrunID.Text;
            //}


            OrderDataListRequest orderDataListRequest = new OrderDataListRequest();
            orderDataListRequest.productSellerCode = ProductSellerCode;
            orderDataListRequest.recipient = Recipient;
            orderDataListRequest.period = orderSearchPeriod;
            orderDataListRequest.buyerName = BuyerName;
            //orderDataListRequest.productId = productIdValue;
            orderDataListRequest.orderNumber = OrderNumber;
            orderDataListRequest.status = OrderStatus;

            N11OrderService.RequestPagingData pagingData = new N11OrderService.RequestPagingData();
            pagingData.currentPage = currentPageValue;
            pagingData.pageSize = pageSizeValue;

            OrderListRequest request = new OrderListRequest();
            request.auth = authentication;
            request.pagingData = pagingData;
            request.searchData = orderDataListRequest;

            OrderServicePortService service = new OrderServicePortService();

            OrderListResponse response = service.OrderList(request);

            List<OrderData> OrderDataList = response.orderList.ToList();



            if (response.result.status == "success")
            {
                if (response.orderList != null && response.orderList.Count() > 0)
                {


                    foreach (OrderData sampleOrder in OrderDataList)
                    {



                        tblOrderList dbOrderList = new tblOrderList();
                        dbOrderList.SiparisID = sampleOrder.id.ToString();
                        db.tblOrderList.Add(dbOrderList);
                        db.SaveChanges();

                    }
                    MessageBox.Show("Aktarma başarılı.");
                }
                else
                {
                    MessageBox.Show("Sipariş Bulunamadı");
                }
            }
            else
            {
                MessageBox.Show(response.result.errorMessage);
            }

        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSiparisler.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value == true)
                    {
                        Onayla();
                    }
                }
            }
        }

        private void dgvSiparisler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSiparisler.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvSiparisler.CurrentRow.Selected = true;
                //Detay(Convert.ToInt32(dgvSiparisler.Rows[e.RowIndex].Cells[1].FormattedValue.ToString()));
                SiparisDetayiniGetir(Convert.ToInt32(dgvSiparisler.Rows[e.RowIndex].Cells[1].FormattedValue.ToString()));
            }
            lbImgProductId.Text = dgvDetayUrun.CurrentRow.Cells[2].Value.ToString();
            UrunImage();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSiparisler.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value == true)
                    {
                        Reddet();
                    }
                }
            }
        }

        private void btnKargo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSiparisler.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value == true)
                    {  
                        Kargola();
                    }
                }
            }
        }
    }
}
