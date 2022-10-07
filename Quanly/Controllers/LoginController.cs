using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models.DTO;
using Quanly.Models.DALImpl;
using Quanly.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quanly.Controllers
{
    public class LoginController : Controller
    {
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        /*DBConnect db = new DBConnect();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Login_user(string thongbao)
        {
            ViewBag.thongbao = thongbao;
            return View();
        }
        
        [HttpPost]
        public IActionResult Verify(Login login)
        {
            
            string sql= "SELECT * FROM Data_User Where UserName = '"+login.UserName+"'AND [PassWord] ='"+login.Password+"'";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("MyHome");
            }
            else
            {
                con.Close();
                return RedirectToAction("Login_user",new {thongbao = "Username or password is incorrect" });
            }
            
            
        }*/
        public IActionResult Login_user(string thongbao)
        {
            //ViewBag["thongbao"] = thongbao;
            return View();
        }
        [HttpPost]
        public IActionResult Verify(Login login)
        {
            if (ModelState.IsValid)//kiem tra xem cac truong da day du chua
            {
                login.Password = GetMD5(login.Password);
                LoginImpl lg = new LoginImpl();
                int tb = lg.loginAcc(login);
                if (tb > 0)
                {
                    HttpContext.Session.SetString("Name", login.UserName.ToString());
                    
                    return RedirectToAction("MyHome");


                }
                else
                {
                    return RedirectToAction("Login_user", new { thongbao = "UseyHomername or password is incorrect" });
                }
            }
            return RedirectToAction("Login_user", new { thongbao = "Điền đầy đủ thông tin !" });

        }

        //dang ki acc
        public IActionResult Register(string thongbao)
        {
            ViewBag.thongbao = thongbao;
            
            return View();
        }
        [HttpPost]//don su kien gui len server
        public IActionResult Register(Login login)
        {
            if (ModelState.IsValid)//kiem tra xem cac truong da day du chua
            {
                login.Password = GetMD5(login.Password);
                RegisterImpl rgt = new RegisterImpl();//khoi tao
                int tb = rgt.createNew(login);
                if( tb >0 )
                {
                    return RedirectToAction("Register", new { thongbao = "Tài khoản đã tồn tại !" });//hien thi lai danh sach
                }
                else
                {
                    return RedirectToAction("Update_Account", new { user = login.UserName });//hien thi lai danh sach
                    
                }
                

            }
            return RedirectToAction("Register",new { thongbao = "Điền đầy đủ thông tin !" } );
        }

        //dien du thong tin
        public IActionResult Update_Account(string user)
        {
            ViewBag.user = user;
           
            return View();
        }
        [HttpPost]//don su kien gui len server
        public IActionResult Update_Account(string user,Nhanvien nhanvien)
        {
            ViewBag.user = user;
            if (ModelState.IsValid)//kiem tra xem cac truong da day du chua
            {
                nhanvien.user = user;
                RegisterImpl rgt = new RegisterImpl();//khoi tao
                rgt.updateNew( nhanvien);
                return RedirectToAction("Login_user", new { thongbao = "Điền thông tin đăng ký thành công !" });
            }
            return RedirectToAction("Update-Account", new { thongbao = "Điền đầy đủ thông tin !" });
        }


        public IActionResult MyHome()
        {
            HomeImpl hm = new HomeImpl();//khoi tao
            List<Hanghoa> obj = hm.listHang().OrderBy(x => x.Soluong).ToList(); ;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                return View(obj);
            }
            ViewBag.user = HttpContext.Session.GetString("Name");
           
            return View(obj);

        }



    }
}

