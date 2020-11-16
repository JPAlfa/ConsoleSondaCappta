using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleSondaCappta
{
    class SondaService
    {
        #region Métodos Públicos

        public static void ExtrairValoresDoPlanalto(string planalto, out int xTotal, out int yTotal)
        {
            char[] a = planalto.Where(x => char.IsDigit(x)).ToArray();
            xTotal = (int)Char.GetNumericValue(a[0]);
            yTotal = (int)Char.GetNumericValue(a[1]);
        }

        public static void Processar(int xTotal, int yTotal, string posicaoInicial, string movimentos)
        {
            int xAtual = 0;
            int yAtual = 0;
            char direcaoAtual = '.';
            ExtrairValoresDaPosicaoInicial(posicaoInicial, out xAtual, out yAtual, out direcaoAtual);

            ExecutarMovimentacao(movimentos, xTotal, yTotal, xAtual, yAtual, direcaoAtual);
            
        }

        #endregion

        #region Métodos Privados

        private static void ExecutarMovimentacao(string movimentos, int xTotal, int yTotal, int xAtual, int yAtual, char direcaoAtual)
        {
            for (int i = 0; i < movimentos.Length; i++)
            {
                if (movimentos[i] == 'M' )
                {
                    switch (direcaoAtual)
                    {
                        case 'E':
                            if (xAtual < xTotal)
                                xAtual++;
                            break;
                        case 'W':
                            if (xAtual > 0)
                                xAtual--;
                            break;
                        case 'N':
                            if (yAtual < yTotal)
                                yAtual++;
                            break;
                        case 'S':
                            if (yAtual > 0)
                                yAtual--;
                            break;
                    }
                }
                else if (movimentos[i] == 'R')
                {
                    switch (direcaoAtual)
                    {
                        case 'N':
                            direcaoAtual = 'E';
                            break;
                        case 'E':
                            direcaoAtual = 'S';
                            break;
                        case 'S':
                            direcaoAtual = 'W';
                            break;
                        case 'W':
                            direcaoAtual = 'N';
                            break;
                    }
                }
                else if (movimentos[i] == 'L')
                {
                    switch (direcaoAtual)
                    {
                        case 'N':
                            direcaoAtual = 'W';
                            break;
                        case 'W':
                            direcaoAtual = 'S';
                            break;
                        case 'S':
                            direcaoAtual = 'E';
                            break;
                        case 'E':
                            direcaoAtual = 'N';
                            break;
                    }
                }
            }

            Console.WriteLine(string.Format("{0} {1} {2}", xAtual, yAtual, direcaoAtual));
        }

        private static void ExtrairValoresDaPosicaoInicial(string posicaoInicial, out int xAtual, out int yAtual, out char direcaoAtual)
        {
            char[] b = posicaoInicial.Where(x => char.IsDigit(x)).ToArray();
            direcaoAtual = posicaoInicial.Where(x => char.IsLetter(x)).FirstOrDefault();
            xAtual = (int)Char.GetNumericValue(b[0]);
            yAtual = (int)Char.GetNumericValue(b[1]);
            //Console.WriteLine(String.Format("Leitura Posição Inicial: x = {0}, y = {1}", xAtual, yAtual));
        }

        #endregion
    }
}
