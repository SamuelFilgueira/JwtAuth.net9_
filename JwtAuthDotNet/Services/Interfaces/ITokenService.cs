using JwtAuthDotNet.DTOs;
using JwtAuthDotNet.Entities;

namespace JwtAuthDotNet.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(LoginDto loginDto);
    }
}
