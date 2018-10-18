using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Lesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Список отделов
        /// </summary>
        private static List<Department> departments = new List<Department>();
        /// <summary>
        /// Экземпляр окна добавления сотрудников
        /// </summary>
        WorkerEditor workerEditor = new WorkerEditor();
        
        /// <summary>
        /// Свойство для получения списка отделов
        /// </summary>
        internal static List<Department> Departments { get => departments; set => departments = value; }


        public MainWindow()
        {
            InitializeComponent();
            LoadDepts();
        }

        /// <summary>
        /// Метод загрузки из файла в список отделов
        /// </summary>
        private void LoadDepts()
        {
            string json = File.ReadAllText("admin.json");
            Departments = JsonConvert.DeserializeObject<List<Department>>(json);
            cmbDepartments.ItemsSource = from n in Departments
                                         select n.Name;
        }


        private void cmbDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddWorkersToList();
        }

        /// <summary>
        /// Метод добавления в ListBox сотрудников из определенного отдела
        /// </summary>
        private void AddWorkersToList()
        {
            var x = from n in Departments
                    where n.Name == cmbDepartments.SelectedValue.ToString()
                    select (from m in n.Employees select m).ToList();



            foreach (var item in x)
            {

                listBoxEmployee.ItemsSource = item;
            }
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            SinchronizeFields();
        }

        /// <summary>
        /// Синхронизация полей разных форм
        /// </summary>
        private void SinchronizeFields()
        {
            workerEditor.cmbDept.ItemsSource = cmbDepartments.ItemsSource;
            workerEditor.cmbDept.SelectedValue = cmbDepartments.SelectedValue;
            workerEditor.Show();
        }

        /// <summary>
        /// Сериализация в JSON
        /// </summary>
        public static void Save()
        {
            string json = JsonConvert.SerializeObject(Departments);
            File.WriteAllText("admin.json", json);
        }
    }
}
