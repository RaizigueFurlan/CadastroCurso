using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEscola.Models
{
    public class Escola
    {
        public int Id { get; set; } = 0;
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEst { get; set; }
        public string NomeResp { get; set; }
        public string TelefoneResp { get; set; }
        public string TelefoneEscola { get; set; }
        public string Email { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string Tipo { get; set; }

        public void SetTipo(bool tipo)
        {
            this.Tipo = tipo == true ? "Publica" : "Privada";
        }
    }
}