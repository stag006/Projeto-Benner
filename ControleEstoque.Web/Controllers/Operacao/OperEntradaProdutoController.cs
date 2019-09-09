using ControleEstoque.Web.Controllers.Operacao;
using ControleEstoque.Web.Models;
using System.Web.Mvc;

namespace ControleEstoque.Web.Controllers
{
    public class OperEntradaProdutoController : OperEntradaSaidaProdutoController
    {
        protected override string SalvarPedido(EntradaSaidaProdutoViewModel dados)
        {
            return ProdutoModel.SalvarPedidoEntrada(dados.Data, dados.Produtos);
        }
    }
}