using Sistema_de_Banco;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    [Serializable]
    public class ContaPoupanca : Conta
    {
        public double Rendimento = 0.01;

        public ContaPoupanca(int numero, double saldo, Cliente titular1)
        {
            this.saldo = saldo;
            this.nConta = numero++;
            this.titular1 = titular1;
            this.TipoConta = 1;
        }

        public ContaPoupanca(int numero, double saldo, Cliente titular1, Cliente cliente2)
        {
            this.saldo = saldo;
            this.nConta = numero++;
            this.titular1 = titular1;
            this.cliente2 = cliente2;
            this.TipoConta = 2;
        }

        public bool Saca(double valor)
        {
            if (this.saldo >= valor)
            {
                this.saldo -= valor;
                return true;
            }
            return false;
        }

        public void Deposita(double valor)
        {
            this.saldo += valor;
        }

        public bool Transfere(double valor, ContaPoupanca destino)
        {
            if (this.Saca(valor))
            {
                destino.saldo += valor;
                return true;
            }
            return false;
        }

        public bool Transfere(double valor, ContaCorrente destino)
        {
            if (this.Saca(valor))
            {
                destino.Deposita(valor);
                return true;
            }
            return false;
        }
    }
}
