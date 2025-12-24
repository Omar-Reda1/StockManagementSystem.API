using StockManagementSystem.API.Models;

namespace StockManagementSystem.API.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}
