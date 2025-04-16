using JwtAuthDotNet.Entities;

namespace JwtAuthDotNet.Repositories.Interfaces
{
    public interface IUser
    {
        void Add(User user);
        User? GetByUserName(string userName);
    }
}
