using KittuBookStore.Data;
using KittuBookStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace KittuBookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //creating ConnectionString
            builder.Services.AddDbContext<BookStoreContext>(
               options => options.UseSqlServer("user id = sa; pwd =123; data source = DELL\\SQLEXPRESS; database = BookStore; "));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
#if DEBUG   
            //adding Razor pages
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            builder.Services.AddScoped<BookRepository, BookRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();



        }

    }
}
