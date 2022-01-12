using Core.DataProviders;
using Core.Models;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AdministratorClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateTaskListItems();
        }

        

        private void UpdateTaskListItems()
        {
            WorkList.ItemsSource = TaskDataProvider.GetTasks().ToList();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            var window = new TaskWindow(null);
            if(window.ShowDialog() ?? false)
            {
                UpdateTaskListItems();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedTask = WorkList.SelectedItem as Task;
            if(selectedTask != null)
            {
                var window = new TaskWindow(selectedTask);
                if (window.ShowDialog() ?? false)
                {
                    UpdateTaskListItems();
                }
            }

            
        }
    }
}
