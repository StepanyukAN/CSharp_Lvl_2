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
        


        public MainWindow()
        {
            InitializeComponent();
            mainGrid.DataContext = DB.Departments;
        }

        private void btnAddDept_Click(object sender, RoutedEventArgs e)
        {
            InputBox input = new InputBox();
            input.ShowDialog();
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow ww = new WorkerWindow();
            ww.Department = cmbDepartments.SelectedValue as Department;
            ww.ShowDialog();
        }

        private void listViewWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDepartmentWindow cw = new ChangeDepartmentWindow();
            cw.Employee = listViewWorkers.SelectedValue as Employee;
            cw.mainGrid.DataContext = cw.Employee;
            cw.ShowDialog();
        }
    }
}
