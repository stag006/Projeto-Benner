using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace ControleEstoque.Web.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }
    }
}