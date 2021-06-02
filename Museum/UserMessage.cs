using DBConnect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Museum
{
    public class UserMessage
    {
          public static void Welcome()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("MY PERSONAL MUSEUM");
                Console.WriteLine();
                Console.ResetColor();
            }

            public static void GoodBye()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("MY PERSONAL MUSEUM CLOSED");
                Console.ResetColor();
            }

            public static void ShowMenu()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Найти автора");
                Console.WriteLine("2. Найти произведение искусств");
                Console.WriteLine("3. Найти место хранения");
                Console.WriteLine("4. Найти место хранения экспоната");
                Console.WriteLine("0. Выход из программы");
                Console.ResetColor();
            }

            public static int InputKey()
            {
                Console.Write("Введите пункт меню: ");
                var key = Console.ReadLine();
                return key switch
                {
                    "1" => 1,
                    "2" => 2,
                    "3" => 3,
                    "0" => 0,
                    _ => InputKey()
                };
            }

            public static void FindAuthor()
            {
                var db = new DB();
                db.Open();

                var author = db.GetAuthor("Писсарро Камиль");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"id - {author.Id}");
                Console.WriteLine($"author_name - {author.AuthorName}");
                Console.WriteLine($"birth_date - {author.BirthDate}");
                Console.WriteLine($"death_date - {author.DeathDate}");
                Console.WriteLine($"birth_country - {author.BirthCountry}");
                Console.WriteLine();
                Console.ResetColor();

                db.Close();
            }
            public static void FindExhibits()
            {
                var db = new DB();
                db.Open();

                var exhibits = db.GetExhibits("Поцелуй");
            Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"id - {exhibits.Id}");
                Console.WriteLine($"name - {exhibits.ExhibitsName}");
                Console.WriteLine($"id_author - {exhibits.IdAuthor}");
                Console.WriteLine($"creation_date - {exhibits.CreationDate}");
                Console.WriteLine($" art_direction - {exhibits.ArtDirection}");
                Console.WriteLine($"art_form - {exhibits.ArtForm}");
                Console.WriteLine($"materials - {exhibits.Materials}");
                Console.WriteLine();
                Console.ResetColor();

                db.Close();
            }

        public static void FindStorage()
        {
            var db = new DB();
            db.Open();

            var storage = db.GetStorage("зал 1");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"id - {storage.Id}");
            Console.WriteLine($"storage_name - {storage.StorageName}");
            Console.WriteLine();
            Console.ResetColor();

            db.Close();
        }

        public static void FindSpaceStorage()
        {
            var db = new DB();
            db.Open();

            var spaceStorage = db.GetSpaceStorage(6);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"id - {spaceStorage.Id}");
            Console.WriteLine($"name - {spaceStorage.IdExhibits}");
            Console.WriteLine($"id_author - {spaceStorage.IdStorage}");
            Console.WriteLine($"creation_date - {spaceStorage.SpecialConditions}");
            Console.WriteLine();
            Console.ResetColor();

            db.Close();
        }
    }
    }
