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
    public partial class cpu : Window
    {
        public static void check(MainWindow widow)
        {
            string[] amd = { "negr"};
            string[] intel = {"" };
            if (widow.name.Text.Contains(amd) || widow.name.Text.Contains(intel))
            {

            }
        }
    }
}
