using ControleEstoque.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models.Maps
{
    public class EntradaProdutoMap : EntityTypeConfiguration<EntradaProdutoModel>
    {
        public EntradaProdutoMap()
        {
            ToTable("entrada_produto");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            Property(x => x.Data).HasColumnName("data").IsRequired();
            Property(x => x.Quantidade).HasColumnName("quant").IsRequired();

            Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            HasRequired(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto).WillCascadeOnDelete(false);
        }
    }
}