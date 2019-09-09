﻿using ControleEstoque.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models.Maps
{
    public class InventarioEstoqueMap : EntityTypeConfiguration<InventarioEstoqueModel>
    {
        public InventarioEstoqueMap()
        {
            ToTable("inventario_estoque");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Data).HasColumnName("data").IsRequired();
            Property(x => x.Motivo).HasColumnName("motivo").HasMaxLength(100).IsOptional();
            Property(x => x.QuantidadeEstoque).HasColumnName("quant_estoque").IsRequired();
            Property(x => x.QuantidadeEstoque).HasColumnName("quant_inventario").IsRequired();

            Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            HasRequired(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto).WillCascadeOnDelete(false);
        }
    }
}