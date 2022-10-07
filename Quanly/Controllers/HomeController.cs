using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quanly.Models;
using Quanly.Models.DALImpl;
using Quanly.Models.DTO;
using Microsoft.AspNetCore.Http;


namespace Quanly.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string user)
        {
            HomeImpl hm = new HomeImpl();//khoi tao
            List<Hanghoa> obj = hm.listHang().OrderBy(x => x.Soluong).ToList(); ;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                ViewBag.user = HttpContext.Session.GetString("Name");
                ViewBag.Title = "";
                
                return View(obj);
            }
           
            return View();
            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

