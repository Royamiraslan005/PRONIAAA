using Microsoft.EntityFrameworkCore;
using Proniaaa.DAL;

namespace Proniaaa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });


            builder.Services.AddControllersWithViews();
            

            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name:"Default",
                pattern:"{controller=Home}/{action=Index}"
                );
            
            app.Run();
        }
    }
}
