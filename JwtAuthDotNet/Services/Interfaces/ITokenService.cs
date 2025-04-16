using JwtAuthDotNet.Entities;

namespace JwtAuthDotNet.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
