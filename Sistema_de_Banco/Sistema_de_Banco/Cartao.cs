using Sistema_de_Banco;
using System;
namespace SistemaBancario
{
    [Serializable]
    public class Cartao
    {
        public int Numero { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public double TaxaChequeEspecial { get; set; }

        public Cartao(int Numero, Cliente Titular, double Limite)
        {
            this.Numero = Numero++;
            this.Titular = Titular;
            this.Saldo = 0;
            this.TaxaChequeEspecial = 0.10;
        }

        public bool pagaCartao(double valor)
        {
            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                return true;
            }

            return false;
        }

        public void usaCartao(double valor)
        {
            if (this.Limite >= (this.Saldo + valor))
            {
                this.Saldo += valor;
            }
            else
            {
                valor += valor * TaxaChequeEspecial;
                this.Saldo += valor;
            }
        }

    }
}
