using System;
using System.Collections.Generic;

namespace Kata
{
    public class FactoresPrimos
    {
        private const int PRIMER_PRIMO = 2;
        public static IEnumerable<int> Generar(int numero)
        {
            foreach(int divisor in Divisores)
            {
                if (NoTieneFactores(numero)) break;
                while (EsDivisble(numero, divisor))
                {
                    yield return divisor;
                    numero /= divisor;
                }
            }
        }

        private static bool EsDivisble(int numero, int divisor)
        {
            return numero % divisor == 0;
        }

        private static bool NoTieneFactores(int numero)
        {
            return numero < PRIMER_PRIMO;
        }

        protected static IEnumerable<int> Divisores
        {
            get
            {
                int divisor = PRIMER_PRIMO;
                while (true)
                    yield return divisor++;
            }
        }
    }
}