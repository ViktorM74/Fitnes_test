using Fitnes.BL.Controller;
using Fitnes.BL.Model;
using System;

namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа Fitnes загружена.");
            
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                
                var birthdate = ParseDateTime();
                var weigth = ParseDouble("вес");
                var heigth = ParseDouble("рост");

                userController.SetNowUserData(gender, birthdate, weigth, heigth);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что Вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                EnterEating();
            }

            Console.ReadKey();
         }

        private static (Food, double weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var weight = ParseDouble("вес порции");

            return new Food(food, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthdate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
                }
            }

            return birthdate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}
