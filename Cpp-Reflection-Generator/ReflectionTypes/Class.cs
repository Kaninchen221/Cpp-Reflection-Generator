using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cpp_Reflection_Generator.ReflectionTypes
{
    public class Class
    {
        [XmlElement(ElementName = "compoundname")]
        public string Name { get; set; }

        [XmlElement(ElementName = "templateparamlist")]
        public Template OptionalTemplate { get; set; }

        [XmlElement(ElementName = "sectiondef")]
        public List<SectionDefinititon> SectionDefinititons { get; set; }

        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }

        public override string ToString()
        {
            var Builder = new StringBuilder();

            Builder.Append($"\tName : {Name}\n");
            if(OptionalTemplate != null)
                Builder.Append("\tTemplate : " + OptionalTemplate.ToString() + '\n');
            foreach(var SectionDef in SectionDefinititons)
            {
                Builder.Append(SectionDef.ToString() + '\n');
            }
            Builder.Append(Location.ToString());

            return Builder.ToString();
        }
    };
}
