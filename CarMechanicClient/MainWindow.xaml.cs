using Core;
using Core.Models;
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

namespace CarMechanicClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Core.Models.Task> dataList = new List<Core.Models.Task>();
        public MainWindow()
        {
            InitializeComponent();
            WorkList.ItemsSource = dataList;

            StatusList.Items.Add(WorkStatus.FelvettMunka);
            StatusList.Items.Add(WorkStatus.ElvegzesAlatt);
            StatusList.Items.Add(WorkStatus.Befejezett);
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
