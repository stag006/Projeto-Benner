﻿using Dapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ControleEstoque.Web.Models
{
    public class PerfilViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual List<UsuarioModel> Usuarios { get; set; }

        public PerfilViewModel()
        {
            this.Usuarios = new List<UsuarioModel>();
        }
    }
}