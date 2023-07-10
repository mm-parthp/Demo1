using Demo1.Data;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Diagnostics;
using System.Linq;

namespace Demo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicatonDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicatonDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(register reg)
        {

            _db.Add(reg);

            _db.SaveChanges();
            TempData["success"] = "Register Successfully";

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(loginVM log)
        {
            
            var uservalidate = _db.registers.Where(x => x.Email == log.Email && x.Password == log.Password).FirstOrDefault();
            
            if (uservalidate != null) 
            { 
                TempData["success"] = "Login Successfully";
                return RedirectToAction("Index","Category");
            }
            
            else
            {
                TempData["error"] = "Invalid Credential";
                return View();
            }
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