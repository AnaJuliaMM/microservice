using UserAuthAPI.DTOs;

namespace UserAuthAPI.Services
{
    public interface IAuthUserService
    {
        Task<bool> Authenticate(AuthDTO authDTO);

    }
}
