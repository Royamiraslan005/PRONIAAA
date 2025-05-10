using Microsoft.AspNetCore.Mvc;

namespace Proniaaa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
