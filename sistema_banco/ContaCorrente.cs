using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    public class ContaCorrente : Conta
    {

        public ContaCorrente()
        {

        }
        public ContaCorrente(int nConta, Cliente tit, double saldo)
        {
            this.nConta = nConta;
            this.titular = tit;
            this.saldo = saldo;
        }
        public ContaCorrente(int nConta, Cliente tit,Cliente cliente2, double saldo)
        {
            this.nConta = nConta;
            this.titular = tit;
            this.cliente2 = cliente2;
            this.saldo = saldo;
        }
    }
}
