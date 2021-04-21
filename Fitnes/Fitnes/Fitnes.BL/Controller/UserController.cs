using Fitnes.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    /// <summary>
    /// Контроллер Пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get;  }
        
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        /// <summary>
        /// Сохранение данных пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }

        }
        /// <summary>
        /// Чтение данных пользователя
        /// </summary>
        /// <returns> Пользователь приложения </returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
    }
}
