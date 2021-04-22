using System;


namespace Fitnes.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrayes { get;  }
        /// <summary>
        /// Калории за 100г продукта
        /// </summary>
        public double Calories { get;  }


        public Food(string name): this(name, 0, 0, 0, 0) { }

        public Food(string name, double proteins, double fats, double carbohydrayes, double calories)
        {
            //TODO Проверка

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0 ;
            Carbohydrayes = carbohydrayes / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
