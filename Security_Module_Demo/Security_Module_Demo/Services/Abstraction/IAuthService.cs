using Security_Module_Demo.Dtos;
using Security_Module_Demo.Models;

namespace Security_Module_Demo.Services.Abstraction
{
   public interface IAuthService
    {
        Task<AuthResponse> RegisterAsyc(RegisterDto registerDto);
        Task<AuthResponse> LogInAsync (RegisterDto registerDto);
     }
}
