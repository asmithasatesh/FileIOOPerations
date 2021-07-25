using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;

namespace FileIOOperations
{
    class CSVOperations
    {
        //Instance Variables
        public string name;
        public string email;
        public string phone;
        public string country;

        //Parameterised Constructors
        public CSVOperations(string name,string email,string phone,string country)
        {
            this.name = name;
            this.email=email;
            this.phone=phone;
            this.country=country;
        }
        public static string imortFilePath = @"D:\Assignments\FileIOOperations\FileIOOperations\CSVFile.csv";
        //Read Content of CSV File and Print
        public static void ImplementCSVOperation()
        {
            //Initialization

            using var reader = new StreamReader(imortFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            while(csv.Read())
            {
                var name = csv.GetField(0);
                var email = csv.GetField(1);
                var phone = csv.GetField(2);
                var country = csv.GetField(3);
                Console.WriteLine("Name: {0} \t Email: {1} \t Phone Number: {2} \t Country: {3}",name,email,phone,country);
            }
        }
        //Write Contents into CSV File
        public static void WriteCSVOperation()
        {
            string exportfile = @"D:\Assignments\FileIOOperations\FileIOOperations\CSVExportFile.csv";
            var users = new List<CSVOperations>{
            new CSVOperations("Ash","ash@gmail.com","9842905050","India"),
            new CSVOperations("Bhanu","bhanu@gmail.com","980005050","US"),
            new CSVOperations("dhee","dhee@gmail.com","761905050","Canada")
            };
            StreamWriter writer = File.AppendText(exportfile);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture) ;
            foreach (var user in users)
            {
                csv.WriteField(user.name);
                csv.WriteField(user.email);
                csv.WriteField(user.phone);
                csv.WriteField(user.country);
                csv.NextRecord();
            }

        }
    }
}
