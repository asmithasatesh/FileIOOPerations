using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileIOOperations
{
    class FileOperations
    {
        //Path stored in a string
        public static String path = @"D:\Assignments\FileIOOperations\FileIOOperations\File.txt";

        //Check whether a file exist
        public static void FileExists(string path)
        {
            Console.WriteLine("-----Check whether a File Exist-----");
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists!\n");

            }
            else
            {
                Console.WriteLine("File Does Not Exist!");
            }
        }
        //Read all Lines from File and store in a List
        public static void ReadAllLine()
        {
            Console.WriteLine("-----Read each line from file and store in List-----\n");
            string[] lines;
            lines = File.ReadAllLines(path);
            Console.WriteLine(lines[0]);
            Console.WriteLine(lines[1]+ "\n");


        }
        //Read all text from file
        public static void ReadAllText()
        {
            Console.WriteLine("-----Read all Text from File-----\n");
            string lines;
            lines = File.ReadAllText(path);
            Console.WriteLine(lines+ "\n");

        }
        //Cope one file to Another
        public static void FileCopy()
        {
            Console.WriteLine("-----Copy file from One file to another-----\n");
            string copyPath= @"D:\Assignments\FileIOOperations\FileIOOperations\CopiedFile.txt"; 
            File.Copy(path, copyPath);
            string lines = File.ReadAllText(copyPath);
            Console.WriteLine(lines + "\n");

        }
        //Delete copied file
        public static void DeleteFile()
        {
            Console.WriteLine("Delete a File\n");
            string copyPath = @"D:\Assignments\FileIOOperations\FileIOOperations\CopiedFile.txt";
            File.Delete(copyPath);
            FileExists(copyPath);
        }
    }
}
