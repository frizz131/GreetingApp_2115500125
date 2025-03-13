using BusinessLayer.Interface;
using RepositoryLayer.DTO;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL _userRL;

        public UserBL(IUserRL userRL)
        {
            _userRL = userRL;
        }

        public bool Register(UserDTO userDTO)
        {
            return _userRL.Register(userDTO);
        }

        public string Login(string email, string password)
        {
            return _userRL.Login(email, password);
        }

        public bool ForgotPassword(string email)
        {
            return _userRL.ForgotPassword(email);
        }

        public bool ResetPassword(string email, string newPassword)
        {
            return _userRL.ResetPassword(email, newPassword);
        }
    }
}
