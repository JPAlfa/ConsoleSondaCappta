using System;

namespace ConsoleSondaCappta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao simulador de sonda! (; \nColoque qual o tamanho do planalto: ");
            string planalto = Console.ReadLine();
            
            int xTotal = 0;
            int yTotal = 0;
            SondaService.ExtrairValoresDoPlanalto(planalto, out xTotal, out yTotal);

            while (true)
            {
                Console.WriteLine("Coloque agora a posição inicial da sonda: ");
                string posicaoInicial = Console.ReadLine();
                Console.WriteLine("Coloque agora quais os movimentos que você gostaria de fazer: ");
                string movimentos = Console.ReadLine();

                SondaService.Processar(xTotal, yTotal, posicaoInicial, movimentos);
            }
        }
    }
}
