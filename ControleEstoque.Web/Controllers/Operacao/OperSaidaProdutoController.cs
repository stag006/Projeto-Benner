﻿using ControleEstoque.Web.Models;

namespace ControleEstoque.Web.Controllers.Operacao
{
    public class OperSaidaProdutoController : OperEntradaSaidaProdutoController
    {
        protected override string SalvarPedido(EntradaSaidaProdutoViewModel dados)
        {
            return ProdutoModel.SalvarPedidoSaida(dados.Data, dados.Produtos);
        }
    }
}