using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cpp_Reflection_Generator.ReflectionTypes
{
    public class Location
    {
        [XmlAttribute(AttributeName = "file")]
        public string RelativePath { get; set; }

        public override string ToString()
        {
            return "Relative path : " + RelativePath;
        }
    };
}
