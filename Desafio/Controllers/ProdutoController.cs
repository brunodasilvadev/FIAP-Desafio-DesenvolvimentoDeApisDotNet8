using Desafio.Enums;
using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    /// <summary>
    /// Controller responsável pela manutenção dos dados relacionados aos produtos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Endpoint para inserir um novo produto
        /// somente administradores podem inserir um novo produto
        /// </summary>
        /// <param name="produto">Dados do novo produto</param>
        /// <returns>O id do produto inserido</returns>
        [HttpPost]
        [Authorize(Roles = PermissaoSistema.Administrador)]
        public IActionResult InserirProduto(Produto produto)
        {
            var idProduto = _produtoRepository.InserirProduto(produto);
            return Ok(idProduto);
        }

        /// <summary>
        /// endpoint para pesquisar todos os produtos
        /// </summary>
        /// <returns>Todos os produtos cadastrados</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PesquisarProduto()
        {
            return Ok(_produtoRepository.PesquisarProduto());
        }

        /// <summary>
        /// endpoint para deletar um produto específico
        /// somente administradores podem inserir um novo produto
        /// </summary>
        /// <param name="id">id do produto que deseja deletar</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete]
        [Authorize(Roles = PermissaoSistema.Administrador)]
        public IActionResult DeletarProduto(int id)
        {
            _produtoRepository.DeletarProduto(id);
            return NoContent();
        }
    }
}
