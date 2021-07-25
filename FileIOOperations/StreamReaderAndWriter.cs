using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileIOOperations
{
    class StreamReaderAndWriter
    {
        public static String path = @"D:\Assignments\FileIOOperations\FileIOOperations\File.txt";

        public static void ReadFromStreamReader()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public static void WriteUsingStreamWriter()
        {
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine("Using Stream Writer");
                sr.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
    }
}
