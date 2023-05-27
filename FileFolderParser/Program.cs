using System;
using System.Text;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static FileFolderParser.ParserTools;
using static System.Net.WebRequestMethods;
using System.Drawing;

namespace FileFolderParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilesFoldersParser();
            CompareFiles();
            Console.ReadKey();
        }

        static void FilesFoldersParser() // Perform parsing of folders and files at the first level
        {
            Console.Write("Enter path to folder: ");
            string? folder_path = Console.ReadLine(); // Specifying the path to the dir, for example: D:\\A\\C Sharp\\
            Console.Write("Enter the file name to store a text: ");
            string? file_name = Console.ReadLine(); // Specifyinng the name of the file
            Console.Write("Enter path to file: ");
            string? file_path = Console.ReadLine(); // Specifying the name of the file to reading, for example: D:\\A\\C Sharp\\test_x.txt

            // Print the text from specified file
            Task<string> text = ReadFile(file_path);
            Console.WriteLine(text);

            // Parse the folders and files
            ParserFolders(folder_path, file_name);
        }
        static void CompareFiles()
        {
            Console.WriteLine("Specify the first path to the folder: "); // Example: D:\\A\\C Sharp\\FileFolderParser\\test folder\\1 
            string? first_folder_path = Console.ReadLine();
            Console.Write("Specify the second path to the folder: "); // Example: D:\\A\\C Sharp\\FileFolderParser\\test folder\\2
            string? second_folder_path = Console.ReadLine();

            // Get a list of files from specified folders
            string[] first_batch_files = Directory.GetFiles(first_folder_path, "*", SearchOption.AllDirectories);
            string[] second_batch_files = Directory.GetFiles(second_folder_path, "*", SearchOption.AllDirectories);

            // Get list of the all files from second specified folder
            StringBuilder contentBuilder = new StringBuilder();
            foreach (string sfile in second_batch_files)
            {
                contentBuilder.AppendLine(sfile);
            }
            string allContent = contentBuilder.ToString();

            // Checking for files in folder one in folder two
            foreach (string ffile in first_batch_files) // Parsing the all files in the first specified folder
            {
                string short_version_second_file = ffile.Remove(0, first_folder_path.Length);
                if (allContent.Contains(short_version_second_file))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"Doesn't contain: {ffile}");
                }
            }
        }
    }
}