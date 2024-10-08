using System.Threading.Tasks;
using UserAuthAPI.DTOs;
using UserAuthAPI.Data;
using UserAuthAPI.Helpers;
using UserAuthAPI.Models;

namespace UserAuthAPI.Services
{

    public class AuthService : IAuthUserService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Authenticate(AuthDTO authDTO)
        {
            // Verifica se o usuário existe
            User user = await _userRepository.GetUserByEmail(authDTO.Email);

            if (user == null)
            {
                return false; 
            }

            string enteredPassword = authDTO.Password;
            string storedHash = user.Password;
            
            return PasswordHelper.VerifyPassword(enteredPassword, storedHash );

            
        }
    }
}
