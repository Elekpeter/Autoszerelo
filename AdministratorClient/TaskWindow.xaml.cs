using Core.DataProviders;
using Core.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace AdministratorClient
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private readonly Task _task;

        public TaskWindow(Task task)
        {
            InitializeComponent();
            if(task != null)
            {
                _task = task;

                tbUser.Text = task.UserName;
                tbType.Text = task.Type;
                tbLicensePlate.Text = task.LicensePlate;
                tbProblem.Text = task.Problem;
            }
            else
            {
                _task = new Task();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            userError.Content = IsValidUser(tbUser.Text);

            typeError.Content = IsValidType(tbType.Text);

            licensePlateError.Content = IsValidLicensePlate(tbLicensePlate.Text);

            problemError.Content = IsValidProblem(tbProblem.Text);

            if (userError.Content == null && typeError.Content == null && licensePlateError.Content == null && problemError.Content == null)
            {
                TaskDataProvider.CreateTask(new Task(tbUser.Text, tbType.Text, tbLicensePlate.Text, tbProblem.Text));

                //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(WorkList.ItemsSource);
                //view.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

                DialogResult = true;
                Close();
            }
        }
        

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            userError.Content = IsValidUser(tbUser.Text);

            typeError.Content = IsValidType(tbType.Text);

            licensePlateError.Content = IsValidLicensePlate(tbLicensePlate.Text);

            problemError.Content = IsValidProblem(tbProblem.Text);

            if (userError.Content == null && typeError.Content == null && licensePlateError.Content == null && problemError.Content == null)
            {
                _task.UserName = tbUser.Text;
                _task.Type = tbType.Text;
                _task.LicensePlate = tbLicensePlate.Text;
                _task.Problem = tbProblem.Text;

                TaskDataProvider.UpdateTask(_task);

                DialogResult = true;
                Close();
            }
        }

#region validation

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
#endregion
    }
}
