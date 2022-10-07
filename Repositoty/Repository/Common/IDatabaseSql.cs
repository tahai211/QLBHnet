using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public interface IDatabaseSql
    {
        string GetConnectByDomain(string domain);
        SqlConnection GetConnect();
        DataTable ExecuteTable(string sql);
        int ExecuteNonQuery(string sql);
        DataTable ExecuteProcTable(string procName, List<SqlParameter> lstParam);
        DataSet ExecuteProcDataSet(string procName, List<SqlParameter> lstParam);
        List<Dictionary<string, object>> ParseTableToDictionary(DataTable dt);
        int ExecuteProcNonQuery(string procName, List<SqlParameter> lstParam);
        IList<T> ExecuteProcToList<T>(string procName, List<SqlParameter> lstParam);
        string ExecuteProcToStringJson(string procName, List<SqlParameter> lstParam);
        string ConvertDataTabletoJson(DataTable dt);
        List<T> ConvertDataTableToList<T>(DataTable dt);
        IList<T> DataTableToList<T>(DataTable table);
        IList<T> ConvertToList<T>(DataTable dt);
        string ExecuteProcToJson(string procName, List<SqlParameter> lstParam);
        SqlParameter CreateSqlParameter(object value, string name);
        List<SqlParameter> ConvertClassToSqlParameter<T>(T dt);
        List<SqlParameter> ConvertClassToSqlParameterNull<T>(T dt);
        DataTable ToUserDefinedDataTable<T>(T dt);
        DataTable ConvertToCustomUserDefinedDataTable<T>(IEnumerable<T> values) where T : class;

        // nhamnv
        IList<T> ExecuteProcXmlToList<T>(string procName, List<SqlParameter> lstParam);
        T ExecuteProcXmlToObject<T>(string procName, List<SqlParameter> lstParam) where T : new();
    }
}
