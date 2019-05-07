using sistema_banco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            Tela tela = new Tela();

            tela.telaInicial();

            //Preenche uma lista
            //List<Socio> list = new List<Socio>();
            //for (int i = 0; i < 25; i++)
            //{
            //    Socio a = new Socio();
            //    a.Nome = "Ricardo" + i;
            //    a.addDependente(new Dependente("Juliana1" + i));
            //    a.addDependente(new Dependente("Juliana2" + i));
            //    a.addDependente(new Dependente("Juliana3" + i));
            //    list.Add(a);
            //}
            //Salva em arquivo
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, list);
                }
            }
            catch (IOException)
            {
            }
            //Carrega de arquivo
            List<Socio> list2 = new List<Socio>();
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    list2 = (List<Socio>)bin.Deserialize(stream);
                    foreach (Socio s in list2)
                    {
                        Console.WriteLine(s.Nome);
                        s.printDependentes();
                    }
                }
            }
            catch (IOException)
            {
            }

            Console.ReadKey();
        }
    }
}
