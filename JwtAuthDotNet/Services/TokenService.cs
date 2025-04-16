using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Repositories.Interfaces;
using JwtAuthDotNet.Services.Interfaces;

namespace JwtAuthDotNet.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUser _userRepository;

        public TokenService(IConfiguration configuration, IUser userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
