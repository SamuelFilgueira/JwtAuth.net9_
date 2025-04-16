using JwtAuthDotNet.Entities;

namespace JwtAuthDotNet.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        User? GetByUserName(string userName);   
    }
}
