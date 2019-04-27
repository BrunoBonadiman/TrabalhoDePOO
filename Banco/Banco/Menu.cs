using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Menu
    {
        //public Conta Conta { get; set; }
        double valor;
        Conta Conta = new Conta();
        Conta dependente = new Conta();
        Cliente Cliente = new Cliente();
        Banco Banco = new Banco();
        Gerente G = new Gerente();
        Gerente Gerente = new Gerente();
        List<Conta> Contas = new List<Conta>();
        List<Cliente> ListaClientes = new List<Cliente>();
        Conta aux = new Conta
        {

            Numero = 1,
            Saldo = 500,
            Tipo = 1,
            Titular = new Cliente
            {
                Nome = "nayara",
                Cpf = "000.000.000.00",
                Email = "nayaradias@gmail.com",
            }
        };
        public void MenuOpcoes()
        {
            int Opcao = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("***************| MENU DE OPÇÕES (BANCO) |********************");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("[ 1 ] - Menu Gerente:");
                Console.WriteLine("[ 2 ] - Editar Conta:");
                Console.WriteLine("[ 3 ] - Realizar Transferência:");
                Console.WriteLine("[ 4 ] - Realizar Depósito:");
                Console.WriteLine("[ 5 ] - Realizar Saque:");
                Console.WriteLine("[ 6 ] - Listar Contas:");
                Console.WriteLine("[ 7 ] - Listar Clientes:");
                Console.WriteLine("[ 8 ] - :");
                Console.WriteLine("[ 9 ] - :");
                Console.WriteLine("[ 0 ] - Sair do Sistema:");
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("Escolha uma das opções acima: ");

                try
                {
                    Opcao = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Opção Inválida, pressione uma tecla para tentar novamente...");
                    Console.ReadKey();
                    MenuOpcoes();
                }
                //Console.WriteLine("\t\t\t\t---------------------------------------------");
                //Console.WriteLine("\t\t\t\t\n");
                //Console.WriteLine("\t\t\t\t*********************************************");
                //Console.WriteLine("\t\t\t\tPara criar Conta--------- [GRERENTE]------[1]");
                //Console.WriteLine("\t\t\t\tPara deletar Conta------- [GRERENTE]------[2]");
                //Console.WriteLine("\t\t\t\t*********************************************");
                //Console.WriteLine("\t\t\t\t\n");
                //Console.WriteLine("\t\t\t\tPara editar Conta                         [3]");
                //Console.WriteLine("\t\t\t\tPara realizar transferencia               [4]");//ok
                //Console.WriteLine("\t\t\t\tPara realizar deposito                    [5]");//ok
                //Console.WriteLine("\t\t\t\tPara realizaar saque                      [6]");//ok
                //Console.WriteLine("\t\t\t\tPara Consultar saldo                      [7]");//ok
                //Console.WriteLine("\t\t\t\tPara Listar Contas                        [8]");
                //Console.WriteLine("\t\t\t\tPara Listar Clientes                      [9]");
                //Console.WriteLine("\t\t\t\tPara sair                                 [0]");
                //Console.WriteLine("\t\t\t\t---------------------------------------------");
                //Opcao = Convert.ToInt32(Console.ReadLine());
                if (Opcao == 1)
                {
                    int dep;
                    Console.WriteLine("Digite o nome do gerente");
                    G.Nome = Console.ReadLine();
                    Console.WriteLine("Digite a matricula:");
                    G.Matricula = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite a senha:");
                    G.Senha = Convert.ToInt32(Console.ReadLine());
                    if (Gerente.Nome == G.Nome && Gerente.Matricula == G.Matricula && Gerente.Senha == G.Senha)
                    {
                        Console.WriteLine("Adicionar um Cliente digite 1:");
                        Console.WriteLine("Adicionar dois Cliente digite 2:");
                        dep = Convert.ToInt32(Console.ReadLine());
                        if (dep == 1)
                        {
                            Opcao1();
                        }
                        else if (dep == 2)
                        {
                            Opcao1_2();
                        }
                        else
                            Console.WriteLine("Escolha invalida");
                    }
                    else
                        Console.WriteLine("Permicao negada ! ! ! ! \n");
                }
                else if (Opcao == 2)
                {
                    int dep;
                    Console.WriteLine("Digite o nome do gerente");
                    G.Nome = Console.ReadLine();
                    Console.WriteLine("Digite a matricula:");
                    G.Matricula = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite a senha:");
                    G.Senha = Convert.ToInt32(Console.ReadLine());
                    if (Gerente.Nome == G.Nome && Gerente.Matricula == G.Matricula && Gerente.Senha == G.Senha)
                    {
                        Console.WriteLine("Deletar uma Conta Normal 1:");
                        Console.WriteLine("Deletar uma Conta Conjunta 2:");
                        dep = Convert.ToInt32(Console.ReadLine());
                        if (dep == 1)
                        {
                            Opcao2();
                        }
                        else if (dep == 2)
                        {
                            Opcao2_2();
                        }
                        else
                            Console.WriteLine("Escolha invalida");
                    }
                    else
                        Console.WriteLine("Permicao negada ! ! ! ! \n");
                }
                else if (Opcao == 3)
                {
                    int numAux;
                    Console.Write("Digite o numero Da conta que dejeja alterar:");
                    numAux = Convert.ToInt32(Console.ReadLine());
                    Banco.PesquisarConta(numAux);
                }
                else if (Opcao == 4)
                {
                    Opcao4();
                }
                else if (Opcao == 5)
                {
                    Opcao5();
                }
                else if (Opcao == 6)
                {
                    Opcao6();
                }
                else if (Opcao == 7)
                {
                    Opcao7();
                }
                else if (Opcao == 8)
                {
                    Opcao8();
                }
                else if (Opcao == 9)
                {
                    Opcao9();
                }
                else if (Opcao == 0)
                {
                    Console.WriteLine("Encerrando . . . . . . . . .");
                }
                else
                    Console.WriteLine("Opção invalida ! ! ! !");
            }
            while (Opcao != 0);
        }
        public void Opcao1()
        {
            Conta c = new Conta();
            Console.WriteLine("Digite o Nome:");
            c.Titular.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Cpf:");
            c.Titular.Cpf = Console.ReadLine();
            Console.WriteLine("Digite a Data de nascimento:");
            c.Titular.DataNascimento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o Email:");
            c.Titular.Email = Console.ReadLine();
            Banco.AdicionaConta(c);
        }
        public void Opcao1_2()
        {
            Console.WriteLine("Digite o Nome do Titular:");
            Conta.Titular.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Titular do Cpf:");
            Conta.Titular.Cpf = Console.ReadLine();
            Console.WriteLine("Digite a Data de nascimento do Titular:");
            Conta.Titular.DataNascimento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o Email do Titular:");
            Conta.Titular.Email = Console.ReadLine();
            Console.WriteLine("Digite o Nome do Dependente:");
            dependente.Titular.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Titular do Dependente:");
            dependente.Titular.Cpf = Console.ReadLine();
            Console.WriteLine("Digite a Data de nascimento do Dependente:");
            dependente.Titular.DataNascimento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o Email do Dependente:");
            dependente.Titular.Email = Console.ReadLine();
            Banco.AdicionaContaDep(Conta, dependente);
        }
        public void Opcao2()
        {
            Console.Clear();
            Banco.RemoverConta(Conta);
        }
        public void Opcao2_2()
        {
            Console.Clear();
            Banco.RemoverContaDep(Conta, dependente);

        }
        public void Opcao3()
        {
            Console.Clear();
            Console.WriteLine("Digite o numero da conta:");
            Conta.Numero = Convert.ToInt32(Console.ReadLine());
            Conta.AlterarConta(Conta.Titular);
        }
        public void Opcao4()
        {
            Console.Clear();
            valor = 0;
            Console.WriteLine("Digite o numero da conta fonte:");
            Conta.Numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o valor que deseja tranferir:");
            valor = Convert.ToDouble(Console.ReadLine());
            if (Banco.PesquisarConta2(Conta.Numero))
            {
                aux.TransfereDe(valor, Conta);
            }
            else
                Console.WriteLine("Conta não encontarda");
        }
        public void Opcao5()
        {
            Console.Clear();
            valor = 0;
            Console.WriteLine("Digite o numero da conta:");
            Conta.Numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o valor que deseja sacar:");
            valor = Convert.ToDouble(Console.ReadLine());
            if (Banco.PesquisarConta2(Conta.Numero))
            {
                Conta.Deposita(valor);
            }
            else
                Console.WriteLine("Conta não encontarda");
        }
        public void Opcao6()
        {
            Console.Clear();
            valor = 0;
            Console.WriteLine("Digite o numero da conta:");
            Conta.Numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o valor que deseja sacar:");
            valor = Convert.ToDouble(Console.ReadLine());
            if (Banco.PesquisarConta2(Conta.Numero))
            {
                Conta.Sacar(valor);
            }
            else
                Console.WriteLine("Conta não encontarda");
        }
        public void Opcao7()
        {
            Console.Clear();
            Console.WriteLine("Digite o numero da conta:");
            Conta.Numero = Convert.ToInt32(Console.ReadLine());
            if (Banco.PesquisarConta2(Conta.Numero))
            {
                Conta.Consulta();
            }
            else
                Console.WriteLine("Conta não encontrada");
        }
        public void Opcao8()
        {
            Console.Clear();
            Banco.ExibirContas();
        }
        public void Opcao9()
        {
            Console.Clear();
            Conta.ExibirClientes();
        }
    }
}
