using Cpp_Reflection_Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Cpp_Reflection_Generator_Tests
{
    [TestClass]
    public class IInterpreter_Tests
    {
        class TestClass
        {
            public int X { get; set; } = 100;
            public int Y { get; set; } = 200;
        }

        class InterpreterTestClass : IInterpreter
        {
            string IInterpreter.NameOfPropertyToInterpret { get => "X"; }
            List<IInterpreter> IInterpreter.Interpreters { get => new List<IInterpreter>(); }

            string IInterpreter.GenerateBeginOfThisSection(ref object ObjectToInterpret)
            {
                return $"Begin {IInterpreter.NewLine()}";
            }

            string IInterpreter.GenerateEndOfThisSection(ref object ObjectToInterpret)
            {
                return $"End {IInterpreter.NewLine()}";
            }
        }

        [TestMethod]
        public void GetProperties_Test()
        {
            object ObjToTest = new TestClass();
            var Properties = IInterpreter.GetProperties(ref ObjToTest);

            int ExpectedCount = 2;
            Assert.AreEqual(ExpectedCount, Properties.Length);
        }

        [TestMethod]
        public void IsMemberToInterpret_Test()
        {
            var TestClassObj = new TestClass();
            var Type = TestClassObj.GetType();
            var Property = Type.GetProperty("X");
            var Interpreter = new InterpreterTestClass();

            var IsToInterpret = IInterpreter.IsMemberToInterpret(Property, Interpreter);
            Assert.IsTrue(IsToInterpret);
        }
    }
}
