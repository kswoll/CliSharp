using System;
using System.IO;

namespace BulkRename
{
    class Program
    {
        static void Main(string[] args)
        {
            var fromPattern = args[0];
            var toPattern = args[1];
            var folder = Environment.CurrentDirectory;

            foreach (var file in Directory.EnumerateFiles(folder, fromPattern, SearchOption.AllDirectories))
            {
                var toDirectory = Path.GetDirectoryName(file);
                var toFileWithoutExtension = Path.GetFileNameWithoutExtension(file);
                var toFile = Path.Combine(toDirectory, $"{toFileWithoutExtension}.{toPattern}");
                Console.WriteLine(toFile);
                File.Move(file, toFile);
            }
        }
    }
}
