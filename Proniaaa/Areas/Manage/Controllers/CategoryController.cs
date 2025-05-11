using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proniaaa.DAL;
using Proniaaa.Models;

namespace Proniaaa.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = _context.categories.Include(x => x.products).ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
