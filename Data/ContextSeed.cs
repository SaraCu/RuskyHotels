using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
    }
}
