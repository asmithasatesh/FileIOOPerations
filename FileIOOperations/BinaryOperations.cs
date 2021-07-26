using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FileIOOperations
{
    //Indicate that Class can be Serialized
    [Serializable]
    class BinaryOperations
    {

        //Instance Variables
        public string name { get; set; }
        public string age { get; set; }

        public BinaryOperations(string name, string age)
        {
            this.name = name;
            this.age=age;
  
        }
        //Serialization: From object to Binary Format
        public static void BinarySerialization()
        {
            string Binarypath = @"D:\Assignments\FileIOOperations\FileIOOperations\BinaryFile.txt";
            //Creating object and call Parameterised Constructor
            BinaryOperations users = new BinaryOperations("ash", "15");
            FileStream file = File.OpenWrite(Binarypath);

            //Binary format is used to serialize and deserialize object
            BinaryFormatter serialise = new BinaryFormatter();
            serialise.Serialize(file, users);
            Console.WriteLine("Successfully Serialized!");
        }
        //DeSerialization: Binary Format to Object
        public static  void BinaryDeSerialization()
        {
            string Binarypath = @"D:\Assignments\FileIOOperations\FileIOOperations\BinaryFile.txt";
            FileStream file = File.OpenRead(Binarypath);
            BinaryFormatter deserialise = new BinaryFormatter();
            BinaryOperations person = (BinaryOperations)deserialise.Deserialize(file);
            Console.WriteLine("----- After Binary Deserialization -----");
            Console.WriteLine("Name: {0} \t Age: {1}", person.name, person.age);
        }
    }
}
