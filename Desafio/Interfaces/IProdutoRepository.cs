using Desafio.Models;

namespace Desafio.Interfaces
{
    public interface IProdutoRepository
    {
        public int InserirProduto(Produto produto);
        public Produto PesquisarProduto(string nome);
        public void DeletarProduto(int id);
    }
}
