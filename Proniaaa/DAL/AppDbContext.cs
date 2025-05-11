using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proniaaa.Models;

namespace Proniaaa.DAL
{
    public class AppDbContext :IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

             public DbSet<Category> categories { get; set; }
             public DbSet<Product> products { get; set; }
             public DbSet<ProductImage> images { get; set; }
        }
       
    }
