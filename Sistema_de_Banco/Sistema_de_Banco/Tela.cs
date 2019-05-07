using Sistema_de_Banco;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    [Serializable]
    class Tela
    {
        public Banco banco = new Banco();
        Gerente gerente;


        public void telaInicial()
        {

            Console.WriteLine("------ * Bem-vindo ao Sistema Bancário! " +
                "* ------");
            Console.WriteLine("[1]- Iniciar");

            ConsoleKeyInfo op;
            op = Console.ReadKey(true);

            if (op.KeyChar == '1')
            {
                Console.Clear();
                this.cadastrarGerente();
            }
            else
            {
                Console.WriteLine("Ops! Comando inválido!");
            }
        }


        public void cadastrarGerente()
        {
            string nome;
            string email;
            string cpf;
            string senha;
            string senha2;
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("----      Cadastro de Gerente     ---- ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("Digite o seu nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o email: ");
            email = Console.ReadLine();
            Console.WriteLine("Digite o cpf");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            senha = Console.ReadLine();
            Console.WriteLine("Confirma a senha");
            senha2 = Console.ReadLine();
            bool valid = banco.CompSenha(senha, senha2);
            if (!valid)
            {
                Console.WriteLine("Senhas não conferem, Digite novamente");
                Console.WriteLine("Digite a senha: ");
                senha = Console.ReadLine();
                Console.WriteLine("Confirma a senha");
                senha2 = Console.ReadLine();
            }
            Gerente gerente = new Gerente(nome, email, cpf, senha);
            var ver = this.banco.addGerente(gerente);

            if (!ver)
            {
                Console.WriteLine("****** Erro ao cadastrar ********");
                Console.WriteLine("[1] - Voltar");
                ConsoleKeyInfo op;
                op = Console.ReadKey(true);
                if (op.KeyChar == '1')
                {
                    Console.Clear();
                    this.telaInicial();
                }
            }
            else
            {
                Console.WriteLine("********* Gerente cadastrado **********");
                Console.WriteLine("[1] - Tela inicial");
                ConsoleKeyInfo v;
                v = Console.ReadKey(true);
                if (v.KeyChar == '1')
                {
                    Console.Clear();
                    this.acesso();
                }
            }

        }

        public void acesso()
        {
            Console.WriteLine("************** ACESSO ***************");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("[1] - Gerente");
            Console.WriteLine("[2] - Funcionário");
            //Console.WriteLine("[3] - Acessar Conta Corrente");
            //Console.WriteLine("[4] - Acessar Conta Poupança");
            Console.WriteLine("--------------------------------------");
            ConsoleKeyInfo op;
            op = Console.ReadKey(true);
            if (op.KeyChar == '1')
            {
                Console.Clear();
                this.LoginGerente();
            }
            if (op.KeyChar == '2')
            {

            }
            if (op.KeyChar == '3')
            {

            }


        }
        public void LoginGerente()
        {
            string cpf;
            string senha;
            Console.WriteLine("************** ACESSO ***************");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Digite o cpf: "); cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha"); senha = Console.ReadLine();
            bool ac = this.banco.acesso(cpf, senha);

            if (!ac)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("-------     ACESSO NEGADO!  ----------");
                Console.WriteLine("[1] - Voltar");
                ConsoleKeyInfo op;
                op = Console.ReadKey(true);
                if (op.KeyChar == '1')
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Gerente: ", this.banco.gerente.nome);
                    Console.WriteLine("----------------------------------");
                    this.LoginGerente();
                }

            }
            else
            {
                Console.Clear();
                this.menuGerente();
            }
        }

        public void menuGerente()
        {
            int op = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("---------- MENU DO GERENTE -----------");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("[1] - Cadastrar Funcionário:");
                Console.WriteLine("[2] - Trasferir:");
                Console.WriteLine("[3] - Sacar:");
                Console.WriteLine("[4] - Empréstimo:");
                Console.WriteLine("[5] - Pagar Empréstimo:");
                Console.WriteLine("[6] - Listar Contas:");
                Console.WriteLine("[7] - Deletar Conta:");
                Console.WriteLine("[8] - Listar Clientes:");
                Console.WriteLine("[9] - Adicionar Conta Corrente:");
                Console.WriteLine("[10] - Adicionar Conta Poupança:");
                Console.WriteLine("[11] - Depósito:");
                Console.WriteLine("[12] - Transferência:");
                Console.WriteLine("[13] - Vincular Cartão à Cliente:");
                Console.WriteLine("[14] - Pagar Empréstimo com Cartão:");
                Console.WriteLine("[15] - Total Armazenado:");
                Console.WriteLine("[16] - Total Emprestado:");
                Console.WriteLine("[17] - Total a Receber:");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("Escolha uma das opções acima:");
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    Console.Clear();
                    this.cadastrarFuncionario();
                }

                else if (op == 2)
                {
                    int tipoConta3 = -1;

                    while (tipoConta3 != 1 && tipoConta3 != 2)
                    {
                        Console.WriteLine("Escolha o tipo de conta para realizar a transferência?");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta3 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o número da conta origem:");
                        int origemConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o número da conta destino");
                        int destinoConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja transferir:");
                        int valorTransferencia = int.Parse(Console.ReadLine());

                        if (tipoConta3 == 1)
                        {
                            banco.procuraContaCorrente(origemConta).Transfere(valorTransferencia, banco.procuraContaCorrente(destinoConta));
                        }
                        else if (tipoConta3 == 2)
                        {
                            banco.procuraContaPoupanca(origemConta).Transfere(valorTransferencia, banco.procuraContaCorrente(destinoConta));
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida!");
                        }
                    }
                }
                else if (op == 3)
                {
                    int tipoConta = -1;

                    while (tipoConta != 1 && tipoConta != 2)
                    {
                        Console.WriteLine("Escolha o tipo de conta para realizar o saque?");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta que deseja realizar o saque:");
                        int sacaConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja saca:r");
                        int valorSaque = int.Parse(Console.ReadLine());

                        if (tipoConta == 1)
                        {
                            banco.procuraContaCorrente(sacaConta).Saca(valorSaque);
                        }
                        else if (tipoConta == 2)
                        {
                            banco.procuraContaPoupanca(sacaConta).Saca(valorSaque);
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida!");
                        }
                    }
                }
                else if (op == 4)
                {
                    Console.WriteLine("Informe o número da conta que deseja pedir empréstimo:");
                    int emprestimoConta = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe o valor do empréstimo:");
                    int valorEmprestimo = int.Parse(Console.ReadLine());

                    banco.procuraContaCorrente(emprestimoConta).PedeEmprestimo(valorEmprestimo);
                }
                else if (op == 5)
                {
                    Console.WriteLine("Informe o número da conta:");
                    int contaPagaEmprestimo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe o valor à pagar:");
                    int valorPagaEmprestimo = int.Parse(Console.ReadLine());

                    banco.procuraContaCorrente(contaPagaEmprestimo).PagarEmprestimo(valorPagaEmprestimo);
                }
                else if (op == 6)
                {
                    banco.ListaContas();
                }
                else if (op == 7)
                {
                    Console.WriteLine("Informe o número da conta à remover:");
                    int conta = int.Parse(Console.ReadLine());

                    banco.RemoverConta(conta);
                }
                else if (op == 8)
                {
                    banco.ListaCliente();
                }
                else if (op == 9)
                {
                    Cliente user = new Cliente();
                    Console.WriteLine("Informe o nome do Titular:");
                    user.Nome = Console.ReadLine();
                    Console.WriteLine("Informe o CPF do Titular:");
                    user.Cpf = Console.ReadLine();
                    Console.WriteLine("Informe o endereço do Titular:");
                    user.Endereco = Console.ReadLine();
                    Console.WriteLine("Informe a Data de Nascimento do Titular:");
                    user.DataNascimento = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o E-mail do Titular:");
                    user.Email = Console.ReadLine();
                    Random Random = new Random();
                    if (Random.Next(2) == 1)
                    {
                        user.NomeSujo = true;
                    }
                    else
                    {
                        user.NomeSujo = false;
                    }

                    Console.WriteLine("Qual será o valor do saldo?");
                    double saldo = double.Parse(Console.ReadLine());

                    int verifica = -1;

                    while (verifica != 1 && verifica != 2)
                    {
                        Console.WriteLine("Deseja adicionar um dependente?");
                        Console.WriteLine("[1] - Sim");
                        Console.WriteLine("[2] - Não");
                        verifica = int.Parse(Console.ReadLine());

                        if (verifica == 1)
                        {
                            Cliente user2 = new Cliente();
                            Console.WriteLine("Informe o nome do Titular:");
                            user2.Nome = Console.ReadLine();
                            Console.WriteLine("Informe o CPF do Titular:");
                            user2.Cpf = Console.ReadLine();
                            Console.WriteLine("Informe o Endereço do Titular:");
                            user2.Endereco = Console.ReadLine();
                            Console.WriteLine("Informe a Data de Nascimento do Titular:");
                            user2.DataNascimento = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Informe o E-mail do Titular:");
                            user2.Email = Console.ReadLine();
                            Random Random1 = new Random();
                            if (Random1.Next(2) == 1)
                            {
                                user2.NomeSujo = true;
                            }
                            else
                            {
                                user2.NomeSujo = false;
                            }


                            banco.AdicionaContaCorrente(saldo, user2);
                        }
                        else if (verifica == 2)
                        {
                            banco.AdicionaContaCorrente(saldo, user);
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção válida");
                        }
                    }
                }
                else if (op == 10)
                {
                    Cliente usr = new Cliente();
                    Console.WriteLine("Informe o nome do Titular:");
                    usr.Nome = Console.ReadLine();
                    Console.WriteLine("Informe o CPF do Titular:");
                    usr.Cpf = Console.ReadLine();
                    Console.WriteLine("Informe o endereço do Titular:");
                    usr.Endereco = Console.ReadLine();
                    Console.WriteLine("Informe a Data de Nascimento do Titular:");
                    usr.DataNascimento = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o E-mail do Titular:");
                    usr.Email = Console.ReadLine();
                    Random Random2 = new Random();
                    if (Random2.Next(2) == 1)
                    {
                        usr.NomeSujo = true;
                    }
                    else
                    {
                        usr.NomeSujo = false;
                    }

                    Console.WriteLine("Qual será o valor do saldo?");
                    double saldo2 = double.Parse(Console.ReadLine());

                    int verifica2 = -1;

                    while (verifica2 != 1 && verifica2 != 2)
                    {
                        Console.WriteLine("Deseja adicionar um dependente?");
                        Console.WriteLine("[1] - Sim");
                        Console.WriteLine("[2] - Não");
                        verifica2 = int.Parse(Console.ReadLine());

                        if (verifica2 == 1)
                        {
                            Cliente usr2 = new Cliente();
                            Console.WriteLine("Informe o nome do Titular:");
                            usr2.Nome = Console.ReadLine();
                            Console.WriteLine("Informe o CPF do Titular:");
                            usr2.Cpf = Console.ReadLine();
                            Console.WriteLine("Informe o endereço do Titular:");
                            usr2.Endereco = Console.ReadLine();
                            Console.WriteLine("Informe a Data de Nascimento do Titular:");
                            usr2.DataNascimento = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Informe o E-mail do Titular:");
                            usr2.Email = Console.ReadLine();
                            Random Random3 = new Random();
                            if (Random3.Next(2) == 1)
                            {
                                usr2.NomeSujo = true;
                            }
                            else
                            {
                                usr2.NomeSujo = false;
                            }

                            banco.AdicionaContaPoupanca(saldo2, usr2);
                        }
                        else if (verifica2 == 2)
                        {
                            banco.AdicionaContaPoupanca(saldo2, usr);
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção válida");
                        }
                    }
                }
                else if (op == 11)
                {
                    int tipoConta2 = -1;

                    while (tipoConta2 != 1 && tipoConta2 != 2)
                    {
                        Console.WriteLine("Qual o tipo da conta que deseja realizar o depósito?");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta que deseja depositar?");
                        int depositaConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja depositar?");
                        int valorDeposito = int.Parse(Console.ReadLine());

                        if (tipoConta2 == 1)
                        {
                            banco.procuraContaCorrente(depositaConta).Deposita(valorDeposito);
                        }
                        else if (tipoConta2 == 2)
                        {
                            banco.procuraContaPoupanca(depositaConta).Deposita(valorDeposito);
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida!");
                        }
                    }
                }
                else if (op == 12)
                {
                    int tipoConta3 = -1;

                    while (tipoConta3 != 1 && tipoConta3 != 2)
                    {
                        Console.WriteLine("Qual o tipo da conta que deseja realizar a transferência?");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta3 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta origem:");
                        int origemConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta destino:");
                        int destinoConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja transferir:");
                        int valorTransferencia = int.Parse(Console.ReadLine());

                        if (tipoConta3 == 1)
                        {
                            banco.procuraContaCorrente(origemConta).Transfere(valorTransferencia, banco.procuraContaCorrente(destinoConta));
                        }
                        else if (tipoConta3 == 2)
                        {
                            banco.procuraContaPoupanca(origemConta).Transfere(valorTransferencia, banco.procuraContaCorrente(destinoConta));
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida");
                        }
                    }
                }
                else if (op == 13)
                {
                    Console.WriteLine("Informe o número da conta que deseja vincular um cartão:");
                    int numConta = int.Parse(Console.ReadLine());

                    banco.VinculaCartao(numConta);
                }
                else if (op == 14)
                {
                    Console.WriteLine("Informe o número da conta corrente:");
                    int numCorrente = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe o número do cartão:");
                    int numCartao = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe o valor que deseja pagar:");
                    double valorPagaCartao = double.Parse(Console.ReadLine());


                    if (banco.procuraCartao(numCartao).Saldo > 0)
                    {
                        if (valorPagaCartao > banco.procuraCartao(numCartao).Saldo)
                        {
                            valorPagaCartao -= banco.procuraCartao(numCartao).Saldo;
                        }

                        if (banco.procuraContaCorrente(numCorrente).Saca(valorPagaCartao))
                        {
                            banco.procuraCartao(numCartao).pagaCartao(valorPagaCartao);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Você não tem nenhum valor a ser pago");
                    }
                }
                else if (op == 15)
                {
                    banco.TotalArmazenado();
                }
                else if (op == 16)
                {
                    banco.TotalEmprestado();
                }
                else if (op == 17)
                {
                    banco.TotalReceber();
                }
                else
                {
                    Console.WriteLine("Opção Inválida, pressione uma tecla para tentar novamente...");
                }
            } while (op != 0);
        } 
            
            

        public void menuFuncionario()
        {
            int Opcao = 0;
            do
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("---------------------- MENU DO FUNCIONÁRIO ---------------------");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("[1] - Listar Contas:");
                Console.WriteLine("[2] - Listar Clientes:");
                Console.WriteLine("[3] - Vincular Cartão à Cliente:");
                Console.WriteLine("[4] - Saque:");
                Console.WriteLine("[5] - Depósito:");
                Console.WriteLine("[6] - Transferência:");
                Console.WriteLine("[7] - Empréstimo:");
                Console.WriteLine("[8] - Pagar Empréstimo:");
                Console.WriteLine("[9] - Pagar Cartão:");
                Console.WriteLine("[0] - Voltar ao Menu Principal:");
                Console.WriteLine("----------------------------------------------------------------");

                Console.Write("Escolha uma das opções acima: ");
                Opcao = int.Parse(Console.ReadLine());

                if(Opcao == 1)
                {
                    banco.ListaContas();
                }
                else if(Opcao == 2)
                {
                    banco.ListaCliente();
                }
                else if (Opcao == 3)
                {
                    Console.WriteLine("Informe o número da conta que deseja vincular a um cartão:");
                    int numConta = int.Parse(Console.ReadLine());

                    banco.VinculaCartao(numConta);
                }
                else if (Opcao == 4)
                {
                    int tipoConta = -1;

                    while (tipoConta != 0)
                    {
                        Console.WriteLine("Informe o tipo de conta que deseja realizar o saque:");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o número da conta que deseja sacar:");
                        int sacaConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja sacar:");
                        int valorSaque = int.Parse(Console.ReadLine());

                        if (tipoConta == 1)
                        {
                            banco.procuraContaCorrente(sacaConta).Saca(valorSaque);
                        }
                        else if (tipoConta == 2)
                        {
                            banco.procuraContaPoupanca(sacaConta).Saca(valorSaque);
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida!");
                        }
                    }
                }
                else if (Opcao == 5)
                {
                    int tipoConta2 = -1;

                    while (tipoConta2 != 0)
                    {
                        Console.WriteLine("Informe o tipo de conta que deseja realizar o depósito:");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o número da conta que deseja depositar:");
                        int depositaConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja depositar:");
                        int valorDeposito = int.Parse(Console.ReadLine());

                        if (tipoConta2 == 1)
                        {
                            banco.procuraContaCorrente(depositaConta).Deposita(valorDeposito);
                        }
                        else if (tipoConta2 == 2)
                        {
                            banco.procuraContaPoupanca(depositaConta).Deposita(valorDeposito);
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida!");
                        }
                    }
                }
                else if (Opcao == 6)
                {
                    int tipoConta3 = -1;

                    while (tipoConta3 != 0)
                    {
                        Console.WriteLine("Informe o tipo da conta que deseja realizar a transferência:");
                        Console.WriteLine("[1] - Conta Corrente");
                        Console.WriteLine("[2] - Conta Poupança");
                        tipoConta3 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe a conta origem:");
                        int origemConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe a conta destino:");
                        int destinoConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o valor que deseja transferir:");
                        int valorTransferencia = int.Parse(Console.ReadLine());

                        if (tipoConta3 == 1)
                        {
                            banco.procuraContaCorrente(origemConta).Transfere(valorTransferencia, banco.procuraContaCorrente(destinoConta));
                        }
                        else if (tipoConta3 == 2)
                        {
                            banco.procuraContaPoupanca(origemConta).Transfere(valorTransferencia, banco.procuraContaCorrente(destinoConta));
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção Válida!");
                        }
                    }
                }
                else if (Opcao == 7)
                {
                    Console.WriteLine("Informe o número da conta que deseja realizar o empréstimo:");
                    int emprestimoConta = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o valor desejado:");
                    int valorEmprestimo = int.Parse(Console.ReadLine());

                    banco.procuraContaCorrente(emprestimoConta).PedeEmprestimo(valorEmprestimo);
                }
                else if (Opcao == 8)
                {
                    Console.WriteLine("Informe o número da conta:");
                    int contaPagaEmprestimo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe o valor que deseja pagar:");
                    int valorPagaEmprestimo = int.Parse(Console.ReadLine());

                    banco.procuraContaCorrente(contaPagaEmprestimo).PagarEmprestimo(valorPagaEmprestimo);
                }
                else if (Opcao == 9)
                {
                    Console.WriteLine("Digite o número da conta corrente:");
                    int numCorrente = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o número do cartão:");
                    int numCartao = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o valor que deseja pagar:");
                    int valorPagaCartao = int.Parse(Console.ReadLine());

                    if (banco.procuraContaCorrente(numCorrente).Saca(valorPagaCartao))
                    {
                        banco.procuraCartao(numCartao).pagaCartao(valorPagaCartao);
                    }
                }
                else
                {
                    Console.WriteLine("Opção Inválida, pressione uma tecla para tentar novamente...");
                }

            } while (Opcao != 0);
        }

        public void cadastrarFuncionario()
        {
            string nome;
            string email;
            string cpf;
            string senha;
            string senha2;
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("----   Cadastro de Funcionário    ---- ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("Digite o nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o email: ");
            email = Console.ReadLine();
            Console.WriteLine("Digite o cpf: ");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            senha = Console.ReadLine();
            Console.WriteLine("Confirma a senha: ");
            senha2 = Console.ReadLine();
            var v = this.banco.CompSenha(senha, senha2);

            if (!v)
            {
                Console.WriteLine("Senhas não conferem, Digite novamente");
                Console.WriteLine("Digite a senha: ");
                senha = Console.ReadLine();
                Console.WriteLine("Confirma a senha");
                senha2 = Console.ReadLine();
            }

            Funcionario funcionario = new Funcionario(nome, cpf, email, senha);
            bool ver = this.banco.addFuncionario(funcionario);

            if (!ver)
            {
                Console.WriteLine("****** Erro ao cadastrar ********");
                Console.WriteLine("[1] - Voltar");
                ConsoleKeyInfo op;
                op = Console.ReadKey(true);
                if (op.KeyChar == '1')
                {
                    Console.Clear();
                    this.menuGerente();
                }
            }
            else
            {
                Console.WriteLine("********* Funcionário cadastrado **********");
                Console.WriteLine("[1] - Tela inicial");
                ConsoleKeyInfo x;
                x = Console.ReadKey(true);
                if (x.KeyChar == '1')
                {
                    Console.Clear();
                    this.menuGerente();
                }
            }


        }

        //public void menuConta()
        //{
        //    Console.WriteLine("-------------------------------------- ");
        //    Console.WriteLine("---------      MENU CONTA     -------- ");
        //    Console.WriteLine("-------------------------------------- ");
        //    Console.WriteLine("[1] - Criar Conta Corrente: ");
        //    Console.WriteLine("[2] - Criar Conta Poupança");
        //    ConsoleKeyInfo x;
        //    x = Console.ReadKey(true);
        //    if (x.KeyChar == '1')
        //    {
        //        Console.Clear();
        //    }
        //    if (x.KeyChar == '2')
        //    {
        //        Console.Clear();
        //    }

        //}

        //public void CriaCorrente()
        //{
        //    string titular;
        //    string cpf;
        //    string email;
        //    string senha;
        //    string senha2;
        //    Console.WriteLine("-------------------------------------- ");
        //    Console.WriteLine("-----  CONTA CORRENTE - CRIAR     ---- ");
        //    Console.WriteLine("-------------------------------------- ");
        //    Console.WriteLine("Titular: ");
        //    titular = Console.ReadLine();
        //    Console.WriteLine("CPF do titular: ");
        //    cpf = Console.ReadLine();
        //    Console.WriteLine("email do titular: ");
        //    email = Console.ReadLine();
        //    Console.WriteLine("Senha: ");
        //    senha = Console.ReadLine();
        //    Console.WriteLine("Confirme a senha: ");
        //    senha2 = Console.ReadLine();
        //    var v = this.banco.CompSenha(senha, senha2);
        //    if (!v)
        //    {
        //        Console.WriteLine("Senhas não conferem, Digite novamente");
        //        Console.WriteLine("Digite a senha: ");
        //        senha = Console.ReadLine();
        //        Console.WriteLine("Confirma a senha");
        //        senha2 = Console.ReadLine();
        //    }




        //}
    }
}
