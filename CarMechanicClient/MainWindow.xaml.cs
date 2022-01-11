using Core.DataProviders;
using Core.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
        }

        private void UpdateTaskListItems()
        {
            WorkList.ItemsSource = TaskDataProvider.GetTasks().ToList();
        }

        private void WorkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch (((Data)WorkList.SelectedItem).Status)
            //{
            //    case WorkStatus.FelvettMunka:
            //        StatusList.Te = 
            //    case 

            //    default:
            //        break;
            //}  

            StatusList.Text = ((Core.Models.Task)WorkList.SelectedItem).Status;
        }
    }
}
