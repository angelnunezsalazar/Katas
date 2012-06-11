using System;
using System.Collections.Generic;
using NUnit.Framework;
using Kata;

namespace Test
{
    [TestFixture]
    public class FactoresPrimosTest
    {
        [Test]
        public void Generar_Uno_RetornaListaVacia()
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(1);
            Assert.AreEqual(lista(), primos);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(3571)]
        public void Generar_Primo_RetornaPrimo(int primo)
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(primo);
            Assert.AreEqual(lista(primo), primos);
        }

        [Test]
        public void Generar_Ocho_RetornaTresVecesDos()
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(8);
            Assert.AreEqual(lista(2,2,2), primos);
        }

        [TestCase(4,2,2)]
        [TestCase(6, 2, 3)]
        [TestCase(9, 3,3)]
        [TestCase(10, 2, 5)]
        public void Generar_NoPrimoConDosFactores_RetornaDosFactores(int noPrimo,int factor1,int factor2)
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(noPrimo);
            Assert.AreEqual(lista(factor1,factor2), primos);
        }

        [TestCase(4,new[]{2,2})]
        public void Generar_Prueba(int numero,int[] resultado)
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(numero);
            Assert.AreEqual(resultado,primos);
        }

        public object lista2()
        {
            return null;
        }

        [Test]
        public void Generar_NumeroGrandePotenciaTres_RetornaVariosTres()
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(59049);
            Assert.AreEqual(lista(3,3,3,3,3,3,3,3,3,3), primos);
        }

        [Test]
        public void Generar_Doce_RetornaDosDosTres()
        {
            IEnumerable<int> primos = FactoresPrimos.Generar(12);
            Assert.AreEqual(lista(2,2,3), primos);
        }

        private IEnumerable<int> lista(params int[] numeros)
        {
            foreach (int numero in numeros)
            {
                yield return numero;
            }
        }
    }
}