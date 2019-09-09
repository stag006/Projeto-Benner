using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models.Maps
{
    public class UnidadeMedidaMap : EntityTypeConfiguration<UnidadeMedidaModel>
    {
        public UnidadeMedidaMap()
        {
            ToTable("unidade_medida");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnName("nome").HasMaxLength(30).IsRequired();
            Property(x => x.Sigla).HasColumnName("sigla").HasMaxLength(3).IsRequired();
            Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}