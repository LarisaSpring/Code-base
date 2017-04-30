using System;
using System.Collections.Generic;
using System.IO;
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

namespace ReadingWriting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Object thisLock = new Object();

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override async void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();
            //WriteToFileAsync();

            DeadLockSample();
        }

        public async Task WriteToFileAsync()
        {
            await Task.Run(() =>
            {
                lock (thisLock)
                {
                    string path = @"c:\temp\MyTest.txt";
                    // This text is added only once to the file.
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("Hello");
                            sw.WriteLine("And");
                            sw.WriteLine("Welcome");
                        }
                    }

                    // This text is always added, making the file longer over time
                    // if it is not deleted.
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("This");
                        sw.WriteLine("is Extra");
                        sw.WriteLine("Text");
                    }

                    // Open the file to read from.
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            });
        }

        public void DeadLockSample()
        {
            // thread 1
            lock (typeof(int))
            {
                Thread.Sleep(1000);
                lock (typeof(float))
                {
                    MessageBox.Show("Thread 1 got both locks");
                }

            }

            // thread 2
            lock (typeof(float))
            {
                Thread.Sleep(1000);
                lock (typeof(int))
                {
                    MessageBox.Show("Thread 2 got both locks");
                }
            }
        }
    }
}
