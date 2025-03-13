using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DTO;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            bool result = _userBL.Register(userDTO);
            if (!result) return BadRequest(new { message = "User already exists" });

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO loginDTO)
        {
            string token = _userBL.Login(loginDTO.Email, loginDTO.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { message = "Login successful", token });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] string email)
        {
            bool result = _userBL.ForgotPassword(email);
            if (!result) return NotFound(new { message = "User not found" });

            return Ok(new { message = "Password reset email sent" });
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDTO resetDTO)
        {
            bool result = _userBL.ResetPassword(resetDTO.Email, resetDTO.NewPassword);
            if (!result) return NotFound(new { message = "User not found" });

            return Ok(new { message = "Password updated successfully" });
        }
    }
}
