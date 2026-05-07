using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Security_Module_Demo.Dtos;
using Security_Module_Demo.Models;
using Security_Module_Demo.Services.Abstraction;

namespace Security_Module_Demo.Services.Implentaation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        

        public AuthService(UserManager<ApplicationUser> userManager,IMapper mapper,ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            
        }

        public IMapper Mapper { get; }

        public async Task<AuthResponse> RegisterAsyc(RegisterDto registerDto)
        {
            if (await _userManager.FindByNameAsync(registerDto.User_Name) is not null
                &&
                await _userManager.FindByEmailAsync(registerDto.Email) is not null)

                return new AuthResponse { Message = "User Name Or Email Are Exist " };

            var user = _mapper.Map<ApplicationUser>(registerDto);

            var result = await _userManager.CreateAsync(user ,registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description} , ";
                }
            }

            await _userManager.AddToRoleAsync(user , "User");
            var roles = new List<string> { "User" };
            var jwttoken = _tokenService.GetToken(user, roles);
            return new AuthResponse
            {
                Eamil = user.Email,
                Token = jwttoken,
                Username = user.User_Name,
                Message = "Register sucesfull",
                Roles = roles
            };

            

           


        }

        public Task<AuthResponse> LogInAsync(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
