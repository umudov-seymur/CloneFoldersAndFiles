using System;
using System.IO;

namespace Clone_All_Folder_and_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Environment.CurrentDirectory;
            string destPath = Path.Combine(sourcePath, "ClonedFolder");

            CopyFolder(sourcePath, destPath);
        }

        /// <summary>
        /// Function to recursively clone a all folder and files to another folder
        /// </summary>
        /// <param name="sourceFolder">Source folder path</param>
        /// <param name="destFolder">Destination folder path</param>
        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourceFolder);

            if (!sourceDir.Exists)
            {
                throw new DirectoryNotFoundException(
                    $"Source directory does not exist or could be found {sourceFolder}"
                );
            }

            DirectoryInfo[] dirs = sourceDir.GetDirectories();
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            FileInfo[] files = sourceDir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destFolder, file.Name);
                file.CopyTo(tempPath, true);
            }

            foreach (DirectoryInfo subDirectory in dirs)
            {
                string tempSubDirPath = Path.Combine(destFolder, subDirectory.Name);
                CopyFolder(subDirectory.FullName, tempSubDirPath);
            }
        }
    }
}
