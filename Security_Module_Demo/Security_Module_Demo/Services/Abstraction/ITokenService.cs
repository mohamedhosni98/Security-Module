using Security_Module_Demo.Models;

namespace Security_Module_Demo.Services.Abstraction
{
    public interface ITokenService
    {
        string GetToken(ApplicationUser user , IList<string> role  );
    }
}
