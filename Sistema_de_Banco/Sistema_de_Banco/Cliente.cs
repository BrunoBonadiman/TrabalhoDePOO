using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Banco
{
    [Serializable]
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool NomeSujo { get; set; }

        public Cliente()
        { }

        public Cliente(string nome, string cpf, string telefone, string email, DateTime? dataNascimento)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Email = email;
            this.DataNascimento = dataNascimento;
        }
    }
}
