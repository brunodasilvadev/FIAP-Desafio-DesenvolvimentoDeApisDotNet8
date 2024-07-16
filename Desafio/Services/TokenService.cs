using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuario;

        public TokenService(IConfiguration configuration, IUsuarioService usuario)
        {
            _configuration = configuration;
            _usuario = usuario;
        }

        public string GerarToken(Usuario usuario)
        {
            if (!_usuario.UsuarioExiste(usuario)) return string.Empty;

            var chaveCriptografada = RecuperarChaveCriptografada();

            var propriedadesToken = DefinirPropriedadesToken(usuario, chaveCriptografada);

            return CriarToken(propriedadesToken);
        }

        private static string CriarToken(SecurityTokenDescriptor propriedadesToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(propriedadesToken);
            return tokenHandler.WriteToken(token);
        }

        private static SecurityTokenDescriptor DefinirPropriedadesToken(Usuario usuario, byte[] chaveCriptografada) => new()
        {
            Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, (usuario.TipoPermissao).ToString())
                }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografada), SecurityAlgorithms.HmacSha256Signature)
        };

        private byte[] RecuperarChaveCriptografada() => Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));
    }
}
