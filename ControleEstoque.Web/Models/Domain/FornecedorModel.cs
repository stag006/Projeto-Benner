﻿using Dapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ControleEstoque.Web.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public TipoPessoa Tipo { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int IdPais { get; set; }
        public virtual PaisModel Pais { get; set; }
        public int IdEstado { get; set; }
        public virtual EstadoModel Estado { get; set; }
        public int IdCidade { get; set; }
        public virtual CidadeModel Cidade { get; set; }
        public bool Ativo { get; set; }

        public static int RecuperarQuantidade()
        {
            var ret = 0;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();

                ret = conexao.ExecuteScalar<int>("select count(*) from fornecedor");
            }

            return ret;
        }

        public static List<FornecedorModel> RecuperarLista(int pagina = 0, int tamPagina = 0, string filtro = "", string ordem = "")
        {
            var ret = new List<FornecedorModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();

                var filtroWhere = "";
                if (!string.IsNullOrEmpty(filtro))
                {
                    filtroWhere = string.Format(" where lower(nome) like '%{0}%'", filtro.ToLower());
                }

                var pos = (pagina - 1) * tamPagina;
                var paginacao = "";
                if (pagina > 0 && tamPagina > 0)
                {
                    paginacao = string.Format(" offset {0} rows fetch next {1} rows only",
                        pos > 0 ? pos - 1 : 0, tamPagina);
                }

                var sql =
                    "select id, nome, tipo, telefone, contato, logradouro, numero, complemento, cep, ativo, " +
                    "razao_social as RazaoSocial, num_documento as NumDocumento, id_pais as IdPais, " +
                    "id_estado as IdEstado, id_cidade as IdCidade" +
                    " from fornecedor" +
                    filtroWhere +
                    " order by " + (!string.IsNullOrEmpty(ordem) ? ordem : "nome") +
                    paginacao;

                ret = conexao.Query<FornecedorModel>(sql).ToList();
            }

            return ret;
        }

        public static FornecedorModel RecuperarPeloId(int id)
        {
            FornecedorModel ret = null;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();

                var sql =
                    "select id, nome, tipo, telefone, contato, logradouro, numero, complemento, cep, ativo, " +
                    "razao_social as RazaoSocial, num_documento as NumDocumento, id_pais as IdPais, " +
                    "id_estado as IdEstado, id_cidade as IdCidade " +
                    "from fornecedor " +
                    "where (id = @id)";
                var parametros = new { id };
                ret = conexao.Query<FornecedorModel>(sql, parametros).SingleOrDefault();
            }

            return ret;
        }

        public static bool ExcluirPeloId(int id)
        {
            var ret = false;

            if (RecuperarPeloId(id) != null)
            {
                using (var conexao = new SqlConnection())
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                    conexao.Open();

                    var sql = "delete from fornecedor where (id = @id)";
                    var parametros = new { id };
                    ret = (conexao.Execute(sql, parametros) > 0);
                }
            }

            return ret;
        }

        public int Salvar()
        {
            var ret = 0;

            var model = RecuperarPeloId(this.Id);

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();

                if (model == null)
                {
                    var sql =
                        "insert into fornecedor (nome, razao_social, num_documento, tipo, telefone, contato, logradouro," +
                        " numero, complemento, cep, id_pais, id_estado, id_cidade, ativo) values (@nome, @razao_social, @num_documento," +
                        " @tipo, @telefone, @contato, @logradouro, @numero, @complemento, @cep, @id_pais, @id_estado, @id_cidade, @ativo);" +
                        " select convert(int, scope_identity())";
                    var parametros = new
                    {
                        nome = this.Nome,
                        razao_social = this.RazaoSocial ?? "",
                        num_documento = this.NumDocumento ?? "",
                        tipo = this.Tipo,
                        telefone = this.Telefone ?? "",
                        contato = this.Contato ?? "",
                        logradouro = this.Logradouro ?? "",
                        numero = this.Numero ?? "",
                        complemento = this.Complemento ?? "",
                        cep = this.Cep ?? "",
                        id_pais = this.IdPais,
                        id_estado = this.IdEstado,
                        id_cidade = this.IdCidade,
                        ativo = (this.Ativo ? 1 : 0)
                    };
                    ret = conexao.ExecuteScalar<int>(sql, parametros);
                }
                else
                {
                    var sql =
                        "update fornecedor set nome=@nome, razao_social=@razao_social, num_documento=@num_documento," +
                        " tipo=@tipo, telefone=@telefone, contato=@contato, logradouro=@logradouro, numero=@numero, complemento=@complemento," +
                        " cep=@cep, id_pais=@id_pais, id_estado=@id_estado, id_cidade=@id_cidade, ativo=@ativo where id = @id";
                    var parametros = new
                    {
                        id = this.Id,
                        nome = this.Nome,
                        razao_social = this.RazaoSocial ?? "",
                        num_documento = this.NumDocumento ?? "",
                        tipo = this.Tipo,
                        telefone = this.Telefone ?? "",
                        contato = this.Contato ?? "",
                        logradouro = this.Logradouro ?? "",
                        numero = this.Numero ?? "",
                        complemento = this.Complemento ?? "",
                        cep = this.Cep ?? "",
                        id_pais = this.IdPais,
                        id_estado = this.IdEstado,
                        id_cidade = this.IdCidade,
                        ativo = (this.Ativo ? 1 : 0)
                    };
                    if (conexao.Execute(sql, parametros) > 0)
                    {
                        ret = this.Id;
                    }
                }
            }

            return ret;
        }
    }
}