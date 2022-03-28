using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN.");
            }

            

            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();


        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
                //Console.WriteLine("Código depois do throw");
            }
        }

        // MÉTODOS PARA TESTES COM A CLASSE LEITOR DE ARQUIVOS E NOVAS EXCEÇÕES

        private static void CarregarContas()
        {
            using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt")) // to compile this we need the IDisposable interface in the LeitorDeArquivos class
            {
                // Using is basically doing all we did with the try catch finally below. 
                // IDisposable
                leitor.LerProximaLinha(); 
               
            }

            //------------------------------

            //LeitorDeArquivos leitor = null;
            //try
            //{
            //    leitor = new LeitorDeArquivos("contas.txt"); // this string is causing a FileNotFoundException

            //    for (int i = 0; i < 4; i++)
            //    {
            //        leitor.LerProximaLinha();

            //        //throw new IOException();    
            //    }

            //}
            //catch (IOException) // PODE TER UM CATCH OU NÃO. NESSE CASO NÃO É NECESSÁRIO
            //{

            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            //}
            //finally // happening a exception or not the finally block is always gonna be executed
            //{
            //    Console.WriteLine("Executando o finally.");
            //    if (leitor != null) // we are trying to call Fechar from a null reference(leitor) coming from the constructor, Which is going to generate a null reference ex.  That´s why we need this structure to close the application
            //    {

            //        leitor.Fechar();
            //    }

            //}



        }


        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                // conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException)
            {
                throw new OperacaoFinanceiraException("Exceção do tipo OperaçãoFinanceira detectada");

            }
        }


    }
}
