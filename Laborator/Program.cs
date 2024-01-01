using Laborator.Data;
using Laborator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Laborator.Services;

namespace Laborator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<List>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("List") ?? throw new InvalidOperationException("Connection string 'List' not found.")));
			builder.Services.AddRazorPages();

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
	        options.UseSqlServer(connectionString));

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
            })
            //.AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();




            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();



            builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Identity/Account/Login";
				options.LogoutPath = $"/Identity/Account/Logout";
			});


			builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });
            builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			builder.Services.AddScoped<Cart>(sp => CartService.GetCart(sp));

			var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseAuthentication();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            

			await DBInitializer.Populate(app);

            app.Run();
        }


    }
}