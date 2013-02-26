using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OwnTestFramework
{
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CheckTests
    {
        public Check Create(Type fixture)
        {
            return new Check(fixture);
        }

        [TestMethod]
        public void Encuentra0TestMethod()
        {
            var checkUnit = this.Create(typeof(FixtureSinTestMethods));
            checkUnit.FindMethodsWithAttributes();
            Assert.AreEqual(0, checkUnit.TestCases.Count);
        }

        [TestMethod]
        public void Encuentra1TestMethod()
        {
            var checkUnit = this.Create(typeof(FixtureConUnTestMethodCorrecto));
            checkUnit.FindMethodsWithAttributes();
            Assert.AreEqual(1, checkUnit.TestCases.Count);
        }

        [TestMethod]
        public void EjecutaUnTestMethodExitoso()
        {
            var checkUnit = this.Create(typeof(FixtureConUnTestMethodCorrecto));
            checkUnit.Execute();
            var testClass = (FixtureConUnTestMethodCorrecto)checkUnit.TestClass;
            Assert.IsTrue(testClass.RunTests);
        }

        [TestMethod]
        public void EjecutaUnTestMethodExitosoYFallido()
        {
            var checkUnit = this.Create(typeof(FixtureConMuchosTestMethod));
            checkUnit.Execute();
            var testClass = (FixtureConMuchosTestMethod)checkUnit.TestClass;
            Assert.IsTrue(testClass.TestsRunned);
        }

        [TestMethod]
        public void RegistraSiLaEjecucionFueExitosa()
        {
            var checkUnit = this.Create(typeof(FixtureConUnTestMethodCorrecto));
            checkUnit.Execute();
            Assert.IsTrue(checkUnit.FixtureSuccess);
        }

        [TestMethod]
        public void RegistraSiLaEjecucionFueFallida()
        {
            var checkUnit = this.Create(typeof(FixtureConMuchosTestMethod));
            checkUnit.Execute();
            Assert.IsFalse(checkUnit.FixtureSuccess);
        }

        [TestMethod]
        public void EncuentraSetupMethods()
        {
            var checkUnit = this.Create(typeof(FixtureConUnTestMethodCorrecto));
            checkUnit.FindMethodsWithAttributes();
            Assert.AreEqual("Setup", checkUnit.Setup.Name);
        }

        [TestMethod]
        public void EjecutaSetupMethodsAntesDelTestCase()
        {
            var checkUnit = this.Create(typeof(FixtureConUnTestMethodCorrecto));
            checkUnit.Execute();
            var fixture = checkUnit.TestClass as FixtureConUnTestMethodCorrecto;
            Assert.AreEqual(fixture.MethodsCalled.First(), "Setup");
        }
    }

    public class FixtureConMuchosTestMethod
    {
        public bool TestsRunned = false;

        [Check]
        public void Sucess()
        {
            this.TestsRunned = true;
        }

        [Check]
        public void Fail()
        {
            this.TestsRunned = true;
            throw new Exception();
        }
    }

    public class FixtureConUnTestMethodCorrecto
    {
        public bool RunTests = false;
        public List<string> MethodsCalled = new List<string>();

        [CheckFirst]
        public void Setup()
        {
            MethodsCalled.Add("Setup");
        }

        [Check]
        public void Test()
        {
            MethodsCalled.Add("Test");
            this.RunTests = true;
        }
    }

    public class FixtureSinTestMethods
    {
    }
}
