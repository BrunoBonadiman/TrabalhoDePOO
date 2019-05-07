using Sistema_de_Banco;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    [Serializable]
    public class ContaCorrente : Conta
    {
        public double Emprestimo;
        double TaxaJuros = 0.1;
        double TaxaMovimentacao = 0.01;

        public ContaCorrente()
        {

        }
        public ContaCorrente(int nConta, Cliente tit, double saldo)
        {
            this.nConta = nConta++;
            this.titular1 = tit;
            this.saldo = saldo;
            this.TipoConta = 1;
        }
        public ContaCorrente(int nConta, Cliente tit, Cliente cliente2, double saldo)
        {
            this.nConta = nConta++;
            this.titular1 = tit;
            this.cliente2 = cliente2;
            this.saldo = saldo;
            this.TipoConta = 2;
        }
        public bool Saca(double valor)
        {
            if (this.saldo >= valor)
            {
                valor -= valor * TaxaMovimentacao;
                this.saldo -= valor;
                return true;
            }
            return false;
        }

        public void Deposita(double valor)
        {
            valor -= valor * TaxaMovimentacao;
            this.saldo += valor;
        }

        public bool Transfere(double valor, ContaCorrente destino)
        {
            if (this.Saca(valor))
            {
                valor -= valor * TaxaMovimentacao;
                destino.saldo += valor;
                return true;
            }
            return false;
        }

        public bool Transfere(double valor, ContaPoupanca destino)
        {
            if (this.Saca(valor + valor * TaxaMovimentacao))
            {
                destino.Deposita(valor);
                return true;
            }
            return false;
        }

        public bool PedeEmprestimo(double valor)
        {
            if (this.titular1.NomeSujo)
            {
                return false;
            }
            if (this.TipoConta == 2)
            {
                if (this.cliente2.NomeSujo)
                {
                    return false;
                }
            }
            this.Emprestimo += valor;
            this.saldo += valor;
            return true;

        }

        public bool PagarEmprestimo(double valor)
        {
            if (this.saldo >= valor)
            {
                this.Emprestimo -= valor;
                valor += valor * TaxaJuros;
                this.saldo -= valor;
                return true;
            }
            return false;
        }
    }
}
