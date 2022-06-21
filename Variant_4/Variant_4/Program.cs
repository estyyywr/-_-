using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Note[] notes = new Note[8];
            for (int i = 0; i < notes.Length; i++)
            {
                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine();
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите телефон: ");
                string phone = Console.ReadLine();
                int[] dateOfBirth = new int[3];
                Console.Write("Введите день: ");
                dateOfBirth[0] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите месяц: ");
                dateOfBirth[1] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите год: ");
                dateOfBirth[2] = Convert.ToInt32(Console.ReadLine());

                Note note = new Note
                {
                    Surname = surname,
                    Name = name,
                    Phone = phone,
                    DateOfBirth = dateOfBirth
                };
                notes[i] = note;

                Console.WriteLine("Готово");
                Console.ReadKey();
                Console.Clear();
            }
            notes = notes.OrderBy(p => p.Surname).ThenBy(p => p.Name).ToArray();

            while (true)
            {
                Console.WriteLine("1. Все записи\n2. Поиск записи\n3. Записать в файл");
                int menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Conclusion(notes);
                        break;

                    case 2:
                        Console.Write("Введите месяц рождения: ");
                        int search = Convert.ToInt32(Console.ReadLine());

                        bool exeminationSearch = notes.Any(p => p.DateOfBirth[1] == search);
                        if (exeminationSearch)
                        {
                            var notesSearch = notes.Where(p => p.DateOfBirth[1] == search).ToArray();
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

                        Writer(title, notes);
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

        static void Conclusion(Note[] notes)
        {
            foreach (var item in notes)
            {
                Console.WriteLine(item.Surname + "\t" + item.Name + "\t" + item.Phone + "\t" + item.DateOfBirth[0] + "\t" + item.DateOfBirth[1] + "\t" + item.DateOfBirth[2]);
            }
        }

        static async void Writer(string title, Note[] notes)
        {
            using (StreamWriter writer = new StreamWriter(title, false))
            {
                foreach (var item in notes)
                {
                    await writer.WriteLineAsync(item.Surname + "\t" + item.Name + "\t" + item.Phone + "\t" + item.DateOfBirth[0] + "\t" + item.DateOfBirth[1] + "\t" + item.DateOfBirth[2]);
                }
            }
        }
    }

    class Note
    {
        public string Surname;
        public string Name;
        public string Phone;
        public int[] DateOfBirth = new int[3];
    }
}
