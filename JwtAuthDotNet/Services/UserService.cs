using JwtAuthDotNet.Data;
using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Repositories.Interfaces;
using JwtAuthDotNet.Services.Interfaces;

namespace JwtAuthDotNet.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUser _repository;

        public UserService(AppDbContext context, IUser repository)
        {
            _context = context;
            _repository = repository;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User? GetByUserName(string userName)
        {
            return _repository.GetByUserName(userName);
        }
    }
}
