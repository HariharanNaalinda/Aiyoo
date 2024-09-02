using Microsoft.AspNetCore.Mvc;
using ApiWithRole2.Models;
using ApiWithRole2.Services;
using System.Threading.Tasks;

namespace ApiWithRole2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user, string password)
        {
            var result = await _authService.RegisterUserAsync(user, password);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password, string userType)
        {
            var user = _authService.ValidateUser(username, password, userType);
            if (user != null)
            {
                var token = GenerateToken(); // Implement token generation
                SessionManager.SaveToken(username, token);
                return Ok(new { Message = $"Login successful for {user.UserType}", Token = token });
            }
            return Unauthorized("Invalid username or password");
        }

        private string GenerateToken()
        {
            // Implement token generation logic here
            return "GeneratedToken"; // Placeholder
        }

    }
}
