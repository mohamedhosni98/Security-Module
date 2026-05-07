using Microsoft.AspNetCore.Identity;

namespace Security_Module_Demo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string User_Name { get; set; }
        public string Address { get; set; }
    }
}
