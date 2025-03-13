using RepositoryLayer.DTO;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        bool Register(UserDTO userDTO);
        string Login(string email, string password);
        bool ForgotPassword(string email);
        bool ResetPassword(string email, string newPassword);
    }
}
