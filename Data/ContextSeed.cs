using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RuskyHotels.Enums;
using RuskyHotels.Models;

namespace RuskyHotels.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.Viewer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Role.SuperAdmin.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Sara",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin98765.");
                    await userManager.AddToRoleAsync(defaultUser, Role.Viewer.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Role.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Role.SuperAdmin.ToString());
                }

            }
        }

        public static void SeedRoomPrices(this IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var roomPrices = context.RoomPrices.ToList();
                (RoomType, decimal)[] required = {
                (RoomType.Single, 300),
                (RoomType.Double, 400),
                (RoomType.Triple, 500),
                (RoomType.Penthouse, 700)
            };

                foreach (var item in required)
                {
                    if (!roomPrices.Any(r => r.RoomType == item.Item1))
                    {
                        context.Add(new RoomPrice
                        {
                            RoomType = item.Item1,
                            Price = item.Item2,

                        });
                    }
                }
                context.SaveChanges();
            }

           
        }
    }
}
