using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Banco
    {
        public double Armazenar { get; set; }
        public double Emprestar { get; set; }
        public double Receber { get; set; }
        public List<Conta> Contas { get; set; }

        public int CountConta = 0;

        public Banco()
        {
            this.Armazenar = Armazenar;
            this.Emprestar = Emprestar;
            this.Receber = Receber;
            this.Contas = new List<Conta>();
            Gerente Gerente = new Gerente();
        }

        public void AdicionaConta(Conta conta)
        {
            this.Contas.Add(conta);
        }

        public void AdicionaContaDep(Conta conta, Conta dependente)
        {
            this.Contas.Add(conta);
            this.Contas.Add(dependente);
        }

        public void RemoverConta(Conta conta)
        {
            this.Contas.Remove(conta);
        }

        public void RemoverContaDep(Conta conta, Conta dependente)
        {
            this.Contas.Remove(conta);
            this.Contas.Remove(dependente);
        }

        public void AdicionaContaConjunta(Conta conta, Conta dependente)
        {
            this.Contas.Add(conta);
            this.Contas.Add(dependente);
        }

        public void ExibirContas()
        {
            foreach (Conta conta in Contas)
            {
                conta.ExibirConta();
            }
        }

        public void PesquisarConta(int numero)
        {

            foreach (Conta conta in Contas)
            {
                if (conta.Numero == numero)
                {
                    conta.ExibirConta();
                }
                else
                    Console.WriteLine("A conta informada não foi encontrada!");

            }
        }

        public bool PesquisarConta2(int numero)
        {
            bool verifica = false;
            foreach (Conta conta in Contas)
            {
                if (conta.Numero == numero)
                {
                    return true;
                }
                else
                    return false;

            }
            return verifica;
        }

    }
}
