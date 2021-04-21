using System;


namespace Fitnes.BL.Model
{
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Гендер-название
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создание нового гендера
        /// </summary>
        /// <param name="name"> Название </param>
        public Gender (string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя гендера не может быть пустым.", nameof(name));
            }

            Name = name;
        }
    }
}
