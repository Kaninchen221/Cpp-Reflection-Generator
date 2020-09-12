using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Cpp_Reflection_Generator_Tests
{
    using Cpp_Reflection_Generator;

    [TestClass]
    public class Finder_Tests
    {

        [TestMethod]
        public void FindXmlFilesWithParsedClassesAndStructs_Test()
        {
            Doxygen DoxygenObj = new Doxygen();
            try
            {
                DoxygenObj.PathsOfInputFolders = Path.GetFullPath($"{Directory.GetCurrentDirectory()}\\..\\..\\..\\test_input");
                DoxygenObj.PathToDoxyfile = "../../../../Doxyfile";
                DoxygenObj.PrepareDoxyfile();
                DoxygenObj.Run();
            }
            catch(Exception Ex)
            {
                Assert.Fail($"Doxygen functions shouldn't throw any exceptions : {Ex.Message}");
            }

            try
            {
                var FoundedFilesResult = Finder.FindXmlFilesWithParsedClassesAndStructs(DoxygenObj.XmlOutputDirectory);
                var FoundedFilesExpectedCount = 2;

                Assert.AreEqual(FoundedFilesExpectedCount, FoundedFilesResult.Count);
            }
            catch(Exception Ex)
            {
                Assert.Fail($"Finder.FindXmlFilesWithParsedClassesAndStructs function shouldn't throw any exceptions : {Ex.Message}");
            }
        }

    }
}
