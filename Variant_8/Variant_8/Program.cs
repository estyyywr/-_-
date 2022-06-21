using System;
using System.IO;
using System.Linq;

namespace Variant_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zodiac[] zodiacs = new Zodiac[8];
            for (int i = 0; i < zodiacs.Length; i++)
            {
                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine();
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите знак зодиака: ");
                string zodiacSign = Console.ReadLine();
                int[] dateOfBirth = new int[3];
                Console.Write("Введите день: ");
                dateOfBirth[0] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите месяц: ");
                dateOfBirth[1] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите год: ");
                dateOfBirth[2] = Convert.ToInt32(Console.ReadLine());

                Zodiac zodiac = new Zodiac
                {
                    Surname = surname,
                    Name = name,
                    ZodiacSign = zodiacSign,
                    DateOfBirth = dateOfBirth
                };
                zodiacs[i] = zodiac;
                
                Console.WriteLine("Готово");
                Console.ReadKey();
                Console.Clear();
            }

            zodiacs = Sort(zodiacs);

            while (true)
            {
                Console.WriteLine("1. Все записи\n2. Поиск записи\n3. Записать в файл");
                int menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Conclusion(zodiacs);
                        break;

                    case 2:
                        Console.Write("Введите месяц рождения: ");
                        int search = Convert.ToInt32(Console.ReadLine());

                        bool exeminationSearch = zodiacs.Any(p => p.DateOfBirth[1] == search);
                        if (exeminationSearch)
                        {
                            var notesSearch = zodiacs.Where(p => p.DateOfBirth[1] == search).ToArray();
                            Conclusion(notesSearch);
                        }
                        else
                        {
                            Console.WriteLine("Такой записи нет");
                        }
                        break;

                    case 3:
                        Console.Write("Введите имя файла: ");
                        string title = Console.ReadLine() + ".txt";

                        Writer(title, zodiacs);
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

        static void Conclusion(Zodiac[] zodiacs)
        {
            foreach (var item in zodiacs)
            {
                Console.WriteLine(item.Surname + "\t" + item.Name + "\t" + item.ZodiacSign + "\t" + item.DateOfBirth[0] + "\t" + item.DateOfBirth[1] + "\t" + item.DateOfBirth[2]);
            }
        }

        static async void Writer(string title, Zodiac[] zodiacs)
        {
            using (StreamWriter writer = new StreamWriter(title, false))
            {
                foreach (var item in zodiacs)
                {
                    await writer.WriteLineAsync(item.Surname + "\t" + item.Name + "\t" + item.ZodiacSign + "\t" + item.DateOfBirth[0] + "\t" + item.DateOfBirth[1] + "\t" + item.DateOfBirth[2]);
                }
            }
        }

        static Zodiac[] Sort(Zodiac[] zodiacs)
        {
            for (int i = 0; i < zodiacs.Length; i++)
            {
                for (int j = 0; j < zodiacs.Length; j++)
                {
                    DateTime dateOfBirth = new DateTime(1, zodiacs[i].DateOfBirth[1], zodiacs[i].DateOfBirth[0], 0, 0, 0);
                    DateTime dateOfBirth1 = new DateTime(1, zodiacs[j].DateOfBirth[1], zodiacs[j].DateOfBirth[0], 0, 0, 0);
                    if (dateOfBirth < dateOfBirth1)
                    {
                        var sort = zodiacs[i];
                        zodiacs[i] = zodiacs[j];
                        zodiacs[j] = sort;
                    }
                }
            }

            return zodiacs;
        }
    }

    class Zodiac
    {
        public string Surname;
        public string Name;
        public string ZodiacSign;
        public int[] DateOfBirth = new int[3];
    }
}
