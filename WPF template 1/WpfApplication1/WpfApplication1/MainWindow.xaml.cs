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

namespace WpfApplication1
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


        protected override async void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            try
            {
                await ((MainViewModel)DataContext).Initialize();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void OnSaveButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).SavePermit();
        }

        private void OnButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).CreateWorkPermit();
        }

        private void OnAddAttachment_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).SelectedPermit.CreateAttachment();
        }

        private void ListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAddAttach.Visibility = Visibility.Visible;
        }

        private void OnSaveAttachmentButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
