using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace CPU_Benchmark
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

        private void start_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stops = new Stopwatch();
            float single = 100000;
            float multi = 400000;
            stops.Start();
            if (name.Text != string.Empty) { MessageBox.Show("Dělej zadej něco"); return; }
            for (int i = 0; i < 100; i+=10)
            {
                bar.Value += i;
                Thread.Sleep(700);
            }
            if (singleCore.IsChecked == true)
            {
                for (int i = 0; i < single; i++)
                {
                    for (int j = 0; j < i / 2; j++)
                    {
                        if (j%2 !=0) { break; }
                    }
                }
            }
            else if (multiCore.IsChecked == true)
            {
                for (int i = 0; i < multi; i++)
                {
                    for (int j = 0; j < i /2; j++)
                    {
                        if (j%2 != 0) { break; }
                    }
                }
            }
            stops.Stop();
            MessageBox.Show($"Done in {stops.Elapsed}");
            if (bar.Value == 100)
            {
                Random gen = new Random();
                int rng = gen.Next(0,10000);
                bar.Value = 0;
                result.Text = $" {rng} points";
            }
        }
    }
}
