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
        public Template Template { get; set; }

        [XmlElement(ElementName = "sectiondef")]
        public List<SectionDefinititon> SectionDefinititons { get; set; }

        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }

        public override string ToString()
        {
            var Builder = new StringBuilder();

            Builder.Append("\t~~~~ Class ~~~~\n");

            Builder.Append($"\tName : {Name}\n");

            if(Template != null)
                Builder.Append("\tTemplate : " + Template.ToString() + '\n');

            Builder.Append('\n');

            foreach(var SectionDef in SectionDefinititons)
            {
                Builder.Append(SectionDef.ToString());
            }
            Builder.Append(Location.ToString());
            Builder.Append('\n');

            return Builder.ToString();
        }
    };
}
