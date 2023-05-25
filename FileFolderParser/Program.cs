using System;
using System.Text;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace FileFolderParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path to folder: ");
            string? folder_path = Console.ReadLine(); // Specifying the path to the dir, for example: D:\\A\\C Sharp\\
            Console.Write("Enter the file name to store a text: ");
            string? file_name = Console.ReadLine(); // Specifyinng the name of the file


            Console.Write("Enter path to file: ");
            string? file_path = Console.ReadLine(); // Specifying the name of the file to reading, for example: D:\\A\\C Sharp\\test_x.txt
            //string? file_path = "D:\\A\\C Sharp\\test_x.txt";
            Task<string> text = ReadFile(file_path);
            Console.WriteLine(text);


            List<string> folders = GetListFoldes(folder_path);
            foreach (string folder in folders)
            {
                Console.WriteLine();
                Console.Write("Folder: ");
                Console.WriteLine(folder);
                SaveTextToFile("Folder: " + folder + "\n", folder_path + file_name);

                Console.WriteLine("Files: ");
                List<string> files = GetListFiles(folder);
                foreach (string file in files) // Parsing the files into folder
                {
                    Console.WriteLine($"      {file}");
                    SaveTextToFile("Files:\n" + "      " + file + "\n", folder_path + file_name);
                }

            }
            Console.ReadKey();
        }

        static List<string> GetListFoldes(string dirname) // return the list of the folders
        {
            var directory = new DirectoryInfo(dirname);
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
        static async Task<string> ReadFile(string path) // Reading the specified file
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                Console.WriteLine(text);
                return text;
            }
        }
    }
}