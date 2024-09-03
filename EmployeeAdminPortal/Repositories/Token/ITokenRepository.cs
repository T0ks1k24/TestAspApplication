using EmployeeAdminPortal.Migrations.NZWalksAuth;
using Microsoft.AspNetCore.Identity;

namespace EmployeeAdminPortal.Repositories.Token
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
