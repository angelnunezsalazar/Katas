namespace OwnTestFramework
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Check
    {
        private Type fixture;

        public MethodInfo Setup { get; private set; }

        public List<MethodInfo> TestCases { get; private set; }

        public object TestClass { get; private set; }

        public bool FixtureSuccess { get; private set; }

        public Check(Type fixture)
        {
            TestCases = new List<MethodInfo>();
            this.fixture = fixture;
            this.FixtureSuccess = true;
        }

        public void FindMethodsWithAttributes()
        {
            foreach (var method in fixture.GetMethods())
            {
                if (method.GetCustomAttribute<CheckAttribute>() != null)
                {
                    this.TestCases.Add(method);
                }
                if (method.GetCustomAttribute<CheckFirstAttribute>() != null)
                {
                    this.Setup = method;
                }
            }
        }

        public void Execute()
        {
            this.TestClass = Activator.CreateInstance(this.fixture);
            this.FindMethodsWithAttributes();
            foreach (var testCase in this.TestCases)
            {
                try
                {
                    this.ExecuteSetup();
                    this.ExecuteTestCase(testCase);
                }
                catch (Exception)
                {
                    this.FixtureSuccess = false;
                }
            }
        }

        private void ExecuteSetup()
        {
            if (this.Setup != null)
            {
                this.Setup.Invoke(this.TestClass, null);
            }
        }

        private void ExecuteTestCase(MethodInfo testCase)
        {
            testCase.Invoke(this.TestClass, null);
        }
    }
}