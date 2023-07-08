using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Helpers;
namespace WebApplication1.Services.UserServices
{
    public class UserService : IUserService
    {
        private Context _context;
        private TokenService _tokenService;
        public UserService(Context context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public string LogIn(UserAuthModel userAuthModel)
        {
            var user = _context.users.FirstOrDefault(x =>( x.UserName == userAuthModel.Login) || (x.Email == userAuthModel.Login) 
            && x.Password.Equals(PasswordHasher.GetHashString(userAuthModel.Password)));
           //тут ми шукаємо користувача де вхід за ім'ям користувача або за імейлом
            if (user == null)
            {
                return null;
            }
            return _tokenService.GenerateToken(user.UserName);
        }

        public string Register(UserRegistrationModel userRegistrationModel)
        {
            var user = new User() { Email = userRegistrationModel.Email, Password = PasswordHasher.GetHashString(userRegistrationModel.Password), UserName = userRegistrationModel.UserName };
            List<User> users = _context.users
             .Where(x => x.UserName.Equals(userRegistrationModel.UserName) || x.Email.Equals(userRegistrationModel.Email))
            .ToList();
            if(users.Count > 0)
            {
                return null;
            }
            _context.users.Add(user);
            _context.SaveChanges();
            return _tokenService.GenerateToken(user.UserName);
        }

    }
}
