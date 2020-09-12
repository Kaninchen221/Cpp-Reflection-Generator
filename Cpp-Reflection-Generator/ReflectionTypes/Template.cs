using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cpp_Reflection_Generator.ReflectionTypes
{
    public class Template
    {
        public class Param
        {
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
        }

        [XmlElement(ElementName = "param")]
        public List<Param> Params { get; set; }

        public override string ToString()
        {
            var Builder = new StringBuilder();

            foreach (var Param in Params)
            {
                Builder.Append(Param.Type);
            }

            return Builder.ToString();
        }
    };
}
