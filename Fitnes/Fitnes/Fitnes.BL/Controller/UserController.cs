using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    /// <summary>
    /// Контроллер Пользователя
    /// </summary>
    public class UserController: ControllerBase
    {
        private const string USER_FILE = "users.dat";

        /// <summary>
        /// Пользователи
        /// </summary>
        public List<User> Users { get; } 

        public User CurrentUser { get;  }

        public bool IsNewUser { get; } = false;
        
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть пустым", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns> список пользователей </returns>
        private List<User> GetUserData()
        {
            return Load<List<User>>(USER_FILE) ?? new List<User>();
        }

        public void SetNowUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранение данных пользователя
        /// </summary>
        public void Save()
        {
            Save(USER_FILE, Users);
        }
       
       
    }
}
