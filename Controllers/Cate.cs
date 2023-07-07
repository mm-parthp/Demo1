using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class Cate : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
