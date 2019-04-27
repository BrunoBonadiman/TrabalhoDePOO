using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Gerente
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }        
        public int Senha { get; set; }

        public Gerente()
        {
            this.Nome = "Nayara";
            this.Matricula = 2016;
            this.Senha = 2016;
        }
    }
}
