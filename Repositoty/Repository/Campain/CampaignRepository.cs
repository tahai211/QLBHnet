
using EV.Repository.Infrastructure;
using Repository;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EV.Repository.Dashboard
{
    public class CampaignRepository : RepositoryBase<GoogleCampaignType>, ICampaignRepository
    {
        public CampaignRepository(IDatabaseSql databaseSql) : base(databaseSql)
        {

        }
        public List<ErpCampaignEntity> GetCampainByCondition(string condition)
        {
            var par = new List<SqlParameter>() 
            { 
                    new SqlParameter("@FilterField", condition),
            };
            var result = _databaseSql.ExecuteProcToList<ErpCampaignEntity>("ErpCampaign_GetByCondition", par);
            if (result != null && result.Count > 0)
            {
                return result.ToList();
            }
            return new List<ErpCampaignEntity>();
        }
        public bool CampainCurrentSaveList(List<GoogleCampaignType> data)
        {
            var par = new List<SqlParameter>()
            {
                     new SqlParameter("@Data", _databaseSql.ConvertToCustomUserDefinedDataTable<GoogleCampaignType>(data))
            };
            var result = _databaseSql.ExecuteProcNonQuery("CampaignsCurrent_SaveList", par);
            return result > 0;
        }
        public bool ReloadCampaign(long erpCampaignId)
        {
            var par = new List<SqlParameter>()
            {
                     new SqlParameter("@erpCampaignId", erpCampaignId)
            };
            var result = _databaseSql.ExecuteProcNonQuery("ErpCampaignCostAPIGoogle", par);
            return result > 0;
        }
        public bool CampainCurrentDeleteByDate(DateTime startDate, DateTime endDate, long erpCampaignId)
        {
            var par = new List<SqlParameter>()
            {
                     new SqlParameter("@StartDate", startDate),
                     new SqlParameter("@EndDate", endDate),
                     new SqlParameter("@ErpCampaignId", erpCampaignId),
            };
            var result = _databaseSql.ExecuteProcNonQuery("CampaignsCurrent_DeleteByDate", par);
            return result > 0;
        }
        public List<GoogleCampaignType> CampainFullSaveList(List<GoogleCampaignType> data)
        {
            var par = new List<SqlParameter>()
            {
                     new SqlParameter("@Data", _databaseSql.ConvertToCustomUserDefinedDataTable<GoogleCampaignType>(data))
            };
            var result = _databaseSql.ExecuteProcToList<GoogleCampaignType>("CampaignsFull_SaveList", par);
            if (result != null && result.Count > 0)
            {
                return result.ToList();
            }
            return new List<GoogleCampaignType>();
        }
        public List<GoogleCampaignType> CampainFullDeleteByDate(DateTime startDate, DateTime endDate, long accountId)
        {
            var par = new List<SqlParameter>()
            {
                     new SqlParameter("@StartDate", startDate),
                     new SqlParameter("@EndDate", endDate),
                     new SqlParameter("@ExternalCustomerId", accountId),
            };
            var result = _databaseSql.ExecuteProcToList<GoogleCampaignType>("CampaignsFull_DeleteByDate", par);
            if (result != null && result.Count > 0)
            {
                return result.ToList();
            }
            return new List<GoogleCampaignType>();
        }

    }
}
