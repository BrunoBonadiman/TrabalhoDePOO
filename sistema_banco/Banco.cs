using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    public class Banco
    {
        public Gerente gerente { get; set; }
        public List<Funcionario> funcionarios { get; set; }
        public List<ContaCorrente> contaCorrentes { get; set; }
        public List<ContaPoupanca> contaPoupancas { get; set; }
        public List<Cliente> clientes { get; set; }

        public double emprestado { get; set; }
        public double receber { get; set; }
        public double total { get; set; }
       
        int matricula = 0;
        int cont = 0;
        public Banco() {
            this.funcionarios = new List<Funcionario>();
            this.clientes = new List<Cliente>();
        }
        public Banco(Gerente gerente){
            this.gerente = gerente;
            
        }
         
        
        public bool addGerente(Gerente gerente)
        {
            try{
                this.gerente = gerente;
                matricula += 1;
                gerente.matricula = matricula;
                Console.WriteLine("Matrícula: " + gerente.matricula);
            }
            catch(Exception e)
            { 
                Console.WriteLine("Erro: ", e);
                return false;
            }
            return true;
        }

        public bool CompSenha(string senha, string senha2)
        {
            return senha.Equals(senha2);
        }

        public bool acesso(string cpf, string senha)
        {
            return this.gerente.cpf.Equals(cpf) && this.gerente.senha.Equals(senha); 
        }
        public bool addFuncionario(Funcionario funcionario)
        {
            try
            {
                this.funcionarios.Add(funcionario);
                matricula += 1;
                funcionario.matricula = matricula;
                Console.WriteLine("Matrícula: " + funcionario.matricula);
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro: "+ e);
                return false;
            }
            return true;
        }

     
        public void removeFuncionario(Funcionario funcionario)
        {
            try
            {
                this.funcionarios.Remove(funcionario);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
            }
        }

        public void addContaCorrente(ContaCorrente conta, Cliente cliente)
        {
            try
            {
                this.contaCorrentes.Add(conta);
                this.clientes.Add(cliente);
                cont += 1;
                conta.nConta = cont;
                Console.WriteLine("N da conta: " + conta.nConta); 
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro: " + e);
            }
        }
       
    }
}
