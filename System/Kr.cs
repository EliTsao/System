using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    internal class Kr
    {
        public static int index;
        public static double Kp;
        public static double fma, fba, fmB, fbB;

        //含轴向穿透裂纹的内压圆筒
        public static double Gi(double A0, double A1, double A2,double A3, double A4, double A5, double A6,double a, double Ri, double B)
        {
            double K = 1.818 * a / Math.Sqrt(Ri*B);
            return (A0 + A1 * K + A2 * K * K + A3 * Math.Pow(K, 3)) / 1 + A4 * K + A5 * Math.Pow(K, 2) + A6 * Math.Pow(K, 3);
        }
        // 线性插值法 起始点（X0,YO） 截止点（X1,Y1）,插入点（X，Y）
        public static double linearInter(double Y1,double X1, double Y0, double X0, double X)
        {
            return Y1 + (Y1 - Y0) / (X1 - X0) * (X - X0);
        }
        //Ki计算
        public static double Ki(double a, double limit_m, double limit_b,double fm, double fb)
        {
            return Math.Sqrt(Math.PI * a) * (limit_m * fm + limit_b * fb);
        }
        public static double Calculate_Kr(double G,double KIP, double KIS, double Kp, double P)
        {
            Console.WriteLine(G);
            Console.WriteLine(KIP);
            Console.WriteLine(KIS);
            Console.WriteLine(Kp);
            Console.WriteLine(P);
            return G * (KIP + KIS) / Kp + P;
        }

        public static double Sx(double a,double Kis,double limit_s)
        {
            double Sx = Kis / (limit_s * Math.Sqrt(Math.PI * a));
            if (Sx <= 0.1) return 0.125 * Sx;
            if (Sx <= 0.2) return (0.02 - 0.0125) * 10 * (Sx - 0.1) + 0.0125;
            if (Sx <= 0.3) return (0.024 - 0.02) * 10 * (Sx - 0.2) + 0.02;
            if (Sx <= 0.4) return (0.025 - 0.024) * 10 * (Sx - 0.3) + 0.024;
            if (Sx <= 0.5) return (0.026 - 0.025) * 10 * (Sx - 0.4) + 0.025;
            if (Sx <= 0.6) return (0.0375 - 0.026) * 10 * (Sx - 0.5) + 0.026;
            if (Sx <= 0.7) return (0.05625 - 0.0375) * 10 * (Sx - 0.6) + 0.0375;
            if (Sx <= 0.8) return (0.0875 - 0.05625) * 10 * (Sx - 0.7) + 0.05625;
            if (Sx <= 0.9) return (0.1625 - 0.0875) * 10 * (Sx - 0.8) + 0.0875;
            else return (0.23 - 0.1625) * 10 * (Sx - 0.9) + 0.1625;
        }
        public static double P(double Lr,double psil)
        {
            if(Lr<0.8) return   psil;
            if (Lr < 1.1) return psil * (11 - 10 * Lr) / 3;
            else return 0;

        }
        public static string shixiao(double lr,double kr,double lrmax)
        {
            double kr1 = (1 - 0.14 * Math.Pow(lr, 2)) * (0.3 + 0.7 * Math.Exp(-0.65 * Math.Pow(lr, 6)));
            if (kr < kr1 && lr < lrmax) return "安全";
            else return "失效";
        }
        // 含半椭圆表面裂纹（a*2c）的平板（板宽2W，板长2L，板厚B）
        public static double FixKI_1(double a, double Limit_M, double Limit_B)
        {
            return Math.Sqrt(Math.PI * a) * (Limit_M + Limit_B);
        }
        //含半椭圆表面裂纹的平板
        public static double FixKI_2(double a, double c, double B,double Limit_M, double Limit_B)
        {
            double fmA = 1 / Math.Pow(1 + 1.464 * Math.Pow((a / c), 1.65), 0.5) * (1.13 - 0.09 * (a / c) + (-0.54 + (0.89 / (0.2 + a / c)))
            * Math.Pow((a / B), 2)) + (0.5 - (1 / (0.65 + a / c)) + 14 * (1 - Math.Pow((a / c), 24))) * Math.Pow(a / B, 4);
            double fbA = (1 + (-1.22 - 0.12 * a / c) * a / B + (0.55 - 1.05 * Math.Pow(a / c, 0.75) + 0.47 * Math.Pow(a / c, 1.5)) * Math.Pow(a / B, 2)) * fmA;
            double fmB = (1.1 + 0.35 * Math.Pow((a / c), 0.5)) * fmA;
            double fbB = (1 - 0.34 * (a / B) - 0.11 * Math.Pow(a, 2) / (c * B)) * fmB;
            double Ki_A = Math.Sqrt(Math.PI * a) * (Limit_M * fmA + Limit_B * fbA);
            double Ki_B = Math.Sqrt(Math.PI * a) * (Limit_M * fmB + Limit_B * fbB);
            if(Ki_A >= Ki_B)
            {
                return Ki_A;
            }
            else return Ki_B;
        }
        //含椭圆埋藏裂纹的平板
        public static double FixKI_3(double a,double B,double c,double Limit_M, double Limit_B,double p1)
        {
            double ee = (B / 2) - p1 - 2;
            double temp = Math.Pow((1 - Math.Pow((2 * a / B / (1 - 2 * ee / B)), 1.8) * (1 - 0.4 * a / c -  Math.Pow((ee / B), 2))), 0.54);
            double fmA = (1.01 - 0.37 * (a / c)) / temp;
            double fbA = (1.01 - 0.37 * (a / c)) * ((2 * ee / B) + (a / B) + 0.34 * Math.Pow(a, 2) / (c * B)) / temp;
            double temp_2 = Math.Pow((1 - Math.Pow(((2 * a / B) / (1 - 2 * ee / B)), 1.8) * (1 - 0.4 * a / c - 0.8 * Math.Pow((ee / B), 0.4))), 0.54);
            double fmB = (1.01 - 0.37 * (a / c)) / temp_2;
            double fbB = ((1.01 - 0.37 * (a / c)) * ((2 * ee / B) - (a / B) - 0.34 * Math.Pow(a, 2) / (c * B))) / temp_2;
            double Ki_A = Math.Sqrt(Math.PI * a) * (Limit_M * fmA + Limit_B * fbA);
            Console.WriteLine(B);
            Console.WriteLine(p1);
            Console.WriteLine(ee);
            double Ki_B = Math.Sqrt(Math.PI * a) * (Limit_M * fmB + Limit_B * fbB);
            if (Ki_A >= Ki_B)
            {
                return Ki_A;
            }
            else return Ki_B;
        }

        //含轴向穿透裂纹(长度2a)的内压圆筒（板厚B，半径Ri)
        public static double FixKI_4(double a, double Ri, double B, double Limit_M, double Limit_B)
        {
            double[,] G0_0 = new double[7, 7]{
                {1.00762, -0.178500, 0.8647, 0.000000, -0.0207, 0.3061, -0.00099},
                {1.00764, 0.48166, 0.16868, 0.000000, 0.12401, 0.02958, -0.00025},
                {1.00848, 0.33814, 0.09133, 0.000000, -0.017405, 0.02798, -0.00049},
                {1.00856, 0.51025, 0.18541, 0.000000, 0.16877, 0.03003, 0.000233},
                {1.00475, 0.58582, 0.21128, 0.000000, 0.23079, 0.03744, -0.00013},
                {1.00566, 1.42209, 0.68983, 0.000000, 1.11375, 0.08548, 0.000444},
                {0.9944, 0.42725, 0.04842, 0.000000, 0.05363, 0.01217, 0.000553}
            };
            double[,] G1_0 = new double[7, 7]{
                {0.99951, 7.9301, 4196810, 1.91115, 9.11712, 3.41264, 0.50331},
                {0.99503, 2.65941, 1.23398, 0.25007, 3.2505, 0.52634, 0.07082},
                {0.99285, 0.78601, 0.49022, 0.000000, 1.02027, 0.10866, 0.00155},
                {0.99922, 1.71368, 0.61207, 0.07555, 1.97385, 0.14237, 0.03116},
                {0.99819, 0.66559, 0.34386, 0.000000, 0.73742, 0.0976, 0.00033},
                {1.00087, 0.92895, 0.3338, 0.000000, 0.95697, 0.08798, 0.00013},
                {0.9985, 0.05834, 0.01687, 0.000000, -0.051282, 0.01085, 0.00022}
            };
            double[] B_Ri = new double[7] { 0.01, 1 / 60, 0.05, 0.01, 0.2, 1 / 3, 1 };
            double[] G0 = new double[7];
            double[] G1 = new double[7];
            double BRi = B / Ri;
            for(int i = 0; i < 7; i++)
            {
                if(B_Ri[i]<BRi&&B_Ri[i+1]>=BRi)
                    index = i - 1;
            }
            for(int i = 0;i < 7;i++)
            {
                G0[i] = G0_0[index, 0];
                G1[i] = G1_0[index, 0];
            }
            double K = 1.818 * a / Math.Sqrt(Ri * B);
            double G0_1 = (G0[0] + G0[1] * K + G0[2] * Math.Pow(K, 2) + G0[3] * Math.Pow(K, 3)) / (1 + G0[4] * K + G0[5] * Math.Pow(K, 2) + G0[6] * Math.Pow(K, 3));
            double G1_1 = (G1[0] + G0[1] * K + G1[2] * Math.Pow(K, 2) + G1[3] * Math.Pow(K, 3)) / (1 + G1[4] * K + G1[5] * Math.Pow(K, 2) + G1[6] * Math.Pow(K, 3));
            double fm = G0_1;
            double fb = G0_1 - 2 * G1_1;
            return Ki(a, Limit_M, Limit_B, fm, fb);
        }

        //含整圈内表面环向裂纹的内压圆筒
        public static double FixKI_5(double a, double B, double Ri, double Limit_M, double Limit_B)
        {
            double[,] gm = new double[5, 2]{
            { 1.122, 1.122 },
            { 1.261, 1.215},
            { 1.582, 1.446},
            { 2.091, 1.804},
            { 2.599, 2.28}};

            double[,] gb = new double[5, 2]{
            {1.122, 1.122},
            {0.954, 0.933},
            {0.909, 0.81},
            {0.81, 0.65},
            {0.6, 0.411}};
            double[] aBi = new double[5] { 0, 0.2, 0.4, 0.6, 0.8 };
            for(int i = 1;i < 5; i++)
            {
                if (aBi[i - 1] < a / B && aBi[i] >= a / B)
                    index = i;
            }
            if (0 < B/Ri && B/Ri <= 0.1)
            {
                double fm = gm[index, 0];
                double fb = gb[index, 0];
                return Ki(a, Limit_M, Limit_B, fm, fb);
            }
            else
            {
                double fm = gm[index, 1];
                double fb = gb[index, 1];
                return Ki(a, Limit_M, Limit_B, fm, fb);
            }
        }

        //含半椭圆内表面轴向裂纹
        public static double FixKI_6(double a, double B,double c, double Ri, double Limit_M, double Limit_B)
        {
            double aB = a / B;
            double ac = a / c;
            double br = B / Ri;
            double[,] gmA = new double[5, 10]
            {
                {0.663, 0.663, 0.951, 0.951, 1.059, 1.059, 1.103, 1.103, 1.12, 1.12},
                {0.647, 0.643, 0.932, 0.919, 1.602, 1.045, 1.172, 1.153, 1.231, 1.211},
                {0.661, 0.656, 1.016, 0.998, 1.26, 1.24, 1.494, 1.47, 1.701, 1.674},
                {0.677, 0.677, 1.109, 1.11, 1.5, 1.514, 1.985, 2.003, 2.619, 2.285},
                {0.694, 0.704, 1.211, 1.255, 1.783, 1.865, 2.737, 2.864, 4.364, 3.163}
            };
            double[,] gmB = new double[5, 10]
            {
                {0.663, 0.663, 0.951, 0.951, 1.059, 1.059, 1.103, 1.103, 1.12, 1.12},
                {0.464, 0.461, 0.698, 0.688, 0.806, 0.791, 0.897, 0.881, 0.946, 0.929},
                {0.291, 0.288, 0.519, 0.506, 0.677, 0.663, 0.834, 0.816, 0.971, 0.95},
                {0.11, 0.107, 0.316, 0.311, 0.515, 0.515, 0.765, 0.765, 1.08, 1.079},
                {-0.08, -0.079, 0.09, 0.103, 0.32, 0.348, 0.689, 0.749, 1.301, 1.081}
            };
            double[] aBi = { 0, 0.2, 0.4, 0.6, 0.8 };
            for (int i = 0; i < 5; i++)
            {
                if(aBi[i]<aB&&aBi[i+1]>=aB)
                    index = i;
            }
            if(ac > 0.5 && ac < 1)
            {
                if(br>0&&br<0.1)
                {
                    fma = gmA[index, 0];
                    fba = gmB[index, 0];
                }
                if(br>0.1&&br<0.2)
                {
                    fma = gmA[index, 1];
                    fba = gmB[index, 1];
                }
            }
            if(ac>0.2&&ac<0.5)
            {
                if(br>0&&br<0.1)
                {
                    fma = gmA[index, 2];
                    fba = gmB[index, 2];
                }
                if(br>0.1&&br<0.2)
                {
                    fma = gmA[index, 3];
                    fba = gmA[index, 3];
                }
            }
            if(ac>0.1&&ac<0.2)
            {
                if(br>0&&br<0.1)
                {
                    fma = gmA[index, 4];
                    fba = gmB[index,4];
                }
                if(br>0.1&&br<0.2)
                {
                    fma = gmA[index, 5];
                    fba = gmB[index,5];
                }
            }
            if(ac>0&&ac<0.1)
            {
                if(br>0&&br<0.1)
                {
                    fma = gmA[index, 6];
                    fba = gmB[index,6];
                }
                if(br>0.1&&br<0.2)
                {
                    fma= gmA[index, 7];
                    fba = gmB[index,7];
                }
            }
            return Ki(a, Limit_M, Limit_B, fma, fba);
        }

        //含半椭圆内表面环向裂纹
        public static double FixKI_7(double a, double B, double c, double Ri, double Limit_M, double Limit_B)
        {
            double[,] gmB = new double[5,8]
            {
                {0.729, 0.729, 0.697, 0.697, 0.521, 0.521, 0.384, 0.384},
                {0.681, 0.681, 0.731, 0.731, 0.617, 0.617, 0.482, 0.482},
                {0.706, 0.706, 0.801, 0.801, 0.835, 0.835, 0.7, 0.7},
                {0.733, 0.7333, 0.889, 0.889, 1.048, 1.048, 0.981, 0.981},
                {0.764, 0.764, 0.993, 0.993, 1.255, 1.255, 1.363, 1.363}
            };
            double[,] gbB = new double[5, 8]
            {
                {0.729, 0.729, 0.697, 0.697, 0.521, 0.521, 0.384, 0.384},
                {0.623, 0.623, 0.628, 0.628, 0.623, 0.623, 0.487, 0.487},
                {0.528, 0.528, 0.563, 0.563, 0.591, 0.591, 0.498, 0.498},
                {0.431, 0.431, 0.502, 0.502, 0.556, 0.556, 0.525, 0.525},
                {0.32, 0.332, 0.445, 0.445, 0.519, 0.519, 0.57, 0.57},
            };
            double[] aBi = { 0, 0.2, 0.4, 0.6, 0.8 };
            double aB = a / B;
            double ac = a / c;
            double br = B / Ri;
            if(ac>0.5&&ac<1)
            {
                if(br>0&&br<0.1)
                {
                    fmB = gmB[index, 0]; 
                    fbB = gmB[index, 0];
                }
                if (br > 0.1 && br < 0.2)
                {
                    fmB = gmB[index, 1];
                    fbB = gmB[index, 1];
                }
            }
            if (ac > 0.2 && ac < 0.5)
            {
                if (br > 0 && br < 0.1)
                {
                    fmB = gmB[index, 2];
                    fbB = gmB[index, 2];
                }
                if (br > 0.1 && br < 0.2)
                {
                    fmB = gmB[index, 3];
                    fbB = gmB[index, 3];
                }
            }
            if (ac > 0.1 && ac < 0.2)
            {
                if (br > 0 && br < 0.1)
                {
                    fmB = gmB[index, 4];
                    fbB = gmB[index, 4];
                }
                if (br > 0.1 && br < 0.2)
                {
                    fmB = gmB[index, 5];
                    fbB = gmB[index, 5];
                }
            }
            if (ac > 0 && ac < 0.1)
            {
                if (br > 0 && br < 0.1)
                {
                    fmB = gmB[index, 6];
                    fbB = gmB[index, 6];
                }
                if (br > 0.1 && br < 0.2)
                {
                    fmB = gmB[index, 7];
                    fbB = gmB[index, 7];
                }
            }
            return Ki(a, Limit_M, Limit_B, fmB, fbB);

        }
    }
}
