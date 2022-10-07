
using EV.Repository.Infrastructure;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EV.Repository.Dashboard
{
    public interface ICampaignRepository : IRepository<GoogleCampaignType>
    {
        List<ErpCampaignEntity> GetCampainByCondition(string condition);
        bool CampainCurrentSaveList(List<GoogleCampaignType> data);
        bool ReloadCampaign(long erpCampaignId);
        bool CampainCurrentDeleteByDate(DateTime startDate, DateTime endDate, long erpCampaignId);
        List<GoogleCampaignType> CampainFullSaveList(List<GoogleCampaignType> data);
        List<GoogleCampaignType> CampainFullDeleteByDate(DateTime startDate, DateTime endDate, long accountId);
    }
}
