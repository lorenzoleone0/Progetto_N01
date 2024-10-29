using Libreria.Abstractions.IService;
using Libreria.Request;
using Libreria.Response;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreaTokenAsync(CreateTokenRequest request)
        {
           
               var token = await _tokenService.CreaTokenAsync(request);
               return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
        }
    }
}