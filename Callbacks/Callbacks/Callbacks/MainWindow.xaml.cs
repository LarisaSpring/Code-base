using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Callbacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassCallbackProvocator provocator;

        public MainWindow()
        {
            InitializeComponent();
            
            provocator = new ClassCallbackProvocator(Callback1, Callback2);
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await provocator.Callback1Run();
            provocator.Callback2Run();
        }

        public async Task Callback1()
        {
            await Task.Delay(1000);

            //await Task.Run(async () =>
            //{
            //    await Dispatcher.InvokeAsync(() =>
            //    {
            //        ButtonCallback1.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            //    });
            //});

            ButtonCallback1.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));

            await Task.Delay(1000);
        }

        public void Callback2()
        {
            Thread.Sleep(2000);
            ButtonCallback1.Width = 500;
        }
    }
}
