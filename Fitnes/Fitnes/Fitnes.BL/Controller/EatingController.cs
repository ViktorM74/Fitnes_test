using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class EatingController: ControllerBase
    {
        private const string FOODS_FILE = "foods.dat";
        private const string EATING_FILE = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GeEating();
        }
      
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GeEating()
        {
            return Load<Eating>(EATING_FILE) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
           return Load<List<Food>>(FOODS_FILE) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE, Foods);
            Save(EATING_FILE, Eating);
        }

        
             
    }
}
