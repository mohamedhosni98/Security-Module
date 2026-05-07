using Microsoft.AspNetCore.Identity;
using Security_Module_Demo.Helper;
using Security_Module_Demo.Models;
using Security_Module_Demo.Services.Abstraction;

namespace Security_Module_Demo.Services.Implentaation
{
    public class AdminSeeder : IDataSedder
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminSeeder(IConfiguration configuration , UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            var settings = _configuration.GetSection("AdminSettings").Get<AdminSettings>();
            if (settings is null) return;

            var existAdmin = await _userManager.FindByEmailAsync(settings.Email);

            if (existAdmin is null)
            {
                // 1. إنشاء اليوزر لو مش موجود
                var admin = new ApplicationUser
                {
                    Email = settings.Email,
                    UserName = settings.Email, // التأكد من الاسم الصحيح للخاصية
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(admin, settings.Password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create Admin: {errors}");
                }

                existAdmin = admin; // نساوي المتغير باليوزر الجديد عشان نديله Role تحت
            }

            // 2. التأكد إن اليوزر معاه الـ Role (حتى لو كان موجود قبل كدة)
            if (!await _userManager.IsInRoleAsync(existAdmin, AppRoles.Admin))
            {
                await _userManager.AddToRoleAsync(existAdmin, AppRoles.Admin);
            }
        }
    }
}
