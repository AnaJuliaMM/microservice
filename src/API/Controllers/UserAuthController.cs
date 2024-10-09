using AuthMicroservice.src.API.DTOs;
using AuthMicroservice.src.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AuthMicroservice.src.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUserService _authService;
        private readonly ILogger<AuthController> _logger;

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
