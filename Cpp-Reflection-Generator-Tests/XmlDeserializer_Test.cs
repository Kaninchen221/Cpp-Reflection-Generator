using Cpp_Reflection_Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cpp_Reflection_Generator_Tests
{
    using Cpp_Reflection_Generator;

    [TestClass]
    public class XmlDeserializer_Test
    {
        [TestMethod]
        public void DeserializeFile_DeserializeXmlOututFromDoxygenTest()
        {
            Doxygen DoxygenObj = new Doxygen();
            var FinderResult = new List<string>();
            try
            {
                DoxygenObj.PathsOfInputFolders = Path.GetFullPath($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\test_input");
                DoxygenObj.PathToDoxyfile = "../../../../Doxyfile";
                DoxygenObj.PrepareDoxyfile();
                DoxygenObj.Run();
                FinderResult = Finder.FindXmlFilesWithParsedClassesAndStructs(DoxygenObj.XmlOutputDirectory);
            }
            catch (Exception Ex)
            {
                Assert.Fail($"Doxygen or Finder function(s) shouldn't throw any exceptions : {Ex.Message}");
            }

            var Result = new List<Cpp_Reflection_Generator.ReflectionTypes.File>();
            try
            {
                foreach(var FilePath in FinderResult) {
                    Result.Add(XmlDeserializer.DeserializeFile(FilePath));
                }
            }
            catch (Exception Ex)
            {
                Assert.Fail($"Finder.FindXmlFilesWithParsedClassesAndStructs function shouldn't throw any exceptions : {Ex.Message}");
            }

            var ExpectedCountOfClasses = 2;
            Assert.AreEqual(ExpectedCountOfClasses, Result.Count);


        }

    }
}
