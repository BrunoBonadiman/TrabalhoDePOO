using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Emprestimo
    {
        public double ValorInicial { get; set; }
        public double Juros { get; set; }
        public double ValorDasParcelas { get; set; }
        public double ValorTotal { get; set; }
        public double ValorPago { get; set; }
        public int Time { get; set; }

        public Emprestimo()
        {
            this.Juros = 0.15;
        }

        public void SimularEmprestimo(Cliente c, double x, int periodo)
        {
            if (c.NomeSujo)
            {
                Console.WriteLine("Operação negada! ! ! !\nEste cliente possui o nome sujo");
            }
            else
            {
                Boolean JaPossue = false;
                foreach (Emprestimo emprestimo in c.Emprestimos)
                {
                    if (emprestimo.ValorPago != 0)
                    {
                        JaPossue = true;
                        break;
                    }
                }
                if (JaPossue)
                {
                    Console.WriteLine("Operação negada!!!!\nEste cliente possue um emprestimo em aberto");
                }
                else
                {
                    this.ValorInicial = x;
                    this.Time = periodo;
                    this.ValorTotal = this.ValorInicial + this.ValorInicial * this.Juros * this.Time;
                    this.ValorPago = -this.ValorTotal;
                    this.ValorDasParcelas = this.ValorTotal / this.Time;
                    ExibirEmprestimo();
                }
            }
        }
        public void ExibirEmprestimo()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("DADOS DO EMPRÉSTIMO SOLICITADO:");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Valor do Emprestimo: R$ " + this.ValorInicial);
            Console.WriteLine("Taxa de juros: {0} %", this.Juros);
            Console.WriteLine("Valor das parcelas: R$ " + this.ValorDasParcelas);
            Console.WriteLine("Nº de parcelas: {0}x", this.Time);
            Console.WriteLine("Valor Pago: R$ " + this.ValorPago);
            Console.WriteLine("--------------------------------------------------------");
        }
        public void PagarParcela()
        {
            this.ValorPago += this.ValorDasParcelas;
            this.Time--;
            ExibirEmprestimo();
        }
    }
}
