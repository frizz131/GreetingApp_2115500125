using RepositoryLayer.DTO;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        bool Register(UserDTO userDTO);
        string Login(string email, string password);
        bool ForgotPassword(string email);
        bool ResetPassword(string email, string newPassword);
    }
}
