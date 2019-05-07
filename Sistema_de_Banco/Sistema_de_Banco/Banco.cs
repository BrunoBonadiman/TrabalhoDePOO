using Sistema_de_Banco;
using SistemaBancario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sistema_banco
{
    [Serializable]
    public class Banco
    {
        int NDC = 0;
        public Gerente gerente { get; set; }
        public List<Funcionario> funcionarios { get; set; }
        List<ContaCorrente> contaCorrentes = new List<ContaCorrente>();
        List<ContaPoupanca> contaPoupancas = new List<ContaPoupanca>();
        List<Cartao> Cartao = new List<Cartao>();
        public List<Cliente> clientes { get; set; }

        public double Armazenado { get; set; }
        public double Emprestado { get; set; }
        public double Receber { get; set; }
        public double total { get; set; }

        int matricula = 0;
        int cont = 0;
        public Banco()
        {
            this.funcionarios = new List<Funcionario>();
            this.clientes = new List<Cliente>();
        }
        public Banco(Gerente gerente)
        {
            this.gerente = gerente;

        }


        public bool addGerente(Gerente gerente)
        {
            try
            {
                this.gerente = gerente;
                matricula += 1;
                gerente.matricula = matricula;
                Console.WriteLine("Matrícula: " + gerente.matricula);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: ", e);
                return false;
            }
            return true;
        }

        public bool CompSenha(string senha, string senha2)
        {
            return senha.Equals(senha2);
        }

        public bool acesso(string cpf, string senha)
        {
            return this.gerente.cpf.Equals(cpf) && this.gerente.senha.Equals(senha);
        }
        public bool addFuncionario(Funcionario funcionario)
        {
            try
            {
                this.funcionarios.Add(funcionario);
                matricula += 1;
                funcionario.matricula = matricula;
                Console.WriteLine("Matrícula: " + funcionario.matricula);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
                return false;
            }
            return true;
        }


        public void removeFuncionario(Funcionario funcionario)
        {
            try
            {
                this.funcionarios.Remove(funcionario);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
            }
        }

        //public void addContaCorrente(ContaCorrente conta, Cliente cliente)
        //{
        //    try
        //    {
        //        this.contaCorrentes.Add(conta);
        //        this.clientes.Add(cliente);
        //        cont += 1;
        //        conta.nConta = cont;
        //        Console.WriteLine("N da conta: " + conta.nConta);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Erro: " + e);
        //    }
        //}
        public void AdicionaContaCorrente(double valor, Cliente Titular)
        {
            this.contaCorrentes.Add(new ContaCorrente(this.NDC, Titular, valor));
            Console.WriteLine("Conta Corrente criada com sucesso!");
            NDC++;
        }

        public void AdicionaContaPoupanca(double valor, Cliente Titular)
        {
            this.contaPoupancas.Add(new ContaPoupanca(this.NDC, valor, Titular));
            Console.WriteLine("Conta Poupança criada com sucesso!");
            NDC++;
        }

        public ContaCorrente procuraContaCorrente(int numero)
        {
            foreach (ContaCorrente conta in contaCorrentes)
            {
                if (conta.nConta == numero)
                {
                    return conta;
                }
            }

            return null;
        }

        public ContaPoupanca procuraContaPoupanca(int numero)
        {
            foreach (ContaPoupanca conta in contaPoupancas)
            {
                if (conta.nConta == numero)
                {
                    return conta;
                }
            }

            return null;
        }

        public void ListaContas()
        {

            Console.WriteLine("Conta Corrente:");
            foreach (ContaCorrente conta in contaCorrentes)
            {
                if (conta.TipoConta == 2)
                {
                    Console.WriteLine(conta.nConta + " - " + conta.titular1.Nome + " / " + conta.cliente2.Nome);
                }
                else
                {
                    Console.WriteLine(conta.nConta + " - " + conta.titular1.Nome);
                }

                Console.WriteLine("Saldo: " + conta.saldo);
            }

            Console.WriteLine();

            Console.WriteLine("Conta Poupança:");
            foreach (ContaPoupanca conta in contaPoupancas)
            {
                if (conta.TipoConta == 2)
                {
                    Console.WriteLine(conta.nConta + " - " + conta.titular1.Nome + " / " + conta.cliente2.Nome);
                }
                else
                {
                    Console.WriteLine(conta.nConta + " - " + conta.titular1.Nome);
                }

                Console.WriteLine("Saldo: " + conta.saldo);
            }
        }
        public void RemoverConta(int procurada)
        {
            foreach (ContaCorrente conta in contaCorrentes.ToList())
            {
                if (conta.nConta == procurada)
                {
                    contaCorrentes.Remove(conta);
                    Console.WriteLine("Conta deletada com sucesso!");
                }
            }

            foreach (ContaPoupanca conta in contaPoupancas.ToList())
            {
                if (conta.nConta == procurada)
                {
                    contaPoupancas.Remove(conta);
                    Console.WriteLine("Conta deletada com sucesso!");
                }
            }
        }

        public void ListaCliente()
        {
            foreach (ContaCorrente conta in contaCorrentes)
            {
                if (conta.TipoConta == 1)
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("NOME : " + conta.titular1.Nome);
                    Console.WriteLine("NOME SUJO? " + conta.titular1.NomeSujo);
                    Console.WriteLine("CPF: " + conta.titular1.Cpf);
                    Console.WriteLine("E-MAIL: " + conta.titular1.Email);
                    Console.WriteLine("ENDEREÇO: " + conta.titular1.Endereco);
                    Console.WriteLine("DATA DE NASCIMENTO: " + conta.titular1.DataNascimento);
                    Console.WriteLine("-------------------------");
                }
                else
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("NOME : " + conta.titular1.Nome);
                    Console.WriteLine("NOME SUJO? " + conta.titular1.NomeSujo);
                    Console.WriteLine("CPF: " + conta.titular1.Cpf);
                    Console.WriteLine("E-MAIL: " + conta.titular1.Email);
                    Console.WriteLine("ENDEREÇO: " + conta.titular1.Endereco);
                    Console.WriteLine("DATA DE NASCIMENTO: " + conta.titular1.DataNascimento);
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("NOME : " + conta.cliente2.Nome);
                    Console.WriteLine("NOME SUJO? " + conta.cliente2.NomeSujo);
                    Console.WriteLine("CPF: " + conta.cliente2.Cpf);
                    Console.WriteLine("E-MAIL: " + conta.cliente2.Email);
                    Console.WriteLine("ENDEREÇO: " + conta.cliente2.Endereco);
                    Console.WriteLine("DATA DE NASCIMENTO: " + conta.cliente2.DataNascimento);
                    Console.WriteLine("-------------------------");
                }
            }

            foreach (ContaPoupanca conta in contaPoupancas)
            {
                if (conta.TipoConta == 1)
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("NOME : " + conta.titular1.Nome);
                    Console.WriteLine("NOME SUJO? " + conta.titular1.NomeSujo);
                    Console.WriteLine("CPF: " + conta.titular1.Cpf);
                    Console.WriteLine("E-MAIL: " + conta.titular1.Email);
                    Console.WriteLine("ENDEREÇO: " + conta.titular1.Endereco);
                    Console.WriteLine("DATA DE NASCIMENTO: " + conta.titular1.DataNascimento);
                    Console.WriteLine("-------------------------");
                }
                else
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("NOME : " + conta.titular1.Nome);
                    Console.WriteLine("NOME SUJO? " + conta.titular1.NomeSujo);
                    Console.WriteLine("CPF: " + conta.titular1.Cpf);
                    Console.WriteLine("E-MAIL: " + conta.titular1.Email);
                    Console.WriteLine("ENDEREÇO: " + conta.titular1.Endereco);
                    Console.WriteLine("DATA DE NASCIMENTO: " + conta.titular1.DataNascimento);
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("NOME : " + conta.cliente2.Nome);
                    Console.WriteLine("NOME SUJO? " + conta.cliente2.NomeSujo);
                    Console.WriteLine("CPF: " + conta.cliente2.Cpf);
                    Console.WriteLine("E-MAIL: " + conta.cliente2.Email);
                    Console.WriteLine("ENDEREÇO: " + conta.cliente2.Endereco);
                    Console.WriteLine("DATA DE NASCIMENTO: " + conta.cliente2.DataNascimento);
                    Console.WriteLine("-------------------------");
                }
            }
        }
        public bool procuraCartao(Cliente Titular)
        {
            foreach (Cartao cartao in Cartao)
            {
                if (cartao.Titular == Titular)
                {
                    cartao.Limite = 1000;
                    return true;
                }
            }

            return false;
        }

        public Cartao procuraCartao(int numCartao)
        {
            foreach (Cartao cartao in Cartao)
            {
                if (cartao.Numero == numCartao)
                {
                    return cartao;
                }
            }

            return null;
        }

        public void VinculaCartao(int numero)
        {

            foreach (ContaCorrente conta in contaCorrentes)
            {
                if (conta.nConta == numero)
                {
                    if (conta.TipoConta == 2)
                    {
                        int read = -1;
                        while (read != 0)
                        {
                            Console.WriteLine("Qual cliente será associado ao cartão?");
                            Console.WriteLine("[1] - " + conta.titular1.Nome);
                            Console.WriteLine("[2] - " + conta.cliente2.Nome);
                            Console.WriteLine("[0] - Voltar");
                            read = Convert.ToInt32(Console.ReadLine());

                            switch (read)
                            {
                                case 1:
                                    if (!procuraCartao(conta.titular1))
                                    {
                                        if (procuraCartao(conta.cliente2))
                                        {
                                            this.Cartao.Add(new Cartao(this.NDC, conta.titular1, 1000));
                                            Console.WriteLine("Cartão " + this.NDC + " vinculado ao cliente " + conta.titular1.Nome + " com sucesso!");
                                        }
                                        else
                                        {
                                            this.Cartao.Add(new Cartao(this.NDC, conta.titular1, 2000));
                                            Console.WriteLine("Cartão " + this.NDC + " vinculado ao cliente " + conta.titular1.Nome + " com sucesso!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Já existe um cartão vinculado à esse cliente.");
                                    }
                                    break;
                                case 2:
                                    if (!procuraCartao(conta.cliente2))
                                    {
                                        if (procuraCartao(conta.titular1))
                                        {
                                            this.Cartao.Add(new Cartao(this.NDC, conta.cliente2, 1000));
                                            Console.WriteLine("Cartão " + this.NDC + " vinculado ao cliente " + conta.cliente2.Nome + " com sucesso!");
                                        }
                                        else
                                        {
                                            this.Cartao.Add(new Cartao(this.NDC, conta.cliente2, 2000));
                                            Console.WriteLine("Cartão " + this.NDC + " vinculado ao cliente " + conta.cliente2.Nome + " com sucesso!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Já existe um cartão vinculado à esse cliente.");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Digite uma opção válida");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (!procuraCartao(conta.titular1))
                        {
                            this.Cartao.Add(new Cartao(this.NDC, conta.titular1, 2000));
                            Console.WriteLine("Cartão " + this.NDC + " vinculado ao cliente " + conta.titular1.Nome + " com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Já existe um cartão vinculado à esse cliente.");
                        }
                    }
                }
            }

        }

        public void TotalArmazenado()
        {
            Armazenado = 0;
            foreach (ContaCorrente conta in contaCorrentes)
            {
                this.Armazenado += conta.saldo;
            }

            foreach (ContaPoupanca conta in contaPoupancas)
            {
                this.Armazenado += conta.saldo;
            }

            Console.WriteLine("O total armazenado é de R$" + this.Armazenado);
        }

        public void TotalEmprestado()
        {
            Emprestado = 0;
            foreach (ContaCorrente conta in contaCorrentes)
            {
                this.Emprestado += conta.Emprestimo;
            }

            Console.WriteLine("O total emprestado é de R$" + this.Emprestado);
        }

        public void TotalReceber()
        {
            Receber = 0;
            foreach (Cartao cartao in Cartao)
            {
                this.Receber += cartao.Saldo;
            }

            foreach (ContaCorrente conta in contaCorrentes)
            {
                this.Receber += conta.Emprestimo;
            }

            Console.WriteLine("O total a receber é de R$" + this.Receber);
        }

        public void PassaMes()
        {
            foreach (ContaCorrente conta in contaCorrentes)
            {
                Random random = new Random();
                int numRandom = random.Next(2);
                int saldoRandom = random.Next(101);

                if (numRandom == 0)
                {
                    conta.Saca(saldoRandom);
                }
                else
                {
                    conta.Deposita(saldoRandom);
                }
            }

            foreach (ContaPoupanca conta in contaPoupancas)
            {
                Random random = new Random();
                int numRandom = random.Next(2);
                int saldoRandom = random.Next(101);

                if (numRandom == 0)
                {
                    conta.Saca(saldoRandom);
                }
                else
                {
                    conta.Deposita(saldoRandom);
                }
            }

            foreach (ContaCorrente conta in contaCorrentes)
            {
                Random random = new Random();
                int numRandom = random.Next(2);
                int saldoRandom = random.Next(101);

                if (numRandom == 0)
                {
                    bool emp = conta.PedeEmprestimo(saldoRandom);
                }
            }

            foreach (ContaPoupanca conta in contaPoupancas)
            {
                conta.saldo += conta.saldo * conta.Rendimento;
            }

            foreach (Cartao cartao in Cartao)
            {
                Random random = new Random();
                int numRandom = random.Next(2);
                int saldoRandom = random.Next(1061);

                if (numRandom == 0)
                {
                    cartao.usaCartao(saldoRandom);
                }
            }

        }

    }
}
