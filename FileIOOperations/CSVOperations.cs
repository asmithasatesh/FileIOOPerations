using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;

namespace FileIOOperations
{
    class CSVOperations
    {
        //Instance Variables
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string country { get; set; }

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
        public static void WriteCSVOperation(int number)
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

            //Serialize and Deserialize Json
            if(number==3)
            {
                //Serialise Json Object
                JsonSerializer jsonSerializer = new JsonSerializer();
                string serializejson = JsonConvert.SerializeObject(users);
                Console.WriteLine("\n-----Serialize Json from List-----\n");
                Console.WriteLine(serializejson);
                //Deserialize Json
                List<CSVOperations> deserializejson = JsonConvert.DeserializeObject<List<CSVOperations>>(serializejson);
                Console.WriteLine("\n-----Deserialize Json object to List-----\n");
                foreach (var i in deserializejson)
                {
                    Console.WriteLine("Name: {0} \t Email: {1} \t Phone: {2} \t Country: {3}", i.name,i.email,i.phone,i.country);
                }
              
            }

        }

        public static void CsvToJson()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(imortFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<CSVOperations>();
                string jsonPath = @"D:\Assignments\FileIOOperations\FileIOOperations\JsonFile.json";
                //Get all records from Csv File
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter stream = new StreamWriter(jsonPath))
                using (JsonWriter jsonWriter = new JsonTextWriter(stream))
                {
                    //Converting from List to Json Object
                    jsonSerializer.Serialize(jsonWriter, records);
                }


            }
        }
        public static void JsonToCsv()
        {
            string jsonPath = @"D:\Assignments\FileIOOperations\FileIOOperations\JsonFile.json";
            //Reading from json file
            List<CSVOperations> json = JsonConvert.DeserializeObject<List<CSVOperations>>(File.ReadAllText(jsonPath));
            //Set hasheaderRecord -> tells that it has no Header
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamWriter(@"D:\Assignments\FileIOOperations\FileIOOperations\JsonToCsv.csv"))
            using (var csv = new CsvWriter(reader, config))
            {
                csv.WriteRecords<CSVOperations>(json);
                Console.WriteLine("Successful!");

            }
        }
    }
}
