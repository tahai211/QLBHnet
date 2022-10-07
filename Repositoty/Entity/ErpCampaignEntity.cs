using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entity
{
    public class ErpCampaignEntity
    {
        public int ErpCampaignID { get; set; }
        public int COADetailID { get; set; }
        public int DS_ContractID { get; set; }
        public int DS_ServiceID { get; set; }
        public int DS_CustomerID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string ExtensionFactorNote { get; set; }
        public string Note { get; set; }
        public string ProcessingNote { get; set; }
        public string BacklogNote { get; set; }
        public Nullable<System.DateTime> DateCustomerCall { get; set; }
        public string ResultCall { get; set; }
        public string Target { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Locked { get; set; }
        public Nullable<double> CurrentKPIQuantity { get; set; }
        public Nullable<double> ExchangeRate { get; set; }
        public Nullable<double> AdsBudgetAdjusted { get; set; }
        public Nullable<double> AdsBudgetOnTime { get; set; }
        public double OriginalMargin { get; set; }
        public string BmMcc { get; set; }
    }
}
