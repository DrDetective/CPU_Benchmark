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
            string[] amdPole = { "Ryzen 7 1800X","Ryzen 7 PRO 1700X", "Ryzen 7 1700X", "Ryzen 7 PRO 1700", "Ryzen 7 1700", "Ryzen 5 1600X", "Ryzen 5 PRO 1600",
                "Ryzen 5 1600", "Ryzen 5 1500X", "Ryzen 5 PRO 1500", "Ryzen 5 1400", "Ryzen 3 1300X","Ryzen 3 PRO 1300","Ryzen 3 PRO 1200","Ryzen 3 1200",
                "Ryzen Threadripper 1950X","Ryzen Threadripper 1920X","Ryzen Threadripper 1900X","Ryzen 5 2400G","Ryzen 5 2400GE","Ryzen 3 2200G","Ryzen 3 2200GE","Ryzen 3 PRO 2100GE",
                "Ryzen 7 2700X","Ryzen 7 2700","Ryzen 7 2700E","Ryzen 5 2600X","Ryzen 5 2600","Ryzen 5 2600E","Ryzen 5 1600","Ryzen 5 2500X","Ryzen 3 2300X","Ryzen 1200","Ryzen Threadripper 2990WX"
                ,"Ryzen Threadripper 2970WX","Ryzen Threadripper 2950X","Ryzen Threadripper 2920X","Ryzen 5 Pro 3400G","Ryzen 5 3400G","Ryzen 5 Pro 3400GE","Ryzen 5 Pro 3350G","Ryzen 5 3350GE","Ryzen 3 Pro 3200G"
                ,"Ryzen 3 3200G","Ryzen 3 3200GE","Ryzen 3 Pro 3200GE","Ryzen 9 3950X","Ryzen 9 3900XT","Ryzen 9 3900X","Ryzen 9 3900","Ryzen 7 3800XT","Ryzen 7 3800X","Ryzen 7 3700X","Ryzen 5 3600XT","Ryzen 5 3600X"
                ,"Ryzen 5 3600","Ryzen 5 3500X","Ryzen 5 3500","Ryzen 3 3300X","Ryzen 3 3100","Ryzen Threadripper PRO 3995WX","Ryzen Threadripper PRO 3975WX","Ryzen Threadripper PRO 3955WX","Ryzen Threadripper PRO 3945WX"
                ,"Ryzen Threadripper 3990X","Ryzen Threadripper 3970X","Ryzen Threadripper 3960X","Ryzen 5 4500","Ryzen 3 4100","Ryzen 7 4700G","Ryzen 7 4700GE","Ryzen 5 4600G","Ryzen 7 4600GE","Ryzen 3 4300G","Ryzen 3 4300GE"
                ,"Ryzen 9 5950X","Ryzen 9 5900X","Ryzen 9 5900","Ryzen 7 5800X3D","Ryzen 7 5800X","Ryzen 7 5800","Ryzen 7 5700X","Ryzen 5 5600X","Ryzen 5 5600","Ryzen 7 5700","Ryzen 5 5500","Ryzen 7 5700G","Ryzen 7 5700GE"
                ,"Ryzen 5 5600G","Ryzen 5 5600GE","Ryzen 3 5300G","Ryzen 5300GE","Ryzen Threadripper PRO 5995WX","Ryzen Threadripper PRO 5975WX","Ryzen Threadripper PRO 5965WX","Ryzen Threadripper PRO 5955WX","Ryzen Threadripper PRO 5945WX"
                ,"Ryzen 9 7950X3D","Ryzen 9 7950X","Ryzen 9 7900X3D","Ryzen 9 7900X","Ryzen 9 7900","Ryzen 9 PRO 7945","Ryzen 7 7800X3D","Ryzen 7 7700X","Ryzen 7 7700","Ryzen 7 PRO 7745","Ryzen 5 7600X","Ryzen 5 7600","Ryzen 5 PRO 7645"
                ,"Ryzen 7 2800H","Ryzen 7 2700U","Ryzen 5 2600H","Ryzen 5 2500U","Ryzen 3 2300U","Ryzen 3 2200U","Ryzen 3 3250U","Ryzen 3 3250C","Ryzen 3 3200U","Ryzen 7 3780U","Ryzen 7 3750H","Ryzen 7 3700C","Ryzen 7 3700U"
                ,"Ryzen 5 3580U","Ryzen 5 3550H","Ryzen 5 3500C","Ryzen 5 3500U","Ryzen 5 3450U","Ryzen 3 3350U","Ryzen 3 3300U","Ryzen 9 4900H","Ryzen 9 4900HS","Ryzen 7 4800H","Ryzen 7 4800HS","Ryzen 7 4980U","Ryzen 7 4800U","Ryzen 7 4700U"
                ,"Ryzen 5 4600H","Ryzen 5 4600HS","Ryzen 5 4680U","Ryzen 5 4600U","Ryzen 5 4500U","Ryzen 3 4300U","Ryzen 7 5700U","Ryzen 5 5500U","Ryzen 3 5300U","Ryzen 9 5980HX","Ryzen 9 5980HS","Ryzen 9 5900HX","Ryzen 9 5900HS","Ryzen 7 5800H"
                ,"Ryzen 7 5800HS","Ryzen 7 5825U","Ryzen 7 5800U","Ryzen 5 5600H","Ryzen 5 5600HS","Ryzen 5 5625U","Ryzen 5 5600U","Ryzen 5 5560U","Ryzen 3 5425U","Ryzen 3 5400U","Ryzen 3 5125C","Ryzen 9 6980HX","Ryzen 9 6980HS","Ryzen 9 6900HX"
                ,"Ryzen 9 6900HS","Ryzen 7 6800H","Ryzen 7 6800HS","Ryzen 7 6800U","Ryzen 5 6600H","Ryzen 5 6600HS","Ryzen 5 6600U","Ryzen 5 7520U","Ryzen 3 7320U","Ryzen 7 PRO 7730U","Ryzen 7 7730U","Ryzen 5 PRO 7530U","Ryzen 5 7530U","Ryzen 3 PRO 7330U"
                ,"Ryzen 3 7330U","Ryzen 7 7735HS","Ryzen 7 7736U","Ryzen 7 7735U","Ryzen 5 7535HS","Ryzen 5 7535U","Ryzen 3 7335U","Ryzen 9 7940HS","Ryzen 9 7940H","Ryzen 7 7840HS","Ryzen 7 7840H","Ryzen 7 7840U","Ryzen 5 7640HS","Ryzen 5 7640H","Ryzen 5 7640U"
                ,"Ryzen 5 7540U","Ryzen 3 7440U","Ryzen 9 7945HX","Ryzen 9 7845HX","Ryzen 7 7745HX","Ryzen 5 7645HX","Ryzen Z1 Extreme","Ryzen Z1","Ryzen 7045","Ryzen 7040","Ryzen 7035","Ryzen 7030","Ryzen 7020"};//Snad to je všechno a dodat EPYC    https://en.wikipedia.org/wiki/Epyc
            List<string> amd = new List<string>(amdPole);


            string[] intelPole = {"Core i9 13900K", "Core i9 13900KF", "Core i9 13900", "Core i9 13900F", "Core i9 13900T", "Core i7 13700K", "Core i7 13700KF", "Core i7 13700", "Core i7 13700F", "Core i7 13700T", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", }; //dodat intel   https://en.wikipedia.org/wiki/List_of_Intel_processors
            List<string> intel = new List<string>(intelPole);
            
            
            
            if (amd.Contains(widow.name.Text))
            {
                //tady nejspis bude switch na prirazeni realnych cpu skore 
            }
            else if (intel.Contains(widow.name.Text))
            {
                //stejne i tady
            }
            else { MessageBox.Show("Co to je"); }
        }
    }
}
