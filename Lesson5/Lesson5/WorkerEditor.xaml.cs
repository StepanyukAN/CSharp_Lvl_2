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
using System.Windows.Shapes;

namespace Lesson5
{
    /// <summary>
    /// Логика взаимодействия для WorkerEditor.xaml
    /// </summary>
    public partial class WorkerEditor : Window
    {
        public WorkerEditor()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorker();
        }

        /// <summary>
        /// Добавляем работника в отдел
        /// </summary>
        private void AddWorker()
        {
            MainWindow.Departments[cmbDept.SelectedIndex].Employees.Add(
                            new Employee(txtName.Text, DTPBirthday.DisplayDate, txtPosition.Text));
            MainWindow.Save();
            this.Hide();
        }
    }
}
