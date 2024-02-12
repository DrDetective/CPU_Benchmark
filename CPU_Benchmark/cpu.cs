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
    public partial class cpu
    {
        private static string[] amdPole = { "AMD","Ryzen Threadripper PRO 5995WX","Ryzen Threadripper PRO 5975WX","Ryzen Threadripper PRO 5965WX","Ryzen Threadripper PRO 5955WX","Ryzen Threadripper PRO 5945WX","Ryzen Threadripper PRO 3995WX","Ryzen Threadripper 3990X",
                                                "Ryzen Threadripper PRO 3975WX","Ryzen Threadripper 3970X","Ryzen Threadripper 3960X","Ryzen Threadripper PRO 3955WX","Ryzen Threadripper PRO 3945WX","Ryzen Threadripper 2990WX","Ryzen Threadripper 2970WX",
                                                "Ryzen Threadripper 2950X","Ryzen Threadripper 2920X","Ryzen Threadripper 1950X","Ryzen Threadripper 1920X","Ryzen Threadripper 1900X",
                                                "Ryzen Z1","Ryzen Z1 Extreme","Ryzen 9 7950X3D","Ryzen 9 7950X","Ryzen 9 PRO 7945","Ryzen 9 7945HX","Ryzen 9 7940HS","Ryzen 9 7940H","Ryzen 9 7900","Ryzen 9 7900X","Ryzen 9 7900X3D","Ryzen 9 7845HX",
                                                "Ryzen 9 6980HX","Ryzen 9 6980HS","Ryzen 9 6900HX","Ryzen 9 6900HS","Ryzen 9 5980HX","Ryzen 9 5980HS","Ryzen 9 5950X","Ryzen 9 5900X","Ryzen 9 5900", "Ryzen 9 5900HX","Ryzen 9 5900HS",
                                                "Ryzen 9 4900H","Ryzen 9 4900HS","Ryzen 9 3950X","Ryzen 9 3900XT","Ryzen 9 3900X","Ryzen 9 3900",
                                                "Ryzen 7 7840HS","Ryzen 7 7840H","Ryzen 7 7840U","Ryzen 7 7800X3D","Ryzen 7 PRO 7745","Ryzen 7 7745HX","Ryzen 7 7736U","Ryzen 7 7735U","Ryzen 7 7735HS","Ryzen 7 PRO 7730U","Ryzen 7 7730U",
                                                "Ryzen 7 7700","Ryzen 7 7700X","Ryzen 7045","Ryzen 7040","Ryzen 7035","Ryzen 7030","Ryzen 7020","Ryzen 7 6800H","Ryzen 7 6800HS","Ryzen 7 6800U","Ryzen 7 5825U","Ryzen 7 5800","Ryzen 7 5800X","Ryzen 7 5800X3D","Ryzen 7 5800U",
                                                "Ryzen 7 5800H","Ryzen 7 5800HS","Ryzen 7 5700","Ryzen 7 5700X","Ryzen 7 5700G","Ryzen 7 5700GE","Ryzen 7 5700U","Ryzen 7 4980U","Ryzen 7 4800H","Ryzen 7 4800HS","Ryzen 7 4800U","Ryzen 7 4700G","Ryzen 7 4700GE","Ryzen 7 4700U",
                                                "Ryzen 7 4600GE","Ryzen 7 3800X","Ryzen 7 3800XT","Ryzen 7 3780U","Ryzen 7 3750H","Ryzen 7 3700C","Ryzen 7 3700U","Ryzen 7 3700X","Ryzen 7 2800H","Ryzen 7 2700","Ryzen 7 2700X","Ryzen 7 2700E","Ryzen 7 2700U","Ryzen 7 1800X",
                                                "Ryzen 7 1700","Ryzen 7 1700X", "Ryzen 7 PRO 1700","Ryzen 7 PRO 1700X",
                                                "Ryzen 5 PRO 7645","Ryzen 5 7645HX","Ryzen 5 7640H","Ryzen 5 7640HS","Ryzen 5 7640U","Ryzen 5 7600","Ryzen 5 7600X","Ryzen 5 7540U","Ryzen 5 7535HS","Ryzen 5 7535U","Ryzen 5 PRO 7530U","Ryzen 5 7530U","Ryzen 5 7520U",
                                                "Ryzen 5 6600H","Ryzen 5 6600HS","Ryzen 5 6600U","Ryzen 5 5625U","Ryzen 5 5600","Ryzen 5 5600X","Ryzen 5 5600G","Ryzen 5 5600GE","Ryzen 5 5600H","Ryzen 5 5600HS","Ryzen 5 5600U","Ryzen 5 5560U","Ryzen 5 5500","Ryzen 5 5500U",
                                                "Ryzen 5 4680U","Ryzen 5 4600H","Ryzen 5 4600HS","Ryzen 5 4600U","Ryzen 5 4600G","Ryzen 5 4500","Ryzen 5 4500U","Ryzen 5 3600","Ryzen 5 3600X","Ryzen 5 3600XT","Ryzen 5 3580U","Ryzen 5 3550H","Ryzen 5 3500",
                                                "Ryzen 5 3500X","Ryzen 5 3500C","Ryzen 5 3500U","Ryzen 5 3450U","Ryzen 5 3400G","Ryzen 5 Pro 3400G","Ryzen 5 Pro 3400GE","Ryzen 5 Pro 3350G","Ryzen 5 3350GE","Ryzen 5 2600","Ryzen 5 2600X",
                                                "Ryzen 5 2600E","Ryzen 5 2600H","Ryzen 5 2500X","Ryzen 5 2500U","Ryzen 5 2400G","Ryzen 5 2400GE","Ryzen 5 1600","Ryzen 5 1600X","Ryzen 5 PRO 1600","Ryzen 5 PRO 1500","Ryzen 5 1500X","Ryzen 5 1400",
                                                "Ryzen 3 7440U","Ryzen 3 7335U","Ryzen 3 7330U","Ryzen 3 PRO 7330U","Ryzen 3 7320U","Ryzen 3 5425U","Ryzen 3 5400U","Ryzen 3 5300U","Ryzen 3 5300G","Ryzen 5300GE","Ryzen 3 5125C","Ryzen 3 4300G","Ryzen 3 4300GE","Ryzen 3 4300U",
                                                "Ryzen 3 4100","Ryzen 3 3350U","Ryzen 3 3300X","Ryzen 3 3300U","Ryzen 3 3250U","Ryzen 3 3250C","Ryzen 3 3200G","Ryzen 3 3200GE","Ryzen 3 Pro 3200GE","Ryzen 3 Pro 3200G","Ryzen 3 3200U","Ryzen 3 3100",
                                                "Ryzen 3 2300U","Ryzen 3 2300X","Ryzen 3 2200U","Ryzen 3 2200G","Ryzen 3 2200GE","Ryzen 3 PRO 2100GE","Ryzen 3 1300X","Ryzen 3 PRO 1300","Ryzen 3 1200","Ryzen 3 PRO 1200",
                                                "Ryzen 1200 (AF)",};

        private static string[] epycPole = {"EPYC 9754","EPYC 9754S","EPYC 9734","EPYC 9684X","EPYC 9654","EPYC 9654P","EPYC 9634","EPYC 9554","EPYC 9554P","EPYC 9534","EPYC 9474F","EPYC 9454","EPYC 9454P","EPYC 9384X","EPYC 9374F","EPYC 9354","EPYC 9354P","EPYC 9334",
                                                "EPYC 9274F","EPYC 9254","EPYC 9224","EPYC 9184X","EPYC 9174F","EPYC 9124",
                                                "EPYC 7773X","EPYC 7763","EPYC 7742","EPYC 7713","EPYC 7713P","EPYC 7702","EPYC 7702P","EPYC 7663","EPYC 7662","EPYC 7643","EPYC 7642","EPYC 7601","EPYC 7573X","EPYC 7571","EPYC 7552","EPYC 7551","EYPC 7551P","EPYC 7542",
                                                "EPYC 7543","EPYC 7543P","EPYC 7532","EPYC 7513","EPYC 7502","EPYC 7502P","EPYC 7501","EPYC 7473X","EPYC 7453","EPYC 7452","EPYC 7451","EPYC 7443","EPYC 7443P","EPYC 7413","EPYC 7402","EPYC 7402P","EPYC 7401","EPYC 7401P","EPYC 7373X",
                                                "EPYC 7371","EPYC 7352","EPYC 7351","EPYC 7351P","EPYC 7343","EPYC 7313","EPYC 7313P","EPYC 7302","EPYC 7302P","EPYC 7301","EPYC 7282","EPYC 7281","EPYC 7272","EPYC 7262","EPYC 7261","EPYC 7252","EPYC 7251","EPYC 7232P",
                                                "EPYC 7F72","EPYC 75F3","EPYC 74F3","EPYC 73F3","EPYC 72F3","EPYC 7F52","EPYC 7F32","EPYC 7H12",
                                                "EPYC 3451","EPYC 3401","EPYC 3351","EPYC 3301","EPYC 3255","EPYC 3251","EPYC 3201","EPYC 3151","EPYC 3101",};

        private static string[] intelPole = {"INTEL","Core i9 13900","Core i9 13900K","Core i9 13900KS","Core i9 13900KF","Core i9 13900F","Core i9 13900T","Core i9 12950HX","Core i9 12900","Core i9 12900K","Core i9 12900KS","Core i9 12900KF",
                                                "Core i9 12900F","Core i9 12900T","Core i9 12900H","Core i9 12900HX","Core i9 12900HK","Core i9 11980HK","Core i9 11950H","Core i9 11900","Core i9 11900K","Core i9 11900KF",
                                                "Core i9 11900F","Core i9 11900T","Core i9 11900H","Core i9 10910","Core i9 10900","Core i9 10900K","Core i9 10900KF","Core i9 10900F","Core i9 10900E","Core i9 10900T","Core i9 10850K","Core i9 9900",
                                                "Core i9 9900K","Core i9 9900KS","Core i9 9900T","Core i9 8950HK","Core i9 7980XE","Core i9 7960X","Core i9 7940X","Core i9 7920X","Core i9 7900X",

                                                "Core i7 13700","Core i7 13700K","Core i7 13700KF","Core i7 13700F","Core i7 13700T","Core i7 12850HX","Core i7 12800H","Core i7 12800HX","Core i7 12700","Core i7 12700K","Core i7 12700KF",
                                                "Core i7 12700F","Core i7 12700T","Core i7 12700H","Core i7 12650H","Core i7 12650HX","Core i7 1195G7","Core i7 1195G7 w/IPU","Core i7 1185GRE","Core i7 1185G7E","Core i7 1185G7 w/IPU",
                                                "Core i7 11850H","Core i7 11850HE","Core i7 11800H","Core i7 1180G7 w/IPU","Core i7 11700","Core i7 11700K", "Core i7 11700KF","Core i7 11700F","Core i7 11700T","Core i7 1165G7","Core i7 1165G7 w/IPU",
                                                "Core i7 11600H","Core i7 1160G7 w/IPU","Core i7 11390H","Core i7 11375H","Core i7 11375H w/IPU","Core i7 11370H w/IPU","Core i7 10750H","Core i7 10710U","Core i7 10700","Core i7 10700K","Core i7 10700KF",
                                                "Core i7 10700F","Core i7 10700T","Core i7 10700E","Core i7 10700TE","Core i7 1065G7","Core i7 10610U","Core i7 1060G7","Core i7 10510U","Core i7 10510Y","Core i7 9700","Core i7 9700K","Core i7 9700T",
                                                "Core i7 9700TE","Core i7 8850H","Core i7 8750H","Core i7 8700","Core i7 8700K","Core i7 8700B","Core i7 8569U","Core i7 8665U","Core i7 8650U","Core i7 8565U","Core i7 8559U","Core i7 8557U","Core i7 8550U",
                                                "Core i7 8500Y","Core i7 8086K","Core i7 7920HQ","Core i7 7900U","Core i7 7820HQ","Core i7 7820HK","Core i7 7820X","Core i7 7800X","Core i7 7740X","Core i7 7700","Core i7 7700K","Core i7 7700T","Core i7 7700HQ",
                                                "Core i7 7660U","Core i7 7560U","Core i7 7500U","Core i7 7Y75",

                                                "Core i7 1280P","Core i7 1270P","Core i7 1265U","Core i7 1260P","Core i7 1260U","Core i7 1255U","Core i7 1250U",

                                                "Core i5 13600","Core i5 13600K","Core i5 13600KF","Core i5 13600T","Core i5 13500","Core i5 13500T","Core i5 13420H","Core i5 13400","Core i5 13400F","Core i5 13400T","Core i5 12600","Core i5 12600K",
                                                "Core i5 12600KF","Core i5 12600T","Core i5 12600HX","Core i5 12600H","Core i5 12500","Core i5 12500T","Core i5 12500H","Core i5 12450H","Core i5 12450HX","Core i5 12400","Core i5 12400F","Core i5 12400T",
                                                "Core i5 11600","Core i5 11600K","Core i5 11600KF","Core i5 11600T","Core i5 1155G7","Core i5 11500","Core i5 11500T","Core i5 11500H","Core i5 11500HE","Core i5 1145G7 w/IPU","Core i5 1145G7E w/IPU",
                                                "Core i5 1145G7E","Core i5 11400","Core i5 11400F","Core i5 11400T","Core i5 11400H","Core i5 1140G7","Core i5 1135G7","Core i5 11320H w/IPU","Core i5 11300H w/IPU","Core i5 1130G7 w/IPU","Core i5 11260H",
                                                "Core i5 10600","Core i5 10600K","Core i5 10600KF","Core i5 10600T","Core i5 10505","Core i5 10500","Core i5 10500E","Core i5 10500T","Core i5 10500TE","Core i5 10500H","Core i5 10400","Core i5 10400F",
                                                "Core i5 10400T","Core i5 10210U","Core i5 9600","Core i5 9600K","Core i5 9600KF","Core i5 9600T","Core i5 9500","Core i5 9500E","Core i5 9500F","Core i5 9500T","Core i5 9400","Core i5 9400F","Core i5 9400T",
                                                "Core i5 8600K","Core i5 8500","Core i5 8500B","Core i5 8400","Core i5 8400H","Core i5 8400B","Core i5 8365U","Core i5 8350U","Core i5 8310Y","Core i5 8300H","Core i5 8279U","Core i5 8269U","Core i5 8265U",
                                                "Core i5 8260U","Core i5 8259U","Core i5 8257U","Core i5 8250U","Core i5 8210Y","Core i5 8200Y","Core i5 7640X","Core i5 7600","Core i5 7600K","Core i5 7600T","Core i5 7500","Core i5 7500T","Core i5 7440HQ",
                                                "Core i5 7400","Core i5 7400T","Core i5 7360U","Core i5 7300HQ","Core i5 7300U","Core i5 7287U","Core i5 7267U","Core i5 7260U","Core i5 7200U","Core i5 7Y57","Core i5 7Y54",

                                                "Core i5 1250P","Core i5 1245U","Core i5 1240P","Core i5 1240U","Core i5 1235U","Core i5 1230U",

                                                "Core i3 13100","Core i3 13100F","Core i3 13100T","Core i3 12300","Core i3 12300T","Core i3 12100","Core i3 12100F","Core i3 12100T","Core i3 1125G4","Core i3 1125G4 w/IPU","Core i3 1120G4 w/IPU",
                                                "Core i3 1115GRE","Core i3 1115G4E","Core i3 1115G4","Core i3 1115G4 w/IPU","Core i3 1110G4 w/IPU","Core i3 11100HE","Core i3 10320","Core i3 10300","Core i3 10300T","Core i3 10110Y","Core i3 10100",
                                                "Core i3 10100F","Core i3 10100T","Core i3 10100E","Core i3 10100TE","Core i3 9350K","Core i3 9350KF","Core i3 9320","Core i3 9300","Core i3 9300T","Core i3 9100","Core i3 9100F","Core i3 9100T","Core i3 9100E",
                                                "Core i3 9100TE","Core i3 8350K","Core i3 8145U","Core i3 8140U","Core i3 8130U","Core i3 8109U","Core i3 8100","Core i3 8100H","Core i3 8100B","Core i3 7350K","Core i3 7320","Core i3 7300","Core i3 7300T",
                                                "Core i3 7130U","Core i3 7167U","Core i3 7101E","Core i3 7101TE","Core i3 7100T","Core i3 7100","Core i3 7100H","Core i3 7100U",

                                                "Core i3 1220P","Core i3 1215U","Core i3 1210U",}; //dodat intel   https://en.wikipedia.org/wiki/List_of_Intel_processors




        private static string[] xeonPole = { "Xeon W-11965MRE", "Xeon W-11955M", "Xeon W-11865MLE", "Xeon W-11855M", "Xeon W-11555MRE", "Xeon W-11555MLE", "Xeon W-11155MRE", "Xeon W-11155MLE", };

        public List<string> amd = new List<string>(amdPole);
        public List<string> epyc = new List<string>(epycPole);
        public List<string> intel = new List<string>(intelPole);
        public List<string> xeon = new List<string>(xeonPole);
        //jestli jsem tohle cely mohl udelat do dict a dat tam score z benchmarku tak kys :)
        //zkusit udělat tohle celý do dict a dát do novýho branche
    }
}
