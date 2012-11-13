using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralsExample.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RomanNumeralsTests
    {
        [TestMethod]
        public void RetornaICuandoElNumeroEs1()
        {
            var roman = RomanNumerals.Convert(1);
            Assert.AreEqual("I", roman);
        }

        [TestMethod]
        public void RetornaIICuandoElNumeroEs2()
        {
            var roman = RomanNumerals.Convert(2);
            Assert.AreEqual("II", roman);
        }

        [TestMethod]
        public void RetornaIIICuandoElNumeroEs3()
        {
            var roman = RomanNumerals.Convert(3);
            Assert.AreEqual("III", roman);
        }

        [TestMethod]
        public void RetornaIVCuandoElNumeroEs4()
        {
            var roman = RomanNumerals.Convert(4);
            Assert.AreEqual("IV", roman);
        }

        [TestMethod]
        public void RetornaVCuandoElNumeroEs5()
        {
            var roman = RomanNumerals.Convert(5);
            Assert.AreEqual("V", roman);
        }

        [TestMethod]
        public void RetornaVCuandoElNumeroEs6()
        {
            var roman = RomanNumerals.Convert(6);
            Assert.AreEqual("VI", roman);
        }

        [TestMethod]
        public void RetornaIXCuandoElNumeroEs9()
        {
            var roman = RomanNumerals.Convert(9);
            Assert.AreEqual("IX", roman);
        }

        [TestMethod]
        public void RetornaXCuandoElNumeroEs10()
        {
            var roman = RomanNumerals.Convert(10);
            Assert.AreEqual("X", roman);
        }

        [TestMethod]
        public void RetornaXIVCuandoElNumeroEs14()
        {
            var roman = RomanNumerals.Convert(14);
            Assert.AreEqual("XIV", roman);
        }

        [TestMethod]
        public void RetornaXVCuandoElNumeroEs15()
        {
            var roman = RomanNumerals.Convert(15);
            Assert.AreEqual("XV", roman);
        }

        [TestMethod]
        public void RetornaXXCuandoElNumeroEs20()
        {
            var roman = RomanNumerals.Convert(20);
            Assert.AreEqual("XX", roman);
        }

        [TestMethod]
        public void RetornaLILCuandoElNumeroEs40()
        {
            var roman = RomanNumerals.Convert(40);
            Assert.AreEqual("XL", roman);
        }

        [TestMethod]
        public void RetornaLILCuandoElNumeroEs50()
        {
            var roman = RomanNumerals.Convert(50);
            Assert.AreEqual("L", roman);
        }

        [TestMethod]
        public void RetornCCCXCVCuandoElNumeroEs395()
        {
            var roman = RomanNumerals.Convert(395);
            Assert.AreEqual("CCCXCV", roman);
        }
    }
}
