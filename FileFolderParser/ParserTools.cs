using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFolderParser
{
    internal class ParserTools
    {
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

        public static void ParserFolders(string folder_path, string file_name)
        {
            List<string> folders = GetListFoldes(folder_path);
            foreach (string folder in folders)
            {
                Console.WriteLine();
                Console.Write("Folder: ");
                Console.WriteLine(folder);
                SaveTextToFile("Folder: " + folder + "\n", folder_path + file_name);

                ParserFiles(folder, folder_path, file_name);
            }
        }
        static void ParserFiles(string folder, string folder_path, string file_name)
        {
            Console.WriteLine("Files: ");
            List<string> files = GetListFiles(folder);
            foreach (string file in files) // Parsing the files into folder
            {
                Console.WriteLine($"      {file}");
                SaveTextToFile("Files:\n" + "      " + file + "\n", folder_path + file_name);
            }
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
        public static async Task<string> ReadFile(string path) // Reading the specified file
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
