using Desafio.Models;

namespace Desafio.Interfaces
{
    public interface ITokenService
    {
        public string GerarToken(Usuario usuario);
    }
}
