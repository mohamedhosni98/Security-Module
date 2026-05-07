using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Security_Module_Demo.Helper;
using Security_Module_Demo.Models;
using Security_Module_Demo.Services.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security_Module_Demo.Services.Implentaation
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _options;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IOptions<JwtSettings>options)
        {
            _options = options.Value;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        }
        public string GetToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email ,user.Email),
            new Claim(JwtRegisteredClaimNames.Name , user.User_Name)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role , role));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = _options.Audience,
                    Issuer = _options.Issuer,
                    Expires = DateTime.UtcNow.AddMinutes(_options.DurationInMinutes),
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = creds
                };

            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}
