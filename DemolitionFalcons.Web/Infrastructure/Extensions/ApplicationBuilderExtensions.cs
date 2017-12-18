namespace DemolitionFalcons.Data.Infrastructure.Extensions
{
    using Data.Models;
    using DemolitionFalcons.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DemolitionFalconsDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var roleName = WebConstants.AdministratorRole;

                        var roleExists = await roleManager.RoleExistsAsync(roleName);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = roleName
                            });
                        }

                        var adminEmail = "admin@admin.bg";

                        var adminUserExists = await userManager.FindByNameAsync(adminEmail);

                        if (adminUserExists == null)
                        {
                            adminUserExists = new User
                            {
                                Email = adminEmail,
                                UserName = adminEmail
                            };

                            await userManager.CreateAsync(adminUserExists, "Admin@2");
                            await userManager.AddToRoleAsync(adminUserExists, roleName);
                        }
                    })
                .Wait();
            }

            return app;
        }
    }
}
