using System;

namespace FileIOOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get option from User
            Console.WriteLine("Welcome to File Operations!");
            Console.WriteLine("Enter 1-For File Operations");
            int options = Convert.ToInt32(Console.ReadLine());
            switch(options)
            {
                case 1:
                    //Get choice on which Io operations to Perform
                    Console.WriteLine("Enter 1-To check Whether File Exist!");
                    Console.WriteLine("Enter 2-To read all Lines of File");
                    Console.WriteLine("Enter 3-To read All Text in File");
                    Console.WriteLine("Enter 4-Create a Copy of another file");
                    Console.WriteLine("Enter 5-Delete a File");
                    int choice= Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            FileOperations.FileExists(@"D:\Assignments\FileIOOperations\FileIOOperations\File.txt");
                            break;
                        case 2:
                            FileOperations.ReadAllLine();
                            break;
                        case 3:
                            FileOperations.ReadAllText();
                            break;
                        case 4:
                            FileOperations.FileCopy();
                            break;
                        case 5:
                            FileOperations.DeleteFile();
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
