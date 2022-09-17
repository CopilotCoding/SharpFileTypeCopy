namespace FileCopySharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using static System.Console;
    
    internal class Program
    {
        private static String fileSearchPath;
        private static String destinationFolderPath;
        private static String fileType;

        private static void Main()
        {
            Start();
        }

        private static void Start()
        {
            WriteLine("Enter a path to search for files to copy from...");
            WriteLine();

            fileSearchPath = ReadLine();
            WriteLine();

            WriteLine("Enter a file type: txt, exe, dll, etc...");
            WriteLine();

            fileType = ReadLine();
            WriteLine();

            WriteLine("Enter the destination folder path for the files...");
            WriteLine();

            destinationFolderPath = ReadLine();
            WriteLine();

            SearchAndCopyFiles();
        }

        private static void SearchAndCopyFiles()
        {
            try
            {      
                IEnumerable<String> searchPath = Directory.EnumerateFileSystemEntries(fileSearchPath, ".", SearchOption.AllDirectories);

                foreach (String file in searchPath)
                {
                    if (file.Contains("." + fileType))
                    {
                        WriteLine("Original: " + file);
                        WriteLine();

                        CopyFiles(file);
                    }
                }             
            }
            catch (Exception e)
            {
                WriteLine("--------------------FILE SEARCH ERROR!-------------------");
                WriteLine(e);
                WriteLine("---------------------------------------------------------");
                WriteLine("PRESS ENTER TO CONTINUE...");

                ReadLine();
            }
        }

        private static void CopyFiles(String fileName)
        {
            Char[] splitSymbols = new Char[] { '\\' };

            String[] fileNameSplits = fileName.Split(splitSymbols);

            foreach (String shortFileName in fileNameSplits)
            {
                if (shortFileName.Contains("." + fileType))
                {
                    try
                    {
                        WriteLine("Destination: " + destinationFolderPath + shortFileName);
                        WriteLine();

                        CopyFiles(fileName, destinationFolderPath + shortFileName);
                    }
                    catch
                    {
                        WriteLine("File conflict: Same name, enter a new name: ");

                        String newName = ReadLine();

                        WriteLine();

                        WriteLine("Destination++: " + destinationFolderPath + newName + "." + fileType);
                        WriteLine();

                        CopyFiles(fileName, destinationFolderPath + newName + "." + fileType);
                    }
                }
            }
        }

        static void CopyFiles(String sourcePath, String destinationPath)
        {
            using (FileStream source = File.OpenRead(sourcePath))
            using (FileStream destination = File.OpenWrite(destinationPath))
            {
                source.CopyTo(destination);
            }
        }
    }
}
