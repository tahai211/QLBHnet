using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Quanly.Models.DAL;
using Quanly.Models;
using Quanly.Models.DTO;
using System.Data;

namespace Quanly.Models.DALImpl
{
    public class RegisterImpl:IRegister
    {
        DBConnect db;
        public RegisterImpl()
        {
            db = new DBConnect();//ham tao cua class DBConnection
        }
        public int createNew(Login login)
        {
           
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand("Create_Account", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", login.UserName);

            cmd.Parameters.AddWithValue("@PassWord", login.Password);

            int tb = (int)Convert.ToUInt32( cmd.ExecuteScalar());

            cmd.Dispose();
            con.Close();
            return tb;

        }

        public void updateNew(Nhanvien nhanvien)
        {
            
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand("Update_Nhanvien", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", nhanvien.user);

            cmd.Parameters.AddWithValue("@MaNV", nhanvien.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nhanvien.TenNV);
            cmd.Parameters.AddWithValue("@Gioitinh", nhanvien.Gioitinh);
            cmd.Parameters.AddWithValue("@Ngaysinh", nhanvien.Ngaysinh);
            cmd.Parameters.AddWithValue("@Diachi", nhanvien.Diachi);
            cmd.Parameters.AddWithValue("@Sdt", nhanvien.Sdt);
            cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();
            
        }
    }
}

