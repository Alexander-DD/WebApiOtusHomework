using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebClient
{
    static class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:5001/");

            while (true)
            {
                Console.WriteLine("======================");
                Console.WriteLine("Меню");
                Console.WriteLine("1. Данные по клиенту.");
                Console.WriteLine("2. Добавление клиента.");
                Console.WriteLine("3. Добавление рандомного клиента.");
                Console.WriteLine("Q. Выход");
                Console.WriteLine("======================");
                Console.Write("> ");
                string menuResult = Console.ReadLine();
                Console.Clear();

                if (menuResult == "1")
                {
                    Console.WriteLine("1. Данные по клиенту.");
                    Console.WriteLine("------------------------");
                    Console.Write("Введите id клиента: ");
                    long? clientId = ReadLineInt64();

                    if (clientId != null)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.GetAsync("customers/" + clientId);
                            //response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            // Above three lines can be replaced with new helper method below
                            // string responseBody = await client.GetStringAsync(uri);

                            Console.WriteLine("------------------------");
                            Console.WriteLine("Информация по клиенту:");
                            Console.WriteLine(responseBody);
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                    }
                }
                else if (menuResult == "2")
                {
                    Console.WriteLine("2. Добавление клиента.");
                    Console.WriteLine("------------------------");
                    Console.Write("Введите имя клиента: ");
                    string firstname = Console.ReadLine();
                    Console.Write("Введите фамилию клиента: ");
                    string lastname = Console.ReadLine();

                    if (firstname != null && lastname != null)
                    {
                        try
                        {
                            CustomerCreateModel newCustomer = new CustomerCreateModel(firstname, lastname);
                            string json = JsonConvert.SerializeObject(newCustomer);

                            var content = new StringContent(json, Encoding.UTF8, "application/json");

                            var response = await client.PostAsync("customers", content);
                            string responseBody = await response.Content.ReadAsStringAsync();

                            Console.WriteLine("------------------------");
                            Console.WriteLine($"Клиент с ID: {responseBody}, добавлен.");
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                    }
                }
                else if (menuResult == "3")
                {
                    Console.WriteLine("3. Добавление рандомного клиента.");
                    Console.WriteLine("------------------------");

                    try
                    {
                        CustomerCreateModel newCustomer = RandomCustomer();
                        string json = JsonConvert.SerializeObject(newCustomer);

                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync("customers", content);
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Console.WriteLine($"Клиент с ID: {responseBody}, добавлен.");
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("\nException Caught!");
                        Console.WriteLine("Message :{0} ", e.Message);
                    }
                }
                else if (menuResult.ToUpper() == "Q")
                {
                    return;
                }
            }

            throw new NotImplementedException();
        }

        private static long? ReadLineInt64()
        {
            string result = Console.ReadLine();

            if (result == null)
            {
                Console.WriteLine("Пустой ввод");
                return null;
            }

            long resultInt64;

            if (!Int64.TryParse(result, out resultInt64))
            {
                Console.WriteLine("Невозможно преобразовать введённое значение в число Int64");
                return null;
            }

            return resultInt64;
        }

        private static CustomerCreateModel RandomCustomer()
        {
            return new CustomerCreateModel(RandomizeString(4), RandomizeString(7));
        }

        private static string RandomizeString(int length)
        {
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }
    }
}