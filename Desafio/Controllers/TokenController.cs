using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    /// <summary>
    /// Controller responsável para gerar token de autorização de acesso a endpoints restritos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Endpoint de geração de token
        /// </summary>
        /// <param name="usuario">dados do usuário para geração do token</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GerarToken([FromBody] Usuario usuario)
        {
            var token = _tokenService.GerarToken(usuario);

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
