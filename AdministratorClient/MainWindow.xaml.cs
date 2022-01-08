using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AdministratorClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Data> dataList = new List<Data>(); 

        public MainWindow()
        {
            InitializeComponent();
            WorkList.ItemsSource = dataList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userError.Content = IsValidUser(tbUser.Text);

            typeError.Content = IsValidType(tbType.Text);

            licensePlateError.Content = IsValidLicensePlate(tbLicensePlate.Text);

            problemError.Content = IsValidProblem(tbProblem.Text);

            if(userError.Content == null && typeError.Content == null && licensePlateError.Content == null && problemError.Content == null)
            {
                dataList.Add(new Data(tbUser.Text, tbType.Text, tbLicensePlate.Text, tbProblem.Text));
                WorkList.Items.Refresh();

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(WorkList.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

                tbUser.Text = null;
                tbType.Text = null;
                tbLicensePlate.Text = null;
                tbProblem.Text = null;
            }
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
            var selectedItem = (Data)WorkList.SelectedItem;
            tbUser.Text = selectedItem.UserName;
            tbType.Text = selectedItem.Type;
            tbLicensePlate.Text = selectedItem.LicensePlate;
            tbProblem.Text = selectedItem.Problem;
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Data)WorkList.SelectedItem;
            selectedItem.UserName = tbUser.Text;
            selectedItem.Type = tbType.Text;
            selectedItem.LicensePlate = tbLicensePlate.Text;
            selectedItem.Problem = tbProblem.Text;

            WorkList.Items.Refresh();
        }
    }
}
