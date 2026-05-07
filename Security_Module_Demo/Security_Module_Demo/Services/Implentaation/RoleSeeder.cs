using Microsoft.AspNetCore.Identity;
using Security_Module_Demo.Helper;
using Security_Module_Demo.Services.Abstraction;

namespace Security_Module_Demo.Services.Implentaation
{
    public class RoleSeeder : IDataSedder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            string[] roles = [AppRoles.Admin, AppRoles.User];
            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    continue;

                await _roleManager.CreateAsync(new IdentityRole(role));
            }

           
        }
    }
}
