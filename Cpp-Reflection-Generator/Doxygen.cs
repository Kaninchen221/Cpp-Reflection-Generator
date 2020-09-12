using System;
using System.Diagnostics;
using System.IO;

namespace Cpp_Reflection_Generator
{
    public class Doxygen
    {
        public string PathsOfInputFolders { get; set; }
        public string PathToDoxyfile { get; set; }
        public string PathToTemporaryDoxyfile { get; set; }
        public string IncludePathDoxyfileProperty { get; }
        public string DoxygenName { get; set; }
        public string XmlOutputDirectory { get; }

        public Doxygen()
        {
            PathToTemporaryDoxyfile = "Doxyfile";
            IncludePathDoxyfileProperty = "INPUT = ";
            DoxygenName = "doxygen";
            XmlOutputDirectory = "xml";
        }

        public void Run()
        {
            RemoveXmlOutputFolder();

            var DoxygenProcess = GenerateProcess();

            RegisterProcessEvents(ref DoxygenProcess);
            StartProcess(ref DoxygenProcess);
            WaitForExitOfProcess(ref DoxygenProcess);

        }

        public Process GenerateProcess()
        {
            Process DoxygenProcess = new Process();
            DoxygenProcess.StartInfo.FileName = DoxygenName;
            DoxygenProcess.StartInfo.Arguments = "Doxyfile";

            return DoxygenProcess;
        }
        
        private void StartProcess(ref Process Process)
        {
            try
            {
                if (!Process.Start())
                    throw new Exception("The process already started");
            }
            catch (Exception Ex)
            {
                throw new Exception($"Can't start Doxygen process. Process.Start throw exception with message: {Ex.Message}");
            }
        }

        private void WaitForExitOfProcess(ref Process Process)
        {
            try
            {
                Process.WaitForExit();
            }
            catch (Exception Ex)
            {
                throw new Exception($"Can't wait for doxygen process exit. Process.WaitForExit throw exception with message: {Ex.Message}");
            }
        }

        private void RegisterProcessEvents(ref Process Process)
        {
            Process.ErrorDataReceived += DataReceivedEventHandler;
        }

        private void DataReceivedEventHandler(object sender, DataReceivedEventArgs Args) 
        {
            throw new Exception($"Received an error from Doxygen Process : {Args.Data}");
        }

        public void PrepareDoxyfile()
        {
            bool Overwrite = true;

            File.Copy(PathToDoxyfile, PathToTemporaryDoxyfile, Overwrite);

            AddInputPathsToTemporaryDoxyfile();
        }

        private void AddInputPathsToTemporaryDoxyfile()
        {
            IfNullThenThrowException(PathsOfInputFolders);
            IfNullThenThrowException(IncludePathDoxyfileProperty);

            using (var Doxyfile = File.AppendText(PathToTemporaryDoxyfile))
            {
                Doxyfile.Write('\n');
                Doxyfile.Write(IncludePathDoxyfileProperty);
                Doxyfile.Write(PathsOfInputFolders);
                Doxyfile.Write('\n');
            }
        }

        private void RemoveXmlOutputFolder()
        {
            bool Recursive = true;

            try 
            {
                Directory.Delete(XmlOutputDirectory, Recursive);
            }
            catch(Exception Ex)
            {
                Console.WriteLine($"Can't clear Xml output directory : {Ex.Message}");
            }
        }

        private void IfNullThenThrowException(object Object)
        {
            if (Object == null)
                throw new ArgumentNullException("Argument is null");
        }

    }
}
