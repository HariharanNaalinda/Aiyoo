using System.Linq;
using System.Threading.Tasks;
using ApiWithRole2.Data;
using ApiWithRole2.Models;
using BCrypt.Net;

namespace ApiWithRole2.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterUserAsync(User user, string password)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return "Username already exists";
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User registered successfully";
        }

        public User ValidateUser(string username, string password, string userType)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username && u.UserType == userType);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }
    }
}
