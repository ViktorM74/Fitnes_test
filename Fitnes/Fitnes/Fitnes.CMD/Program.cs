using Fitnes.BL.Controller;
using Fitnes.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture(""); // ru-ru; en-us
            //var culture = CultureInfo.CurrentCulture;
            ResourceManager resourceManager = new ResourceManager("Fitnes.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello_Stat", culture));
            
            Console.WriteLine(resourceManager.GetString("Input_User_Name", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("Input_gender", culture));
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
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
               var foods =  EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
                
            }

            Console.ReadKey();
         }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var weight = ParseDouble("вес порции");
            var calories = ParseDouble("калорийность продукта");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
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
