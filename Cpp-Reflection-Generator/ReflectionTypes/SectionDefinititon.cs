using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Cpp_Reflection_Generator.ReflectionTypes
{
    public class SectionDefinititon
    {
        [XmlElement(ElementName = "memberdef")]
        public List<MemberDefinition> Members { get; set; }
        public override string ToString()
        {
            var Builder = new StringBuilder();

            foreach (var Member in Members)
            {
                Builder.Append(Member.ToString() + '\n');
            }

            return Builder.ToString();
        }
    };
}
