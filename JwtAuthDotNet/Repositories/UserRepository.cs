using JwtAuthDotNet.Data;
using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Repositories.Interfaces;

namespace JwtAuthDotNet.Repositories
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);

        }
    }
}
