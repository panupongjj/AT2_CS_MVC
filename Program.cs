using AT2_CS_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AT2_CS_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            IConfiguration configuration = new ConfigurationBuilder()
                                               .AddJsonFile("./config.json")
                                               .Build();
            builder.Services.AddMvc();

            builder.Services.AddDbContext<ApplicantDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));
                var connectionString = configuration.GetConnectionString("DBConnection");
                options.UseSqlServer(connectionString);
            });
            
      
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
                pattern: "{controller=Home}/{action=Index}/{id?}");
                //pattern: "{controller=Candidate}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
