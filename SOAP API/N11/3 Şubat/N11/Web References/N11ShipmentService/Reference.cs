﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Kaynak kodu Microsoft.VSDesigner tarafından otomatik üretilmiş , Sürüm 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace HALL.N11ShipmentService {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Collections.Generic;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ShipmentServicePortSoap11", Namespace="http://www.n11.com/ws/schemas")]
    public partial class ShipmentServicePortService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetShipmentTemplateListOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetShipmentTemplateOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateOrUpdateShipmentTemplateOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ShipmentServicePortService() {
            this.Url = global::HALL.Properties.Settings.Default.HALL_N11ShipmentService_ShipmentServicePortService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetShipmentTemplateListCompletedEventHandler GetShipmentTemplateListCompleted;
        
        /// <remarks/>
        public event GetShipmentTemplateCompletedEventHandler GetShipmentTemplateCompleted;
        
        /// <remarks/>
        public event CreateOrUpdateShipmentTemplateCompletedEventHandler CreateOrUpdateShipmentTemplateCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetShipmentTemplateListResponse", Namespace="http://www.n11.com/ws/schemas")]
        public GetShipmentTemplateListResponse GetShipmentTemplateList([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.n11.com/ws/schemas")] GetShipmentTemplateListRequest GetShipmentTemplateListRequest) {
            object[] results = this.Invoke("GetShipmentTemplateList", new object[] {
                        GetShipmentTemplateListRequest});
            return ((GetShipmentTemplateListResponse)(results[0]));
        }
        
        /// <remarks/>
        public void GetShipmentTemplateListAsync(GetShipmentTemplateListRequest GetShipmentTemplateListRequest) {
            this.GetShipmentTemplateListAsync(GetShipmentTemplateListRequest, null);
        }
        
        /// <remarks/>
        public void GetShipmentTemplateListAsync(GetShipmentTemplateListRequest GetShipmentTemplateListRequest, object userState) {
            if ((this.GetShipmentTemplateListOperationCompleted == null)) {
                this.GetShipmentTemplateListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetShipmentTemplateListOperationCompleted);
            }
            this.InvokeAsync("GetShipmentTemplateList", new object[] {
                        GetShipmentTemplateListRequest}, this.GetShipmentTemplateListOperationCompleted, userState);
        }
        
        private void OnGetShipmentTemplateListOperationCompleted(object arg) {
            if ((this.GetShipmentTemplateListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetShipmentTemplateListCompleted(this, new GetShipmentTemplateListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetShipmentTemplateResponse", Namespace="http://www.n11.com/ws/schemas")]
        public GetShipmentTemplateResponse GetShipmentTemplate([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.n11.com/ws/schemas")] GetShipmentTemplateRequest GetShipmentTemplateRequest) {
            object[] results = this.Invoke("GetShipmentTemplate", new object[] {
                        GetShipmentTemplateRequest});
            return ((GetShipmentTemplateResponse)(results[0]));
        }
        
        /// <remarks/>
        public void GetShipmentTemplateAsync(GetShipmentTemplateRequest GetShipmentTemplateRequest) {
            this.GetShipmentTemplateAsync(GetShipmentTemplateRequest, null);
        }
        
        /// <remarks/>
        public void GetShipmentTemplateAsync(GetShipmentTemplateRequest GetShipmentTemplateRequest, object userState) {
            if ((this.GetShipmentTemplateOperationCompleted == null)) {
                this.GetShipmentTemplateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetShipmentTemplateOperationCompleted);
            }
            this.InvokeAsync("GetShipmentTemplate", new object[] {
                        GetShipmentTemplateRequest}, this.GetShipmentTemplateOperationCompleted, userState);
        }
        
        private void OnGetShipmentTemplateOperationCompleted(object arg) {
            if ((this.GetShipmentTemplateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetShipmentTemplateCompleted(this, new GetShipmentTemplateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("CreateOrUpdateShipmentTemplateResponse", Namespace="http://www.n11.com/ws/schemas")]
        public CreateOrUpdateShipmentTemplateResponse CreateOrUpdateShipmentTemplate([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.n11.com/ws/schemas")] CreateOrUpdateShipmentTemplateRequest CreateOrUpdateShipmentTemplateRequest) {
            object[] results = this.Invoke("CreateOrUpdateShipmentTemplate", new object[] {
                        CreateOrUpdateShipmentTemplateRequest});
            return ((CreateOrUpdateShipmentTemplateResponse)(results[0]));
        }
        
        /// <remarks/>
        public void CreateOrUpdateShipmentTemplateAsync(CreateOrUpdateShipmentTemplateRequest CreateOrUpdateShipmentTemplateRequest) {
            this.CreateOrUpdateShipmentTemplateAsync(CreateOrUpdateShipmentTemplateRequest, null);
        }
        
        /// <remarks/>
        public void CreateOrUpdateShipmentTemplateAsync(CreateOrUpdateShipmentTemplateRequest CreateOrUpdateShipmentTemplateRequest, object userState) {
            if ((this.CreateOrUpdateShipmentTemplateOperationCompleted == null)) {
                this.CreateOrUpdateShipmentTemplateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateOrUpdateShipmentTemplateOperationCompleted);
            }
            this.InvokeAsync("CreateOrUpdateShipmentTemplate", new object[] {
                        CreateOrUpdateShipmentTemplateRequest}, this.CreateOrUpdateShipmentTemplateOperationCompleted, userState);
        }
        
        private void OnCreateOrUpdateShipmentTemplateOperationCompleted(object arg) {
            if ((this.CreateOrUpdateShipmentTemplateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateOrUpdateShipmentTemplateCompleted(this, new CreateOrUpdateShipmentTemplateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.n11.com/ws/schemas")]
    public partial class GetShipmentTemplateListRequest {
        
        private Authentication authField;
        
        private RequestPagingData pagingDataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Authentication auth {
            get {
                return this.authField;
            }
            set {
                this.authField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public RequestPagingData pagingData {
            get {
                return this.pagingDataField;
            }
            set {
                this.pagingDataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class Authentication {
        
        private string appKeyField;
        
        private string appSecretField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string appKey {
            get {
                return this.appKeyField;
            }
            set {
                this.appKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string appSecret {
            get {
                return this.appSecretField;
            }
            set {
                this.appSecretField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class ShipmentCompanyApiModel {
        
        private string nameField;
        
        private string shortNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string shortName {
            get {
                return this.shortNameField;
            }
            set {
                this.shortNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class CityApiModel {
        
        private string nameField;
        
        private string codeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class DistrictApiModel {
        
        private string nameField;
        
        private long idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class ShipmentSaveAddress {
        
        private string titleField;
        
        private string addressField;
        
        private DistrictApiModel districtField;
        
        private CityApiModel cityField;
        
        private string postalCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DistrictApiModel district {
            get {
                return this.districtField;
            }
            set {
                this.districtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CityApiModel city {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string postalCode {
            get {
                return this.postalCodeField;
            }
            set {
                this.postalCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class ShipmentApiModel {
        
        private string templateNameField;
        
        private string installmentInfoField;
        
        private string exchangeInfoField;
        
        private string shippingInfoField;
        
        private bool specialDeliveryField;
        
        private string deliveryFeeTypeField;
        
        private bool combinedShipmentAllowedField;
        
        private string shipmentMethodField;
        
        private ShipmentSaveAddress warehouseAddressField;
        
        private ShipmentSaveAddress exchangeAddressField;
        
        private ShipmentCompanyApiModel[] shipmentCompaniesField;
        
        private CityApiModel[] deliverableCitiesField;
        
        private ShipmentCompanyApiModel claimShipmentCompanyField;
        
        private string cargoAccountNoField;
        
        private bool useDmallCargoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string templateName {
            get {
                return this.templateNameField;
            }
            set {
                this.templateNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string installmentInfo {
            get {
                return this.installmentInfoField;
            }
            set {
                this.installmentInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string exchangeInfo {
            get {
                return this.exchangeInfoField;
            }
            set {
                this.exchangeInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string shippingInfo {
            get {
                return this.shippingInfoField;
            }
            set {
                this.shippingInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool specialDelivery {
            get {
                return this.specialDeliveryField;
            }
            set {
                this.specialDeliveryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string deliveryFeeType {
            get {
                return this.deliveryFeeTypeField;
            }
            set {
                this.deliveryFeeTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool combinedShipmentAllowed {
            get {
                return this.combinedShipmentAllowedField;
            }
            set {
                this.combinedShipmentAllowedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string shipmentMethod {
            get {
                return this.shipmentMethodField;
            }
            set {
                this.shipmentMethodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipmentSaveAddress warehouseAddress {
            get {
                return this.warehouseAddressField;
            }
            set {
                this.warehouseAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipmentSaveAddress exchangeAddress {
            get {
                return this.exchangeAddressField;
            }
            set {
                this.exchangeAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("shipmentCompany", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ShipmentCompanyApiModel[] shipmentCompanies {
            get {
                return this.shipmentCompaniesField;
            }
            set {
                this.shipmentCompaniesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("city", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public CityApiModel[] deliverableCities {
            get {
                return this.deliverableCitiesField;
            }
            set {
                this.deliverableCitiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipmentCompanyApiModel claimShipmentCompany {
            get {
                return this.claimShipmentCompanyField;
            }
            set {
                this.claimShipmentCompanyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string cargoAccountNo {
            get {
                return this.cargoAccountNoField;
            }
            set {
                this.cargoAccountNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool useDmallCargo {
            get {
                return this.useDmallCargoField;
            }
            set {
                this.useDmallCargoField = value;
            }
        }

        internal List<ShipmentCompanyApiModel> ToList()
        {
            throw new NotImplementedException();
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class ResultInfo {
        
        private string statusField;
        
        private string errorCodeField;
        
        private string errorMessageField;
        
        private string errorCategoryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string errorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string errorCategory {
            get {
                return this.errorCategoryField;
            }
            set {
                this.errorCategoryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.n11.com/ws/schemas")]
    public partial class RequestPagingData {
        
        private System.Nullable<int> currentPageField;
        
        private System.Nullable<int> pageSizeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> currentPage {
            get {
                return this.currentPageField;
            }
            set {
                this.currentPageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public System.Nullable<int> pageSize {
            get {
                return this.pageSizeField;
            }
            set {
                this.pageSizeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.n11.com/ws/schemas")]
    public partial class GetShipmentTemplateListResponse {
        
        private ResultInfo resultField;
        
        private ShipmentApiModel[] shipmentTemplatesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ResultInfo result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("shipmentTemplate", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ShipmentApiModel[] shipmentTemplates {
            get {
                return this.shipmentTemplatesField;
            }
            set {
                this.shipmentTemplatesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.n11.com/ws/schemas")]
    public partial class GetShipmentTemplateRequest {
        
        private Authentication authField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Authentication auth {
            get {
                return this.authField;
            }
            set {
                this.authField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.n11.com/ws/schemas")]
    public partial class GetShipmentTemplateResponse {
        
        private ResultInfo resultField;
        
        private ShipmentApiModel shipmentTemplateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ResultInfo result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipmentApiModel shipmentTemplate {
            get {
                return this.shipmentTemplateField;
            }
            set {
                this.shipmentTemplateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.n11.com/ws/schemas")]
    public partial class CreateOrUpdateShipmentTemplateRequest {
        
        private Authentication authField;
        
        private ShipmentApiModel shipmentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Authentication auth {
            get {
                return this.authField;
            }
            set {
                this.authField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipmentApiModel shipment {
            get {
                return this.shipmentField;
            }
            set {
                this.shipmentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.n11.com/ws/schemas")]
    public partial class CreateOrUpdateShipmentTemplateResponse {
        
        private ResultInfo resultField;
        
        private ShipmentApiModel shipmentTemplateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ResultInfo result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ShipmentApiModel shipmentTemplate {
            get {
                return this.shipmentTemplateField;
            }
            set {
                this.shipmentTemplateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetShipmentTemplateListCompletedEventHandler(object sender, GetShipmentTemplateListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetShipmentTemplateListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetShipmentTemplateListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GetShipmentTemplateListResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GetShipmentTemplateListResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetShipmentTemplateCompletedEventHandler(object sender, GetShipmentTemplateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetShipmentTemplateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetShipmentTemplateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GetShipmentTemplateResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GetShipmentTemplateResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void CreateOrUpdateShipmentTemplateCompletedEventHandler(object sender, CreateOrUpdateShipmentTemplateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateOrUpdateShipmentTemplateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateOrUpdateShipmentTemplateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CreateOrUpdateShipmentTemplateResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CreateOrUpdateShipmentTemplateResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591