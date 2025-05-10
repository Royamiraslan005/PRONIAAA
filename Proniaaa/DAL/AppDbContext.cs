using Microsoft.EntityFrameworkCore;
using Proniaaa.Models;

namespace Proniaaa.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

             public DbSet<Category> categories { get; set; }
             public DbSet<Product> products { get; set; }
             public DbSet<ProductImage> images { get; set; }
        }
       
    }
