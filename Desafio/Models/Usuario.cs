using Desafio.Enums;

namespace Desafio.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public TipoPermissao TipoPermissao { get; set; }
    }
}
