using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
  
    public class DistrictGenderCount
    {
        public string District { get; set; }
        public int GenderCount { get; set; }
    }

    /*[Authorize(Roles = "Admin")]*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
       // private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            int TotalBeneficiaries = 0;
            var check = _context.LIPAssetTransfer.Include(a => a.Member).Count(a => a.IsAssetTransfer == true);
            //TotalBeneficiaries = _context.LIPAssetTransfer.Include(a => a.Member).Count(a => a.IsAssetTransfer == true);
            return View();
        }

        public IActionResult Dashboard()
        {
            List<WebApplication4.Models.BarData> list = new List<WebApplication4.Models.BarData>();
            WebApplication4.Models.BarData bar = new WebApplication4.Models.BarData()
            {
                category = "Killa Abdullah",
                male = 80,
                female = 10,
                refugeefemale = 90,
                refugeemale = 10,
                total = 190
            };
            WebApplication4.Models.BarData bar1 = new WebApplication4.Models.BarData()
            {
                category = "Killa Saifullah",
                male = 40,
                female = 20,
                refugeefemale = 80,
                refugeemale = 20,
                total = 20
            };
            WebApplication4.Models.BarData bar2 = new WebApplication4.Models.BarData()
            {
                category = "Quetta",
                male = 80,
                female = 30,
                refugeefemale = 0,
                refugeemale = 0,
                total = 1140
            };
            WebApplication4.Models.BarData bar3 = new WebApplication4.Models.BarData()
            {
                category = "Pishin",
                male = 80,
                female = 40,
                refugeefemale = 90,
                refugeemale = 0,
                total = 30
            };
            list.Add(bar);
            list.Add(bar1);
            list.Add(bar2);
            list.Add(bar3);


            ViewBag.TBBarChartData = list;

            //List<WebApplication4.Models.BarData> objCategories = list.ToList();
            //ViewBag.obj = objCategories.ToList();
      
           // var jsonString = JsonSerializer.Serialize(objCategories);
           // ViewBag.JsonData = jsonString;

            ViewBag.check = 1;
            return View(list);
        }

        public IActionResult Combine()
        {
            return View();  
        }

        //[Authorize(Roles ="Member")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PieOfPie()
        {
            return View();
        }

        public IActionResult PDOI()
        {
            return View();  
        }

        public IActionResult Bar()
        {
            return View();
        }

        public IActionResult Render() { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}