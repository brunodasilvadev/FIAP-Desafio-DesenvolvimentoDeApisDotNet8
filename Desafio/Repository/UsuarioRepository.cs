using Desafio.Interfaces;
using Desafio.Models;
using System.Data;
using Dapper;

namespace Desafio.Repository
{
    public class UsuarioRepository : IUsuarioService
    {
        private readonly IDbConnection _dbConnection;
        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool UsuarioExiste(Usuario usuario)
        {
            var pesquisa = @"SELECT * FROM USUARIO WHERE NOME = @NOME AND SENHA = @SENHA";


            var usuarioEncontrado = _dbConnection.Query<Usuario>(pesquisa, new { NOME = usuario.Nome, SENHA = usuario.Senha}).SingleOrDefault();

            return usuarioEncontrado != null;
        }
    }
}
