using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_banco
{
    class Tela
    {
        public Banco banco = new Banco();
        Gerente gerente;


        public void telaInicial()
        { 

            Console.WriteLine("------ * Bem-vindo ao sistema de banco!* ------");
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
            Console.WriteLine("Digite o seu nome: "); nome = Console.ReadLine();
            Console.WriteLine("Digite o email: "); email = Console.ReadLine();
            Console.WriteLine("Digite o cpf"); cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: "); senha = Console.ReadLine();
            Console.WriteLine("Confirma a senha"); senha2 = Console.ReadLine();
            bool valid = banco.CompSenha(senha, senha2);
            if (!valid)
            {
                Console.WriteLine("Senhas não conferem, Digite novamente");
                Console.WriteLine("Digite a senha: "); senha = Console.ReadLine();
                Console.WriteLine("Confirma a senha"); senha2 = Console.ReadLine();
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
            Console.WriteLine("[3] - Acessar Conta Corrente");
            Console.WriteLine("[4] - Acessar Conta Poupança");
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
                if(op.KeyChar == '1')
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
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("[1] - Cadastrar Funcionário");
            Console.WriteLine("[2] - Criar Conta");
            Console.WriteLine("[3] - Trasferir");
            Console.WriteLine("[4] - Sacar");
            Console.WriteLine("[5] - Empréstimo");
            Console.WriteLine("--------------------------------------");
            ConsoleKeyInfo op;
            op = Console.ReadKey(true);
            if(op.KeyChar == '1')
            {
                Console.Clear();
                this.cadastrarFuncionario();
            }
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
            Console.WriteLine("Digite o nome: "); nome = Console.ReadLine();
            Console.WriteLine("Digite o email: "); email = Console.ReadLine();
            Console.WriteLine("Digite o cpf: "); cpf = Console.ReadLine();
            Console.WriteLine("Digite a senha: "); senha = Console.ReadLine();
            Console.WriteLine("Confirma a senha: "); senha2 = Console.ReadLine();
            var v = this.banco.CompSenha(senha, senha2);

            if (!v)
            {
                Console.WriteLine("Senhas não conferem, Digite novamente");
                Console.WriteLine("Digite a senha: "); senha = Console.ReadLine();
                Console.WriteLine("Confirma a senha"); senha2 = Console.ReadLine();
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

        public void menuConta()
        {
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("---------      MENU CONTA     -------- ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("[1] - Criar Conta Corrente: ");
            Console.WriteLine("[2] - Criar Conta Poupança");
            ConsoleKeyInfo x;
            x = Console.ReadKey(true);
            if (x.KeyChar == '1')
            {
                Console.Clear();
            }
            if (x.KeyChar == '2')
            {
                Console.Clear();
            }
             
        }

        public void CriaCorrente()
        {
            string titular;
            string cpf;
            string email;
            string senha;
            string senha2;
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("-----  CONTA CORRENTE - CRIAR     ---- ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("Titular: "); titular = Console.ReadLine();
            Console.WriteLine("CPF do titular: "); cpf = Console.ReadLine();
            Console.WriteLine("email do titular: "); email = Console.ReadLine();
            Console.WriteLine("Senha: "); senha = Console.ReadLine();
            Console.WriteLine("Confirme a senha: "); senha2 = Console.ReadLine();
            var v = this.banco.CompSenha(senha, senha2); 
            if (!v)
            {
                Console.WriteLine("Senhas não conferem, Digite novamente");
                Console.WriteLine("Digite a senha: "); senha = Console.ReadLine();
                Console.WriteLine("Confirma a senha"); senha2 = Console.ReadLine();
            }
            
          


        }
    }
}
