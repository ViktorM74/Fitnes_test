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
            
            Console.WriteLine("Введите пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");
            var birthdate = DateTime.Parse(Console.ReadLine()); //TODO переписать

            Console.WriteLine("Введите вес:");
            var weigth = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост:");
            var heigth = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weigth, heigth);

            userController.Save();

        }
    }
}
