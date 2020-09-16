using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cpp_Reflection_Generator
{
    public interface IInterpreter
    {
        public string NameOfPropertyToInterpret { get; }
        public List<IInterpreter> Interpreters { get; }

        public string Interpret(ref object ObjectToInterpret)
        {
            var ResultOfInterpret = new StringBuilder();

            var BeginOfThisSection = GenerateBeginOfThisSection(ref ObjectToInterpret);
            ResultOfInterpret.Append(BeginOfThisSection);

            var ResultOfPropagate = PropagateInterpreters(ref ObjectToInterpret);
            ResultOfInterpret.Append(ResultOfPropagate);

            var EndOfThisSection = GenerateEndOfThisSection(ref ObjectToInterpret);
            ResultOfInterpret.Append(EndOfThisSection);

            return ResultOfInterpret.ToString();
        }

        protected string GenerateBeginOfThisSection(ref object ObjectToInterpret);
        protected string GenerateEndOfThisSection(ref object ObjectToInterpret);

        static public char NewLine()
        {
            return '\n';
        }

        string PropagateInterpreters(ref object ObjectToInterpret)
        {
            var ResultOfPropagate = new StringBuilder();
            var Properties = GetProperties(ref ObjectToInterpret);
            
            foreach(var Property in Properties)
            {
                foreach(var Interpreter in Interpreters)
                {
                    if (IsMemberToInterpret(Property, Interpreter))
                    {
                        var ValueOfProperty = Property.GetValue(ObjectToInterpret);
                        var ResultOfInterpreter = Interpreter.Interpret(ref ValueOfProperty);
                        ResultOfPropagate.Append(ResultOfInterpreter);
                    }
                }
            }

            return ResultOfPropagate.ToString();
        }

        static public System.Reflection.PropertyInfo[] GetProperties(ref object Object)
        {
            return Object.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }

        static public bool IsMemberToInterpret(System.Reflection.PropertyInfo Property, IInterpreter Interpreter)
        {
            if (Property.Name.Equals(Interpreter.NameOfPropertyToInterpret))
                return true;
            else
                return false;
        }
    }
}
