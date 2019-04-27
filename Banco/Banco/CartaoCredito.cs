using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class CartaoCredito
    {
        public double Limite { get; set; }
        public double ValorUtilizado { get; set; }

        public CartaoCredito()
        {
            this.Limite = 2000;
            this.ValorUtilizado = 0;
        }

        public void UsarCartao(double valor)
        {
            if (valor <= (this.Limite - this.ValorUtilizado))
            {
                this.Limite -= valor;
                this.ValorUtilizado += valor;
            }
            else
            {
                Console.WriteLine("Limite insuficiente!");
            }
        }

        public void PagamentoCartao(double valor)
        {
            if (valor > this.ValorUtilizado)
            {
                Console.WriteLine("O valor informado é menor que o limite disponível.", valor, this.ValorUtilizado);
                ExibirValorUtilizado();
            }
        }

        public void ExibirValorUtilizado()
        {

            Console.WriteLine("Valor a Pagar: R$ " + this.ValorUtilizado);
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine("Limite: " + this.Limite);
            Console.WriteLine("Limite Utilizado: " + this.ValorUtilizado);
        }
    }
}

