using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserAuthAPI.DTOs;
using UserAuthAPI.Services;

namespace UserAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUserService _authService;
        private ILogger<AuthController> _logger;

        public AuthController(IAuthUserService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthDTO authDTO)
        {
            _logger.LogDebug("Chamando Autenticação");
            var isAuthenticated = await _authService.Authenticate(authDTO);

            
            if (!isAuthenticated)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok("Authentication successful");
        }
    }
}
