using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonTask
{
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
    }

    public class Book
    {
        [JsonIgnore]
        public int PublishingHouseId { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        public PublishingHouse? PublishingHouse { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string jsonFilePath = "data.json";

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("Файл data.json не знайдено!");
                return;
            }

            string jsonString = File.ReadAllText(jsonFilePath);
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString)!;

            Console.WriteLine("--- Результат десеріалізації ---");
            foreach (var book in books)
            {
                Console.WriteLine($"Книга: {book.Title}, Видавництво: {book.PublishingHouse?.Name}");
            }

            var options = new JsonSerializerOptions { 
                WriteIndented = true, 
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string reSerializedJson = JsonSerializer.Serialize(books, options);

            Console.WriteLine("\n--- Результат зворотної серіалізації ---");
            Console.WriteLine(reSerializedJson);
        }
    }
}