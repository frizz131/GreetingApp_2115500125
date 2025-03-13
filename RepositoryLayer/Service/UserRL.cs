using System.Linq;
using RepositoryLayer.Context;
using RepositoryLayer.DTO;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Security.Cryptography;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly GreetingDBContext _context;

        public UserRL(GreetingDBContext context)
        {
            _context = context;
        }

        public bool Register(UserDTO userDTO)
        {
            if (_context.Users.Any(u => u.Email == userDTO.Email))
                return false; // User already exists

            // Hash password before storing
            string hashedPassword = HashPassword(userDTO.Password);

            UserEntity user = new UserEntity
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = hashedPassword
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public string Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.Password))
                return null; // Invalid credentials

            return "Login Successful"; // In real-world scenario, return JWT token
        }

        public bool ForgotPassword(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            // Logic to send reset password email
            return true;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            user.Password = HashPassword(newPassword);
            _context.SaveChanges();
            return true;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput == storedHashedPassword;
        }
    }
}
