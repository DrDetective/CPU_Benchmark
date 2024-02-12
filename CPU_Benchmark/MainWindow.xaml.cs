//penis
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
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
using System.Windows.Media.TextFormatting;
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
        cpu CpuList = new cpu();
        public bool AMDcheck;
        public bool Intelcheck;
        public int score { get; set; }
        public bool True = false;
        public string cpuIn = "";
        public MainWindow()
        {
            InitializeComponent();
            //AMD
            foreach (string a in CpuList.amd) { Amd.Items.Add(a);}
            Amd.SelectedIndex = 0;
            Amd.Items.Add("----------------------------------------------EPYC------------------------------------------");
            foreach (string e in CpuList.epyc) { Amd.Items.Add(e); }
            //INTEL
            foreach (string i in CpuList.intel) { Intel.Items.Add(i); }
            Intel.SelectedIndex = 0;
            Intel.Items.Add("----------------------------------------------XEON------------------------------------------");
            foreach (string x in CpuList.xeon) { Intel.Items.Add(x); }
        }
        private void cpuCheck() 
        {
            cpuIn = CpuInput.Text;
            if (CpuList.intel.Contains(cpuIn) || CpuList.xeon.Contains(cpuIn))
            {
                AMDcheck = true;
                Intelcheck = false;
                if (cpuIn.StartsWith("C")) { Intel.SelectedIndex = CpuList.intel.FindIndex(x => x.StartsWith(cpuIn)); }
                else if (cpuIn.StartsWith("X")) { Intel.SelectedIndex = CpuList.xeon.FindIndex(x => x.StartsWith(cpuIn)); }
                cpuSwitch();
            }
            else if (CpuList.amd.Contains(cpuIn) || CpuList.epyc.Contains(cpuIn))
            { 
                AMDcheck = false;
                Intelcheck = true;
                if (cpuIn.StartsWith("R")) { Amd.SelectedIndex = CpuList.amd.FindIndex(x => x.StartsWith(cpuIn)); }
                else if (cpuIn.StartsWith("E")) { Amd.SelectedIndex = CpuList.epyc.FindIndex(x => x.StartsWith(cpuIn)); }
                cpuSwitch();
            }
            else { MessageBox.Show("Není to napsaný v kodu mrdko"); return; }
        }
        private void cpuListCheck(bool AMDcheck, bool Intelcheck) 
        {
            if (AMDcheck == true && Intelcheck == true || AMDcheck == false && Intelcheck == false)
            {
                int andex = Amd.Items.Count;
                int index = Intel.Items.Count;
                MessageBox.Show($"kys (keep yourself safe) {andex}, {index}");
                return;
            }
            else if (singleCore.IsChecked == true || multiCore.IsChecked == true)
            {
                cpuSwitch();
            }
        }
        private void cpuSwitch()  //dopsat score k cpus
        {
            Loadbar();
            if (singleCore.IsChecked == true) //SINGLECORE SELECTED
            {
                if (AMDcheck == false && Intelcheck == true) //AMD SINGLE CORE CPU
                {
                    switch (Amd.SelectedIndex)
                    {
                        case 1: score = 598; break; //Ryzen ThreadRipper PRO 5995WX
                        case 2: score = 1; break; //Ryzen Threadripper PRO 5975WX
                        case 3: score = 11; break; //Ryzen Threadripper PRO 5965WX
                        case 4: score = 111; break; //Ryzen Threadripper PRO 5955WX
                        case 5: score = 1111; break; //Ryzen Threadripper PRO 5945WX
                        case 6: score = 11111; break; //Ryzen Threadripper PRO 3995WX
                        case 7: score = 2; break; //Ryzen Threadripper 3990X
                        case 8: score = 22; break; //Ryzen Threadripper PRO 3975WX
                        case 9: score = 222; break; //Ryzen Threadripper 3970X
                        case 10: score = 2222; break; //Ryzen Threadripper 3960X
                        case 11: score = 22222; break; //Ryzen Threadripper PRO 3955WX
                        case 12: score = 3; break; //Ryzen Threadripper PRO 3945WX
                        case 13: score = 33; break; //Ryzen Threadripper 2990WX
                        case 14: score = 333; break; //Ryzen Threadripper 2970WX
                        case 15: score = 3333; break; //Ryzen Threadripper 2950X
                        case 16: score = 33333; break; //Ryzen Threadripper 2920X
                        case 17: score = 4; break; //Ryzen Threadripper 1950X
                        case 18: score = 44; break; //Ryzen Threadripper 1920X
                        case 19: score = 444; break; //Ryzen Threadripper 1900X
                        case 20: score = 4444; break; //Ryzen Z1
                        case 21: score = 44444; break; //Ryzen Z1 Extreme
                        case 22: score = 5; break; //Ryzen 9 7950X3D
                        case 23: score = 55; break; //Ryzen 9 7950X
                        case 24: score = 555; break; //Ryzen 9 RPO 7945
                        case 25: score = 5555; break; //Ryzen 9 7945HX
                        case 26: score = 55555; break; //Ryzen 9 7940HS
                        case 27: score = 555555; break; //Ryzen 9 7940H
                        case 28: score = 6; break; //Ryzen 9 7900
                        case 29: score = 66; break; //Ryzen 9 7900X
                        case 30: score = 666; break; //Ryzen 9 7900X3D
                        case 31: score = 6666; break; //Ryzen 9 7845HX
                        case 32: score = 66666; break; //Ryzen 9 6980HX
                        case 33: score = 666666; break; //Ryzen 9 6980HS
                        case 34: score = 6666666; break; //Ryzen 9 6900HX
                        case 35: score = 66666666; break; //Ryzen 9 6900HS
                        case 36: score = 666666666; break; //Ryzen 9 5980HX
                        case 37: score = 666666111; break; //Ryzen 9 5980HS
                        case 38: score = 7; break; //Ryzen 9 5950X
                        case 39: score = 77; break; //Ryzen 9 5900X
                        case 40: score = 777; break; //Ryzen 9 5900
                        case 41: score = 7777; break; //Ryzen 9 5900HX
                        case 42: score = 77777; break; //Ryzen 9 5900HS
                        case 43: score = 777777; break; //Ryzen 9 4900H
                        case 44: score = 7777777; break; //Ryzen 9 4900HS
                        case 45: score = 77777777; break; //Ryzen 9 3950X
                        case 46: score = 777777777; break; //Ryzen 9 3900XT
                        case 47: score = 777777711; break; //Ryzen 9 3900X
                        case 48: score = 771777111; break; //Ryzen 9 3900
                        case 49: score = 777771111; break; //Ryzen 7 7840HS
                        case 50: score = 8; break; //Ryzen 7 7840H
                        case 51: score = 88; break; //Ryzen 7 7840U
                        case 52: score = 888; break; //Ryzen 7 7800X3D
                        case 53: score = 8888; break; //Ryzen 7 PRO 7745
                        case 54: score = 88888; break; //Ryzen 7 7745HX
                        case 55: score = 888888; break; //Ryzen 7 7736U
                        case 56: score = 8888888; break; //Ryzen 7 7735U
                        case 57: score = 88888888; break; //Ryzen 7 7735HS
                        case 58: score = 69; break; //Ryzen 7 PRO 7730U
                        case 59: score = 7984; break; //Ryzen 7 7730U
                        case 60: score = 554; break; //Ryzen 7 7700
                        case 61: score = 654545; break; //Ryzen 7 7700X
                        case 62: score = 565154; break; //Ryzen 7045 
                        case 63: score = 5445; break; //Ryzen 7040 
                        case 64: score = 1569; break; //Ryzen 7035 
                        case 65: score = 635; break; //Ryzen 7030 
                        case 66: score = 468; break; //Ryzen 7020
                        case 67: score = 489; break; //Ryzen 7 6800H
                        case 68: score = 48964; break; //Ryzen 7 6800HS
                        case 69: score = 487; break; //Ryzen 7 6800U
                        case 70: score = 1; break; //Ryzen 7 5825U
                        case 71: score = 1; break; //Ryzen 7 5800
                        case 72: score = 1; break; //Ryzen 7 5800X
                        case 73: score = 1; break; //Ryzen 7 5800X3D
                        case 74: score = 1; break; //Ryzen 7 5800U
                        case 75: score = 1; break; //Ryzen 7 5800H
                        case 76: score = 1; break; //Ryzen 7 5800HS
                        case 77: score = 1; break; //Ryzen 7 5700
                        case 78: score = 1; break; //Ryzen 7 5700X
                        case 79: score = 1; break; //Ryzen 7 5700G
                        case 80: score = 1; break; //Ryzen 7 5700GE
                        case 81: score = 1; break; //Ryzen 7 5700U
                        case 82: score = 1; break; //Ryzen 7 4980U
                        case 83: score = 1; break; //Ryzen 7 4800H
                        case 84: score = 1; break; //Ryzen 7 4800HS
                        case 85: score = 1; break; //Ryzen 7 4800U
                        case 86: score = 1; break; //Ryzen 7 4700G
                        case 87: score = 1; break; //Ryzen 7 4700GE
                        case 88: score = 1; break; //Ryzen 7 4700U
                        case 89: score = 1; break; //Ryzen 7 4600GE
                        case 90: score = 1; break; //Ryzen 7 3800X
                        case 91: score = 1; break; //Ryzen 7 3800XT
                        case 92: score = 1; break; //Ryzen 7 3780U
                        case 93: score = 1; break; //Ryzen 7 3750H
                        case 94: score = 1; break; //Ryzen 7 3700C
                        case 95: score = 1; break; //Ryzen 7 3700U
                        case 96: score = 1; break; //Ryzen 7 3700X
                        case 97: score = 1; break; //Ryzen 7 2800H
                        case 98: score = 1; break; //Ryzen 7 2700
                        case 99: score = 1; break; //Ryzen 7 2700X
                        case 100: score = 1; break; //Ryzen 7 2700E
                        case 101: score = 598; break; //Ryzen 7 2700U
                        case 102: score = 598; break; //Ryzen 7 1800X
                        case 103: score = 598; break; //Ryzen 7 1700
                        case 104: score = 598; break; //Ryzen 7 1700X
                        case 105: score = 598; break; //Ryzen 7 PRO 1700
                        case 106: score = 598; break; //Ryzen 7 PRO 1700X
                        case 107: score = 598; break; //Ryzen 5 PRO 7645
                        case 108: score = 598; break; //Ryzen 5 7645HX
                        case 109: score = 598; break; //Ryzen 5 7640H
                        case 110: score = 598; break; //Ryzen 5 7640HS
                        case 111: score = 598; break; //Ryzen 5 7640U
                        case 112: score = 598; break; //Ryzen 5 7600
                        case 113: score = 598; break; //Ryzen 5 7600X
                        case 114: score = 598; break; //Ryzen 5 7540U
                        case 115: score = 598; break; //Ryzen 5 7535HS
                        case 116: score = 598; break; //Ryzen 5 7535U
                        case 117: score = 598; break; //Ryzen 5 PRO 7530U
                        case 118: score = 598; break; //Ryzen 5 7530U
                        case 119: score = 598; break; //Ryzen 5 7520U
                        case 120: score = 598; break; //Ryzen 5 6600H
                        case 121: score = 598; break; //Ryzen 5 6600HS
                        case 122: score = 598; break; //Ryzen 5 6600U
                        case 123: score = 598; break; //Ryzen 5 5625U
                        case 124: score = 598; break; //Ryzen 5 5600
                        case 125: score = 598; break; //Ryzen 5 5600X
                        case 126: score = 598; break; //Ryzen 5 5600G
                        case 127: score = 598; break; //Ryzen 5 5600GE
                        case 128: score = 598; break; //Ryzen 5 5600H
                        case 129: score = 598; break; //Ryzen 5 5600HS
                        case 130: score = 598; break; //Ryzen 5 5600U
                        case 131: score = 598; break; //Ryzen 5 5560U
                        case 132: score = 598; break; //Ryzen 5 5500
                        case 133: score = 598; break; //Ryzen 5 5500U
                        case 134: score = 598; break; //Ryzen 5 4680U
                        case 135: score = 598; break; //Ryzen 5 4600H
                        case 136: score = 598; break; //Ryzen 5 4600HS
                        case 137: score = 598; break; //Ryzen 5 4600U
                        case 138: score = 598; break; //Ryzen 5 4600G
                        case 139: score = 598; break; //Ryzen 5 4500
                        case 140: score = 598; break; //Ryzen 5 4500U
                        case 141: score = 598; break; //Ryzen 5 3600
                        case 142: score = 598; break; //Ryzen 5 3600X
                        case 143: score = 598; break; //Ryzen 5 3600XT
                        case 144: score = 598; break; //Ryzen 5 3580H
                        case 145: score = 598; break; //Ryzen 5 3550H
                        case 146: score = 598; break; //Ryzen 5 3500
                        case 147: score = 598; break; //Ryzen 5 3500X
                        case 148: score = 598; break; //Ryzen 5 3500C
                        case 149: score = 598; break; //Ryzen 5 3500U
                        case 150: score = 598; break; //Ryzen 5 3450U
                        case 151: score = 598; break; //Ryzen 5 3400G
                        case 152: score = 598; break; //Ryzen 5 Pro 3400G
                        case 153: score = 598; break; //Ryzen 5 Pro 3400GE
                        case 154: score = 598; break; //Ryzen 5 3350G
                        case 155: score = 598; break; //Ryzen 5 3350GE
                        case 156: score = 598; break; //Ryzen 5 2600
                        case 157: score = 598; break; //Ryzen 5 2600X
                        case 158: score = 598; break; //Ryzen 5 2600E
                        case 159: score = 598; break; //Ryzen 5 2600H
                        case 160: score = 598; break; //Ryzen 5 2500X
                        case 161: score = 598; break; //Ryzen 5 2500U
                        case 162: score = 598; break; //Ryzen 5 2400G
                        case 163: score = 598; break; //Ryzen 5 2400GE
                        case 164: score = 598; break; //Ryzen 5 1600
                        case 165: score = 598; break; //Ryzen 5 1600X
                        case 166: score = 598; break; //Ryzen 5 PRO 1600
                        case 167: score = 598; break; //Ryzen 5 PRO 1500
                        case 168: score = 598; break; //Ryzen 5 1500X
                        case 169: score = 598; break; //Ryzen 5 1400
                        case 170: score = 598; break; //Ryzen 3 7440U
                        case 171: score = 598; break; //Ryzen 3 7335U
                        case 172: score = 598; break; //Ryzen 3 7330U
                        case 173: score = 598; break; //Ryzen 3 PRO 7330U
                        case 174: score = 598; break; //Ryzen 3 7320U
                        case 175: score = 0; break; //Ryzen 3 5425U
                        case 176: score = 598; break; //Ryzen 3 5400U
                        case 177: score = 598; break; //Ryzen 3 5300U
                        case 178: score = 598; break; //Ryzen 3 5300G
                        case 179: score = 598; break; //Ryzen 3 5300GE
                        case 180: score = 598; break; //Ryzen 3 5125C
                        case 181: score = 598; break; //Ryzen 3 4300G
                        case 182: score = 598; break; //Ryzen 3 4300GE
                        case 183: score = 598; break; //Ryzen 3 4300U
                        case 184: score = 598; break; //Ryzen 3 4100
                        case 185: score = 598; break; //Ryzen 3 3350U
                        case 186: score = 598; break; //Ryzen 3 3300X
                        case 187: score = 598; break; //Ryzen 3 3300U
                        case 188: score = 598; break; //Ryzen 3 3250U
                        case 189: score = 598; break; //Ryzen 3 3250C
                        case 190: score = 598; break; //Ryzen 3 3200G
                        case 191: score = 598; break; //Ryzen 3 3200GE
                        case 192: score = 598; break; //Ryzen 3 Pro 3200GE
                        case 193: score = 598; break; //Ryzen 3 Pro 3200G
                        case 194: score = 598; break; //Ryzen 3 3200U
                        case 195: score = 598; break; //Ryzen 3 3100
                        case 196: score = 598; break; //Ryzen 3 2300U
                        case 197: score = 598; break; //Ryzen 3 2300X
                        case 198: score = 598; break; //Ryzen 3 2200U
                        case 199: score = 598; break; //Ryzen 3 2200G
                        case 200: score = 598; break; //Ryzen 3 2200GE
                        case 201: score = 598; break; //Ryzen 3 PRO 2100GE
                        case 202: score = 598; break; //Ryzen 3 1300X
                        case 203: score = 598; break; //Ryzen 3 PRO 1300
                        case 204: score = 598; break; //Ryzen 3 1200
                        case 205: score = 598; break; //Ryzen 3 PRO 1200
                        case 206: score = 16; break; //Ryzen 1200 (AF)
                        case 208: score = 598; break; //EPYC 9754
                        case 209: score = 598; break; //EPYC 9754S
                        case 210: score = 598; break; //EPYC 9734
                        case 211: score = 598; break; //EPYC 9684X
                        case 212: score = 598; break; //EPYC 9654
                        case 213: score = 598; break; //EPYC 9654P
                        case 214: score = 598; break; //EPYC 9634
                        case 215: score = 598; break; //EPYC 9554
                        case 216: score = 598; break; //EPYC 9554P
                        case 217: score = 598; break; //EPYC 9534
                        case 218: score = 598; break; //EPYC 9474F
                        case 219: score = 598; break; //EPYC 9454
                        case 220: score = 598; break; //EPYC 9454P
                        case 221: score = 598; break; //EPYC 9384X
                        case 222: score = 598; break; //EPYC 9374F
                        case 223: score = 598; break; //EPYC 9354
                        case 224: score = 598; break; //EPYC 9354P
                        case 225: score = 598; break; //EPYC 9334
                        case 226: score = 598; break; //EPYC 9274F
                        case 227: score = 598; break; //EPYC 9254
                        case 228: score = 598; break; //EPYC 9224
                        case 229: score = 598; break; //EPYC 9184X
                        case 230: score = 598; break; //EPYC 9174F
                        case 231: score = 99; break; //EPYC 9124
                        case 232: score = 598; break; //EPYC 7773X
                        case 233: score = 598; break; //EPYC 7763
                        case 234: score = 598; break; //EPYC 7742
                        case 235: score = 598; break; //EPYC 7713
                        case 236: score = 598; break; //EPYC 7713P
                        case 237: score = 598; break; //EPYC 7702
                        case 238: score = 598; break; //EPYC 7702P
                        case 239: score = 598; break; //EPYC 7663
                        case 240: score = 598; break; //EPYC 7662
                        case 241: score = 598; break; //EPYC 7643
                        case 242: score = 598; break; //EPYC 7642
                        case 243: score = 598; break; //EPYC 7624
                        case 244: score = 598; break; //EPYC 7601
                        case 245: score = 598; break; //EPYC 7573X
                        case 246: score = 598; break; //EPYC 7571
                        case 247: score = 598; break; //EPYC 7552
                        case 248: score = 598; break; //EPYC 7551
                        case 249: score = 598; break; //EPYC 7551P
                        case 250: score = 598; break; //EPYC 7542
                        case 251: score = 598; break; //EPYC 7543
                        case 252: score = 598; break; //EPYC 7543P
                        case 253: score = 598; break; //EPYC 7532
                        case 254: score = 598; break; //EPYC 7513
                        case 255: score = 598; break; //EPYC 7502
                        case 256: score = 598; break; //EPYC 7502P
                        case 257: score = 598; break; //EPYC 7501
                        case 258: score = 598; break; //EPYC 7473X
                        case 259: score = 598; break; //EPYC 7453
                        case 260: score = 598; break; //EPYC 7452
                        case 261: score = 598; break; //EPYC 7443
                        case 262: score = 598; break; //EPYC 7443P
                        case 263: score = 598; break; //EPYC 7413
                        case 264: score = 598; break; //EPYC 7402
                        case 265: score = 598; break; //EPYC 7402P
                        case 266: score = 598; break; //EPYC 7401
                        case 267: score = 598; break; //EPYC 7401P
                        case 268: score = 598; break; //EPYC 7373X
                        case 269: score = 598; break; //EPYC 7371
                        case 270: score = 598; break; //EPYC 7352
                        case 271: score = 598; break; //EPYC 7351
                        case 272: score = 598; break; //EPYC 7351P
                        case 273: score = 598; break; //EPYC 7343
                        case 274: score = 598; break; //EPYC 7313
                        case 275: score = 598; break; //EPYC 7313P
                        case 276: score = 598; break; //EPYC 7302
                        case 277: score = 598; break; //EPYC 7302P
                        case 278: score = 598; break; //EPYC 7301
                        case 279: score = 598; break; //EPYC 7282
                        case 280: score = 598; break; //EPYC 7281
                        case 281: score = 598; break; //EPYC 7272
                        case 282: score = 598; break; //EPYC 7262
                        case 283: score = 598; break; //EPYC 7261
                        case 284: score = 598; break; //EPYC 7252
                        case 285: score = 598; break; //EPYC 7251
                        case 286: score = 598; break; //EPYC 7232P
                        case 287: score = 598; break; //EPYC 7F72
                        case 288: score = 598; break; //EPYC 75F3
                        case 289: score = 598; break; //EPYC 74F3
                        case 290: score = 598; break; //EPYC 73F3
                        case 291: score = 598; break; //EPYC 72F3
                        case 292: score = 598; break; //EPYC 7F52
                        case 293: score = 598; break; //EPYC 7F32
                        case 294: score = 598; break; //EPYC 3H12
                        case 295: score = 598; break; //EPYC 3451
                        case 296: score = 598; break; //EPYC 3401
                        case 297: score = 598; break; //EPYC 3351
                        case 298: score = 598; break; //EPYC 3301
                        case 299: score = 598; break; //EPYC 3255
                        case 300: score = 598; break; //EPYC 3251
                        case 301: score = 598; break; //EPYC 3201 
                        case 302: score = 420; break; //EPYC 3151
                        case 303: score = 69; break; //EPYC 3101
                    }
                }
                else if (AMDcheck == true && Intelcheck == false) //INTEL SINGLE CORE CPU
                {
                    switch (Intel.SelectedIndex)
                    {
                        case 1: score = 0; break; //Core i9 13900
                        case 2: score = 0; break; //Core i9 1300K
                        case 3: score = 0; break; //Core i9 1300KS
                        case 4: score = 0; break; //Core i9 13900KF
                        case 5: score = 0; break; //Core i9 13900F
                        case 6: score = 0; break; //Core i9 13900T
                        case 7: score = 0; break; //Core i9 12950HX
                        case 8: score = 0; break; //Core i9 12900
                        case 9: score = 0; break; //Core i9 12900K
                        case 10: score = 0; break; //Core i9 12900KS
                        case 11: score = 0; break; //Core i9 12900KF
                        case 12: score = 0; break; //Core i9 12900F
                        case 13: score = 0; break; //Core i9 12900T
                        case 14: score = 0; break; //Core i9 12900H
                        case 15: score = 0; break; //Core i9 12900HX
                        case 16: score = 0; break; //Core i9 12900HK
                        case 17: score = 0; break; //Core i9 11980HK
                        case 18: score = 0; break; //Core i9 11950H
                        case 19: score = 0; break; //Core i9 11900
                        case 20: score = 0; break; //Core i9 11900K
                        case 21: score = 0; break; //Core i9 11900KF
                        case 22: score = 0; break; //Core i9 11900F
                        case 23: score = 0; break; //Core i9 11900T
                        case 24: score = 0; break; //Core i9 11900H
                        case 25: score = 025; break; //Core i9 10910
                        case 26: score = 99; break; //Core i9 10900
                        case 27: score = 4560; break; //Core i9 10900K
                        case 28: score = 0; break; //Core i9 10900KF
                        case 29: score = 0; break; //Core i9 10900F
                        case 30: score = 0; break; //Core i9 10900E
                        case 31: score = 0; break; //Core i9 10900T
                        case 32: score = 0; break; //Core i9 10850K
                        case 33: score = 0; break; //Core i9 9900
                        case 34: score = 0; break; //Core i9 9900K
                        case 35: score = 0; break; //Core i9 9900KS
                        case 36: score = 0; break; //Core i9 9900T
                        case 37: score = 0; break; //Core i9 8950HK
                        case 38: score = 0; break; //Core i9 7980XE
                        case 39: score = 0; break; //Core i9 7960X
                        case 40: score = 0; break; //Core i9 7940X
                        case 41: score = 0; break; //Core i9 7920X
                        case 42: score = 0; break; //Core i9 7900X
                        case 43: score = 0; break; //Core i7 13700
                        case 44: score = 0; break; //Core i7 13700K
                        case 45: score = 0; break; //Core i7 13700KF
                        case 46: score = 0; break; //Core i7 13700F
                        case 47: score = 0; break; //Core i7 13700T
                        case 48: score = 0; break; //Core i7 12850HX
                        case 49: score = 0; break; //Core i7 12800H
                        case 50: score = 0; break; //Core i7 12800HX
                        case 51: score = 0; break; //Core i7 12700
                        case 52: score = 0; break; //Core i7 12700K
                        case 53: score = 0; break; //Core i7 12700KF
                        case 54: score = 0; break; //Core i7 12700F
                        case 55: score = 0; break; //Core i7 12700T
                        case 56: score = 0; break; //Core i7 12700H
                        case 57: score = 0; break; //Core i7 12650H
                        case 58: score = 0; break; //Core i7 12650HX
                        case 59: score = 0; break; //Core i7 1195G7
                        case 60: score = 0; break; //Core i7 1195G7 w/IPU
                        case 61: score = 0; break; //Core i7 1185GRE
                        case 62: score = 0; break; //Core i7 1185G7E
                        case 63: score = 0; break; //Core i7 1185G7 w/IPU
                        case 64: score = 0; break; //Core i7 11850H
                        case 65: score = 0; break; //Core i7 11850HE
                        case 66: score = 0; break; //Core i7 11800H
                        case 67: score = 0; break; //Core i7 1180G7 w/IPU
                        case 68: score = 0; break; //Core i7 11700
                        case 69: score = 0; break; //Core i7 11700K
                        case 70: score = 0; break; //Core i7 11700KF
                        case 71: score = 0; break; //Core i7 11700F
                        case 72: score = 0; break; //Core i7 11700T
                        case 73: score = 0; break; //Core i7 1165G7
                        case 74: score = 1; break; //Core i7 1165G7 w/IPU
                        case 75: score = 0; break; //Core i7 11600H
                        case 76: score = 0; break; //Core i7 1160G7 w/IPU
                        case 77: score = 0; break; //Core i7 11390H
                        case 78: score = 0; break; //Core i7 11375H
                        case 79: score = 0; break; //Core i7 11375H w/IPU
                        case 80: score = 0; break; //Core i7 11370H w/IPU
                        case 81: score = 0; break; //Core i7 10750H
                        case 82: score = 0; break; //Core i7 10710U
                        case 83: score = 0; break; //Core i7 10700
                        case 84: score = 0; break; //Core i7 10700K
                        case 85: score = 0; break; //Core i7 10700KF
                        case 86: score = 0; break; //Core i7 10700F
                        case 87: score = 0; break; //Core i7 10700T
                        case 88: score = 0; break; //Core i7 10700E
                        case 89: score = 0; break; //Core i7 10700TE
                        case 90: score = 0; break; //Core i7 1065G7
                        case 91: score = 0; break; //Core i7 10610U
                        case 92: score = 0; break; //Core i7 1060G7
                        case 93: score = 0; break; //Core i7 10510U
                        case 94: score = 0; break; //Core i7 10510Y
                        case 95: score = 1; break; //Core i7 9700
                        case 96: score = 0; break; //Core i7 9700K
                        case 97: score = 0; break; //Core i7 9700T
                        case 98: score = 0; break; //Core i7 9700TE
                        case 99: score = 0; break; //Core i7 8850H
                        case 100: score = 0; break; //Core i7 8750H
                        case 101: score = 0; break; //Core i7 8700
                        case 102: score = 0; break; //Core i7 8700K
                        case 103: score = 0; break; //Core i7 8700B
                        case 104: score = 0; break; //Core i7 8569U
                        case 105: score = 0; break; //Core i7 8665U
                        case 106: score = 0; break; //Core i7 8650U
                        case 107: score = 0; break; //Core i7 8565U
                        case 108: score = 0; break; //Core i7 8559U
                        case 109: score = 99; break; //Core i7 8557U
                        case 110: score = 1; break; //Core i7 8550U
                        case 111: score = 0; break; //Core i7 8500Y
                        case 112: score = 0; break; //Core i7 8086K
                        case 113: score = 0; break; //Core i7 7920HQ
                        case 114: score = 0; break; //Core i7 7900U
                        case 115: score = 0; break; //Core i7 7820HQ
                        case 116: score = 0; break; //Core i7 7820HK
                        case 117: score = 0; break; //Core i7 7820X
                        case 118: score = 0; break; //Core i7 7800X
                        case 119: score = 0; break; //Core i7 7740X
                        case 120: score = 0; break; //Core i7 7700
                        case 121: score = 0; break; //Core i7 7700K
                        case 122: score = 0; break; //Core i7 7700T
                        case 123: score = 0; break; //Core i7 7700HQ
                        case 124: score = 0; break; //Core i7 7660U
                        case 125: score = 0; break; //Core i7 7560U
                        case 126: score = 0; break; //Core i7 7500U
                        case 127: score = 0; break; //Core i7 7Y75
                        case 128: score = 0; break; //Core i7 1280P
                        case 129: score = 0; break; //Core i7 1270P
                        case 130: score = 0; break; //Core i7 1265U
                        case 131: score = 0; break; //Core i7 1260P
                        case 132: score = 0; break; //Core i7 1260U
                        case 133: score = 0; break; //Core i7 1255U
                        case 134: score = 2; break; //Core i7 1250U
                        case 135: score = 0; break; //Core i5 13600
                        case 136: score = 0; break; //Core i5 13600K
                        case 137: score = 0; break; //Core i5 13600KF
                        case 138: score = 0; break; //Core i5 13600T
                        case 139: score = 0; break; //Core i5 13500
                        case 140: score = 0; break; //Core i5 13500T
                        case 141: score = 0; break; //Core i5 13420H
                        case 142: score = 0; break; //Core i5 13400
                        case 143: score = 0; break; //Core i5 13400F
                        case 144: score = 0; break; //Core i5 13400T
                        case 145: score = 0; break; //Core i5 12600
                        case 146: score = 0; break; //Core i5 12600K
                        case 147: score = 0; break; //Core i5 12600KF
                        case 148: score = 0; break; //Core i5 12600T
                        case 149: score = 0; break; //Core i5 12600HX
                        case 150: score = 0; break; //Core i5 12600H
                        case 151: score = 0; break; //Core i5 12500
                        case 152: score = 0; break; //Core i5 12500T
                        case 153: score = 0; break; //Core i5 12500H
                        case 154: score = 0; break; //Core i5 12450H
                        case 155: score = 0; break; //Core i5 12450HX
                        case 156: score = 0; break; //Core i5 12400
                        case 157: score = 0; break; //Core i5 12400F
                        case 158: score = 0; break; //Core i5 12400T
                        case 159: score = 0; break; //Core i5 11600
                        case 160: score = 0; break; //Core i5 11600K
                        case 161: score = 0; break; //Core i5 11600KF
                        case 162: score = 0; break; //Core i5 11600T
                        case 163: score = 0; break; //Core i5 1155G7
                        case 164: score = 0; break; //Core i5 11500
                        case 165: score = 0; break; //Core i5 11500T
                        case 166: score = 0; break; //Core i5 11500H
                        case 167: score = 0; break; //Core i5 11500HE
                        case 168: score = 0; break; //Core i5 1145G7 w/IPU
                        case 169: score = 23; break; //Core i5 1145G7E w/IPU
                        case 170: score = 0; break; //Core i5 1145G7E
                        case 171: score = 0; break; //Core i5 11400
                        case 172: score = 0; break; //Core i5 11400F
                        case 173: score = 0; break; //Core i5 11400T
                        case 174: score = 0; break; // Core i5 11400H
                        case 175: score = 0; break; // Core i5 1140G7
                        case 176: score = 0; break; // Core i5 1135G7
                        case 177: score = 0; break; // Core i5 11320H w/IPU
                        case 178: score = 0; break; //Core i5 11300H w/IPU
                        case 179: score = 0; break; //Core i5 1130G7 w/IPU
                        case 180: score = 0; break; //Core i5 11260H
                        case 181: score = 0; break; //Core i5 10600
                        case 182: score = 0; break; //Core i5 10600K
                        case 183: score = 0; break; //Core i5 10600KF
                        case 184: score = 0; break; //Core i5 10600T
                        case 185: score = 0; break; //Core i5 10505
                        case 186: score = 0; break; //Core i5 10500
                        case 187: score = 0; break; //Core i5 10500E
                        case 188: score = 0; break; //Core i5 10500T
                        case 189: score = 0; break; //Core i5 10500TE
                        case 190: score = 0; break; //Core i5 10500H
                        case 191: score = 0; break; //Core i5 10400
                        case 192: score = 0; break; //Core i5 10400F
                        case 193: score = 0; break; //Core i5 10400T
                        case 194: score = 0; break; //Core i5 10210U
                        case 195: score = 0; break; //Core i5 9600
                        case 196: score = 0; break; //Core i5 9600K
                        case 197: score = 0; break; //Core i5 9600KF
                        case 198: score = 0; break; //Core i5 9600T
                        case 199: score = 0; break; //Core i5 9500
                        case 200: score = 0; break; //Core i5 9500E
                        case 201: score = 0; break; //Core i5 9500F
                        case 202: score = 0; break; //Core i5 9500T
                        case 203: score = 0; break; //Core i5 9400
                        case 204: score = 0; break; //Core i5 9400F
                        case 205: score = 0; break; //Core i5 9400T
                        case 206: score = 0; break; //Core i5 8600K
                        case 207: score = 0; break; //Core i5 8500
                        case 208: score = 0; break; //Core i5 8500B
                        case 209: score = 0; break; //Core i5 8400
                        case 210: score = 0; break; //Core i5 8400H
                        case 211: score = 0; break; //Core i5 8400B
                        case 212: score = 0; break; //Core i5 8365U
                        case 213: score = 0; break; //Core i5 8350U
                        case 214: score = 0; break; //Core i5 8310Y
                        case 215: score = 0; break; //Core i5 8300H
                        case 216: score = 0; break; //Core i5 8279U
                        case 217: score = 0; break; //Core i5 8269U
                        case 218: score = 0; break; //Core i5 8265U
                        case 219: score = 0; break; //Core i5 8260U
                        case 220: score = 0; break; //Core i5 8259U
                        case 221: score = 0; break; //Core i5 8257U
                        case 222: score = 0; break; //Core i5 8250U
                        case 223: score = 0; break; //Core i5 8210Y
                        case 224: score = 0; break; //Core i5 8200Y
                        case 225: score = 0; break; //Core i5 7640X
                        case 226: score = 0; break; //Core i5 7600
                        case 227: score = 0; break; //Core i5 7600K
                        case 228: score = 0; break; //Core i5 7600T
                        case 229: score = 10; break; //Core i5 7500
                        case 230: score = 0; break; //Core i5 7500T
                        case 231: score = 0; break; //Core i5 7440HQ
                        case 232: score = 0; break; //Core i5 7400
                        case 233: score = 0; break; //Core i5 7400T
                        case 234: score = 0; break; //Core i5 7360U
                        case 235: score = 0; break; //Core i5 7300HQ
                        case 236: score = 0; break; //Core i5 7300U
                        case 237: score = 0; break; //Core i5 7287U
                        case 238: score = 0; break; //Core i5 7267U
                        case 239: score = 0; break; //Core i5 7260U
                        case 240: score = 0; break; //Core i5 7200U
                        case 241: score = 10; break; //Core i5 7Y57
                        case 242: score = 0; break; //Core i5 7Y54
                        case 243: score = 0; break; //Core i5 1250P
                        case 244: score = 0; break; //Core i5 1245U
                        case 245: score = 0; break; //Core i5 1240P
                        case 246: score = 0; break; //Core i5 1240U
                        case 247: score = 54; break; //Core i5 1235U
                        case 248: score = 5; break; //Core i5 1230U
                        case 249: score = 0; break; //Core i3 13100
                        case 250: score = 0; break; //Core i3 13100F
                        case 251: score = 0; break; //Core i3 13100T
                        case 252: score = 0; break; //Core i3 12300
                        case 253: score = 0; break; //Core i3 12300T
                        case 254: score = 0; break; //Core i3 12100
                        case 255: score = 0; break; //Core i3 12100F
                        case 256: score = 0; break; //Core i3 12100T
                        case 257: score = 0; break; //Core i3 1125G4
                        case 258: score = 0; break; //Core i3 1125G4 w/IPU
                        case 259: score = 0; break; //Core i3 1120G4 w/IPU
                        case 260: score = 0; break; //Core i3 1115GRE
                        case 261: score = 0; break; //Core i3 1115G4E
                        case 262: score = 0; break; //Core i3 1115G4
                        case 263: score = 0; break; //Core i3 1115G4 w/IPU
                        case 264: score = 0; break; //Core i3 1110G4 w/IPU
                        case 265: score = 0; break; //Core i3 1110HE
                        case 266: score = 0; break; //Core i3 10320
                        case 267: score = 0; break; //Core i3 10300
                        case 268: score = 0; break; //Core i3 10300T
                        case 269: score = 0; break; //Core i3 10110Y
                        case 270: score = 0; break; //Core i3 10100
                        case 271: score = 0; break; //Core i3 10100F
                        case 272: score = 0; break; //Core i3 10100T
                        case 273: score = 0; break; //Core i3 10100E
                        case 274: score = 0; break; //Core i3 10100TE
                        case 275: score = 0; break; //Core i3 9350K
                        case 276: score = 0; break; //Core i3 9350KF
                        case 277: score = 0; break; //Core i3 9320
                        case 278: score = 0; break; //Core i3 9300
                        case 279: score = 0; break; //Core i3 9300T
                        case 280: score = 0; break; //Core i3 9100
                        case 281: score = 0; break; //Core i3 9100F
                        case 282: score = 0; break; //Core i3 9100T
                        case 283: score = 0; break; //Core i3 9100E
                        case 284: score = 0; break; //Core i3 9100TE
                        case 285: score = 0; break; //Core i3 8350K
                        case 286: score = 0; break; //Core i3 8145U
                        case 287: score = 0; break; //Core i3 8140U
                        case 288: score = 0; break; //Core i3 8130U
                        case 289: score = 0; break; //Core i3 8109U
                        case 290: score = 0; break; //Core i3 8100
                        case 291: score = 0; break; //Core i3 8100H
                        case 292: score = 0; break; //Core i3 8100B
                        case 293: score = 0; break; //Core i3 7350K
                        case 294: score = 0; break; //Core i3 7320
                        case 295: score = 0; break; //Core i3 7300
                        case 296: score = 0; break; //Core i3 7300T
                        case 297: score = 0; break; //Core i3 7130U
                        case 298: score = 0; break; //Core i3 7167U
                        case 299: score = 0; break; //Core i3 7101E
                        case 300: score = 0; break; //Core i3 7101TE
                        case 301: score = 0; break; //Core i3 7100T
                        case 302: score = 0; break; //Core i3 7100
                        case 303: score = 0; break; //Core i3 7100H
                        case 304: score = 0; break; //Core i3 7100U
                        case 305: score = 0; break; //Core i3 1220P
                        case 306: score = 0; break; //Core i3 1215U
                        case 307: score = 0; break; //Core i3 1210U
                        case 309: score = 0; break; //Xeon W-11965MRE
                        case 310: score = 0; break; //Xeon W-11955M
                        case 311: score = 0; break; //Xeon W-11865MLE
                        case 312: score = 0; break; //Xeon W-11855M
                        case 313: score = 0; break; //Xeon W-11555MRE
                        case 314: score = 0; break; //Xeon W-11555MLE
                        case 315: score = 0; break; //Xeon W-11155MRE
                        case 316: score = 96; break; //Xeon W-11155MLE
                    }
                }
            }

            else if (multiCore.IsChecked == true) //MULTICORE SELECTED
            {
                if (AMDcheck == false && Intelcheck == true) //AMD MULTI CORE CPU
                {
                    switch (Amd.SelectedIndex)
                    {
                        case 1: score = 598; break; //Ryzen ThreadRipper PRO 5995WX
                        case 2: score = 1; break; //Ryzen Threadripper PRO 5975WX
                        case 3: score = 11; break; //Ryzen Threadripper PRO 5965WX
                        case 4: score = 111; break; //Ryzen Threadripper PRO 5955WX
                        case 5: score = 1111; break; //Ryzen Threadripper PRO 5945WX
                        case 6: score = 11111; break; //Ryzen Threadripper PRO 3995WX
                        case 7: score = 2; break; //Ryzen Threadripper 3990X
                        case 8: score = 22; break; //Ryzen Threadripper PRO 3975WX
                        case 9: score = 222; break; //Ryzen Threadripper 3970X
                        case 10: score = 2222; break; //Ryzen Threadripper 3960X
                        case 11: score = 22222; break; //Ryzen Threadripper PRO 3955WX
                        case 12: score = 3; break; //Ryzen Threadripper PRO 3945WX
                        case 13: score = 33; break; //Ryzen Threadripper 2990WX
                        case 14: score = 333; break; //Ryzen Threadripper 2970WX
                        case 15: score = 3333; break; //Ryzen Threadripper 2950X
                        case 16: score = 33333; break; //Ryzen Threadripper 2920X
                        case 17: score = 4; break; //Ryzen Threadripper 1950X
                        case 18: score = 44; break; //Ryzen Threadripper 1920X
                        case 19: score = 444; break; //Ryzen Threadripper 1900X
                        case 20: score = 4444; break; //Ryzen Z1
                        case 21: score = 44444; break; //Ryzen Z1 Extreme
                        case 22: score = 5; break; //Ryzen 9 7950X3D
                        case 23: score = 55; break; //Ryzen 9 7950X
                        case 24: score = 555; break; //Ryzen 9 RPO 7945
                        case 25: score = 5555; break; //Ryzen 9 7945HX
                        case 26: score = 55555; break; //Ryzen 9 7940HS
                        case 27: score = 555555; break; //Ryzen 9 7940H
                        case 28: score = 6; break; //Ryzen 9 7900
                        case 29: score = 66; break; //Ryzen 9 7900X
                        case 30: score = 666; break; //Ryzen 9 7900X3D
                        case 31: score = 6666; break; //Ryzen 9 7845HX
                        case 32: score = 66666; break; //Ryzen 9 6980HX
                        case 33: score = 666666; break; //Ryzen 9 6980HS
                        case 34: score = 6666666; break; //Ryzen 9 6900HX
                        case 35: score = 66666666; break; //Ryzen 9 6900HS
                        case 36: score = 666666666; break; //Ryzen 9 5980HX
                        case 37: score = 666666111; break; //Ryzen 9 5980HS
                        case 38: score = 7; break; //Ryzen 9 5950X
                        case 39: score = 77; break; //Ryzen 9 5900X
                        case 40: score = 777; break; //Ryzen 9 5900
                        case 41: score = 7777; break; //Ryzen 9 5900HX
                        case 42: score = 77777; break; //Ryzen 9 5900HS
                        case 43: score = 777777; break; //Ryzen 9 4900H
                        case 44: score = 7777777; break; //Ryzen 9 4900HS
                        case 45: score = 77777777; break; //Ryzen 9 3950X
                        case 46: score = 777777777; break; //Ryzen 9 3900XT
                        case 47: score = 777777711; break; //Ryzen 9 3900X
                        case 48: score = 771777111; break; //Ryzen 9 3900
                        case 49: score = 777771111; break; //Ryzen 7 7840HS
                        case 50: score = 8; break; //Ryzen 7 7840H
                        case 51: score = 88; break; //Ryzen 7 7840U
                        case 52: score = 888; break; //Ryzen 7 7800X3D
                        case 53: score = 8888; break; //Ryzen 7 PRO 7745
                        case 54: score = 88888; break; //Ryzen 7 7745HX
                        case 55: score = 888888; break; //Ryzen 7 7736U
                        case 56: score = 8888888; break; //Ryzen 7 7735U
                        case 57: score = 88888888; break; //Ryzen 7 7735HS
                        case 58: score = 69; break; //Ryzen 7 PRO 7730U
                        case 59: score = 7984; break; //Ryzen 7 7730U
                        case 60: score = 554; break; //Ryzen 7 7700
                        case 61: score = 654545; break; //Ryzen 7 7700X
                        case 62: score = 565154; break; //Ryzen 7045 
                        case 63: score = 5445; break; //Ryzen 7040 
                        case 64: score = 1569; break; //Ryzen 7035 
                        case 65: score = 635; break; //Ryzen 7030 
                        case 66: score = 468; break; //Ryzen 7020
                        case 67: score = 489; break; //Ryzen 7 6800H
                        case 68: score = 48964; break; //Ryzen 7 6800HS
                        case 69: score = 487; break; //Ryzen 7 6800U
                        case 70: score = 1; break; //Ryzen 7 5825U
                        case 71: score = 1; break; //Ryzen 7 5800
                        case 72: score = 1; break; //Ryzen 7 5800X
                        case 73: score = 1; break; //Ryzen 7 5800X3D
                        case 74: score = 1; break; //Ryzen 7 5800U
                        case 75: score = 1; break; //Ryzen 7 5800H
                        case 76: score = 1; break; //Ryzen 7 5800HS
                        case 77: score = 1; break; //Ryzen 7 5700
                        case 78: score = 1; break; //Ryzen 7 5700X
                        case 79: score = 1; break; //Ryzen 7 5700G
                        case 80: score = 1; break; //Ryzen 7 5700GE
                        case 81: score = 1; break; //Ryzen 7 5700U
                        case 82: score = 1; break; //Ryzen 7 4980U
                        case 83: score = 1; break; //Ryzen 7 4800H
                        case 84: score = 1; break; //Ryzen 7 4800HS
                        case 85: score = 1; break; //Ryzen 7 4800U
                        case 86: score = 1; break; //Ryzen 7 4700G
                        case 87: score = 1; break; //Ryzen 7 4700GE
                        case 88: score = 1; break; //Ryzen 7 4700U
                        case 89: score = 1; break; //Ryzen 7 4600GE
                        case 90: score = 1; break; //Ryzen 7 3800X
                        case 91: score = 1; break; //Ryzen 7 3800XT
                        case 92: score = 1; break; //Ryzen 7 3780U
                        case 93: score = 1; break; //Ryzen 7 3750H
                        case 94: score = 1; break; //Ryzen 7 3700C
                        case 95: score = 1; break; //Ryzen 7 3700U
                        case 96: score = 1; break; //Ryzen 7 3700X
                        case 97: score = 1; break; //Ryzen 7 2800H
                        case 98: score = 1; break; //Ryzen 7 2700
                        case 99: score = 1; break; //Ryzen 7 2700X
                        case 100: score = 1; break; //Ryzen 7 2700E
                        case 101: score = 598; break; //Ryzen 7 2700U
                        case 102: score = 598; break; //Ryzen 7 1800X
                        case 103: score = 598; break; //Ryzen 7 1700
                        case 104: score = 598; break; //Ryzen 7 1700X
                        case 105: score = 598; break; //Ryzen 7 PRO 1700
                        case 106: score = 598; break; //Ryzen 7 PRO 1700X
                        case 107: score = 598; break; //Ryzen 5 PRO 7645
                        case 108: score = 598; break; //Ryzen 5 7645HX
                        case 109: score = 598; break; //Ryzen 5 7640H
                        case 110: score = 598; break; //Ryzen 5 7640HS
                        case 111: score = 598; break; //Ryzen 5 7640U
                        case 112: score = 598; break; //Ryzen 5 7600
                        case 113: score = 598; break; //Ryzen 5 7600X
                        case 114: score = 598; break; //Ryzen 5 7540U
                        case 115: score = 598; break; //Ryzen 5 7535HS
                        case 116: score = 598; break; //Ryzen 5 7535U
                        case 117: score = 598; break; //Ryzen 5 PRO 7530U
                        case 118: score = 598; break; //Ryzen 5 7530U
                        case 119: score = 598; break; //Ryzen 5 7520U
                        case 120: score = 598; break; //Ryzen 5 6600H
                        case 121: score = 598; break; //Ryzen 5 6600HS
                        case 122: score = 598; break; //Ryzen 5 6600U
                        case 123: score = 598; break; //Ryzen 5 5625U
                        case 124: score = 598; break; //Ryzen 5 5600
                        case 125: score = 598; break; //Ryzen 5 5600X
                        case 126: score = 598; break; //Ryzen 5 5600G
                        case 127: score = 598; break; //Ryzen 5 5600GE
                        case 128: score = 598; break; //Ryzen 5 5600H
                        case 129: score = 598; break; //Ryzen 5 5600HS
                        case 130: score = 598; break; //Ryzen 5 5600U
                        case 131: score = 598; break; //Ryzen 5 5560U
                        case 132: score = 598; break; //Ryzen 5 5500
                        case 133: score = 598; break; //Ryzen 5 5500U
                        case 134: score = 598; break; //Ryzen 5 4680U
                        case 135: score = 598; break; //Ryzen 5 4600H
                        case 136: score = 598; break; //Ryzen 5 4600HS
                        case 137: score = 598; break; //Ryzen 5 4600U
                        case 138: score = 598; break; //Ryzen 5 4600G
                        case 139: score = 598; break; //Ryzen 5 4500
                        case 140: score = 598; break; //Ryzen 5 4500U
                        case 141: score = 598; break; //Ryzen 5 3600
                        case 142: score = 598; break; //Ryzen 5 3600X
                        case 143: score = 598; break; //Ryzen 5 3600XT
                        case 144: score = 598; break; //Ryzen 5 3580H
                        case 145: score = 598; break; //Ryzen 5 3550H
                        case 146: score = 598; break; //Ryzen 5 3500
                        case 147: score = 598; break; //Ryzen 5 3500X
                        case 148: score = 598; break; //Ryzen 5 3500C
                        case 149: score = 598; break; //Ryzen 5 3500U
                        case 150: score = 598; break; //Ryzen 5 3450U
                        case 151: score = 598; break; //Ryzen 5 3400G
                        case 152: score = 598; break; //Ryzen 5 Pro 3400G
                        case 153: score = 598; break; //Ryzen 5 Pro 3400GE
                        case 154: score = 598; break; //Ryzen 5 3350G
                        case 155: score = 598; break; //Ryzen 5 3350GE
                        case 156: score = 598; break; //Ryzen 5 2600
                        case 157: score = 598; break; //Ryzen 5 2600X
                        case 158: score = 598; break; //Ryzen 5 2600E
                        case 159: score = 598; break; //Ryzen 5 2600H
                        case 160: score = 598; break; //Ryzen 5 2500X
                        case 161: score = 598; break; //Ryzen 5 2500U
                        case 162: score = 598; break; //Ryzen 5 2400G
                        case 163: score = 598; break; //Ryzen 5 2400GE
                        case 164: score = 598; break; //Ryzen 5 1600
                        case 165: score = 598; break; //Ryzen 5 1600X
                        case 166: score = 598; break; //Ryzen 5 PRO 1600
                        case 167: score = 598; break; //Ryzen 5 PRO 1500
                        case 168: score = 598; break; //Ryzen 5 1500X
                        case 169: score = 598; break; //Ryzen 5 1400
                        case 170: score = 598; break; //Ryzen 3 7440U
                        case 171: score = 598; break; //Ryzen 3 7335U
                        case 172: score = 598; break; //Ryzen 3 7330U
                        case 173: score = 598; break; //Ryzen 3 PRO 7330U
                        case 174: score = 598; break; //Ryzen 3 7320U
                        case 175: score = 0; break; //Ryzen 3 5425U
                        case 176: score = 598; break; //Ryzen 3 5400U
                        case 177: score = 598; break; //Ryzen 3 5300U
                        case 178: score = 598; break; //Ryzen 3 5300G
                        case 179: score = 598; break; //Ryzen 3 5300GE
                        case 180: score = 598; break; //Ryzen 3 5125C
                        case 181: score = 598; break; //Ryzen 3 4300G
                        case 182: score = 598; break; //Ryzen 3 4300GE
                        case 183: score = 598; break; //Ryzen 3 4300U
                        case 184: score = 598; break; //Ryzen 3 4100
                        case 185: score = 598; break; //Ryzen 3 3350U
                        case 186: score = 598; break; //Ryzen 3 3300X
                        case 187: score = 598; break; //Ryzen 3 3300U
                        case 188: score = 598; break; //Ryzen 3 3250U
                        case 189: score = 598; break; //Ryzen 3 3250C
                        case 190: score = 598; break; //Ryzen 3 3200G
                        case 191: score = 598; break; //Ryzen 3 3200GE
                        case 192: score = 598; break; //Ryzen 3 Pro 3200GE
                        case 193: score = 598; break; //Ryzen 3 Pro 3200G
                        case 194: score = 598; break; //Ryzen 3 3200U
                        case 195: score = 598; break; //Ryzen 3 3100
                        case 196: score = 598; break; //Ryzen 3 2300U
                        case 197: score = 598; break; //Ryzen 3 2300X
                        case 198: score = 598; break; //Ryzen 3 2200U
                        case 199: score = 598; break; //Ryzen 3 2200G
                        case 200: score = 598; break; //Ryzen 3 2200GE
                        case 201: score = 598; break; //Ryzen 3 PRO 2100GE
                        case 202: score = 598; break; //Ryzen 3 1300X
                        case 203: score = 598; break; //Ryzen 3 PRO 1300
                        case 204: score = 598; break; //Ryzen 3 1200
                        case 205: score = 598; break; //Ryzen 3 PRO 1200
                        case 206: score = 16; break; //Ryzen 1200 (AF)
                        case 208: score = 598; break; //EPYC 9754
                        case 209: score = 598; break; //EPYC 9754S
                        case 210: score = 598; break; //EPYC 9734
                        case 211: score = 598; break; //EPYC 9684X
                        case 212: score = 598; break; //EPYC 9654
                        case 213: score = 598; break; //EPYC 9654P
                        case 214: score = 598; break; //EPYC 9634
                        case 215: score = 598; break; //EPYC 9554
                        case 216: score = 598; break; //EPYC 9554P
                        case 217: score = 598; break; //EPYC 9534
                        case 218: score = 598; break; //EPYC 9474F
                        case 219: score = 598; break; //EPYC 9454
                        case 220: score = 598; break; //EPYC 9454P
                        case 221: score = 598; break; //EPYC 9384X
                        case 222: score = 598; break; //EPYC 9374F
                        case 223: score = 598; break; //EPYC 9354
                        case 224: score = 598; break; //EPYC 9354P
                        case 225: score = 598; break; //EPYC 9334
                        case 226: score = 598; break; //EPYC 9274F
                        case 227: score = 598; break; //EPYC 9254
                        case 228: score = 598; break; //EPYC 9224
                        case 229: score = 598; break; //EPYC 9184X
                        case 230: score = 598; break; //EPYC 9174F
                        case 231: score = 99; break; //EPYC 9124
                        case 232: score = 598; break; //EPYC 7773X
                        case 233: score = 598; break; //EPYC 7763
                        case 234: score = 598; break; //EPYC 7742
                        case 235: score = 598; break; //EPYC 7713
                        case 236: score = 598; break; //EPYC 7713P
                        case 237: score = 598; break; //EPYC 7702
                        case 238: score = 598; break; //EPYC 7702P
                        case 239: score = 598; break; //EPYC 7663
                        case 240: score = 598; break; //EPYC 7662
                        case 241: score = 598; break; //EPYC 7643
                        case 242: score = 598; break; //EPYC 7642
                        case 243: score = 598; break; //EPYC 7624
                        case 244: score = 598; break; //EPYC 7601
                        case 245: score = 598; break; //EPYC 7573X
                        case 246: score = 598; break; //EPYC 7571
                        case 247: score = 598; break; //EPYC 7552
                        case 248: score = 598; break; //EPYC 7551
                        case 249: score = 598; break; //EPYC 7551P
                        case 250: score = 598; break; //EPYC 7542
                        case 251: score = 598; break; //EPYC 7543
                        case 252: score = 598; break; //EPYC 7543P
                        case 253: score = 598; break; //EPYC 7532
                        case 254: score = 598; break; //EPYC 7513
                        case 255: score = 598; break; //EPYC 7502
                        case 256: score = 598; break; //EPYC 7502P
                        case 257: score = 598; break; //EPYC 7501
                        case 258: score = 598; break; //EPYC 7473X
                        case 259: score = 598; break; //EPYC 7453
                        case 260: score = 598; break; //EPYC 7452
                        case 261: score = 598; break; //EPYC 7443
                        case 262: score = 598; break; //EPYC 7443P
                        case 263: score = 598; break; //EPYC 7413
                        case 264: score = 598; break; //EPYC 7402
                        case 265: score = 598; break; //EPYC 7402P
                        case 266: score = 598; break; //EPYC 7401
                        case 267: score = 598; break; //EPYC 7401P
                        case 268: score = 598; break; //EPYC 7373X
                        case 269: score = 598; break; //EPYC 7371
                        case 270: score = 598; break; //EPYC 7352
                        case 271: score = 598; break; //EPYC 7351
                        case 272: score = 598; break; //EPYC 7351P
                        case 273: score = 598; break; //EPYC 7343
                        case 274: score = 598; break; //EPYC 7313
                        case 275: score = 598; break; //EPYC 7313P
                        case 276: score = 598; break; //EPYC 7302
                        case 277: score = 598; break; //EPYC 7302P
                        case 278: score = 598; break; //EPYC 7301
                        case 279: score = 598; break; //EPYC 7282
                        case 280: score = 598; break; //EPYC 7281
                        case 281: score = 598; break; //EPYC 7272
                        case 282: score = 598; break; //EPYC 7262
                        case 283: score = 598; break; //EPYC 7261
                        case 284: score = 598; break; //EPYC 7252
                        case 285: score = 598; break; //EPYC 7251
                        case 286: score = 598; break; //EPYC 7232P
                        case 287: score = 598; break; //EPYC 7F72
                        case 288: score = 598; break; //EPYC 75F3
                        case 289: score = 598; break; //EPYC 74F3
                        case 290: score = 598; break; //EPYC 73F3
                        case 291: score = 598; break; //EPYC 72F3
                        case 292: score = 598; break; //EPYC 7F52
                        case 293: score = 598; break; //EPYC 7F32
                        case 294: score = 598; break; //EPYC 3H12
                        case 295: score = 598; break; //EPYC 3451
                        case 296: score = 598; break; //EPYC 3401
                        case 297: score = 598; break; //EPYC 3351
                        case 298: score = 598; break; //EPYC 3301
                        case 299: score = 598; break; //EPYC 3255
                        case 300: score = 598; break; //EPYC 3251
                        case 301: score = 598; break; //EPYC 3201 
                        case 302: score = 420; break; //EPYC 3151
                        case 303: score = 69; break; //EPYC 3101
                    }
                }
                else if (AMDcheck == true && Intelcheck == false) //INTEL MULTI CORE CPU
                {
                    switch (Intel.SelectedIndex)
                    {
                        case 1: score = 0; break; //Core i9 13900
                        case 2: score = 0; break; //Core i9 1300K
                        case 3: score = 0; break; //Core i9 1300KS
                        case 4: score = 0; break; //Core i9 13900KF
                        case 5: score = 0; break; //Core i9 13900F
                        case 6: score = 0; break; //Core i9 13900T
                        case 7: score = 0; break; //Core i9 12950HX
                        case 8: score = 0; break; //Core i9 12900
                        case 9: score = 0; break; //Core i9 12900K
                        case 10: score = 0; break; //Core i9 12900KS
                        case 11: score = 0; break; //Core i9 12900KF
                        case 12: score = 0; break; //Core i9 12900F
                        case 13: score = 0; break; //Core i9 12900T
                        case 14: score = 0; break; //Core i9 12900H
                        case 15: score = 0; break; //Core i9 12900HX
                        case 16: score = 0; break; //Core i9 12900HK
                        case 17: score = 0; break; //Core i9 11980HK
                        case 18: score = 0; break; //Core i9 11950H
                        case 19: score = 0; break; //Core i9 11900
                        case 20: score = 0; break; //Core i9 11900K
                        case 21: score = 0; break; //Core i9 11900KF
                        case 22: score = 0; break; //Core i9 11900F
                        case 23: score = 0; break; //Core i9 11900T
                        case 24: score = 0; break; //Core i9 11900H
                        case 25: score = 0; break; //Core i9 10910
                        case 26: score = 0; break; //Core i9 10900
                        case 27: score = 0; break; //Core i9 10900K
                        case 28: score = 0; break; //Core i9 10900KF
                        case 29: score = 0; break; //Core i9 10900F
                        case 30: score = 0; break; //Core i9 10900E
                        case 31: score = 0; break; //Core i9 10900T
                        case 32: score = 0; break; //Core i9 10850K
                        case 33: score = 0; break; //Core i9 9900
                        case 34: score = 0; break; //Core i9 9900K
                        case 35: score = 0; break; //Core i9 9900KS
                        case 36: score = 0; break; //Core i9 9900T
                        case 37: score = 0; break; //Core i9 8950HK
                        case 38: score = 0; break; //Core i9 7980XE
                        case 39: score = 0; break; //Core i9 7960X
                        case 40: score = 0; break; //Core i9 7940X
                        case 41: score = 0; break; //Core i9 7920X
                        case 42: score = 0; break; //Core i9 7900X
                        case 43: score = 0; break; //Core i7 13700
                        case 44: score = 0; break; //Core i7 13700K
                        case 45: score = 0; break; //Core i7 13700KF
                        case 46: score = 0; break; //Core i7 13700F
                        case 47: score = 0; break; //Core i7 13700T
                        case 48: score = 0; break; //Core i7 12850HX
                        case 49: score = 0; break; //Core i7 12800H
                        case 50: score = 0; break; //Core i7 12800HX
                        case 51: score = 0; break; //Core i7 12700
                        case 52: score = 0; break; //Core i7 12700K
                        case 53: score = 0; break; //Core i7 12700KF
                        case 54: score = 0; break; //Core i7 12700F
                        case 55: score = 0; break; //Core i7 12700T
                        case 56: score = 0; break; //Core i7 12700H
                        case 57: score = 0; break; //Core i7 12650H
                        case 58: score = 0; break; //Core i7 12650HX
                        case 59: score = 0; break; //Core i7 1195G7
                        case 60: score = 0; break; //Core i7 1195G7 w/IPU
                        case 61: score = 0; break; //Core i7 1185GRE
                        case 62: score = 0; break; //Core i7 1185G7E
                        case 63: score = 0; break; //Core i7 1185G7 w/IPU
                        case 64: score = 0; break; //Core i7 11850H
                        case 65: score = 0; break; //Core i7 11850HE
                        case 66: score = 0; break; //Core i7 11800H
                        case 67: score = 0; break; //Core i7 1180G7 w/IPU
                        case 68: score = 0; break; //Core i7 11700
                        case 69: score = 0; break; //Core i7 11700K
                        case 70: score = 0; break; //Core i7 11700KF
                        case 71: score = 0; break; //Core i7 11700F
                        case 72: score = 0; break; //Core i7 11700T
                        case 73: score = 0; break; //Core i7 1165G7
                        case 74: score = 1; break; //Core i7 1165G7 w/IPU
                        case 75: score = 0; break; //Core i7 11600H
                        case 76: score = 0; break; //Core i7 1160G7 w/IPU
                        case 77: score = 0; break; //Core i7 11390H
                        case 78: score = 0; break; //Core i7 11375H
                        case 79: score = 0; break; //Core i7 11375H w/IPU
                        case 80: score = 0; break; //Core i7 11370H w/IPU
                        case 81: score = 0; break; //Core i7 10750H
                        case 82: score = 0; break; //Core i7 10710U
                        case 83: score = 0; break; //Core i7 10700
                        case 84: score = 0; break; //Core i7 10700K
                        case 85: score = 0; break; //Core i7 10700KF
                        case 86: score = 0; break; //Core i7 10700F
                        case 87: score = 0; break; //Core i7 10700T
                        case 88: score = 0; break; //Core i7 10700E
                        case 89: score = 0; break; //Core i7 10700TE
                        case 90: score = 0; break; //Core i7 1065G7
                        case 91: score = 0; break; //Core i7 10610U
                        case 92: score = 0; break; //Core i7 1060G7
                        case 93: score = 0; break; //Core i7 10510U
                        case 94: score = 0; break; //Core i7 10510Y
                        case 95: score = 1; break; //Core i7 9700
                        case 96: score = 0; break; //Core i7 9700K
                        case 97: score = 0; break; //Core i7 9700T
                        case 98: score = 0; break; //Core i7 9700TE
                        case 99: score = 0; break; //Core i7 8850H
                        case 100: score = 0; break; //Core i7 8750H
                        case 101: score = 0; break; //Core i7 8700
                        case 102: score = 0; break; //Core i7 8700K
                        case 103: score = 0; break; //Core i7 8700B
                        case 104: score = 0; break; //Core i7 8569U
                        case 105: score = 0; break; //Core i7 8665U
                        case 106: score = 0; break; //Core i7 8650U
                        case 107: score = 0; break; //Core i7 8565U
                        case 108: score = 0; break; //Core i7 8559U
                        case 109: score = 99; break; //Core i7 8557U
                        case 110: score = 1; break; //Core i7 8550U
                        case 111: score = 0; break; //Core i7 8500Y
                        case 112: score = 0; break; //Core i7 8086K
                        case 113: score = 0; break; //Core i7 7920HQ
                        case 114: score = 0; break; //Core i7 7900U
                        case 115: score = 0; break; //Core i7 7820HQ
                        case 116: score = 0; break; //Core i7 7820HK
                        case 117: score = 0; break; //Core i7 7820X
                        case 118: score = 0; break; //Core i7 7800X
                        case 119: score = 0; break; //Core i7 7740X
                        case 120: score = 0; break; //Core i7 7700
                        case 121: score = 0; break; //Core i7 7700K
                        case 122: score = 0; break; //Core i7 7700T
                        case 123: score = 0; break; //Core i7 7700HQ
                        case 124: score = 0; break; //Core i7 7660U
                        case 125: score = 0; break; //Core i7 7560U
                        case 126: score = 0; break; //Core i7 7500U
                        case 127: score = 0; break; //Core i7 7Y75
                        case 128: score = 0; break; //Core i7 1280P
                        case 129: score = 0; break; //Core i7 1270P
                        case 130: score = 0; break; //Core i7 1265U
                        case 131: score = 0; break; //Core i7 1260P
                        case 132: score = 0; break; //Core i7 1260U
                        case 133: score = 0; break; //Core i7 1255U
                        case 134: score = 2; break; //Core i7 1250U
                        case 135: score = 0; break; //Core i5 13600
                        case 136: score = 0; break; //Core i5 13600K
                        case 137: score = 0; break; //Core i5 13600KF
                        case 138: score = 0; break; //Core i5 13600T
                        case 139: score = 0; break; //Core i5 13500
                        case 140: score = 0; break; //Core i5 13500T
                        case 141: score = 0; break; //Core i5 13420H
                        case 142: score = 0; break; //Core i5 13400
                        case 143: score = 0; break; //Core i5 13400F
                        case 144: score = 0; break; //Core i5 13400T
                        case 145: score = 0; break; //Core i5 12600
                        case 146: score = 0; break; //Core i5 12600K
                        case 147: score = 0; break; //Core i5 12600KF
                        case 148: score = 0; break; //Core i5 12600T
                        case 149: score = 0; break; //Core i5 12600HX
                        case 150: score = 0; break; //Core i5 12600H
                        case 151: score = 0; break; //Core i5 12500
                        case 152: score = 0; break; //Core i5 12500T
                        case 153: score = 0; break; //Core i5 12500H
                        case 154: score = 0; break; //Core i5 12450H
                        case 155: score = 0; break; //Core i5 12450HX
                        case 156: score = 0; break; //Core i5 12400
                        case 157: score = 0; break; //Core i5 12400F
                        case 158: score = 0; break; //Core i5 12400T
                        case 159: score = 0; break; //Core i5 11600
                        case 160: score = 0; break; //Core i5 11600K
                        case 161: score = 0; break; //Core i5 11600KF
                        case 162: score = 0; break; //Core i5 11600T
                        case 163: score = 0; break; //Core i5 1155G7
                        case 164: score = 0; break; //Core i5 11500
                        case 165: score = 0; break; //Core i5 11500T
                        case 166: score = 0; break; //Core i5 11500H
                        case 167: score = 0; break; //Core i5 11500HE
                        case 168: score = 0; break; //Core i5 1145G7 w/IPU
                        case 169: score = 23; break; //Core i5 1145G7E w/IPU
                        case 170: score = 0; break; //Core i5 1145G7E
                        case 171: score = 0; break; //Core i5 11400
                        case 172: score = 0; break; //Core i5 11400F
                        case 173: score = 0; break; //Core i5 11400T
                        case 174: score = 0; break; // Core i5 11400H
                        case 175: score = 0; break; // Core i5 1140G7
                        case 176: score = 0; break; // Core i5 1135G7
                        case 177: score = 0; break; // Core i5 11320H w/IPU
                        case 178: score = 0; break; //Core i5 11300H w/IPU
                        case 179: score = 0; break; //Core i5 1130G7 w/IPU
                        case 180: score = 0; break; //Core i5 11260H
                        case 181: score = 0; break; //Core i5 10600
                        case 182: score = 0; break; //Core i5 10600K
                        case 183: score = 0; break; //Core i5 10600KF
                        case 184: score = 0; break; //Core i5 10600T
                        case 185: score = 0; break; //Core i5 10505
                        case 186: score = 0; break; //Core i5 10500
                        case 187: score = 0; break; //Core i5 10500E
                        case 188: score = 0; break; //Core i5 10500T
                        case 189: score = 0; break; //Core i5 10500TE
                        case 190: score = 0; break; //Core i5 10500H
                        case 191: score = 0; break; //Core i5 10400
                        case 192: score = 0; break; //Core i5 10400F
                        case 193: score = 0; break; //Core i5 10400T
                        case 194: score = 0; break; //Core i5 10210U
                        case 195: score = 0; break; //Core i5 9600
                        case 196: score = 0; break; //Core i5 9600K
                        case 197: score = 0; break; //Core i5 9600KF
                        case 198: score = 0; break; //Core i5 9600T
                        case 199: score = 0; break; //Core i5 9500
                        case 200: score = 0; break; //Core i5 9500E
                        case 201: score = 0; break; //Core i5 9500F
                        case 202: score = 0; break; //Core i5 9500T
                        case 203: score = 0; break; //Core i5 9400
                        case 204: score = 0; break; //Core i5 9400F
                        case 205: score = 0; break; //Core i5 9400T
                        case 206: score = 0; break; //Core i5 8600K
                        case 207: score = 0; break; //Core i5 8500
                        case 208: score = 0; break; //Core i5 8500B
                        case 209: score = 0; break; //Core i5 8400
                        case 210: score = 0; break; //Core i5 8400H
                        case 211: score = 0; break; //Core i5 8400B
                        case 212: score = 0; break; //Core i5 8365U
                        case 213: score = 0; break; //Core i5 8350U
                        case 214: score = 0; break; //Core i5 8310Y
                        case 215: score = 0; break; //Core i5 8300H
                        case 216: score = 0; break; //Core i5 8279U
                        case 217: score = 0; break; //Core i5 8269U
                        case 218: score = 0; break; //Core i5 8265U
                        case 219: score = 0; break; //Core i5 8260U
                        case 220: score = 0; break; //Core i5 8259U
                        case 221: score = 0; break; //Core i5 8257U
                        case 222: score = 0; break; //Core i5 8250U
                        case 223: score = 0; break; //Core i5 8210Y
                        case 224: score = 0; break; //Core i5 8200Y
                        case 225: score = 0; break; //Core i5 7640X
                        case 226: score = 0; break; //Core i5 7600
                        case 227: score = 0; break; //Core i5 7600K
                        case 228: score = 0; break; //Core i5 7600T
                        case 229: score = 10; break; //Core i5 7500
                        case 230: score = 0; break; //Core i5 7500T
                        case 231: score = 0; break; //Core i5 7440HQ
                        case 232: score = 0; break; //Core i5 7400
                        case 233: score = 0; break; //Core i5 7400T
                        case 234: score = 0; break; //Core i5 7360U
                        case 235: score = 0; break; //Core i5 7300HQ
                        case 236: score = 0; break; //Core i5 7300U
                        case 237: score = 0; break; //Core i5 7287U
                        case 238: score = 0; break; //Core i5 7267U
                        case 239: score = 0; break; //Core i5 7260U
                        case 240: score = 0; break; //Core i5 7200U
                        case 241: score = 10; break; //Core i5 7Y57
                        case 242: score = 0; break; //Core i5 7Y54
                        case 243: score = 0; break; //Core i5 1250P
                        case 244: score = 0; break; //Core i5 1245U
                        case 245: score = 0; break; //Core i5 1240P
                        case 246: score = 0; break; //Core i5 1240U
                        case 247: score = 54; break; //Core i5 1235U
                        case 248: score = 5; break; //Core i5 1230U
                        case 249: score = 0; break; //Core i3 13100
                        case 250: score = 0; break; //Core i3 13100F
                        case 251: score = 0; break; //Core i3 13100T
                        case 252: score = 0; break; //Core i3 12300
                        case 253: score = 0; break; //Core i3 12300T
                        case 254: score = 0; break; //Core i3 12100
                        case 255: score = 0; break; //Core i3 12100F
                        case 256: score = 0; break; //Core i3 12100T
                        case 257: score = 0; break; //Core i3 1125G4
                        case 258: score = 0; break; //Core i3 1125G4 w/IPU
                        case 259: score = 0; break; //Core i3 1120G4 w/IPU
                        case 260: score = 0; break; //Core i3 1115GRE
                        case 261: score = 0; break; //Core i3 1115G4E
                        case 262: score = 0; break; //Core i3 1115G4
                        case 263: score = 0; break; //Core i3 1115G4 w/IPU
                        case 264: score = 0; break; //Core i3 1110G4 w/IPU
                        case 265: score = 0; break; //Core i3 1110HE
                        case 266: score = 0; break; //Core i3 10320
                        case 267: score = 0; break; //Core i3 10300
                        case 268: score = 0; break; //Core i3 10300T
                        case 269: score = 0; break; //Core i3 10110Y
                        case 270: score = 0; break; //Core i3 10100
                        case 271: score = 0; break; //Core i3 10100F
                        case 272: score = 0; break; //Core i3 10100T
                        case 273: score = 0; break; //Core i3 10100E
                        case 274: score = 0; break; //Core i3 10100TE
                        case 275: score = 0; break; //Core i3 9350K
                        case 276: score = 0; break; //Core i3 9350KF
                        case 277: score = 0; break; //Core i3 9320
                        case 278: score = 0; break; //Core i3 9300
                        case 279: score = 0; break; //Core i3 9300T
                        case 280: score = 0; break; //Core i3 9100
                        case 281: score = 0; break; //Core i3 9100F
                        case 282: score = 0; break; //Core i3 9100T
                        case 283: score = 0; break; //Core i3 9100E
                        case 284: score = 0; break; //Core i3 9100TE
                        case 285: score = 0; break; //Core i3 8350K
                        case 286: score = 0; break; //Core i3 8145U
                        case 287: score = 0; break; //Core i3 8140U
                        case 288: score = 0; break; //Core i3 8130U
                        case 289: score = 0; break; //Core i3 8109U
                        case 290: score = 0; break; //Core i3 8100
                        case 291: score = 0; break; //Core i3 8100H
                        case 292: score = 0; break; //Core i3 8100B
                        case 293: score = 0; break; //Core i3 7350K
                        case 294: score = 0; break; //Core i3 7320
                        case 295: score = 0; break; //Core i3 7300
                        case 296: score = 0; break; //Core i3 7300T
                        case 297: score = 0; break; //Core i3 7130U
                        case 298: score = 0; break; //Core i3 7167U
                        case 299: score = 0; break; //Core i3 7101E
                        case 300: score = 0; break; //Core i3 7101TE
                        case 301: score = 0; break; //Core i3 7100T
                        case 302: score = 0; break; //Core i3 7100
                        case 303: score = 0; break; //Core i3 7100H
                        case 304: score = 0; break; //Core i3 7100U
                        case 305: score = 0; break; //Core i3 1220P
                        case 306: score = 0; break; //Core i3 1215U
                        case 307: score = 0; break; //Core i3 1210U
                        case 309: score = 0; break; //Xeon W-11965MRE
                        case 310: score = 0; break; //Xeon W-11955M
                        case 311: score = 0; break; //Xeon W-11865MLE
                        case 312: score = 0; break; //Xeon W-11855M
                        case 313: score = 0; break; //Xeon W-11555MRE
                        case 314: score = 0; break; //Xeon W-11555MLE
                        case 315: score = 0; break; //Xeon W-11155MRE
                        case 316: score = 96; break; //Xeon W-11155MLE
                    }
                }
            }
            else //KYS
            {
                MessageBox.Show("Kys");
            }
        }
        private async void Loadbar()
        {
            bar.Value = 0;
            for (int progressValue = 0; progressValue <= 100; progressValue++)
            {
                int interval = 100;
                bar.Value = progressValue;
                await Task.Delay(interval);
            }
            if (bar.Value == 100) { result.Content = $" {score} points"; }
            Intel.SelectedIndex = 0;
            Amd.SelectedIndex = 0;
            bar.Value = 0;
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (CpuInput.Text != "") { cpuCheck(); return; }
            else if (Amd.SelectedIndex == 207 && Intel.SelectedIndex == 308 || Amd.SelectedIndex == 0 && Intel.SelectedIndex == 0) { AMDcheck = true; Intelcheck = true; }
            else if (Amd.SelectedIndex != 207 && Amd.SelectedIndex != 0 || Intel.SelectedIndex != 308 && Intel.SelectedIndex != 0)
            {
                if (Amd.SelectedIndex == 0 && Intel.SelectedIndex != 308) { Intelcheck = false; AMDcheck = true; }
                else if (Intel.SelectedIndex == 0 && Amd.SelectedIndex != 207) { Intelcheck = true; AMDcheck = false; }
                else { AMDcheck = false; Intelcheck = false; }
            }
            cpuListCheck(AMDcheck, Intelcheck);
        }
        private void mode_Click(object sender, RoutedEventArgs e) //nějak to funguje radši na to šahat nebudu
        {
            if (True == false)
            {
                window.Background = Brushes.Black;
                title.Foreground = Brushes.White;
                enter.Foreground = Brushes.White;
                singleCore.Foreground = Brushes.White;
                multiCore.Foreground = Brushes.White;
                result.Foreground = Brushes.White;
                mode.Foreground = Brushes.Black;
                True = true;
                mode.Content = "Light mode";
            }
            else if(True == true)
            {
                window.Background = Brushes.White;
                title.Foreground = Brushes.Black;
                enter.Foreground = Brushes.Black;
                singleCore.Foreground = Brushes.Black;
                multiCore.Foreground = Brushes.Black;   
                result.Foreground = Brushes.Black;
                mode.Foreground = Brushes.Black;
                True = false;
                mode.Content = "Dark mode";
            }
        }
        private void help_Click(object sender, RoutedEventArgs e) //info box
        {
            MessageBoxResult helpBox = MessageBox.Show($"Pokud chceš zvolit Amd cpu tak v druhém boxu dej Intel.\nPokud chceš zvolit Intel cpu tak v prvném boxu dej Amd.\nCpu skóre jsou pravdivé\nDej ANO aby jsi mohl jít napsat report na hmyz","Help",MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (helpBox == MessageBoxResult.Yes)
            {
                var psi = new ProcessStartInfo
                { FileName = "https://github.com/DrDetective/CPU_Benchmark/issues/new", UseShellExecute = true, };
                Process.Start(psi);
            }
        } //sice to neni hypertext ale funguje to

        private void cpuInput_KeyDown(object sender, KeyEventArgs e) { if (e.Key == Key.Enter) { start_Click(sender, e); } }
    }
}