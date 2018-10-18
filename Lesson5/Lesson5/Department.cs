using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    /// <summary>
    /// Отдел
    /// </summary>
    class Department
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get;}
        public List<Employee> Employees { get => employees; set => employees = value; }

        /// <summary>
        /// Список сотрудников
        /// </summary>
        private List<Employee> employees;

        public Department(string name) { Name = name; Employees = new List<Employee>(); }

    }
}
