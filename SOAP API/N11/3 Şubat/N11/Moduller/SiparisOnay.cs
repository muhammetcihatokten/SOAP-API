
using HALL.N11OrderService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALL.Moduller
{
    public partial class SiparisOnay : Form
    {
        public SiparisOnay()
        {
            InitializeComponent();
        }

        private void SiparisOnay_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Siparislerr()
        {


            string apiKey = "fbbcbfb5-0122-4e64-b66d-1dd5a26366fa";
            string apiSecret = "olYhqNMLzQcVkd5I";

            string StartDate = "03/01/2023";
            string EndDate = "01/02/2023";


            string OrderStatus = "";
            string Recipient = "";
            string BuyerName = "";
            string OrderNumber = "";
            string ProductSellerCode = "";
            string ProductName = "";


            long productIdValue = 0;

            int currentPageValue = 0;
            int pageSizeValue = 0;

            N11OrderService.Authentication authentication = new N11OrderService.Authentication();
            authentication.appKey = apiKey;
            authentication.appSecret = apiSecret;

            OrderSearchPeriod orderSearchPeriod = new OrderSearchPeriod();
            orderSearchPeriod.startDate = StartDate;
            orderSearchPeriod.endDate = EndDate;

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



            if (response.result.status == "success")
            {
                if (response.orderList != null && response.orderList.Count() > 0)
                {
                    foreach (OrderData sampleOrder in OrderDataList)
                    {


                        dataGridView1.DataSource = (from siparisler in OrderDataList
                                                    select new
                                                    {
                                                        SiparişId = siparisler.id,
                                                        SiparşNumarası = siparisler.orderNumber,
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
                                                        siparisler.status != null && siparisler.status == "1" ? "Yeni siparişler" :
                                                        siparisler.status != null && siparisler.status == "2" ? "Onaylanmış Siparişler" :
                                                        siparisler.status != null && siparisler.status == "3" ? "İptal Edilmiş Siparişler" :
                                                        siparisler.status != null && siparisler.status == "4" ? "Kargolanmış Siparişler" :
                                                        siparisler.status != null && siparisler.status == "5" ? "Teslim Edilen Siparişler" :
                                                        siparisler.status != null && siparisler.status == "6" ? "Tamamlanmış Siparişler" :
                                                        siparisler.status != null && siparisler.status == "7" ? "İptal/İade/Değişim Durumundaki Siparişler" :
                                                        siparisler.status != null && siparisler.status == "8" ? "Kargolanması Geciken Siparişler" : "Tanımsız"
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
        private void Detaylandir(int id)
        {

            string apiKey = "fbbcbfb5-0122-4e64-b66d-1dd5a26366fa";
            string apiSecret = "olYhqNMLzQcVkd5I";

            long orderIdValue = 113975650;

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
            dataGridView2.Rows.Clear();

            foreach (OrderSearchData sampleItem in orderItemList)
            {
                dataGridView2.DataSource = (from sd in orderItemList
                                            select new
                                            {
                                                KampanyaKodu = sd.shipmentInfo.campaignNumber,
                                                AlıcıAdı = orderDetail.buyer.fullName,
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
                                                SiparişNumarası = orderDetail.orderNumber,
                                                KargoFirması = sd.shipmentInfo.shipmentCompany.name,
                                                ÖdemeTipi =
                                               (
                                               sd.deliveryFeeType != null && sd.deliveryFeeType == "1" ? "N11 Öder" :
                                               sd.deliveryFeeType != null && sd.deliveryFeeType == "2" ? "Alıcı Öder" :
                                               sd.deliveryFeeType != null && sd.deliveryFeeType == "3" ? "Mağaza  Öder" :
                                               sd.deliveryFeeType != null && sd.deliveryFeeType == "4" ? "Şartlı Kargo (Alıcı Öder)" :
                                               sd.deliveryFeeType != null && sd.deliveryFeeType == "5" ? "Şartlı Kargo Ücretsiz (Satıcı Öder)" : "Tanımsız"

                                               ),
                                            }).ToArray();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Detaylandir(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()));
            }
        }



        private void Onayla()
        {
            //string apiKey = "fbbcbfb5-0122-4e64-b66d-1dd5a26366fa";
            //string apiSecret = "olYhqNMLzQcVkd5I";
                        
            //var orderItemIdVal = 204713967918;

            //string data = "";


            //Authentication authentication = new Authentication();
            //authentication.appSecret = apiSecret;
            //authentication.appKey= apiKey;

            //OrderItemDataRequest orderItemDataRequest = new OrderItemDataRequest();
            //orderItemDataRequest.id = orderItemIdVal;
            //orderItemDataRequest.NumberOfPackages = 1;

            ////OrderItemIdentityDataRequest order = new OrderItemIdentityDataRequest();
            ////oro        

            ////OrderItemAcceptRequest request = new OrderItemAcceptRequest();
            ////request.auth = authentication;
            ////request.orderItemList = order;





            ////OrderServicePortService service= new OrderServicePortService();

            ////OrderItemAcceptResponse response = service.orderItemAccept(request);

            //List <OrderItemData> İtemDataList  = response.orderItemList.ToList();




        }


        private void Reddet()
        {
            string apiKey = "fbbcbfb5-0122-4e64-b66d-1dd5a26366fa";
            string apiSecret = "olYhqNMLzQcVkd5I";
            string RejectReason = "Ürün stoklarımızda bulunmamaktadır.";
            string RejReasonType = "OUT_OF_STOCK";

            long orderItemIdVal = 132312;

            Authentication authentication = new Authentication();
            authentication.appSecret = apiSecret;
            authentication.appKey = apiKey;

            OrderItemDataRequest orderItemDataRequest = new OrderItemDataRequest();
            orderItemDataRequest.id = orderItemIdVal;

            OrderItemRejectRequest request = new OrderItemRejectRequest();
            request.auth = authentication;
            request.orderItemList.ToList().Add(orderItemDataRequest);
            request.rejectReason= RejectReason;
            request.rejectReasonType= RejReasonType;

            OrderServicePortService service = new OrderServicePortService();

            OrderItemRejectResponse response = service.OrderItemReject(request);

            List<OrderItemData> orderItemDataList = response.orderItemList.ToList();

        }

        private void Kargola()
        {
            string apiKey = "fbbcbfb5-0122-4e64-b66d-1dd5a26366fa";
            string apiSecret = "olYhqNMLzQcVkd5I";
            string CampaignNumber = "466805582805015";
            string TrackingNumber = "123";
            long orderItemIdVal = 18675505;
            int shipmentCompanyIdVal = 341;
            int shipmentMethodValue = 1;

            Authentication authentication = new Authentication();
            authentication.appSecret = apiSecret;
            authentication.appKey = apiKey;

            ShipmentCompanyRequest shipmentCompanyRequest= new ShipmentCompanyRequest();
            shipmentCompanyRequest.id = shipmentCompanyIdVal;


            MakeShipmentInfoRequest makeShipmentInfoRequest = new MakeShipmentInfoRequest();
            makeShipmentInfoRequest.campaignNumber= CampaignNumber;
            makeShipmentInfoRequest.trackingNumber= TrackingNumber;
            makeShipmentInfoRequest.shipmentMethod = shipmentMethodValue.ToString();
            makeShipmentInfoRequest.shipmentCompany = shipmentCompanyRequest;

            OrderItemShipmentRequest orderItemShipmentRequest = new OrderItemShipmentRequest();
            orderItemShipmentRequest.id = orderItemIdVal;
            orderItemShipmentRequest.shipmentInfo = makeShipmentInfoRequest;

            MakeOrderItemShipmentRequest request = new MakeOrderItemShipmentRequest();
            request.auth= authentication;
            request.orderItemList.ToList().Add(orderItemShipmentRequest);

            OrderServicePortService service= new OrderServicePortService();

            MakeOrderItemShipmentResponse response = service.MakeOrderItemShipment(request);

            MessageBox.Show(response.result.status.Length.ToString());


        }





        private void button1_Click(object sender, EventArgs e)
        {
            Onayla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reddet();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kargola();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Siparislerr();
        }
    }
}
