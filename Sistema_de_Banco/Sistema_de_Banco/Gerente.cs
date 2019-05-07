using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    public class Gerente : Funcionario
    {

        public Banco banco;

        public Gerente()
        {

        }
        public Gerente(string nome, string email, string cpf, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.cpf = cpf;
            this.senha = senha;
        }
    }
}
