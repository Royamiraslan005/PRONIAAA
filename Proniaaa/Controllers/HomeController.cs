using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proniaaa.DAL;
using Proniaaa.Models;
using Proniaaa.ViewModels.Home;

namespace Proniaaa.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVm homeVm = new HomeVm
            {
                products = await _context.products
                    .Include(x => x.Images)
                    .ToListAsync(),

                categories = await _context.categories.ToListAsync()
            };

            return View(homeVm);
        }
    }
}
