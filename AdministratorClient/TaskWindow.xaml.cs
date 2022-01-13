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
        private bool IsNew;

        public TaskWindow(Task task)
        {
            InitializeComponent();
            if(task != null)
            {
                _task = task;
                IsNew = false;

                tbUser.Text = task.UserName;
                tbType.Text = task.Type;
                tbLicensePlate.Text = task.LicensePlate;
                tbProblem.Text = task.Problem;
            }
            else
            {
                IsNew = true;
                _task = new Task();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (IsAllValid())
            {
                if (IsNew)
                {
                    TaskDataProvider.CreateTask(new Task(tbUser.Text, tbType.Text, tbLicensePlate.Text, tbProblem.Text));
                }
                else
                {
                    _task.UserName = tbUser.Text;
                    _task.Type = tbType.Text;
                    _task.LicensePlate = tbLicensePlate.Text;
                    _task.Problem = tbProblem.Text;

                    TaskDataProvider.UpdateTask(_task);
                }

                DialogResult = true;
                Close();
            }
        }
        
        private bool IsAllValid()
        {
            userError.Content = IsValidUser(tbUser.Text);

            typeError.Content = IsValidType(tbType.Text);

            licensePlateError.Content = IsValidLicensePlate(tbLicensePlate.Text);

            problemError.Content = IsValidProblem(tbProblem.Text);

            if (userError.Content == null && typeError.Content == null && licensePlateError.Content == null && problemError.Content == null)
            {
                return true;
            }

            return false;
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
