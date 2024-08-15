using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BusManagement.Data;
using BusManagement.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BusManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginModel user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Username == user.Username);

            if (existingUser != null && VerifyPassword(user.Password, existingUser.PasswordHash))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Username == model.Username);

            if (existingUser != null && VerifyPassword(model.CurrentPassword, existingUser.PasswordHash))
            {
                existingUser.PasswordHash = HashPassword(model.NewPassword);
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        private static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2)
                return false;

            var salt = Convert.FromBase64String(parts[0]);
            var storedPasswordHash = parts[1];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed == storedPasswordHash;
        }
    }

    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordModel
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
