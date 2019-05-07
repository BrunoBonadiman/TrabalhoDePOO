using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    public class Conta
    {
        public int nConta { get; set; }
        public Cliente titular { get; set; } 
        public Cliente cliente2 { get; set; }
        public double saldo { get; set; }

    }
}
