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
using WpfApplication2.ViewModels;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAddButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).CreatePermit();
        }

        private void OnSaveButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).SavePermit();
        }

        private void OnDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).DeletePermit();
        }

        private void OnSortButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).SortPermits();
        }

        private void PermitsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveButton.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
        }
    }
}
