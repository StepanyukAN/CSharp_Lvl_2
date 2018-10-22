using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson5
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    class Employee
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">ФИО</param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="position">Должность</param>
        public Employee(string name, DateTime birthday, string position)
        {
            FullName = name;
            Birthday = birthday;
            Position = position;
        }

        public override string ToString()
        {
            return $"{FullName} {Position}";
        }
    }
    
}
