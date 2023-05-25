using System;
using System.Text;
using System.Runtime.CompilerServices;

namespace FileFolderParser
{
    class Program
    {
        const string DIRNAME = "D:\\A\\C Sharp"; // Specifying the path to the dir
        const string FILE_NAME = "\\Test.txt";
        static void Main(string[] args)
        {
            List<string> folders = GetListFoldes();
            foreach (string folder in folders)
            {
                Console.WriteLine();
                Console.Write("Folder: ");
                Console.WriteLine(folder);
                SaveTextToFile("Folder: " + folder + "\n", DIRNAME + FILE_NAME);

                Console.WriteLine("Files: ");
                List<string> files = GetListFiles(folder);
                foreach (string file in files) // Parsing the files into folder
                {
                    Console.WriteLine($"      {file}");
                    SaveTextToFile("Files:\n" + "      " + file + "\n", DIRNAME + FILE_NAME);
                }

            }
            Console.ReadLine();
        }

        static List<string> GetListFoldes() // return the list of the folders
        {
            var directory = new DirectoryInfo(DIRNAME);
            List<string> paths = new List<string>();
            if (directory.Exists)
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    paths.Add(dir.FullName);
                }
            }
            return paths;
        }
        static List<string> GetListFiles(string dirName) // return the list of the files
        {
            var directory = new DirectoryInfo(dirName);
            List<string> got_files = new List<string>();
            string[] files = Directory.GetFiles(dirName);
            if (directory.Exists)
            {
                foreach (string file in files)
                {
                    got_files.Add(file);
                }
            }
            return got_files;
        }
        static async void SaveTextToFile(string text, string path) // Save the text in txt file to the specify path
        {
            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                Console.WriteLine("The text was written to a file.");
            }
        }
    }
}