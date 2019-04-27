using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Conta
    {
        public int Numero { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; set; }
        public int Tipo { get; set; }
        public double TaxaDeAcrescimo { get; set; }
        public double TaxaDeDescrescimo { get; set; }
        public double ChequeEspecial { get; set; }
        public double TaxaCheque { get; set; }
        public List<Cliente> Clientes { get; set; }
        public CartaoCredito Cartao { get; set; }

        public int CountClientes = 0;

        public Conta()
        {

        }
        public Conta(Cliente titular)
        {

            this.Titular = titular;
            this.Titular.IdCliente = CountClientes;
            this.Numero = CountClientes;
            this.Clientes = new List<Cliente>();
            this.Clientes.Add(titular);
            this.Saldo = 100;
            this.TaxaDeDescrescimo = 0.01;
            this.TaxaDeAcrescimo = 0.03;
            this.TaxaCheque = 0.15;
            if (this.Tipo == 1) //Nesse caso define 1 como Conta Corrente
            {
                if (Sacar(Saldo))
                {
                    this.Saldo -= Saldo + (Saldo * this.TaxaDeDescrescimo);
                }
                this.Saldo -= Saldo + (Saldo * this.TaxaCheque);
            }
            else //Para outro valor a conta e poupanca
            {
                this.Saldo += Saldo + (Saldo * this.TaxaDeAcrescimo);
            }        
        }

        public Conta(Cliente titular, Cliente dependente)
        {

            this.Numero = CountClientes;
            this.Titular.IdCliente = CountClientes;
            dependente.IdCliente = this.Titular.IdCliente;
            this.Clientes = new List<Cliente>();
            this.Clientes.Add(titular);
            this.Clientes.Add(dependente);
            this.Saldo = 100;
            this.TaxaDeDescrescimo = 0.01;
            this.TaxaDeAcrescimo = 0.03;
            this.TaxaCheque = 0.15;
            if (this.Tipo == 1)//defini 1 como conta corrente
            {

                if (Sacar(Saldo))
                {
                    this.Saldo -= Saldo + (Saldo * this.TaxaDeDescrescimo);
                }
                this.Saldo -= Saldo + (Saldo * this.TaxaCheque);
            }
            else//para outro valor a conta e poupanca
            {
                this.Saldo += Saldo + (Saldo * this.TaxaDeAcrescimo);
            }
        }
        public Conta(int n, int t)
        {
            Numero = n;
            Titular.IdCliente = Numero;
            Tipo = t;
        }
        public double Consulta()
        {
            Console.WriteLine("Saldo =\t" + Saldo);
            return this.Saldo;
        }
        public bool Sacar(double valor)
        {
            if (this.Saldo >= valor)
            {
                Saldo = Saldo - valor;
                Console.WriteLine("Saldo =\t" + Saldo);
                return true;
            }
            else
                Console.WriteLine("Saldo insuficiente  ! ! ! !");
            return false;
        }
        public bool Deposita(double valor)
        {
            this.Saldo = this.Saldo + valor;
            return true;
        }
        public bool TransfereDe(double valor, Conta fonte)
        {
            bool verifica;
            verifica = fonte.Sacar(valor);
            if (verifica)
            {
                return this.Deposita(valor);
            }
            else
            {
                return false;
            }
        }
        public void CartaoCred(CartaoCredito card)
        {
            this.Cartao = card;
        }
        public void AdicionaCliente(Cliente Cliente)
        {
            if (this.Clientes.Count <= 2)
            {
                this.Clientes.Add(Cliente);
            }
        }
        public void ExibirConta()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\n\nConta(s):");
            if (this.Clientes.Count == 1)
            {
                Console.WriteLine("Esta não é uma conta conjunta.");
            }
            else
            {
                Console.WriteLine("Esta é uma cponta conjunta.");
            }
            Console.WriteLine("Número da Conta:" + this.Numero);
            Console.WriteLine("Tipo da conta:" + this.Tipo);
            Console.WriteLine("Tipo do Saldo:" + this.Saldo);
            foreach (Cliente Cliente in this.Clientes)
            {
                Cliente.ListarCliente();
            }
            Console.WriteLine("----------------------------------------");
        }
        public void ExibirClientes()
        {
            foreach (Cliente cliente in this.Clientes)
            {
                Titular.ListarCliente();
            }
        }
        public void AlterarConta(Cliente cliente)
        {
            Cliente novo = new Cliente();
            this.Titular.Endereco = novo.Endereco;
            this.Titular.Email = novo.Email;
            this.Titular.Telefone = novo.Telefone;
        }
        public void AlterarConta(Cliente cliente, Cliente dependente)
        { }
    }
}
