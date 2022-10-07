using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entity
{
    public class GoogleCampaignType
    {
        public long GGCampaignId { get; set; }
        public long AccountId { get; set; }
        public long ErpCampaignId { get; set; }
        public string GGCampaignName { get; set; }
        public string PaymentMode { get; set; }
        public string CustomerDescriptiveName { get; set; }
        public string CampaignStatus { get; set; }
        public string CurrencyCode { get; set; }
        public long Impressions { get; set; }
        public long Clicks { get; set; }
        public Decimal Ctr { get; set; }
        public Decimal AverageCpc { get; set; }
        public Decimal CostMicros { get; set; }
        public Decimal Conversions { get; set; }
        public long View { get; set; }
        public DateTime Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string AdNetworkType { get; set; }

    }
}
