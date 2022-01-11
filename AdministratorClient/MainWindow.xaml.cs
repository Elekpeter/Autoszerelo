using AdministratorClient.DataProviders;
using Core.Models;
using System.Collections.Generic;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userError.Content = IsValidUser(tbUser.Text);

            typeError.Content = IsValidType(tbType.Text);

            licensePlateError.Content = IsValidLicensePlate(tbLicensePlate.Text);

            problemError.Content = IsValidProblem(tbProblem.Text);

            if(userError.Content == null && typeError.Content == null && licensePlateError.Content == null && problemError.Content == null)
            {
                TaskDataProvider.CreateTask(new Task(tbUser.Text, tbType.Text, tbLicensePlate.Text, tbProblem.Text));
                UpdateTaskListItems();

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(WorkList.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

                tbUser.Text = null;
                tbType.Text = null;
                tbLicensePlate.Text = null;
                tbProblem.Text = null;
            }
        }

        private void UpdateTaskListItems()
        {
            WorkList.ItemsSource = TaskDataProvider.GetTasks().ToList();
        }

        public string IsValidUser(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                 return "Nem lehet üres!";
            }
            if (hasSpecialChar(user))
            {
                return "Nem használható speciális karakter!";
            }

            return null;
        }

        public string IsValidType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return "Nem lehet üres!";
            }
            if (hasSpecialChar(type))
            {
                return "Nem használható speciális karakter!";
            }

            return null;
        }

        public string IsValidLicensePlate(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "Nem lehet üres!";
            }
            bool isOK = Regex.IsMatch(id, @"[A-Z][A-Z][A-Z]\-[0-9][0-9][0-9]$");
            if (!isOK)
            {
                return "Rossz formátum! A helyes: XXX-000";
            }
           
            return null;
        }

        public string IsValidProblem(string problem)
        {
            if (string.IsNullOrWhiteSpace(problem))
            {
                return "Nem lehet üres!";
            }
     
            return null;
        }

        private bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?-»«@£§€{}.;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        private void WorkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Task)WorkList.SelectedItem;
            tbUser.Text = selectedItem.UserName;
            tbType.Text = selectedItem.Type;
            tbLicensePlate.Text = selectedItem.LicensePlate;
            tbProblem.Text = selectedItem.Problem;

            UpdateTaskListItems();
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Task)WorkList.SelectedItem;
            selectedItem.UserName = tbUser.Text;
            selectedItem.Type = tbType.Text;
            selectedItem.LicensePlate = tbLicensePlate.Text;
            selectedItem.Problem = tbProblem.Text;

            WorkList.Items.Refresh();
        }
    }
}
