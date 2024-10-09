

using AuthMicroservice.src.API.DTOs;
using AuthMicroservice.src.Domain.Entities;

namespace AuthMicroservice.src.Application.Interfaces
{
    public interface IAuthUserService
    {
        Task<User> Authenticate(AuthDTO authDTO);

    }
}
