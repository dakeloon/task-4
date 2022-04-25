# task-4
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    [Serializable]
    class TextFile
    {
        public string Author { get; set; }

        public TextFile(string Name)
        {
            Author = Name;
        }

    }

    class Program
    {
        static string FileName;
        public static void CreateFile()
        {
            try
            {
                Console.Write("Enter file name: ");
                FileName = Console.ReadLine();

                File.Move($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}.txt", $"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}Copy.txt");
                FileStream StreamFile = new FileStream(FileName + ".txt", FileMode.Create);
                Console.WriteLine("File text: ");
                string text = Console.ReadLine();
                StreamWriter TextWriter = new StreamWriter(StreamFile);
                TextWriter.WriteLine(text);
                TextWriter.Close();
            }
            catch (Exception exception)
            { Console.WriteLine("File creation error: { 0}", exception.Message); }
        }
        public static void OpenFile()
        {
            try
            {
                Console.WriteLine("Enter file name: ");
                using (StreamReader ReaderStream = new StreamReader(Console.ReadLine() + ".txt"))
                {
                    string Line;
                    Console.WriteLine("File text: ");
                    while ((Line = ReaderStream.ReadLine()) != null)
                    { Console.WriteLine(Line + "\n"); }
                }
            }
            catch (Exception exeption)
            { Console.WriteLine("File opening error: {0}", exeption.Message); }
        }

        public static void RollbackChanges()
        {
            File.Delete($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}.txt");
            File.Move($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}Copy.txt", $"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}.txt");
            Console.WriteLine("Rollback was successful");
        }
