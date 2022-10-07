using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Data.SqlClient;


namespace Quanly.Models
{
    public class DBConnect
    {
        public DBConnect()
        {

        }
       
        public SqlConnection getConnection()
        {
            string ConnectionString = "Data Source=192.168.4.37;" +
            "Initial Catalog=QLBH;" +
            "User id=TTS;" +
            "Password=Novaon@123";
            var sqlcon = new SqlConnection(ConnectionString);
            if(sqlcon.State == System.Data.ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            else
            {
                sqlcon.Close();
            }
            return sqlcon;

            
        }
    }
}

