using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cpp_Reflection_Generator
{
    static public class Finder
    {
        public static List<string> FindXmlFilesWithParsedClassesAndStructs(string PathToFolderWithXmlFiles)
        {
            var StructsPaths = Directory.GetFiles(PathToFolderWithXmlFiles, "struct*.xml", SearchOption.TopDirectoryOnly);
            var ClassesPaths = Directory.GetFiles(PathToFolderWithXmlFiles, "class*.xml", SearchOption.TopDirectoryOnly);

            var Paths = StructsPaths.Concat(ClassesPaths);

            return Paths.ToList();
        }

    }
}
