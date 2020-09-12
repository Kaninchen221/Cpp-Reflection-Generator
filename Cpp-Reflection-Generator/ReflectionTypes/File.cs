using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cpp_Reflection_Generator.ReflectionTypes
{
    [XmlRoot(ElementName = "doxygen", IsNullable = true)]
    public class File
    {

        [XmlElement(ElementName = "compounddef", IsNullable = true)]
        public Class Class { get; set; }

        public override string ToString()
        {
            return Class.ToString();
        }

    };
}
