using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Employee> Employees { get => employees; set => employees = value; }

        /// <summary>
        /// Список сотрудников
        /// </summary>
        private ObservableCollection<Employee> employees;

        public Department(string name) { Name = name; Employees = new ObservableCollection<Employee>(); }

        public override string ToString()
        {
            return Name;
        }
    }
}
