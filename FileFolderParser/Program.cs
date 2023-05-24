using System;
using System.Runtime.CompilerServices;

namespace FileFolderParser
{
    class Program
    {
        const string DIRNAME = "D:\\A\\C Sharp";
        static void Main(string[] args)
        {
            List<string> text = GetListFiles();
            foreach (string file in text)
            {
                Console.WriteLine(file);
            }
        }

        static List<string> GetListFiles()
        {
            var directory = new DirectoryInfo(DIRNAME);
            List<string> paths = new List<string>();
            if (directory.Exists)
            {
                Console.WriteLine("Subdirectories: ");
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    paths.Add(dir.FullName);
                }
            }
            return paths;
        }
    }
}