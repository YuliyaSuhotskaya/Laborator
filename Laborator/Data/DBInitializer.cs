using Laborator.Entities;
using Laborator.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;


namespace Laborator.Data
{
	public static class DBInitializer
	{
		public static async Task Populate(WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			using var roleManager = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole>>();
			using var userManager = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();

			//await context.Database.EnsureDeletedAsync();
			// создать БД, если она еще не создана
			await context.Database.EnsureCreatedAsync();
			// проверка наличия ролей
			if (!context.Roles.Any())
			{
				var roleAdmin = new IdentityRole
				{
					Name = "admin",
					NormalizedName = "admin"
				};
				// создать роль admin
				await roleManager.CreateAsync(roleAdmin);
			}
			// проверка наличия пользователей
			if (!context.Users.Any())
			{
				// создать пользователя user@mail.ru
				var user = new ApplicationUser
				{
					Email = "user@mail.ru",
					UserName = "user@mail.ru"
				};
				await userManager.CreateAsync(user, "123456");
				// создать пользователя admin@mail.ru
				var admin = new ApplicationUser
				{
					Email = "admin@mail.ru",
					UserName = "admin@mail.ru"
				};
				await userManager.CreateAsync(admin, "123456");
				// назначить роль admin
				admin = await userManager.FindByEmailAsync("admin@mail.ru");
				await userManager.AddToRoleAsync(admin, "admin");
			}

			if(!context.JewelryGroups.Any())
			{
				context.JewelryGroups.AddRange(
				new List<JewelryGroup>
				{
						new JewelryGroup {GroupName="Кольца"},
						new JewelryGroup {GroupName="Браслеты"},
						new JewelryGroup {GroupName = "Серьги" },
						new JewelryGroup {GroupName = "Подвески" },
						new JewelryGroup {GroupName = "Броши" }	
				});
					await context.SaveChangesAsync();
			}
					// проверка наличия объектов
			if (!context.Jewelries.Any())
			{
						context.Jewelries.AddRange(
						new List<Jewelry>
						{
						new Jewelry {JewelryName="Браслет с аметистами", Description="Великолепный", Price =200, JewelryGroupId=2, Image="Браслет_с_аметистами.jpg"  },
						new Jewelry {JewelryName="Браслет с гранатами", Description="Страстный", Price =330, JewelryGroupId=2, Image="Браслет_с_гранатами.jpg"  },
						new Jewelry {JewelryName="Кольцо с бриллиантом", Description="Очень дорогое", Price =635, JewelryGroupId=1, Image="Кольцо_с_бриллиантом.jpg" },
						new Jewelry {JewelryName="Кольцо с топазом", Description="Загадочное", Price =524, JewelryGroupId=1, Image="Кольцо_с_топазом.jpg"},
						new Jewelry {JewelryName="Серьги из золота с бриллиантами", Description="Манящие", Price =180, JewelryGroupId=3, Image="Серьги_из_золота_с_бриллиантами.jpg" },
						new Jewelry {JewelryName="Брошь с сапфирами", Description="Строгая", Price =220, JewelryGroupId=5, Image="Брошь_с_сапфирами.jpg"}
                        });
					await context.SaveChangesAsync();
					
			}
		}

		

	}
}
	
