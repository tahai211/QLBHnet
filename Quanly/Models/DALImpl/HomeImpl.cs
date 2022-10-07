using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Quanly.Models.DAL;
using Quanly.Models.DTO;

namespace Quanly.Models.DALImpl
{
    public class HomeImpl : IHome
    {
        DBConnect db;
        public HomeImpl()
        {
            db = new DBConnect();//ham tao cua class DBConnection
        }

        public List<Hanghoa> listHang()
        {
            try
            {
                List<Hanghoa> lh = new List<Hanghoa>();
                SqlConnection con = db.getConnection();
                SqlCommand cmd = new SqlCommand("List_goods", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var render = cmd.ExecuteReader();
                while (render.Read())
                {
                    lh.Add(new Hanghoa
                    {
                        MaMH = render["MaMH"].ToString(),
                        TenMH = render["TenMH"].ToString(),
                        Xuatxu = render["Xuatxu"].ToString(),
                        Gianhap = Convert.ToInt32(render["Gianhap"]),
                        Giaban = Convert.ToInt32(render["Giaban"]),
                        NSX = render["NSX"].ToString(),
                        HSD = render["HSD"].ToString(),
                        Soluong = Convert.ToInt32(render["Soluong"]),
                        Conlai = Convert.ToInt32(render["Conlai"])

                    });

                }
                return lh;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

