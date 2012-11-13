using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisExample.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TennisTests
    {
        [TestMethod]
        public void EmpateAlIniciarElJuego()
        {
            var tennis = new Tennis();
            var score = tennis.Score();
            Assert.AreEqual("0,0", score);
        }

        [TestMethod]
        public void AnotoElJugadorUno()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            var score = tennis.Score();
            Assert.AreEqual("15,0", score);
        }

        [TestMethod]
        public void AnotoElJugadorDos()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("0,15", score);
        }

        [TestMethod]
        public void PrimerEmpate()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("15,15", score);
        }

        [TestMethod]
        public void ElJugadorUnoAnoto2Veces()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            var score = tennis.Score();
            Assert.AreEqual("30,0", score);
        }

        [TestMethod]
        public void ElJugadorDosAnoto2Veces()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("0,30", score);
        }

        [TestMethod]
        public void ElJugadorUnoAnota3Veces()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            var score = tennis.Score();
            Assert.AreEqual("40,0", score);
        }

        [TestMethod]
        public void ElJugadorDosAnota3Veces()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("0,40", score);
        }

        [TestMethod]
        public void GanoJugadorUno()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            var score = tennis.Score();
            Assert.AreEqual("Juan wins", score);
        }

        [TestMethod]
        public void GanoJugadorDos()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Miguel wins", score);
        }

        [TestMethod]
        public void PrimerDeuce()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Deuce", score);
        }

        [TestMethod]
        public void SegundoDeuce()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Deuce", score);
        }

        [TestMethod]
        public void VentajaPrimerJugador()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Advantage Juan", score);
        }

        [TestMethod]
        public void VentajaSegundoJugador()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Advantage Miguel", score);
        }

        [TestMethod]
        public void GanoJugadorUnoDespuesDeVentaja()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Juan wins", score);
        }

        [TestMethod]
        public void GanoJugadorDosDespuesDeVentaja()
        {
            var tennis = new Tennis();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer1();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            tennis.ScorePlayer2();
            var score = tennis.Score();
            Assert.AreEqual("Miguel wins", score);
        }
    }
}
