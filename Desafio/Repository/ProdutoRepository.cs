using Dapper;
using Desafio.Interfaces;
using Desafio.Models;
using System.Data;

namespace Desafio.Service
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _dbConnection;
        public ProdutoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int InserirProduto(Produto produto)
        {
            var insercao = @"INSERT INTO PRODUTO (NOME, DESCRICAO, Valor)
                                VALUES (@Nome, @Descricao, @Valor)";

            var idProduto = _dbConnection.Execute(insercao, produto);

            return idProduto;
        }

        public Produto PesquisarProduto(string nome)
        {
            var pesquisa = @"SELECT * FROM PRODUTO WHERE NOME = '%@NOME%'";

            var produto = _dbConnection.Query<Produto>(pesquisa, new { NOME = nome }).SingleOrDefault();

            return produto;
        }

        public void DeletarProduto(int id)
        {
            var delecao = @"DELETE FROM PRODUTO WHERE ID = @ID";
            _dbConnection.Execute(delecao, new { ID = id });
        }
    }
}
