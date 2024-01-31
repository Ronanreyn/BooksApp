using BooksApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksApp //includes initial commands and settings to set up app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //get connection string info and store it into a variable
            var connectionString = builder.Configuration.GetConnectionString("BooksDBConnection");

            //add the db context class to the services using sql server as the default DBMS, along with the connection string fetched in the previous statement
            builder.Services.AddDbContext<BooksDBContext>(options => options.UseSqlServer(connectionString));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=Index}/{id?}");

            app.Run();
        }
    }
}