using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeTransferTestClass srcObject = new DateTimeTransferTestClass()
            {
                DateWithTime1 = DateTime.Now,
                DateOnly = DateTime.Today,
                DateWithTime2 = DateTime.Now.AddHours(-2)
            };
            Console.WriteLine("Before serialization:");
            srcObject.Print();

            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            var srcJSON = JsonConvert.SerializeObject(srcObject, microsoftDateFormatSettings);
            Console.WriteLine("Serialized object:");
            Console.WriteLine(srcJSON);

            Console.WriteLine("After deserialization:");
            DateTimeTransferTestClass dstObject = JsonConvert.DeserializeObject<DateTimeTransferTestClass>(srcJSON);
            dstObject.Print();

            Console.ReadLine();
        }

        
        public class DateTimeTransferTestClass
        {
            public DateTime DateWithTime1 { get; set; }
            [JsonConverter(typeof(DateOnlyJsonConverter))]
            public DateTime DateOnly { get; set; }
            public DateTime DateWithTime2 { get; set; }

            internal void Print()
            {
                Console.WriteLine($"Date with tme 1: {DateWithTime1}");
                Console.WriteLine($"Date only: {DateOnly}");
                Console.WriteLine($"Date with tme 2: {DateWithTime2}");
            }
        }
    }   
}
