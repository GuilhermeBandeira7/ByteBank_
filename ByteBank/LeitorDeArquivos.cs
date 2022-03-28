using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivos : IDisposable // By implementing IDisposable, you are announcing that instances of this type allocate scarce resources.

    {
        public string Arquivos { get; }
        public LeitorDeArquivos(string arquivo)
        {
               
            //throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            //throw new IOException(); //Input Output exception
            return "Linha do arquivo";
        }

        

        public void Fechar() // Fechar method is really important to tell the OS we are closing the file
        {
            Console.WriteLine("Fechando arquivo.");
        }

        public void Dispose() // IDisposable contract. Dispose method responsible for releasing the resources. Provides a mechanism for releasing unmanaged resources.
        {
            Console.WriteLine("Fechando arquivo");
        }
    }
}
