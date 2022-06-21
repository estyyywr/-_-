using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Variant_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Route[] routes = new Route[8];
            for (int i = 0; i < routes.Length; i++)
            {
                Console.Write("Введите номер маршрута: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите начальную станцию: ");
                string startPoint = Console.ReadLine();
                Console.Write("Введите конечную станцияю: ");
                string endPoint = Console.ReadLine();

                Route route = new Route
                {
                    Number = number,
                    StartPoint = startPoint,
                    EndPoint = endPoint
                };
                routes[i] = route;

                Console.WriteLine("Маршрут добавлен");
                Console.ReadKey();
                Console.Clear();
            }
            routes = routes.OrderBy(p => p.Number).ToArray();

            while (true)
            {
                Console.WriteLine("1. Все маршруты\n2. Поиск маршрута\n3. Запись маршрутов в файл");
                int menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Conclusion(routes);
                        break;

                    case 2:
                        Console.Write("Введите станцию: ");
                        string search = Console.ReadLine();

                        bool exeminationSearch = routes.Any(p => p.StartPoint == search || p.EndPoint == search);
                        if (exeminationSearch)
                        {
                            var routesSearch = routes.Where(p => p.StartPoint == search || p.EndPoint == search).ToArray();
                            Conclusion(routesSearch);
                        }
			else
			{
		            Console.ReadLine("Такого маршрута нет");
			}
                        break;

                    case 3:
                        Console.Write("Введите имя файла: ");
                        string title = Console.ReadLine() + ".txt";

                        Writer(title, routes);
                        Console.WriteLine("Файл изменен");
                        break;

                    default:
                        Console.WriteLine("Что-то пошло не так :(");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void Conclusion(Route[] routes)
        {
            foreach (var item in routes)
            {
                Console.WriteLine(item.Number + "\t" + item.StartPoint + "\t" + item.EndPoint);
            }
        }

        static async void Writer(string title, Route[] routes)
        {
            using (StreamWriter writer = new StreamWriter(title, false))
            {
                foreach (var item in routes)
                {
                    await writer.WriteLineAsync(item.Number + "\t" + item.StartPoint + "\t" + item.EndPoint);
                }
            }
        }
    }

    class Route
    {
        public string StartPoint;
        public string EndPoint;
        public int Number;
    }
}
