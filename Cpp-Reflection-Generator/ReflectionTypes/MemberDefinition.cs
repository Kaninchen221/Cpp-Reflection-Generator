using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cpp_Reflection_Generator.ReflectionTypes
{
    public class MemberDefinition
    {
        public class Type
        {
            public class Reference
            {
                [XmlAttribute(AttributeName = "refid")]
                public string ReferenceId { get; set; }

                [XmlAttribute(AttributeName = "kindref")]
                public string KindReference { get; set; }

                public override string ToString()
                {
                    return $"\t\t\tReferenceId : {ReferenceId}\n" +
                        $"\t\t\tKindReference : {KindReference}\n";
                }
            }

            [XmlText()]
            public string Value { get; set; }

            [XmlElement(ElementName = "ref")]
            public Reference ReferenceToType { get; set; }

            public override string ToString()
            {
                var Builder = new StringBuilder();

                Builder.Append($"\n\t\tValue : {Value}\n");
                if (ReferenceToType != null)
                {
                    Builder.Append(ReferenceToType.ToString());
                }

                return Builder.ToString();
            }
        }

        [XmlAttribute(AttributeName = "kind")]
        public string Kind { get; set; }

        [XmlAttribute(AttributeName = "prot")]
        public string AccessSpecifier { get; set; }

        [XmlAttribute(AttributeName = "static")]
        public string Static { get; set; }

        [XmlAttribute(AttributeName = "mutable")]
        public string Mutable { get; set; }

        [XmlAttribute(AttributeName = "const")]
        public string Const { get; set; }

        [XmlAttribute(AttributeName = "explicit")]
        public string Explicit { get; set; }

        [XmlAttribute(AttributeName = "inline")]
        public string Inline { get; set; }

        [XmlAttribute(AttributeName = "virt")]
        public string Virtual { get; set; }

        [XmlElement(ElementName = "type")]
        public Type TypeInformation { get; set; }

        [XmlElement(ElementName = "definition")]
        public string Definition { get; set; }

        [XmlElement(ElementName = "argsstring")]
        public string Arguments { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "initializer")]
        public string Initializer { get; set; }

        public override string ToString()
        {
            var Builder = new StringBuilder();

            var Type = typeof(MemberDefinition);

            foreach (var Property in Type.GetProperties())
            {
                Builder.Append($"\n\t{Property.Name} : {Property.GetValue(this)}");
            }

            return Builder.ToString();
        }
    };
}
