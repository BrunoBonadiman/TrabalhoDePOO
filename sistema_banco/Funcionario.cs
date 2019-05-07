using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    public class Funcionario
    {
        public int matricula { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string senha { get; set; }

        public string email { get; set; }

        public Funcionario()
        {}

        public Funcionario( string nome, string cpf, string email, string senha)
        { 
            this.nome = nome;
            this.email = email;
            this.cpf = cpf; 
            this.senha = senha;
        }
    }
}
