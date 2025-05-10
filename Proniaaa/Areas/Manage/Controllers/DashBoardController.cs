using Microsoft.AspNetCore.Mvc;

namespace Proniaaa.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashBoard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
