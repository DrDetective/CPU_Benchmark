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
using CPU_Benchmark;

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
        private void Loadbar()
        {
            for (int i = 0; i < 100; i += 10)
            {
                bar.Value += i;
                Thread.Sleep(700);
            }
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text.ToString() != string.Empty == false) { MessageBox.Show("Dělej zadej něco"); return; }
            Stopwatch stops = new Stopwatch();
            float single = 100000;
            float multi = 400000;
            stops.Start();
            if (singleCore.IsChecked == true)
            {
                Loadbar();
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
                Loadbar();
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
                result.Content = $" {rng} points";
            }
        }
        private void mode_Click(object sender, RoutedEventArgs e)
        {
            window.Background = Brushes.Black;
            cpu.Foreground = Brushes.White;
            enter.Foreground = Brushes.White;
            singleCore.Foreground = Brushes.White;
            multiCore.Foreground = Brushes.White;
            result.Foreground = Brushes.White;
            mode.Foreground = Brushes.Black;
        }
    }
}
