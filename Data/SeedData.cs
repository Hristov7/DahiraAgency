using Microsoft.AspNetCore.Identity;

namespace DahiraAgency.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Create roles
                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                    {
                        roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
                    }
                }

                // Create admin user
                var adminEmail = "admin@dahira.com";
                var adminPassword = "Admin@123"; // use strong password in production

                var adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();
                if (adminUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    var result = userManager.CreateAsync(user, adminPassword).GetAwaiter().GetResult();
                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
                    }
                }
                else
                {
                    // Ensure admin user has the Admin role
                    if (!userManager.IsInRoleAsync(adminUser, "Admin").GetAwaiter().GetResult())
                    {
                        userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}
