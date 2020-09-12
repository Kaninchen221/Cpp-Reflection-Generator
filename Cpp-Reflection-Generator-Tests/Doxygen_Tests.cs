using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cpp_Reflection_Generator_Tests
{
    using Cpp_Reflection_Generator;
    using System;
    using System.IO;
    using System.Linq;

    [TestClass]
    public class Doxygen_Tests
    {
        private string WorkingDirectory = Directory.GetCurrentDirectory();

        [TestMethod]
        public void Run_Test()
        {
            var Doxygen = PrepareDoxygenObject();

            Doxygen.PrepareDoxyfile();

            try
            {
                Doxygen.Run();
            }
            catch (Exception Ex)
            {
                Assert.Fail($"Doxygen.Run shouldn't throw any exception : {Ex.Message}");
            }
        }

        [TestMethod]
        public void PrepareDoxyfile_Test()
        {
            var Doxygen = PrepareDoxygenObject();

            try
            {
                Doxygen.PrepareDoxyfile();
            }
            catch (Exception Ex)
            {
                Assert.Fail($"Doxygen.PrepareDoxyfile shouldn't throw any exception : {Ex.Message}");
            }

            Assert.IsTrue(File.Exists(Doxygen.PathToTemporaryDoxyfile));

        }

        Doxygen PrepareDoxygenObject()
        {
            var Doxygen = new Doxygen();
            Doxygen.PathToTemporaryDoxyfile = "Doxyfile";
            Doxygen.PathsOfInputFolders = Path.GetFullPath($"{WorkingDirectory}\\..\\..\\..\\test_input");
            Doxygen.PathToDoxyfile = "../../../../Doxyfile";
            return Doxygen;
        }
    }
}
