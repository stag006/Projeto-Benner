﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models.Maps
{
    public class GrupoProdutoMap : EntityTypeConfiguration<GrupoProdutoModel>
    {
        public GrupoProdutoMap()
        {
            ToTable("grupo_produto");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}