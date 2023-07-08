using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Services.UserServices
{
    public interface IUserService
    {
        string Register(UserRegistrationModel user);
        string LogIn(UserAuthModel userAuthModel);
    }
}
