using Sistema_de_Banco;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    [Serializable]
    public class Conta
    {
        public int nConta { get; set; }
        public Cliente titular1 { get; set; }
        public Cliente cliente2 { get; set; }
        public double saldo { get; set; }
        public int TipoConta { get; set; }

    }
}
