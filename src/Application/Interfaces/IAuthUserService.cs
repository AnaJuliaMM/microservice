

using AuthMicroservice.src.API.DTOs;

namespace AuthMicroservice.src.Application.Interfaces
{
    public interface IAuthUserService
    {
        Task<bool> Authenticate(AuthDTO authDTO);

    }
}
