using AuthMicroservice.src.Application.Interfaces;
using AuthMicroservice.src.Domain.Interfaces;
using AuthMicroservice.src.Domain.Entities;
using AuthMicroservice.src.Application.Helpers;
using AuthMicroservice.src.API.DTOs;

namespace AuthMicroservice.src.Application.Services
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
