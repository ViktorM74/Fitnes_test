using Fitnes.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class UserController
    {
        public User User { get;  }

        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть равен null", nameof(user));
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
                if(formatter.Deserialize(fs) is User user)
                {
                    return user;
                }
                else
                {
                    throw new FileLoadException("Не удалось получить данные из файла", "users.dat");
                }
            }
        }
    }
}
