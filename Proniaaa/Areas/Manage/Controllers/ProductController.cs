using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proniaaa.DAL;
using Proniaaa.Models;
using Proniaaa.Utils.Extentions;

namespace Proniaaa.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.products.ToListAsync();

            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!product.file.ContentType.Contains("image"))
            {
                ModelState.AddModelError("file", "duzgun daxil edin");
                return View();
            }
            if (product.file.Length > 2097152)
            {
                ModelState.AddModelError("file", "Sekil max 2mb ola biler");
                return View();
            }

            string filename = product.file.FileName;
            string path = "C:\\Users\\hp\\source\\repos\\Proniaaa\\Proniaaa\\wwwroot\\images\\";
            using(FileStream stream=new FileStream(path + filename, FileMode.Create))
            {
                product.file.CopyTo(stream);
            }
            product.ImgUrl = product.file.Createfile(_environment.WebRootPath,"images/Product");


            await _context.products.AddRangeAsync(product);
            await _context.SaveChangesAsync();



            return RedirectToAction("index");
        }

    }
}
