using Core.DataProviders;
using Core.Models;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CarMechanicClient
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

            StatusList.Items.Add(WorkStatus.FelvettMunka);
            StatusList.Items.Add(WorkStatus.ElvegzesAlatt);
            StatusList.Items.Add(WorkStatus.Befejezett);
            StatusList.IsEnabled = false;
        }

        private void UpdateTaskListItems()
        {
            WorkList.ItemsSource = TaskDataProvider.GetTasks().ToList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(WorkList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
        }

        private void WorkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Task)WorkList.SelectedItem;

            if (selectedItem != null)
            {
                StatusList.IsEnabled = true;
                StatusList.Text = selectedItem.Status;
            }
            else
            {
                StatusList.IsEnabled = false;
                StatusList.Text = string.Empty;
            }
        }

        private void StatusList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Task)WorkList.SelectedItem;
            
            if (selectedItem != null && selectedItem.Status != StatusList.SelectedItem.ToString())
            {
                selectedItem.Status = StatusList.SelectedItem.ToString();
                TaskDataProvider.UpdateTask(selectedItem);

                UpdateTaskListItems();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateTaskListItems();
        }
    }
}
