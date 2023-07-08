using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1.Services
{
        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; 
            public const string AUDIENCE = "MyAuthClient"; 
            const string KEY = "mysupersecret_secretkey!123";   
            public const int LIFETIME = 180; 
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
        }
    
}
