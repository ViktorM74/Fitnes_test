using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Model
{
    public class Gender
    {
        public string Name { get; }
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
