using Fitnes.BL.Controller;
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
            Console.ReadKey();
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
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }
    }
}
