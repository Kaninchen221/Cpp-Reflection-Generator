using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Cpp_Reflection_Generator
{
    static public class XmlDeserializer
    {
        static public ReflectionTypes.File DeserializeFile(string PathToFile)
        {
            if (PathToFile == null)
                throw new ArgumentNullException("PathToFile param is null");

            if (!File.Exists(PathToFile.ToString()))
                throw new IOException($"File not exists : {PathToFile}");

            var Stream = File.Open(PathToFile, FileMode.Open);

            return Deserialize(Stream);
        }

        static private ReflectionTypes.File Deserialize(Stream Input)
        {
            var Serializer = new XmlSerializer(typeof(ReflectionTypes.File));
            RegisterEvents(ref Serializer);

            var Result = (ReflectionTypes.File)Serializer.Deserialize(Input);

            return Result;
        }

        static private void RegisterEvents(ref XmlSerializer Serializer)
        {
            Serializer.UnknownNode += new XmlNodeEventHandler(UnknownNode);
            Serializer.UnknownAttribute += new XmlAttributeEventHandler(UnknownAttribute);
            Serializer.UnknownElement += new XmlElementEventHandler(UnknownElement);
            Serializer.UnreferencedObject += new UnreferencedObjectEventHandler(UnreferencedObject);
        }

        static private void UnknownNode(object Sender, XmlNodeEventArgs Args)
        {
            Console.WriteLine($"Unknown Node : {Args.Name}\t{Args.Text}");
        }

        static private void UnknownAttribute(object Sender, XmlAttributeEventArgs Args)
        {
            var Attr = Args.Attr;
            Console.WriteLine($"Unknown attribute : {Attr.Name} = {Attr.Value}");
        }

        static private void UnknownElement(object Sender, XmlElementEventArgs Args)
        {
            var Element = Args.Element;
            Console.WriteLine($"Unknown element : {Element.Name}");
        }

        static private void UnreferencedObject(object Sender, UnreferencedObjectEventArgs Args)
        {
            Console.WriteLine($"Unreferenced object : {Args.UnreferencedId}");
        }
    }
}
