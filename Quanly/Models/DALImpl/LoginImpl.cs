using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Quanly.Models.DAL;
using Quanly.Models.DTO;
using Quanly.Models;
using System.Data.SqlClient;

namespace Quanly.Models.DALImpl
{
    
    public class LoginImpl : ILogin
    {
        DBConnect db;
        public LoginImpl()
        {
            db = new DBConnect();//ham tao cua class DBConnection
        }
        public int loginAcc(Login login)
        {
            var tb = 0;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand("Login_Account", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", login.UserName);

            cmd.Parameters.AddWithValue("@PassWord", login.Password);
            var result = cmd.ExecuteScalar();
            try
            {
                tb = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                tb = 0;
            }
            cmd.Dispose();
            con.Close();
            return tb;
        }
    }
}

