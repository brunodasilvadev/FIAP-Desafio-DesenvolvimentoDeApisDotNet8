using Desafio.Models;

namespace Desafio.Interfaces
{
    public interface IUsuarioService
    {
        public bool UsuarioExiste(Usuario usuario);
    }
}
