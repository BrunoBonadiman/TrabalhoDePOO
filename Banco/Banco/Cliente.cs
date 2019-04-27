using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public bool NomeSujo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Conta Conta { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente()
        {
            this.IdCliente = IdCliente;
            this.Nome = Nome;
            this.Endereco = Endereco;
            this.Cpf = Cpf;
            this.Telefone = Telefone;
            this.Email = Email;
            this.Conta = Conta;
            this.NomeSujo = false;
        }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string email, Conta conta)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Email = email;
            this.Conta = conta;
        }

        public void ListarCliente()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("INFORMAÇÕES DO CLIENTE");
            Console.WriteLine("*************************");
            Console.WriteLine("NOME : " + this.Nome);
            Console.WriteLine("STATUS: " + this.NomeSujo);
            Console.WriteLine("CPF: " + this.Cpf);
            Console.WriteLine("EMAIL: " + this.Email);
            Console.WriteLine("ID: " + this.IdCliente);
            Console.WriteLine("*************************");
        }

        public void SolicitarEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Add(emprestimo);
        }

        public void Adicionar(Conta Conta)
        {
            this.Conta = Conta;
        }
    }
}
