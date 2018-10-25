using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    /// <summary>
    /// Класс базы данных
    /// </summary>
    static class DB
    {
        /// <summary>
        /// Свойство для получения списка отделов
        /// </summary>
        public static ObservableCollection<Department> Departments { get; set; }
        /// <summary>
        /// Загрузка списка отделов из JSON
        /// </summary>
        static DB()
        {
            string json = File.ReadAllText("admin.json");
            Departments = JsonConvert.DeserializeObject<ObservableCollection<Department>>(json);
        }

        /// <summary>
        /// Сохранение в JSON
        /// </summary>
        public static void Save()
        {
            string json = JsonConvert.SerializeObject(Departments);
            File.WriteAllText("admin.json", json);
        }

        /// <summary>
        /// Добавление сотрудника в отдел
        /// </summary>
        /// <param name="name">ФИО</param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="position">Должность</param>
        /// <param name="department">Отдел</param>
        public static void AddWorker(string name, DateTime birthday, string position, Department department)
        {
            Departments[Departments.IndexOf(department)].Employees.Add(new Employee(name, birthday, position));
            Save();
        }

        /// <summary>
        /// Метод добавления нового отдела
        /// </summary>
        /// <param name="text"></param>
        public static void Add(string text)
        {
            Departments.Add(new Department(text));
            Save();
        }
    }
}
