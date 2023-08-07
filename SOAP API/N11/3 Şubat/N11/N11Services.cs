using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HALL.N11ProductService;

namespace HALL
{
    public class N11Services
    {

        public Tuple<string, int, ProductBasic[]> N11ArananUrunGetir(string name, string mpn, string gtin, string durum, bool? bundle, int sayfaNo, int pageSize)
        {
            string hata = "";
            int gelenN11UrunAdet = 0;
            ProductBasic[] gelenN11Urunler = null;
            Tuple<string, int, ProductBasic[]> sonuc = null;

            if (sayfaNo > 0)
            {
                sayfaNo = sayfaNo - 1;
                try
                {
                    string apiKey = "";
                    string apiSecret = "";


                    ProductSearch ara = new ProductSearch();
                    ara.name = name;
                    ara.mpn = mpn;
                    ara.gtin = gtin;
                    ara.bundle = bundle;

                    if (durum == "1")//Aktif
                    {
                        ara.approvalStatus = ProductStatus.Active;
                    }
                    if (durum == "2")//Askıya alındı
                    {
                        ara.approvalStatus = ProductStatus.Suspended;
                    }
                    if (durum == "3")//Yasaklı
                    {
                        ara.approvalStatus = ProductStatus.Prohibited;
                    }

                    RequestPagingData pagingData = new RequestPagingData();
                    pagingData.currentPage = sayfaNo;
                    pagingData.pageSize = pageSize;

                    Authentication authentication = new Authentication();
                    authentication.appKey = apiKey;
                    authentication.appSecret = apiSecret;

                    var request = new SearchProductsRequest();
                    request.auth = authentication;
                    request.pagingData = pagingData;
                    request.productSearch = ara;


                    var service = new ProductServicePortService();
                    SearchProductsResponse response = service.SearchProducts(request);

                    if (response.result.status == "success")
                    {
                        if (response.products != null)
                        {
                            gelenN11Urunler = response.products;

                        }
                        if (response.pagingData != null && response.pagingData.totalCount != null)
                        {
                            gelenN11UrunAdet = Convert.ToInt32(response.pagingData.totalCount);
                        }

                        sonuc = Tuple.Create(hata, gelenN11UrunAdet, gelenN11Urunler);

                    }
                    else
                    {
                        hata = response.result.errorMessage;
                        sonuc = Tuple.Create(hata, gelenN11UrunAdet, gelenN11Urunler);
                    }

                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                    sonuc = Tuple.Create(hata, gelenN11UrunAdet, gelenN11Urunler);
                }
            }
            return sonuc;
        }

        public Tuple<string, int, ProductBasic[]> N11TumUrunleriGetir(int sayfaNo, int pageSize)
        {
            string hata = "";
            int gelenN11UrunAdet = 0;
            ProductBasic[] gelenN11Urunler = null;
            Tuple<string, int, ProductBasic[]> sonuc = null;

            if (sayfaNo > 0)
            {
                sayfaNo = sayfaNo - 1;
                try
                {
                    string apiKey = "";
                    string apiSecret = "";


                    ProductSearch ara = new ProductSearch();

                    RequestPagingData pagingData = new RequestPagingData();
                    pagingData.currentPage = sayfaNo;
                    pagingData.pageSize = pageSize;

                    Authentication aut = new Authentication();
                    aut.appKey = apiKey;
                    aut.appSecret = apiSecret;

                    var req = new SearchProductsRequest();
                    req.auth = aut;
                    req.pagingData = pagingData;
                    req.productSearch = ara;


                    var port = new ProductServicePortService();
                    SearchProductsResponse response = port.SearchProducts(req);

                    if (response.result.status == "succes")
                    {
                        if (response.products != null)
                        {
                            gelenN11Urunler = response.products;

                        }
                        if (response.pagingData != null && response.pagingData.totalCount != null)
                        {
                            gelenN11UrunAdet = Convert.ToInt32(response.pagingData.totalCount);
                        }

                        sonuc = Tuple.Create(hata, gelenN11UrunAdet, gelenN11Urunler);

                    }
                    else
                    {
                        hata = response.result.errorMessage;
                        sonuc = Tuple.Create(hata, gelenN11UrunAdet, gelenN11Urunler);
                    }

                }
                catch (Exception ex)
                {
                    hata = ex.Message;
                    sonuc = Tuple.Create(hata, gelenN11UrunAdet, gelenN11Urunler);
                }
            }
            return sonuc;
        }
    }
}

