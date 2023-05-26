using System;
using System.Text;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static FileFolderParser.ParserTools;

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

            // Print the text from specified file
            Task<string> text = ParserTools.ReadFile(file_path); 
            Console.WriteLine(text);

            // Parse the folders and files
            ParserTools.ParserFolders(folder_path, file_name);

            Console.ReadKey();
        }
    }
}