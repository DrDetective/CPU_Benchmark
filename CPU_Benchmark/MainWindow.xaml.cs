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
            else if (singleThread.IsChecked == true || multiThread.IsChecked == true)
            {
                cpuSwitch();
            }
        }
        private void cpuSwitch()  //dopsat score k cpus
        {
            Loadbar();
            if (singleThread.IsChecked == true) //SINGLETHREAD SELECTED
            {
                if (AMDcheck == false && Intelcheck == true) //AMD SINGLE THREAD CPU
                {
                    switch (Amd.SelectedIndex)
                    {
                        case 1: score = 616; break;  //Ryzen ThreadRipper PRO 5995WX
                        case 2: score = 648; break;  //Ryzen Threadripper PRO 5975WX
                        case 3: score = 627; break;  //Ryzen Threadripper PRO 5965WX
                        case 4: score = 626; break;  //Ryzen Threadripper PRO 5955WX
                        case 5: score = 628; break;  //Ryzen Threadripper PRO 5945WX
                        case 6: score = 510; break;  //Ryzen Threadripper PRO 3995WX
                        case 7: score = 380; break;  //Ryzen Threadripper 3990X
                        case 8: score = 529; break;  //Ryzen Threadripper PRO 3975WX
                        case 9: score = 528; break;  //Ryzen Threadripper 3970X
                        case 10: score = 535; break; //Ryzen Threadripper 3960X
                        case 11: score = 505; break; //Ryzen Threadripper PRO 3955WX
                        case 12: score = 530; break; //Ryzen Threadripper PRO 3945WX
                        case 13: score = 477; break; //Ryzen Threadripper 2990WX
                        case 14: score = 467; break; //Ryzen Threadripper 2970WX
                        case 15: score = 490; break; //Ryzen Threadripper 2950X
                        case 16: score = 484; break; //Ryzen Threadripper 2920X
                        case 17: score = 469; break; //Ryzen Threadripper 1950X
                        case 18: score = 466; break; //Ryzen Threadripper 1920X
                        case 19: score = 438; break; //Ryzen Threadripper 1900X
                        case 20: score = ; break; //Ryzen Z1
                        case 21: score = 659; break; //Ryzen Z1 Extreme
                        case 22: score = 705; break; //Ryzen 9 7950X3D
                        case 23: score = 787; break; //Ryzen 9 7950X
                        case 24: score = 759; break; //Ryzen 9 PRO 7945
                        case 25: score = 681; break; //Ryzen 9 7945HX
                        case 26: score = 661; break; //Ryzen 9 7940HS
                        case 27: score = 652; break; //Ryzen 9 7940H
                        case 28: score = 779; break; //Ryzen 9 7900
                        case 29: score = 735; break; //Ryzen 9 7900X
                        case 30: score = 725; break; //Ryzen 9 7900X3D
                        case 31: score = 702; break; //Ryzen 9 7845HX
                        case 32: score = ; break; //Ryzen 9 6980HX
                        case 33: score = ; break; //Ryzen 9 6980HS
                        case 34: score = 609; break; //Ryzen 9 6900HX
                        case 35: score = 643; break; //Ryzen 9 6900HS
                        case 36: score = 603; break; //Ryzen 9 5980HX
                        case 37: score = 611; break; //Ryzen 9 5980HS
                        case 38: score = 658; break; //Ryzen 9 5950X
                        case 39: score = 668; break; //Ryzen 9 5900X
                        case 40: score = ; break; //Ryzen 9 5900
                        case 41: score = 601; break; //Ryzen 9 5900HX
                        case 42: score = 578; break; //Ryzen 9 5900HS
                        case 43: score = 435; break; //Ryzen 9 4900H
                        case 44: score = 525; break; //Ryzen 9 4900HS
                        case 45: score = 547; break; //Ryzen 9 3950X
                        case 46: score = 542; break; //Ryzen 9 3900XT
                        case 47: score = 569; break; //Ryzen 9 3900X
                        case 48: score = 535; break; //Ryzen 9 3900
                        case 49: score = 655; break; //Ryzen 7 7840HS
                        case 50: score = 350; break; //Ryzen 7 7840H
                        case 51: score = 664; break; //Ryzen 7 7840U
                        case 52: score = 654; break; //Ryzen 7 7800X3D
                        case 53: score = ; break; //Ryzen 7 PRO 7745
                        case 54: score = 714; break; //Ryzen 7 7745HX
                        case 55: score = ; break; //Ryzen 7 7736U
                        case 56: score = 631; break; //Ryzen 7 7735U
                        case 57: score = 527; break; //Ryzen 7 7735HS
                        case 58: score = ; break; //Ryzen 7 PRO 7730U
                        case 59: score = 557; break; //Ryzen 7 7730U
                        case 60: score = 712; break; //Ryzen 7 7700
                        case 61: score = 749; break; //Ryzen 7 7700X
                        case 62: score = ; break; //Ryzen 7045 
                        case 63: score = ; break; //Ryzen 7040 
                        case 64: score = ; break; //Ryzen 7035 
                        case 65: score = ; break; //Ryzen 7030 
                        case 66: score = ; break; //Ryzen 7020
                        case 67: score = 646; break; //Ryzen 7 6800H
                        case 68: score = 620; break; //Ryzen 7 6800HS
                        case 69: score = 621; break; //Ryzen 7 6800U
                        case 70: score = 622; break; //Ryzen 7 5825U
                        case 71: score = 637; break; //Ryzen 7 5800
                        case 72: score = 650; break; //Ryzen 7 5800X
                        case 73: score = 601; break; //Ryzen 7 5800X3D
                        case 74: score = 477; break; //Ryzen 7 5800U
                        case 75: score = 570; break; //Ryzen 7 5800H
                        case 76: score = 574; break; //Ryzen 7 5800HS
                        case 77: score = ; break; //Ryzen 7 5700
                        case 78: score = 643; break; //Ryzen 7 5700X
                        case 79: score = 631; break; //Ryzen 7 5700G
                        case 80: score = 627; break; //Ryzen 7 5700GE
                        case 81: score = 527; break; //Ryzen 7 5700U
                        case 82: score = ; break; //Ryzen 7 4980U
                        case 83: score = 433; break; //Ryzen 7 4800H
                        case 84: score = 516; break; //Ryzen 7 4800HS
                        case 85: score = 521; break; //Ryzen 7 4800U
                        case 86: score = 541; break; //Ryzen 7 4700G
                        case 87: score = 524; break; //Ryzen 7 4700GE
                        case 88: score = 496; break; //Ryzen 7 4700U
                        case 89: score = ; break; //Ryzen 7 4600GE
                        case 90: score = 544; break; //Ryzen 7 3800X
                        case 91: score = 562; break; //Ryzen 7 3800XT
                        case 92: score = ; break; //Ryzen 7 3780U
                        case 93: score = 379; break; //Ryzen 7 3750H
                        case 94: score = ; break; //Ryzen 7 3700C
                        case 95: score = 360; break; //Ryzen 7 3700U
                        case 96: score = 528; break; //Ryzen 7 3700X
                        case 97: score = ; break; //Ryzen 7 2800H
                        case 98: score = 401; break; //Ryzen 7 2700
                        case 99: score = 498; break; //Ryzen 7 2700X
                        case 100: score = 466; break; //Ryzen 7 2700E
                        case 101: score = 399; break; //Ryzen 7 2700U
                        case 102: score = 411; break; //Ryzen 7 1800X
                        case 103: score = 445; break; //Ryzen 7 1700
                        case 104: score = 406; break; //Ryzen 7 1700X
                        case 105: score = 376; break; //Ryzen 7 PRO 1700
                        case 106: score = 406; break; //Ryzen 7 PRO 1700X
                        case 107: score = ; break; //Ryzen 5 PRO 7645
                        case 108: score = ; break; //Ryzen 5 7645HX
                        case 109: score = ; break; //Ryzen 5 7640H
                        case 110: score = 660; break; //Ryzen 5 7640HS
                        case 111: score = ; break; //Ryzen 5 7640U
                        case 112: score = 751; break; //Ryzen 5 7600
                        case 113: score = 767; break; //Ryzen 5 7600X
                        case 114: score = ; break; //Ryzen 5 7540U
                        case 115: score = 569; break; //Ryzen 5 7535HS
                        case 116: score = ; break; //Ryzen 5 7535U
                        case 117: score = ; break; //Ryzen 5 PRO 7530U
                        case 118: score = 255; break; //Ryzen 5 7530U
                        case 119: score = 439; break; //Ryzen 5 7520U
                        case 120: score = 586; break; //Ryzen 5 6600H
                        case 121: score = 552; break; //Ryzen 5 6600HS
                        case 122: score = 429; break; //Ryzen 5 6600U
                        case 123: score = 585; break; //Ryzen 5 5625U
                        case 124: score = 638; break; //Ryzen 5 5600
                        case 125: score = 643; break; //Ryzen 5 5600X
                        case 126: score = 596; break; //Ryzen 5 5600G
                        case 127: score = 608; break; //Ryzen 5 5600GE
                        case 128: score = 547; break; //Ryzen 5 5600H
                        case 129: score = ; break; //Ryzen 5 5600HS
                        case 130: score = 586; break; //Ryzen 5 5600U
                        case 131: score = 465; break; //Ryzen 5 5560U
                        case 132: score = 607; break; //Ryzen 5 5500
                        case 133: score = 483; break; //Ryzen 5 5500U
                        case 134: score = ; break; //Ryzen 5 4680U
                        case 135: score = 486; break; //Ryzen 5 4600H
                        case 136: score = 474; break; //Ryzen 5 4600HS
                        case 137: score = 486; break; //Ryzen 5 4600U
                        case 138: score = 521; break; //Ryzen 5 4600G
                        case 139: score = 437; break; //Ryzen 5 4500
                        case 140: score = 490; break; //Ryzen 5 4500U
                        case 141: score = 515; break; //Ryzen 5 3600
                        case 142: score = 515; break; //Ryzen 5 3600X
                        case 143: score = 573; break; //Ryzen 5 3600XT
                        case 144: score = ; break; //Ryzen 5 3580H
                        case 145: score = 420; break; //Ryzen 5 3550H
                        case 146: score = 473; break; //Ryzen 5 3500
                        case 147: score = 482; break; //Ryzen 5 3500X
                        case 148: score = ; break; //Ryzen 5 3500C
                        case 149: score = 377; break; //Ryzen 5 3500U
                        case 150: score = 360; break; //Ryzen 5 3450U
                        case 151: score = 467; break; //Ryzen 5 3400G
                        case 152: score = ; break; //Ryzen 5 PRO 3400G
                        case 153: score = 453; break; //Ryzen 5 PRO 3400GE
                        case 154: score = 438; break; //Ryzen 5 3350G
                        case 155: score = ; break; //Ryzen 5 3350GE
                        case 156: score = 475; break; //Ryzen 5 2600
                        case 157: score = 478; break; //Ryzen 5 2600X
                        case 158: score = 463; break; //Ryzen 5 2600E
                        case 159: score = ; break; //Ryzen 5 2600H
                        case 160: score = 441; break; //Ryzen 5 2500X
                        case 161: score = 346; break; //Ryzen 5 2500U
                        case 162: score = 331; break; //Ryzen 5 2400G
                        case 163: score = ; break; //Ryzen 5 2400GE
                        case 164: score = 412; break; //Ryzen 5 1600
                        case 165: score = 408; break; //Ryzen 5 1600X
                        case 166: score = ; break; //Ryzen 5 PRO 1600
                        case 167: score = 459; break; //Ryzen 5 PRO 1500
                        case 168: score = 477; break; //Ryzen 5 1500X
                        case 169: score = 432; break; //Ryzen 5 1400
                        case 170: score = ; break; //Ryzen 3 7440U
                        case 171: score = ; break; //Ryzen 3 7335U
                        case 172: score = ; break; //Ryzen 3 7330U
                        case 173: score = ; break; //Ryzen 3 PRO 7330U
                        case 174: score = 224; break; //Ryzen 3 7320U
                        case 175: score = 535; break; //Ryzen 3 5425U
                        case 176: score = 506; break; //Ryzen 3 5400U
                        case 177: score = 447; break; //Ryzen 3 5300U
                        case 178: score = 578; break; //Ryzen 3 5300G
                        case 179: score = ; break; //Ryzen 3 5300GE
                        case 180: score = ; break; //Ryzen 3 5125C
                        case 181: score = 493; break; //Ryzen 3 4300G
                        case 182: score = 415; break; //Ryzen 3 4300GE
                        case 183: score = 464; break; //Ryzen 3 4300U
                        case 184: score = 500; break; //Ryzen 3 4100
                        case 185: score = 381; break; //Ryzen 3 3350U
                        case 186: score = 514; break; //Ryzen 3 3300X
                        case 187: score = 353; break; //Ryzen 3 3300U
                        case 188: score = 337; break; //Ryzen 3 3250U
                        case 189: score = ; break; //Ryzen 3 3250C
                        case 190: score = 440; break; //Ryzen 3 3200G
                        case 191: score = ; break; //Ryzen 3 3200GE
                        case 192: score = 440; break; //Ryzen 3 Pro 3200GE
                        case 193: score = ; break; //Ryzen 3 Pro 3200G
                        case 194: score = 145; break; //Ryzen 3 3200U
                        case 195: score = 478; break; //Ryzen 3 3100
                        case 196: score = 333; break; //Ryzen 3 2300U
                        case 197: score = 489; break; //Ryzen 3 2300X
                        case 198: score = 338; break; //Ryzen 3 2200U
                        case 199: score = 448; break; //Ryzen 3 2200G
                        case 200: score = 473; break; //Ryzen 3 2200GE
                        case 201: score = 313; break; //Ryzen 3 PRO 2100GE
                        case 202: score = 409; break; //Ryzen 3 1300X
                        case 203: score = 421; break; //Ryzen 3 PRO 1300
                        case 204: score = 444; break; //Ryzen 3 1200
                        case 205: score = ; break; //Ryzen 3 PRO 1200
                        case 206: score = ; break; //Ryzen 1200 (AF)
                        case 208: score = 273; break; //EPYC 9754
                        case 209: score = ; break; //EPYC 9754S
                        case 210: score = ; break; //EPYC 9734
                        case 211: score = ; break; //EPYC 9684X
                        case 212: score = 519; break; //EPYC 9654
                        case 213: score = ; break; //EPYC 9654P
                        case 214: score = ; break; //EPYC 9634
                        case 215: score = ; break; //EPYC 9554
                        case 216: score = ; break; //EPYC 9554P
                        case 217: score = ; break; //EPYC 9534
                        case 218: score = ; break; //EPYC 9474F
                        case 219: score = ; break; //EPYC 9454
                        case 220: score = ; break; //EPYC 9454P
                        case 221: score = ; break; //EPYC 9384X
                        case 222: score = ; break; //EPYC 9374F
                        case 223: score = ; break; //EPYC 9354
                        case 224: score = ; break; //EPYC 9354P
                        case 225: score = ; break; //EPYC 9334
                        case 226: score = ; break; //EPYC 9274F
                        case 227: score = ; break; //EPYC 9254
                        case 228: score = ; break; //EPYC 9224
                        case 229: score = ; break; //EPYC 9184X
                        case 230: score = ; break; //EPYC 9174F
                        case 231: score = ; break; //EPYC 9124
                        case 232: score = ; break; //EPYC 7773X
                        case 233: score = 485; break; //EPYC 7763
                        case 234: score = 416; break; //EPYC 7742
                        case 235: score = 505; break; //EPYC 7713
                        case 236: score = ; break; //EPYC 7713P
                        case 237: score = 407; break; //EPYC 7702
                        case 238: score = 411; break; //EPYC 7702P
                        case 239: score = ; break; //EPYC 7663
                        case 240: score = ; break; //EPYC 7662
                        case 241: score = ; break; //EPYC 7643
                        case 242: score = ; break; //EPYC 7642
                        case 243: score = ; break; //EPYC 7624
                        case 244: score = 253; break; //EPYC 7601
                        case 245: score = ; break; //EPYC 7573X
                        case 246: score = 407; break; //EPYC 7571
                        case 247: score = ; break; //EPYC 7552
                        case 248: score = ; break; //EPYC 7551
                        case 249: score = 343; break; //EPYC 7551P
                        case 250: score = 410; break; //EPYC 7542
                        case 251: score = 515; break; //EPYC 7543
                        case 252: score = ; break; //EPYC 7543P
                        case 253: score = 403; break; //EPYC 7532
                        case 254: score = ; break; //EPYC 7513
                        case 255: score = ; break; //EPYC 7502
                        case 256: score = 396; break; //EPYC 7502P
                        case 257: score = 373; break; //EPYC 7501
                        case 258: score = ; break; //EPYC 7473X
                        case 259: score = ; break; //EPYC 7453
                        case 260: score = ; break; //EPYC 7452
                        case 261: score = ; break; //EPYC 7443
                        case 262: score = ; break; //EPYC 7443P
                        case 263: score = ; break; //EPYC 7413
                        case 264: score = 399; break; //EPYC 7402
                        case 265: score = ; break; //EPYC 7402P
                        case 266: score = 343; break; //EPYC 7401
                        case 267: score = ; break; //EPYC 7401P
                        case 268: score = ; break; //EPYC 7373X
                        case 269: score = ; break; //EPYC 7371
                        case 270: score = ; break; //EPYC 7352
                        case 271: score = 337; break; //EPYC 7351
                        case 272: score = ; break; //EPYC 7351P
                        case 273: score = ; break; //EPYC 7343
                        case 274: score = ; break; //EPYC 7313
                        case 275: score = ; break; //EPYC 7313P
                        case 276: score = 403; break; //EPYC 7302
                        case 277: score = 407; break; //EPYC 7302P
                        case 278: score = 309; break; //EPYC 7301
                        case 279: score = ; break; //EPYC 7282
                        case 280: score = 310; break; //EPYC 7281
                        case 281: score = 388; break; //EPYC 7272
                        case 282: score = 395; break; //EPYC 7262
                        case 283: score = ; break; //EPYC 7261
                        case 284: score = 388; break; //EPYC 7252
                        case 285: score = 330; break; //EPYC 7251
                        case 286: score = ; break; //EPYC 7232P
                        case 287: score = ; break; //EPYC 7F72
                        case 288: score = ; break; //EPYC 75F3
                        case 289: score = ; break; //EPYC 74F3
                        case 290: score = ; break; //EPYC 73F3
                        case 291: score = 575; break; //EPYC 72F3
                        case 292: score = 479; break; //EPYC 7F52
                        case 293: score = ; break; //EPYC 7F32
                        case 294: score = ; break; //EPYC 3H12
                        case 295: score = ; break; //EPYC 3451
                        case 296: score = ; break; //EPYC 3401
                        case 297: score = ; break; //EPYC 3351
                        case 298: score = ; break; //EPYC 3301
                        case 299: score = ; break; //EPYC 3255
                        case 300: score = ; break; //EPYC 3251
                        case 301: score = ; break; //EPYC 3201 
                        case 302: score = ; break; //EPYC 3151
                        case 303: score = ; break; //EPYC 3101
                    }
                }
                else if (AMDcheck == true && Intelcheck == false) //INTEL SINGLE THREAD CPU
                {
                    switch (Intel.SelectedIndex)
                    {
                        case 1: score = ; break; //Core i9 13900
                        case 2: score = 2973; break; //Core i9 13900K
                        case 3: score = 3104; break; //Core i9 13000KS
                        case 4: score = ; break; //Core i9 13900KF
                        case 5: score = ; break; //Core i9 13900F
                        case 6: score = ; break; //Core i9 13900T
                        case 7: score = ; break; //Core i9 12950HX
                        case 8: score = ; break; //Core i9 12900
                        case 9: score = ; break; //Core i9 12900K
                        case 10: score = ; break; //Core i9 12900KS
                        case 11: score = ; break; //Core i9 12900KF
                        case 12: score = ; break; //Core i9 12900F
                        case 13: score = ; break; //Core i9 12900T
                        case 14: score = ; break; //Core i9 12900H
                        case 15: score = ; break; //Core i9 12900HX
                        case 16: score = ; break; //Core i9 12900HK
                        case 17: score = ; break; //Core i9 11980HK
                        case 18: score = ; break; //Core i9 11950H
                        case 19: score = ; break; //Core i9 11900
                        case 20: score = ; break; //Core i9 11900K
                        case 21: score = ; break; //Core i9 11900KF
                        case 22: score = ; break; //Core i9 11900F
                        case 23: score = ; break; //Core i9 11900T
                        case 24: score = ; break; //Core i9 11900H
                        case 25: score = ; break; //Core i9 10910
                        case 26: score = ; break; //Core i9 10900
                        case 27: score = ; break; //Core i9 10900K
                        case 28: score = ; break; //Core i9 10900KF
                        case 29: score = ; break; //Core i9 10900F
                        case 30: score = ; break; //Core i9 10900E
                        case 31: score = ; break; //Core i9 10900T
                        case 32: score = ; break; //Core i9 10850K
                        case 33: score = ; break; //Core i9 9900
                        case 34: score = ; break; //Core i9 9900K
                        case 35: score = ; break; //Core i9 9900KS
                        case 36: score = ; break; //Core i9 9900T
                        case 37: score = ; break; //Core i9 8950HK
                        case 38: score = ; break; //Core i9 7980XE
                        case 39: score = ; break; //Core i9 7960X
                        case 40: score = ; break; //Core i9 7940X
                        case 41: score = ; break; //Core i9 7920X
                        case 42: score = ; break; //Core i9 7900X
                        case 43: score = ; break; //Core i7 13700
                        case 44: score = ; break; //Core i7 13700K
                        case 45: score = ; break; //Core i7 13700KF
                        case 46: score = ; break; //Core i7 13700F
                        case 47: score = ; break; //Core i7 13700T
                        case 48: score = ; break; //Core i7 12850HX
                        case 49: score = ; break; //Core i7 12800H
                        case 50: score = ; break; //Core i7 12800HX
                        case 51: score = ; break; //Core i7 12700
                        case 52: score = ; break; //Core i7 12700K
                        case 53: score = ; break; //Core i7 12700KF
                        case 54: score = ; break; //Core i7 12700F
                        case 55: score = ; break; //Core i7 12700T
                        case 56: score = ; break; //Core i7 12700H
                        case 57: score = ; break; //Core i7 12650H
                        case 58: score = ; break; //Core i7 12650HX
                        case 59: score = ; break; //Core i7 1195G7
                        case 60: score = ; break; //Core i7 1195G7 w/IPU
                        case 61: score = ; break; //Core i7 1185GRE
                        case 62: score = ; break; //Core i7 1185G7E
                        case 63: score = ; break; //Core i7 1185G7 w/IPU
                        case 64: score = ; break; //Core i7 11850H
                        case 65: score = ; break; //Core i7 11850HE
                        case 66: score = ; break; //Core i7 11800H
                        case 67: score = ; break; //Core i7 1180G7 w/IPU
                        case 68: score = ; break; //Core i7 11700
                        case 69: score = ; break; //Core i7 11700K
                        case 70: score = ; break; //Core i7 11700KF
                        case 71: score = ; break; //Core i7 11700F
                        case 72: score = ; break; //Core i7 11700T
                        case 73: score = ; break; //Core i7 1165G7
                        case 74: score = ; break; //Core i7 1165G7 w/IPU
                        case 75: score = ; break; //Core i7 11600H
                        case 76: score = ; break; //Core i7 1160G7 w/IPU
                        case 77: score = ; break; //Core i7 11390H
                        case 78: score = ; break; //Core i7 11375H
                        case 79: score = ; break; //Core i7 11375H w/IPU
                        case 80: score = ; break; //Core i7 11370H w/IPU
                        case 81: score = ; break; //Core i7 10750H
                        case 82: score = ; break; //Core i7 10710U
                        case 83: score = ; break; //Core i7 10700
                        case 84: score = ; break; //Core i7 10700K
                        case 85: score = ; break; //Core i7 10700KF
                        case 86: score = ; break; //Core i7 10700F
                        case 87: score = ; break; //Core i7 10700T
                        case 88: score = ; break; //Core i7 10700E
                        case 89: score = ; break; //Core i7 10700TE
                        case 90: score = ; break; //Core i7 1065G7
                        case 91: score = ; break; //Core i7 10610U
                        case 92: score = ; break; //Core i7 1060G7
                        case 93: score = ; break; //Core i7 10510U
                        case 94: score = ; break; //Core i7 10510Y
                        case 95: score = ; break; //Core i7 9700
                        case 96: score = ; break; //Core i7 9700K
                        case 97: score = ; break; //Core i7 9700T
                        case 98: score = ; break; //Core i7 9700TE
                        case 99: score = ; break; //Core i7 8850H
                        case 100: score = ; break; //Core i7 8750H
                        case 101: score = ; break; //Core i7 8700
                        case 102: score = ; break; //Core i7 8700K
                        case 103: score = ; break; //Core i7 8700B
                        case 104: score = ; break; //Core i7 8569U
                        case 105: score = ; break; //Core i7 8665U
                        case 106: score = ; break; //Core i7 8650U
                        case 107: score = ; break; //Core i7 8565U
                        case 108: score = ; break; //Core i7 8559U
                        case 109: score = ; break; //Core i7 8557U
                        case 110: score = ; break; //Core i7 8550U
                        case 111: score = ; break; //Core i7 8500Y
                        case 112: score = ; break; //Core i7 8086K
                        case 113: score = ; break; //Core i7 7920HQ
                        case 114: score = ; break; //Core i7 7900U
                        case 115: score = ; break; //Core i7 7820HQ
                        case 116: score = ; break; //Core i7 7820HK
                        case 117: score = ; break; //Core i7 7820X
                        case 118: score = ; break; //Core i7 7800X
                        case 119: score = ; break; //Core i7 7740X
                        case 120: score = ; break; //Core i7 7700
                        case 121: score = ; break; //Core i7 7700K
                        case 122: score = ; break; //Core i7 7700T
                        case 123: score = ; break; //Core i7 7700HQ
                        case 124: score = ; break; //Core i7 7660U
                        case 125: score = ; break; //Core i7 7560U
                        case 126: score = ; break; //Core i7 7500U
                        case 127: score = ; break; //Core i7 7Y75
                        case 128: score = ; break; //Core i7 1280P
                        case 129: score = ; break; //Core i7 1270P
                        case 130: score = ; break; //Core i7 1265U
                        case 131: score = ; break; //Core i7 1260P
                        case 132: score = ; break; //Core i7 1260U
                        case 133: score = ; break; //Core i7 1255U
                        case 134: score = ; break; //Core i7 1250U
                        case 135: score = ; break; //Core i5 13600
                        case 136: score = ; break; //Core i5 13600K
                        case 137: score = ; break; //Core i5 13600KF
                        case 138: score = ; break; //Core i5 13600T
                        case 139: score = ; break; //Core i5 13500
                        case 140: score = ; break; //Core i5 13500T
                        case 141: score = ; break; //Core i5 13420H
                        case 142: score = ; break; //Core i5 13400
                        case 143: score = ; break; //Core i5 13400F
                        case 144: score = ; break; //Core i5 13400T
                        case 145: score = ; break; //Core i5 12600
                        case 146: score = ; break; //Core i5 12600K
                        case 147: score = ; break; //Core i5 12600KF
                        case 148: score = ; break; //Core i5 12600T
                        case 149: score = ; break; //Core i5 12600HX
                        case 150: score = ; break; //Core i5 12600H
                        case 151: score = ; break; //Core i5 12500
                        case 152: score = ; break; //Core i5 12500T
                        case 153: score = ; break; //Core i5 12500H
                        case 154: score = ; break; //Core i5 12450H
                        case 155: score = ; break; //Core i5 12450HX
                        case 156: score = ; break; //Core i5 12400
                        case 157: score = ; break; //Core i5 12400F
                        case 158: score = ; break; //Core i5 12400T
                        case 159: score = ; break; //Core i5 11600
                        case 160: score = ; break; //Core i5 11600K
                        case 161: score = ; break; //Core i5 11600KF
                        case 162: score = ; break; //Core i5 11600T
                        case 163: score = ; break; //Core i5 1155G7
                        case 164: score = ; break; //Core i5 11500
                        case 165: score = ; break; //Core i5 11500T
                        case 166: score = ; break; //Core i5 11500H
                        case 167: score = ; break; //Core i5 11500HE
                        case 168: score = ; break; //Core i5 1145G7 w/IPU
                        case 169: score = ; break; //Core i5 1145G7E w/IPU
                        case 170: score = ; break; //Core i5 1145G7E
                        case 171: score = ; break; //Core i5 11400
                        case 172: score = ; break; //Core i5 11400F
                        case 173: score = ; break; //Core i5 11400T
                        case 174: score = ; break; // Core i5 11400H
                        case 175: score = ; break; // Core i5 1140G7
                        case 176: score = ; break; // Core i5 1135G7
                        case 177: score = ; break; // Core i5 11320H w/IPU
                        case 178: score = ; break; //Core i5 11300H w/IPU
                        case 179: score = ; break; //Core i5 1130G7 w/IPU
                        case 180: score = ; break; //Core i5 11260H
                        case 181: score = ; break; //Core i5 10600
                        case 182: score = ; break; //Core i5 10600K
                        case 183: score = ; break; //Core i5 10600KF
                        case 184: score = ; break; //Core i5 10600T
                        case 185: score = ; break; //Core i5 10505
                        case 186: score = ; break; //Core i5 10500
                        case 187: score = ; break; //Core i5 10500E
                        case 188: score = ; break; //Core i5 10500T
                        case 189: score = ; break; //Core i5 10500TE
                        case 190: score = ; break; //Core i5 10500H
                        case 191: score = ; break; //Core i5 10400
                        case 192: score = ; break; //Core i5 10400F
                        case 193: score = ; break; //Core i5 10400T
                        case 194: score = ; break; //Core i5 10210U
                        case 195: score = ; break; //Core i5 9600
                        case 196: score = ; break; //Core i5 9600K
                        case 197: score = ; break; //Core i5 9600KF
                        case 198: score = ; break; //Core i5 9600T
                        case 199: score = ; break; //Core i5 9500
                        case 200: score = ; break; //Core i5 9500E
                        case 201: score = ; break; //Core i5 9500F
                        case 202: score = ; break; //Core i5 9500T
                        case 203: score = ; break; //Core i5 9400
                        case 204: score = ; break; //Core i5 9400F
                        case 205: score = ; break; //Core i5 9400T
                        case 206: score = ; break; //Core i5 8600K
                        case 207: score = ; break; //Core i5 8500
                        case 208: score = ; break; //Core i5 8500B
                        case 209: score = ; break; //Core i5 8400
                        case 210: score = ; break; //Core i5 8400H
                        case 211: score = ; break; //Core i5 8400B
                        case 212: score = ; break; //Core i5 8365U
                        case 213: score = ; break; //Core i5 8350U
                        case 214: score = ; break; //Core i5 8310Y
                        case 215: score = ; break; //Core i5 8300H
                        case 216: score = ; break; //Core i5 8279U
                        case 217: score = ; break; //Core i5 8269U
                        case 218: score = ; break; //Core i5 8265U
                        case 219: score = ; break; //Core i5 8260U
                        case 220: score = ; break; //Core i5 8259U
                        case 221: score = ; break; //Core i5 8257U
                        case 222: score = ; break; //Core i5 8250U
                        case 223: score = ; break; //Core i5 8210Y
                        case 224: score = ; break; //Core i5 8200Y
                        case 225: score = ; break; //Core i5 7640X
                        case 226: score = ; break; //Core i5 7600
                        case 227: score = ; break; //Core i5 7600K
                        case 228: score = ; break; //Core i5 7600T
                        case 229: score = ; break; //Core i5 7500
                        case 230: score = ; break; //Core i5 7500T
                        case 231: score = ; break; //Core i5 7440HQ
                        case 232: score = ; break; //Core i5 7400
                        case 233: score = ; break; //Core i5 7400T
                        case 234: score = ; break; //Core i5 7360U
                        case 235: score = ; break; //Core i5 7300HQ
                        case 236: score = ; break; //Core i5 7300U
                        case 237: score = ; break; //Core i5 7287U
                        case 238: score = ; break; //Core i5 7267U
                        case 239: score = ; break; //Core i5 7260U
                        case 240: score = ; break; //Core i5 7200U
                        case 241: score = ; break; //Core i5 7Y57
                        case 242: score = ; break; //Core i5 7Y54
                        case 243: score = ; break; //Core i5 1250P
                        case 244: score = ; break; //Core i5 1245U
                        case 245: score = ; break; //Core i5 1240P
                        case 246: score = ; break; //Core i5 1240U
                        case 247: score = ; break; //Core i5 1235U
                        case 248: score = ; break; //Core i5 1230U
                        case 249: score = ; break; //Core i3 13100
                        case 250: score = ; break; //Core i3 13100F
                        case 251: score = ; break; //Core i3 13100T
                        case 252: score = ; break; //Core i3 12300
                        case 253: score = ; break; //Core i3 12300T
                        case 254: score = ; break; //Core i3 12100
                        case 255: score = ; break; //Core i3 12100F
                        case 256: score = ; break; //Core i3 12100T
                        case 257: score = ; break; //Core i3 1125G4
                        case 258: score = ; break; //Core i3 1125G4 w/IPU
                        case 259: score = ; break; //Core i3 1120G4 w/IPU
                        case 260: score = ; break; //Core i3 1115GRE
                        case 261: score = ; break; //Core i3 1115G4E
                        case 262: score = ; break; //Core i3 1115G4
                        case 263: score = ; break; //Core i3 1115G4 w/IPU
                        case 264: score = ; break; //Core i3 1110G4 w/IPU
                        case 265: score = ; break; //Core i3 1110HE
                        case 266: score = ; break; //Core i3 10320
                        case 267: score = ; break; //Core i3 10300
                        case 268: score = ; break; //Core i3 10300T
                        case 269: score = ; break; //Core i3 10110Y
                        case 270: score = ; break; //Core i3 10100
                        case 271: score = ; break; //Core i3 10100F
                        case 272: score = ; break; //Core i3 10100T
                        case 273: score = ; break; //Core i3 10100E
                        case 274: score = ; break; //Core i3 10100TE
                        case 275: score = ; break; //Core i3 9350K
                        case 276: score = ; break; //Core i3 9350KF
                        case 277: score = ; break; //Core i3 9320
                        case 278: score = ; break; //Core i3 9300
                        case 279: score = ; break; //Core i3 9300T
                        case 280: score = ; break; //Core i3 9100
                        case 281: score = ; break; //Core i3 9100F
                        case 282: score = ; break; //Core i3 9100T
                        case 283: score = ; break; //Core i3 9100E
                        case 284: score = ; break; //Core i3 9100TE
                        case 285: score = ; break; //Core i3 8350K
                        case 286: score = ; break; //Core i3 8145U
                        case 287: score = ; break; //Core i3 8140U
                        case 288: score = ; break; //Core i3 8130U
                        case 289: score = ; break; //Core i3 8109U
                        case 290: score = ; break; //Core i3 8100
                        case 291: score = ; break; //Core i3 8100H
                        case 292: score = ; break; //Core i3 8100B
                        case 293: score = ; break; //Core i3 7350K
                        case 294: score = ; break; //Core i3 7320
                        case 295: score = ; break; //Core i3 7300
                        case 296: score = ; break; //Core i3 7300T
                        case 297: score = ; break; //Core i3 7130U
                        case 298: score = ; break; //Core i3 7167U
                        case 299: score = ; break; //Core i3 7101E
                        case 300: score = ; break; //Core i3 7101TE
                        case 301: score = ; break; //Core i3 7100T
                        case 302: score = ; break; //Core i3 7100
                        case 303: score = ; break; //Core i3 7100H
                        case 304: score = ; break; //Core i3 7100U
                        case 305: score = ; break; //Core i3 1220P
                        case 306: score = ; break; //Core i3 1215U
                        case 307: score = ; break; //Core i3 1210U
                        case 309: score = ; break; //Xeon W-11965MRE
                        case 310: score = ; break; //Xeon W-11955M
                        case 311: score = ; break; //Xeon W-11865MLE
                        case 312: score = ; break; //Xeon W-11855M
                        case 313: score = ; break; //Xeon W-11555MRE
                        case 314: score = ; break; //Xeon W-11555MLE
                        case 315: score = ; break; //Xeon W-11155MRE
                        case 316: score = ; break; //Xeon W-11155MLE
                    }
                }
            }

            else if (multiThread.IsChecked == true) //MULTITHREAD SELECTED
            {
                if (AMDcheck == false && Intelcheck == true) //AMD MULTI THREAD CPU
                {
                    switch (Amd.SelectedIndex)
                    {
                        case 1: score = 32529; break; //Ryzen ThreadRipper PRO 5995WX
                        case 2: score = 25121; break; //Ryzen Threadripper PRO 5975WX
                        case 3: score = 18976; break; //Ryzen Threadripper PRO 5965WX
                        case 4: score = 12767; break; //Ryzen Threadripper PRO 5955WX
                        case 5: score = 9680; break; //Ryzen Threadripper PRO 5945WX
                        case 6: score = 28096; break; //Ryzen Threadripper PRO 3995WX
                        case 7: score = 27670; break; //Ryzen Threadripper 3990X
                        case 8: score = 20924; break; //Ryzen Threadripper PRO 3975WX
                        case 9: score = 21604; break; //Ryzen Threadripper 3970X
                        case 10: score = 17151; break;//Ryzen Threadripper 3960X
                        case 11: score = 9936; break; //Ryzen Threadripper PRO 3955WX
                        case 12: score = 8450; break; //Ryzen Threadripper PRO 3945WX
                        case 13: score = 18588; break; //Ryzen Threadripper 2990WX
                        case 14: score = 14022; break; //Ryzen Threadripper 2970WX
                        case 15: score = 9618; break; //Ryzen Threadripper 2950X
                        case 16: score = 7437; break; //Ryzen Threadripper 2920X
                        case 17: score = 9676; break; //Ryzen Threadripper 1950X
                        case 18: score = 7534; break; //Ryzen Threadripper 1920X
                        case 19: score = 4695; break; //Ryzen Threadripper 1900X
                        case 20: score = ; break; //Ryzen Z1
                        case 21: score = 5866; break; //Ryzen Z1 Extreme
                        case 22: score = 14910; break; //Ryzen 9 7950X3D
                        case 23: score = 15824; break; //Ryzen 9 7950X
                        case 24: score = 10484; break; //Ryzen 9 PRO 7945
                        case 25: score = 13060; break; //Ryzen 9 7945HX
                        case 26: score = ; break; //Ryzen 9 7940HS
                        case 27: score = 6838; break; //Ryzen 9 7940H
                        case 28: score = 11477; break; //Ryzen 9 7900
                        case 29: score = 11922; break; //Ryzen 9 7900X
                        case 30: score = 11572; break; //Ryzen 9 7900X3D
                        case 31: score = 10430; break; //Ryzen 9 7845HX
                        case 32: score = ; break; //Ryzen 9 6980HX
                        case 33: score = ; break; //Ryzen 9 6980HS
                        case 34: score = 4864; break; //Ryzen 9 6900HX
                        case 35: score = 5895; break; //Ryzen 9 6900HS
                        case 36: score = 6094; break; //Ryzen 9 5980HX
                        case 37: score = 5713; break; //Ryzen 9 5980HS
                        case 38: score = 12366; break; //Ryzen 9 5950X
                        case 39: score = 9110; break; //Ryzen 9 5900X
                        case 40: score = ; break; //Ryzen 9 5900
                        case 41: score = 6107; break; //Ryzen 9 5900HX
                        case 42: score = 5650; break; //Ryzen 9 5900HS
                        case 43: score = 5253; break; //Ryzen 9 4900H
                        case 44: score = 5540; break; //Ryzen 9 4900HS
                        case 45: score = 11063; break; //Ryzen 9 3950X
                        case 46: score = 8240; break; //Ryzen 9 3900XT
                        case 47: score = 9009; break; //Ryzen 9 3900X
                        case 48: score = 7979; break; //Ryzen 9 3900
                        case 49: score = 6971; break; //Ryzen 7 7840HS
                        case 50: score = 3825; break; //Ryzen 7 7840H
                        case 51: score = 5661; break; //Ryzen 7 7840U
                        case 52: score = 6856; break; //Ryzen 7 7800X3D
                        case 53: score = ; break; //Ryzen 7 PRO 7745
                        case 54: score = 7345; break; //Ryzen 7 7745HX
                        case 55: score = ; break; //Ryzen 7 7736U
                        case 56: score = 5870; break; //Ryzen 7 7735U
                        case 57: score = 5633; break; //Ryzen 7 7735HS
                        case 58: score = ; break; //Ryzen 7 PRO 7730U
                        case 59: score = 3388; break; //Ryzen 7 7730U
                        case 60: score = 7597; break; //Ryzen 7 7700
                        case 61: score = 7938; break; //Ryzen 7 7700X
                        case 62: score = ; break; //Ryzen 7045 
                        case 63: score = ; break; //Ryzen 7040 
                        case 64: score = ; break; //Ryzen 7035 
                        case 65: score = ; break; //Ryzen 7030 
                        case 66: score = ; break; //Ryzen 7020
                        case 67: score = 6102; break; //Ryzen 7 6800H
                        case 68: score = 5893; break; //Ryzen 7 6800HS
                        case 69: score = 5240; break; //Ryzen 7 6800U
                        case 70: score = 5083; break; //Ryzen 7 5825U
                        case 71: score = 6467; break; //Ryzen 7 5800
                        case 72: score = 6593; break; //Ryzen 7 5800X
                        case 73: score = 6360; break; //Ryzen 7 5800X3D
                        case 74: score = 3280; break; //Ryzen 7 5800U
                        case 75: score = 5776; break; //Ryzen 7 5800H
                        case 76: score = 5643; break; //Ryzen 7 5800HS
                        case 77: score = ; break; //Ryzen 7 5700
                        case 78: score = 6447; break; //Ryzen 7 5700X
                        case 79: score = 6534; break; //Ryzen 7 5700G
                        case 80: score = 5399; break; //Ryzen 7 5700GE
                        case 81: score = 4802; break; //Ryzen 7 5700U
                        case 82: score = 4977; break; //Ryzen 7 4980U
                        case 83: score = ; break; //Ryzen 7 4800H
                        case 84: score = 4946; break; //Ryzen 7 4800HS
                        case 85: score = 5038; break; //Ryzen 7 4800U
                        case 86: score = 5808; break; //Ryzen 7 4700G
                        case 87: score = 5145; break; //Ryzen 7 4700GE
                        case 88: score = 2422; break; //Ryzen 7 4700U
                        case 89: score = ; break; //Ryzen 7 4600GE
                        case 90: score = 5991; break; //Ryzen 7 3800X
                        case 91: score = 6188; break; //Ryzen 7 3800XT
                        case 92: score = ; break; //Ryzen 7 3780U
                        case 93: score = 2104; break; //Ryzen 7 3750H
                        case 94: score = ; break; //Ryzen 7 3700C
                        case 95: score = 1456; break; //Ryzen 7 3700U
                        case 96: score = 5445; break; //Ryzen 7 3700X
                        case 97: score = ; break; //Ryzen 7 2800H
                        case 98: score = 4185; break; //Ryzen 7 2700
                        case 99: score = 5414; break; //Ryzen 7 2700X
                        case 100: score = 5030; break; //Ryzen 7 2700E
                        case 101: score = 1929; break; //Ryzen 7 2700U
                        case 102: score = 4248; break; //Ryzen 7 1800X
                        case 103: score = 4797; break; //Ryzen 7 1700
                        case 104: score = 4370; break; //Ryzen 7 1700X
                        case 105: score = 3961; break; //Ryzen 7 PRO 1700
                        case 106: score = 4370; break; //Ryzen 7 PRO 1700X
                        case 107: score = ; break; //Ryzen 5 PRO 7645
                        case 108: score = ; break; //Ryzen 5 7645HX
                        case 109: score = ; break; //Ryzen 5 7640H
                        case 110: score = 5347; break; //Ryzen 5 7640HS
                        case 111: score = ; break; //Ryzen 5 7640U
                        case 112: score = 6215; break; //Ryzen 5 7600
                        case 113: score = 6276; break; //Ryzen 5 7600X
                        case 114: score = ; break; //Ryzen 5 7540U
                        case 115: score = 4643; break; //Ryzen 5 7535HS
                        case 116: score = ; break; //Ryzen 5 7535U
                        case 117: score = ; break; //Ryzen 5 PRO 7530U
                        case 118: score = 2036; break; //Ryzen 5 7530U
                        case 119: score = 2167; break; //Ryzen 5 7520U
                        case 120: score = 4641; break; //Ryzen 5 6600H
                        case 121: score = 3577; break; //Ryzen 5 6600HS
                        case 122: score = 4067; break; //Ryzen 5 6600U
                        case 123: score = 4018; break; //Ryzen 5 5625U
                        case 124: score = 4780; break; //Ryzen 5 5600
                        case 125: score = 4814; break; //Ryzen 5 5600X
                        case 126: score = 4537; break; //Ryzen 5 5600G
                        case 127: score = 4496; break; //Ryzen 5 5600GE
                        case 128: score = 4228; break; //Ryzen 5 5600H
                        case 129: score = ; break; //Ryzen 5 5600HS
                        case 130: score = 4101; break; //Ryzen 5 5600U
                        case 131: score = 2703; break; //Ryzen 5 5560U
                        case 132: score = 4831; break; //Ryzen 5 5500
                        case 133: score = 3489; break; //Ryzen 5 5500U
                        case 134: score = ; break; //Ryzen 5 4680U
                        case 135: score = 3878; break; //Ryzen 5 4600H
                        case 136: score = 2433; break; //Ryzen 5 4600HS
                        case 137: score = 3906; break; //Ryzen 5 4600U
                        case 138: score = 4241; break; //Ryzen 5 4600G
                        case 139: score = 3617; break; //Ryzen 5 4500
                        case 140: score = 2858; break; //Ryzen 5 4500U
                        case 141: score = 4322; break; //Ryzen 5 3600
                        case 142: score = 4239; break; //Ryzen 5 3600X
                        case 143: score = 4730; break; //Ryzen 5 3600XT
                        case 144: score = ; break; //Ryzen 5 3580H
                        case 145: score = 1449; break; //Ryzen 5 3550H
                        case 146: score = 2769; break; //Ryzen 5 3500
                        case 147: score = 2752; break; //Ryzen 5 3500X
                        case 148: score = ; break; //Ryzen 5 3500C
                        case 149: score = 2002; break; //Ryzen 5 3500U
                        case 150: score = 1813; break; //Ryzen 5 3450U
                        case 151: score = 2512; break; //Ryzen 5 3400G
                        case 152: score = ; break; //Ryzen 5 Pro 3400G
                        case 153: score = 2269; break; //Ryzen 5 Pro 3400GE
                        case 154: score = 2372; break; //Ryzen 5 3350G
                        case 155: score = ; break; //Ryzen 5 3350GE
                        case 156: score = 3829; break; //Ryzen 5 2600
                        case 157: score = 3716; break; //Ryzen 5 2600X
                        case 158: score = 3725; break; //Ryzen 5 2600E
                        case 159: score = ; break; //Ryzen 5 2600H
                        case 160: score = 2286; break; //Ryzen 5 2500X
                        case 161: score = 1879; break; //Ryzen 5 2500U
                        case 162: score = 2236; break; //Ryzen 5 2400G
                        case 163: score = ; break; //Ryzen 5 2400GE
                        case 164: score = 3204; break; //Ryzen 5 1600
                        case 165: score = 3487; break; //Ryzen 5 1600X
                        case 166: score = ; break; //Ryzen 5 PRO 1600
                        case 167: score = 2454; break; //Ryzen 5 PRO 1500
                        case 168: score = 2600; break; //Ryzen 5 1500X
                        case 169: score = 2332; break; //Ryzen 5 1400
                        case 170: score = ; break; //Ryzen 3 7440U
                        case 171: score = ; break; //Ryzen 3 7335U
                        case 172: score = ; break; //Ryzen 3 7330U
                        case 173: score = ; break; //Ryzen 3 PRO 7330U
                        case 174: score = 1260; break; //Ryzen 3 7320U
                        case 175: score = 2654; break; //Ryzen 3 5425U
                        case 176: score = 2675; break; //Ryzen 3 5400U
                        case 177: score = 2322; break; //Ryzen 3 5300U
                        case 178: score = 3047; break; //Ryzen 3 5300G
                        case 179: score = ; break; //Ryzen 3 5300GE
                        case 180: score = ; break; //Ryzen 3 5125C
                        case 181: score = 2731; break; //Ryzen 3 4300G
                        case 182: score = 2335; break; //Ryzen 3 4300GE
                        case 183: score = 1826; break; //Ryzen 3 4300U
                        case 184: score = 2753; break; //Ryzen 3 4100
                        case 185: score = 1402; break; //Ryzen 3 3350U
                        case 186: score = 2669; break; //Ryzen 3 3300X
                        case 187: score = 1422; break; //Ryzen 3 3300U
                        case 188: score = 1043; break; //Ryzen 3 3250U
                        case 189: score = ; break; //Ryzen 3 3250C
                        case 190: score = 1738; break; //Ryzen 3 3200G
                        case 191: score = ; break; //Ryzen 3 3200GE
                        case 192: score = 1733; break; //Ryzen 3 Pro 3200GE
                        case 193: score = ; break; //Ryzen 3 Pro 3200G
                        case 194: score = 411; break; //Ryzen 3 3200U
                        case 195: score = 2579; break; //Ryzen 3 3100
                        case 196: score = 567; break; //Ryzen 3 2300U
                        case 197: score = 1931; break; //Ryzen 3 2300X
                        case 198: score = 1016; break; //Ryzen 3 2200U
                        case 199: score = 1804; break; //Ryzen 3 2200G
                        case 200: score = 1838; break; //Ryzen 3 2200GE
                        case 201: score = 949; break; //Ryzen 3 PRO 2100GE
                        case 202: score = 1603; break; //Ryzen 3 1300X
                        case 203: score = 1604; break; //Ryzen 3 PRO 1300
                        case 204: score = 1758; break; //Ryzen 3 1200
                        case 205: score = ; break; //Ryzen 3 PRO 1200
                        case 206: score = ; break; //Ryzen 1200 (AF)
                        case 208: score = 68803; break; //EPYC 9754
                        case 209: score = ; break; //EPYC 9754S
                        case 210: score = ; break; //EPYC 9734
                        case 211: score = ; break; //EPYC 9684X
                        case 212: score = 95002; break; //EPYC 9654
                        case 213: score = ; break; //EPYC 9654P
                        case 214: score = ; break; //EPYC 9634
                        case 215: score = ; break; //EPYC 9554
                        case 216: score = ; break; //EPYC 9554P
                        case 217: score = ; break; //EPYC 9534
                        case 218: score = ; break; //EPYC 9474F
                        case 219: score = ; break; //EPYC 9454
                        case 220: score = ; break; //EPYC 9454P
                        case 221: score = ; break; //EPYC 9384X
                        case 222: score = ; break; //EPYC 9374F
                        case 223: score = ; break; //EPYC 9354
                        case 224: score = ; break; //EPYC 9354P
                        case 225: score = ; break; //EPYC 9334
                        case 226: score = ; break; //EPYC 9274F
                        case 227: score = ; break; //EPYC 9254
                        case 228: score = ; break; //EPYC 9224
                        case 229: score = ; break; //EPYC 9184X
                        case 230: score = ; break; //EPYC 9174F
                        case 231: score = ; break; //EPYC 9124
                        case 232: score = ; break; //EPYC 7773X
                        case 233: score = 65823; break; //EPYC 7763
                        case 234: score = 23149; break; //EPYC 7742
                        case 235: score = 25426; break; //EPYC 7713
                        case 236: score = ; break; //EPYC 7713P
                        case 237: score = 39890; break; //EPYC 7702
                        case 238: score = 26374; break; //EPYC 7702P
                        case 239: score = ; break; //EPYC 7663
                        case 240: score = ; break; //EPYC 7662
                        case 241: score = ; break; //EPYC 7643
                        case 242: score = ; break; //EPYC 7642
                        case 243: score = ; break; //EPYC 7624
                        case 244: score = 9465; break; //EPYC 7601
                        case 245: score = ; break; //EPYC 7573X
                        case 246: score = 17236; break; //EPYC 7571
                        case 247: score = ; break; //EPYC 7552
                        case 248: score = ; break; //EPYC 7551
                        case 249: score = 12670; break; //EPYC 7551P
                        case 250: score = 26432; break; //EPYC 7542 more co toje
                        case 251: score = 19697; break; //EPYC 7543
                        case 252: score = ; break; //EPYC 7543P
                        case 253: score = 24190; break; //EPYC 7532
                        case 254: score = ; break; //EPYC 7513
                        case 255: score = ; break; //EPYC 7502
                        case 256: score = 14457; break; //EPYC 7502P
                        case 257: score = 26844; break; //EPYC 7501
                        case 258: score = ; break; //EPYC 7473X
                        case 259: score = ; break; //EPYC 7453
                        case 260: score = ; break; //EPYC 7452
                        case 261: score = ; break; //EPYC 7443
                        case 262: score = ; break; //EPYC 7443P
                        case 263: score = ; break; //EPYC 7413
                        case 264: score = 12674; break; //EPYC 7402
                        case 265: score = ; break; //EPYC 7402P
                        case 266: score = 10024; break; //EPYC 7401
                        case 267: score = ; break; //EPYC 7401P
                        case 268: score = ; break; //EPYC 7373X
                        case 269: score = ; break; //EPYC 7371
                        case 270: score = ; break; //EPYC 7352
                        case 271: score = 7273; break; //EPYC 7351
                        case 272: score = ; break; //EPYC 7351P
                        case 273: score = ; break; //EPYC 7343
                        case 274: score = ; break; //EPYC 7313
                        case 275: score = ; break; //EPYC 7313P
                        case 276: score = 8874; break; //EPYC 7302
                        case 277: score = 8948; break; //EPYC 7302P
                        case 278: score = 13299; break; //EPYC 7301
                        case 279: score = ; break; //EPYC 7282
                        case 280: score = 6740; break; //EPYC 7281
                        case 281: score = 9031; break; //EPYC 7272
                        case 282: score = 3051; break; //EPYC 7262
                        case 283: score = ; break; //EPYC 7261
                        case 284: score = 4340; break; //EPYC 7252
                        case 285: score = 3554; break; //EPYC 7251
                        case 286: score = ; break; //EPYC 7232P
                        case 287: score = ; break; //EPYC 7F72
                        case 288: score = ; break; //EPYC 75F3
                        case 289: score = ; break; //EPYC 74F3
                        case 290: score = ; break; //EPYC 73F3
                        case 291: score = 5951; break; //EPYC 72F3
                        case 292: score = 19929; break; //EPYC 7F52
                        case 293: score = ; break; //EPYC 7F32
                        case 294: score = ; break; //EPYC 3H12
                        case 295: score = ; break; //EPYC 3451
                        case 296: score = ; break; //EPYC 3401
                        case 297: score = ; break; //EPYC 3351
                        case 298: score = ; break; //EPYC 3301
                        case 299: score = ; break; //EPYC 3255
                        case 300: score = ; break; //EPYC 3251
                        case 301: score = ; break; //EPYC 3201 
                        case 302: score = ; break; //EPYC 3151
                        case 303: score = ; break; //EPYC 3101
                    }
                }
                else if (AMDcheck == true && Intelcheck == false) //INTEL MULTI THREAD CPU
                {
                    switch (Intel.SelectedIndex)
                    {
                        case 1: score = ; break; //Core i9 13900
                        case 2: score = ; break; //Core i9 1300K
                        case 3: score = ; break; //Core i9 1300KS
                        case 4: score = ; break; //Core i9 13900KF
                        case 5: score = ; break; //Core i9 13900F
                        case 6: score = ; break; //Core i9 13900T
                        case 7: score = ; break; //Core i9 12950HX
                        case 8: score = ; break; //Core i9 12900
                        case 9: score = ; break; //Core i9 12900K
                        case 10: score = ; break; //Core i9 12900KS
                        case 11: score = ; break; //Core i9 12900KF
                        case 12: score = ; break; //Core i9 12900F
                        case 13: score = ; break; //Core i9 12900T
                        case 14: score = ; break; //Core i9 12900H
                        case 15: score = ; break; //Core i9 12900HX
                        case 16: score = ; break; //Core i9 12900HK
                        case 17: score = ; break; //Core i9 11980HK
                        case 18: score = ; break; //Core i9 11950H
                        case 19: score = ; break; //Core i9 11900
                        case 20: score = ; break; //Core i9 11900K
                        case 21: score = ; break; //Core i9 11900KF
                        case 22: score = ; break; //Core i9 11900F
                        case 23: score = ; break; //Core i9 11900T
                        case 24: score = ; break; //Core i9 11900H
                        case 25: score = ; break; //Core i9 10910
                        case 26: score = ; break; //Core i9 10900
                        case 27: score = ; break; //Core i9 10900K
                        case 28: score = ; break; //Core i9 10900KF
                        case 29: score = ; break; //Core i9 10900F
                        case 30: score = ; break; //Core i9 10900E
                        case 31: score = ; break; //Core i9 10900T
                        case 32: score = ; break; //Core i9 10850K
                        case 33: score = ; break; //Core i9 9900
                        case 34: score = ; break; //Core i9 9900K
                        case 35: score = ; break; //Core i9 9900KS
                        case 36: score = ; break; //Core i9 9900T
                        case 37: score = ; break; //Core i9 8950HK
                        case 38: score = ; break; //Core i9 7980XE
                        case 39: score = ; break; //Core i9 7960X
                        case 40: score = ; break; //Core i9 7940X
                        case 41: score = ; break; //Core i9 7920X
                        case 42: score = ; break; //Core i9 7900X
                        case 43: score = ; break; //Core i7 13700
                        case 44: score = ; break; //Core i7 13700K
                        case 45: score = ; break; //Core i7 13700KF
                        case 46: score = ; break; //Core i7 13700F
                        case 47: score = ; break; //Core i7 13700T
                        case 48: score = ; break; //Core i7 12850HX
                        case 49: score = ; break; //Core i7 12800H
                        case 50: score = ; break; //Core i7 12800HX
                        case 51: score = ; break; //Core i7 12700
                        case 52: score = ; break; //Core i7 12700K
                        case 53: score = ; break; //Core i7 12700KF
                        case 54: score = ; break; //Core i7 12700F
                        case 55: score = ; break; //Core i7 12700T
                        case 56: score = ; break; //Core i7 12700H
                        case 57: score = ; break; //Core i7 12650H
                        case 58: score = ; break; //Core i7 12650HX
                        case 59: score = ; break; //Core i7 1195G7
                        case 60: score = ; break; //Core i7 1195G7 w/IPU
                        case 61: score = ; break; //Core i7 1185GRE
                        case 62: score = ; break; //Core i7 1185G7E
                        case 63: score = ; break; //Core i7 1185G7 w/IPU
                        case 64: score = ; break; //Core i7 11850H
                        case 65: score = ; break; //Core i7 11850HE
                        case 66: score = ; break; //Core i7 11800H
                        case 67: score = ; break; //Core i7 1180G7 w/IPU
                        case 68: score = ; break; //Core i7 11700
                        case 69: score = ; break; //Core i7 11700K
                        case 70: score = ; break; //Core i7 11700KF
                        case 71: score = ; break; //Core i7 11700F
                        case 72: score = ; break; //Core i7 11700T
                        case 73: score = ; break; //Core i7 1165G7
                        case 74: score = ; break; //Core i7 1165G7 w/IPU
                        case 75: score = ; break; //Core i7 11600H
                        case 76: score = ; break; //Core i7 1160G7 w/IPU
                        case 77: score = ; break; //Core i7 11390H
                        case 78: score = ; break; //Core i7 11375H
                        case 79: score = ; break; //Core i7 11375H w/IPU
                        case 80: score = ; break; //Core i7 11370H w/IPU
                        case 81: score = ; break; //Core i7 10750H
                        case 82: score = ; break; //Core i7 10710U
                        case 83: score = ; break; //Core i7 10700
                        case 84: score = ; break; //Core i7 10700K
                        case 85: score = ; break; //Core i7 10700KF
                        case 86: score = ; break; //Core i7 10700F
                        case 87: score = ; break; //Core i7 10700T
                        case 88: score = ; break; //Core i7 10700E
                        case 89: score = ; break; //Core i7 10700TE
                        case 90: score = ; break; //Core i7 1065G7
                        case 91: score = ; break; //Core i7 10610U
                        case 92: score = ; break; //Core i7 1060G7
                        case 93: score = ; break; //Core i7 10510U
                        case 94: score = ; break; //Core i7 10510Y
                        case 95: score = ; break; //Core i7 9700
                        case 96: score = ; break; //Core i7 9700K
                        case 97: score = ; break; //Core i7 9700T
                        case 98: score = ; break; //Core i7 9700TE
                        case 99: score = ; break; //Core i7 8850H
                        case 100: score = ; break; //Core i7 8750H
                        case 101: score = ; break; //Core i7 8700
                        case 102: score = ; break; //Core i7 8700K
                        case 103: score = ; break; //Core i7 8700B
                        case 104: score = ; break; //Core i7 8569U
                        case 105: score = ; break; //Core i7 8665U
                        case 106: score = ; break; //Core i7 8650U
                        case 107: score = ; break; //Core i7 8565U
                        case 108: score = ; break; //Core i7 8559U
                        case 109: score = ; break; //Core i7 8557U
                        case 110: score = ; break; //Core i7 8550U
                        case 111: score = ; break; //Core i7 8500Y
                        case 112: score = ; break; //Core i7 8086K
                        case 113: score = ; break; //Core i7 7920HQ
                        case 114: score = ; break; //Core i7 7900U
                        case 115: score = ; break; //Core i7 7820HQ
                        case 116: score = ; break; //Core i7 7820HK
                        case 117: score = ; break; //Core i7 7820X
                        case 118: score = ; break; //Core i7 7800X
                        case 119: score = ; break; //Core i7 7740X
                        case 120: score = ; break; //Core i7 7700
                        case 121: score = ; break; //Core i7 7700K
                        case 122: score = ; break; //Core i7 7700T
                        case 123: score = ; break; //Core i7 7700HQ
                        case 124: score = ; break; //Core i7 7660U
                        case 125: score = ; break; //Core i7 7560U
                        case 126: score = ; break; //Core i7 7500U
                        case 127: score = ; break; //Core i7 7Y75
                        case 128: score = ; break; //Core i7 1280P
                        case 129: score = ; break; //Core i7 1270P
                        case 130: score = ; break; //Core i7 1265U
                        case 131: score = ; break; //Core i7 1260P
                        case 132: score = ; break; //Core i7 1260U
                        case 133: score = ; break; //Core i7 1255U
                        case 134: score = ; break; //Core i7 1250U
                        case 135: score = ; break; //Core i5 13600
                        case 136: score = ; break; //Core i5 13600K
                        case 137: score = ; break; //Core i5 13600KF
                        case 138: score = ; break; //Core i5 13600T
                        case 139: score = ; break; //Core i5 13500
                        case 140: score = ; break; //Core i5 13500T
                        case 141: score = ; break; //Core i5 13420H
                        case 142: score = ; break; //Core i5 13400
                        case 143: score = ; break; //Core i5 13400F
                        case 144: score = ; break; //Core i5 13400T
                        case 145: score = ; break; //Core i5 12600
                        case 146: score = ; break; //Core i5 12600K
                        case 147: score = ; break; //Core i5 12600KF
                        case 148: score = ; break; //Core i5 12600T
                        case 149: score = ; break; //Core i5 12600HX
                        case 150: score = ; break; //Core i5 12600H
                        case 151: score = ; break; //Core i5 12500
                        case 152: score = ; break; //Core i5 12500T
                        case 153: score = ; break; //Core i5 12500H
                        case 154: score = ; break; //Core i5 12450H
                        case 155: score = ; break; //Core i5 12450HX
                        case 156: score = ; break; //Core i5 12400
                        case 157: score = ; break; //Core i5 12400F
                        case 158: score = ; break; //Core i5 12400T
                        case 159: score = ; break; //Core i5 11600
                        case 160: score = ; break; //Core i5 11600K
                        case 161: score = ; break; //Core i5 11600KF
                        case 162: score = ; break; //Core i5 11600T
                        case 163: score = ; break; //Core i5 1155G7
                        case 164: score = ; break; //Core i5 11500
                        case 165: score = ; break; //Core i5 11500T
                        case 166: score = ; break; //Core i5 11500H
                        case 167: score = ; break; //Core i5 11500HE
                        case 168: score = ; break; //Core i5 1145G7 w/IPU
                        case 169: score = ; break; //Core i5 1145G7E w/IPU
                        case 170: score = ; break; //Core i5 1145G7E
                        case 171: score = ; break; //Core i5 11400
                        case 172: score = ; break; //Core i5 11400F
                        case 173: score = ; break; //Core i5 11400T
                        case 174: score = ; break; // Core i5 11400H
                        case 175: score = ; break; // Core i5 1140G7
                        case 176: score = ; break; // Core i5 1135G7
                        case 177: score = ; break; // Core i5 11320H w/IPU
                        case 178: score = ; break; //Core i5 11300H w/IPU
                        case 179: score = ; break; //Core i5 1130G7 w/IPU
                        case 180: score = ; break; //Core i5 11260H
                        case 181: score = ; break; //Core i5 10600
                        case 182: score = ; break; //Core i5 10600K
                        case 183: score = ; break; //Core i5 10600KF
                        case 184: score = ; break; //Core i5 10600T
                        case 185: score = ; break; //Core i5 10505
                        case 186: score = ; break; //Core i5 10500
                        case 187: score = ; break; //Core i5 10500E
                        case 188: score = ; break; //Core i5 10500T
                        case 189: score = ; break; //Core i5 10500TE
                        case 190: score = ; break; //Core i5 10500H
                        case 191: score = ; break; //Core i5 10400
                        case 192: score = ; break; //Core i5 10400F
                        case 193: score = ; break; //Core i5 10400T
                        case 194: score = ; break; //Core i5 10210U
                        case 195: score = ; break; //Core i5 9600
                        case 196: score = ; break; //Core i5 9600K
                        case 197: score = ; break; //Core i5 9600KF
                        case 198: score = ; break; //Core i5 9600T
                        case 199: score = ; break; //Core i5 9500
                        case 200: score = ; break; //Core i5 9500E
                        case 201: score = ; break; //Core i5 9500F
                        case 202: score = ; break; //Core i5 9500T
                        case 203: score = ; break; //Core i5 9400
                        case 204: score = ; break; //Core i5 9400F
                        case 205: score = ; break; //Core i5 9400T
                        case 206: score = ; break; //Core i5 8600K
                        case 207: score = ; break; //Core i5 8500
                        case 208: score = ; break; //Core i5 8500B
                        case 209: score = ; break; //Core i5 8400
                        case 210: score = ; break; //Core i5 8400H
                        case 211: score = ; break; //Core i5 8400B
                        case 212: score = ; break; //Core i5 8365U
                        case 213: score = ; break; //Core i5 8350U
                        case 214: score = ; break; //Core i5 8310Y
                        case 215: score = ; break; //Core i5 8300H
                        case 216: score = ; break; //Core i5 8279U
                        case 217: score = ; break; //Core i5 8269U
                        case 218: score = ; break; //Core i5 8265U
                        case 219: score = ; break; //Core i5 8260U
                        case 220: score = ; break; //Core i5 8259U
                        case 221: score = ; break; //Core i5 8257U
                        case 222: score = ; break; //Core i5 8250U
                        case 223: score = ; break; //Core i5 8210Y
                        case 224: score = ; break; //Core i5 8200Y
                        case 225: score = ; break; //Core i5 7640X
                        case 226: score = ; break; //Core i5 7600
                        case 227: score = ; break; //Core i5 7600K
                        case 228: score = ; break; //Core i5 7600T
                        case 229: score = ; break; //Core i5 7500
                        case 230: score = ; break; //Core i5 7500T
                        case 231: score = ; break; //Core i5 7440HQ
                        case 232: score = ; break; //Core i5 7400
                        case 233: score = ; break; //Core i5 7400T
                        case 234: score = ; break; //Core i5 7360U
                        case 235: score = ; break; //Core i5 7300HQ
                        case 236: score = ; break; //Core i5 7300U
                        case 237: score = ; break; //Core i5 7287U
                        case 238: score = ; break; //Core i5 7267U
                        case 239: score = ; break; //Core i5 7260U
                        case 240: score = ; break; //Core i5 7200U
                        case 241: score = ; break; //Core i5 7Y57
                        case 242: score = ; break; //Core i5 7Y54
                        case 243: score = ; break; //Core i5 1250P
                        case 244: score = ; break; //Core i5 1245U
                        case 245: score = ; break; //Core i5 1240P
                        case 246: score = ; break; //Core i5 1240U
                        case 247: score = ; break; //Core i5 1235U
                        case 248: score = ; break; //Core i5 1230U
                        case 249: score = ; break; //Core i3 13100
                        case 250: score = ; break; //Core i3 13100F
                        case 251: score = ; break; //Core i3 13100T
                        case 252: score = ; break; //Core i3 12300
                        case 253: score = ; break; //Core i3 12300T
                        case 254: score = ; break; //Core i3 12100
                        case 255: score = ; break; //Core i3 12100F
                        case 256: score = ; break; //Core i3 12100T
                        case 257: score = ; break; //Core i3 1125G4
                        case 258: score = ; break; //Core i3 1125G4 w/IPU
                        case 259: score = ; break; //Core i3 1120G4 w/IPU
                        case 260: score = ; break; //Core i3 1115GRE
                        case 261: score = ; break; //Core i3 1115G4E
                        case 262: score = ; break; //Core i3 1115G4
                        case 263: score = ; break; //Core i3 1115G4 w/IPU
                        case 264: score = ; break; //Core i3 1110G4 w/IPU
                        case 265: score = ; break; //Core i3 1110HE
                        case 266: score = ; break; //Core i3 10320
                        case 267: score = ; break; //Core i3 10300
                        case 268: score = ; break; //Core i3 10300T
                        case 269: score = ; break; //Core i3 10110Y
                        case 270: score = ; break; //Core i3 10100
                        case 271: score = ; break; //Core i3 10100F
                        case 272: score = ; break; //Core i3 10100T
                        case 273: score = ; break; //Core i3 10100E
                        case 274: score = ; break; //Core i3 10100TE
                        case 275: score = ; break; //Core i3 9350K
                        case 276: score = ; break; //Core i3 9350KF
                        case 277: score = ; break; //Core i3 9320
                        case 278: score = ; break; //Core i3 9300
                        case 279: score = ; break; //Core i3 9300T
                        case 280: score = ; break; //Core i3 9100
                        case 281: score = ; break; //Core i3 9100F
                        case 282: score = ; break; //Core i3 9100T
                        case 283: score = ; break; //Core i3 9100E
                        case 284: score = ; break; //Core i3 9100TE
                        case 285: score = ; break; //Core i3 8350K
                        case 286: score = ; break; //Core i3 8145U
                        case 287: score = ; break; //Core i3 8140U
                        case 288: score = ; break; //Core i3 8130U
                        case 289: score = ; break; //Core i3 8109U
                        case 290: score = ; break; //Core i3 8100
                        case 291: score = ; break; //Core i3 8100H
                        case 292: score = ; break; //Core i3 8100B
                        case 293: score = ; break; //Core i3 7350K
                        case 294: score = ; break; //Core i3 7320
                        case 295: score = ; break; //Core i3 7300
                        case 296: score = ; break; //Core i3 7300T
                        case 297: score = ; break; //Core i3 7130U
                        case 298: score = ; break; //Core i3 7167U
                        case 299: score = ; break; //Core i3 7101E
                        case 300: score = ; break; //Core i3 7101TE
                        case 301: score = ; break; //Core i3 7100T
                        case 302: score = ; break; //Core i3 7100
                        case 303: score = ; break; //Core i3 7100H
                        case 304: score = ; break; //Core i3 7100U
                        case 305: score = ; break; //Core i3 1220P
                        case 306: score = ; break; //Core i3 1215U
                        case 307: score = ; break; //Core i3 1210U
                        case 309: score = ; break; //Xeon W-11965MRE
                        case 310: score = ; break; //Xeon W-11955M
                        case 311: score = ; break; //Xeon W-11865MLE
                        case 312: score = ; break; //Xeon W-11855M
                        case 313: score = ; break; //Xeon W-11555MRE
                        case 314: score = ; break; //Xeon W-11555MLE
                        case 315: score = ; break; //Xeon W-11155MRE
                        case 316: score = ; break; //Xeon W-11155MLE
                    }
                }
            }
            else //KYS
            {
                MessageBox.Show("Kys");
            }
        }
        //https://www.cpu-monkey.com/en/cpu_benchmark-cinebench_r23_single_core
        //https://browser.geekbench.com/processor-benchmarks
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
                singleThread.Foreground = Brushes.White;
                multiThread.Foreground = Brushes.White;
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
                singleThread.Foreground = Brushes.Black;
                multiThread.Foreground = Brushes.Black;   
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