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
using System.Windows.Media.Media3D;
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
            cpu test = new cpu();
            //AMD
            foreach (string a in test.amd) { Amd.Items.Add(a);}
            Amd.SelectedIndex = 0;
            Amd.Items.Add("----------------------------------------------EPYC------------------------------------------"); //udělat aby uživatel tohle nemohl zvolit
            foreach (string e in test.epyc) { Amd.Items.Add(e); }
            //INTEL
            //foreach (string i in test.intel) { name.Items.Add(i); }
            //Intel.SelectedIndex = 0;
        }
        private void Loadbar()
        {
            //for (int progressValue = 0; progressValue < 101; progressValue++)
            //{
            //    bar.Value = progressValue;
            //    //Thread.Sleep(100);
            //}
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stops = new Stopwatch();
            float single = 100000;
            float multi = 400000;
            bar.Value = 0;
            stops.Start();
            if (singleCore.IsChecked == true)
            {
                Loadbar();
                for (int i = 0; i < single; i++)
                {
                    for (int j = 0; j < i / 2; j++)
                    {
                        if (j%2 !=0) { bar.Value = i; break; }
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
            if (bar.Value == 100)
            {
                Random gen = new Random();
                int rng = gen.Next(0,10000);
                bar.Value = 0;
                result.Content = $" {rng} points";
            }
        }
        int Isclicked = 0;
        private void mode_Click(object sender, RoutedEventArgs e) //nějak to funguje radši na to šahat nebudu
        {
            if(Isclicked == 0)
            {
                window.Background = Brushes.Black;
                title.Foreground = Brushes.White;
                enter.Foreground = Brushes.White;
                singleCore.Foreground = Brushes.White;
                multiCore.Foreground = Brushes.White;
                result.Foreground = Brushes.White;
                mode.Foreground = Brushes.Black;
                Isclicked += 1;
            }
            else if(Isclicked == 1)
            {
                window.Background = Brushes.White;
                title.Foreground = Brushes.Black;
                enter.Foreground = Brushes.Black;
                singleCore.Foreground = Brushes.Black;
                multiCore.Foreground = Brushes.Black;   
                result.Foreground = Brushes.Black;
                mode.Foreground = Brushes.Black;
                Isclicked -= 1;
            }
        }
        private void help_Click(object sender, RoutedEventArgs e) //info box
        { //nevim už
            //var psi = new ProcessStartInfo
            //{ FileName = "https://github.com/DrDetective/CPU_Benchmark/issues/new", UseShellExecute = true, };
            //MessageBox.Show($"Pokud chceš zvolit Amd cpu tak v druhém boxu dej Intel.\nPokud chceš zvolit Intel cpu tak v prvném boxu dej Amd.\nCpu skóre jsou pravdivé\nOdkaz na report bugs");
        } //přidat hypertext na bugs
        //private void Amd_Selected(object sender, RoutedEventArgs e)
        //{

        //}
        //private void Intel_Selected(object sender, RoutedEventArgs e)
        //{

        //}

    }
}


//možná sem dát cpu check místo aby byl v cpu.cs
//Progress bar at jde viet ze se to nacita