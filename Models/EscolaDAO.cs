using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEscola.Database;
using MySql.Data.MySqlClient;
using ProjetoEscola.Helpers;

namespace ProjetoEscola.Models
{
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Escola escola)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "insert into Escola values(null, @nomeFan, @razaoSoc, @cnpj, @inscEst, @tipo, @data, @nomeResp, @telResp, @telEsc," +
                    "@emailEsc, @rua, @numRua, @bairro, @cep, @complemento, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nomeFan", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razaoSoc", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscEst", escola.InscricaoEst);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data", escola.DataCriacao);
                comando.Parameters.AddWithValue("@nomeResp", escola.NomeResp);
                comando.Parameters.AddWithValue("@telResp", escola.TelefoneResp);
                comando.Parameters.AddWithValue("@telEsc", escola.TelefoneEscola);
                comando.Parameters.AddWithValue("@emailEsc", escola.Email);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numRua", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@cep", escola.Cep);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);


                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Escola escola)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = $"update Escola set nome_fantasia_esc = @nomeFan, razao_social_esc = @razaoSoc, " +
                    $"cnpj_esc = @cnpj, insc_esc = @inscEst, tipo_esc = @tipo, data_criacao_esc = @data, " +
                    $"responsavel_esc = @nomeResp, responsavel_telefone_escola_esc = @telResp, telefone_esc = @telEsc," +
                    $"email_esc = @emailEsc, rua_esc = @rua, numero_esc = @numRua, bairro_esc = @bairro, " +
                    $"cep_esc = @cep, complemento_esc = @complemento, cidade_esc = @cidade, estado_esc = @estado where id_esc = @id;";

                comando.Parameters.AddWithValue("@nomeFan", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razaoSoc", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscEst", escola.InscricaoEst);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data", escola.DataCriacao);
                comando.Parameters.AddWithValue("@nomeResp", escola.NomeResp);
                comando.Parameters.AddWithValue("@telResp", escola.TelefoneResp);
                comando.Parameters.AddWithValue("@telEsc", escola.TelefoneEscola);
                comando.Parameters.AddWithValue("@emailEsc", escola.Email);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numRua", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@cep", escola.Cep);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);
                comando.Parameters.AddWithValue("@id", escola.Id);


                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Escola escola)
        {
            try
            {

                Conexao conn = new Conexao();
                var comando = conn.Query();

                comando.CommandText = "delete from escola where id_esc = @id";

                comando.Parameters.AddWithValue("@id", escola.Id);
                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro ao Apagar os dados do Banco de dados");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Escola> List()
        {
            try
            {
                var lista = new List<Escola>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM escola";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var escola = new Escola();

                    escola.Id = reader.GetInt32("id_esc");
                    escola.NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_esc");
                    escola.RazaoSocial = DAOHelper.GetString(reader, "razao_social_esc");
                    escola.Cnpj = DAOHelper.GetString(reader, "cnpj_esc");
                    escola.InscricaoEst = DAOHelper.GetString(reader, "insc_esc");
                    escola.Tipo = DAOHelper.GetString(reader, "tipo_esc");
                    escola.DataCriacao = DAOHelper.GetDateTime(reader, "data_criacao_esc");
                    escola.NomeResp = DAOHelper.GetString(reader, "responsavel_esc");
                    escola.TelefoneResp = DAOHelper.GetString(reader, "responsavel_telefone_escola_esc");
                    escola.Email = DAOHelper.GetString(reader, "email_esc");
                    escola.TelefoneEscola = DAOHelper.GetString(reader, "telefone_esc");
                    escola.Rua = DAOHelper.GetString(reader, "rua_esc");
                    escola.Numero = reader.GetInt32("numero_esc");
                    escola.Bairro = DAOHelper.GetString(reader, "bairro_esc");
                    escola.Complemento = DAOHelper.GetString(reader, "complemento_esc");
                    escola.Cep = DAOHelper.GetString(reader, "cep_esc");
                    escola.Cidade = DAOHelper.GetString(reader, "cidade_esc");
                    escola.Estado = DAOHelper.GetString(reader, "estado_esc");

                    lista.Add(escola);
                }

                reader.Close();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}