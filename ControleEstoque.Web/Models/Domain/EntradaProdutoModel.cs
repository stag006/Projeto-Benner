using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models.Domain
{
    public class EntradaProdutoModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        public virtual ProdutoModel Produto { get; set; }
    }
}