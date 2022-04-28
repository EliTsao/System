using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    internal class Kr
    {
        public static double Kp;
        public static double A0, A1, A2, A3, A4, A5, A6;
        //内轴向穿透裂纹的内压圆筒
        public static double Gi(double A0, double A1, double A2,double A3, double A4, double A5, double A6,double a, double Ri, double B)
        {
            double K = 1.818 * a / Math.Sqrt(Ri*B);
            return (A0 + A1 * K + A2 * K * K + A3 * Math.Pow(K, 3)) / 1 + A4 * K + A5 * Math.Pow(K, 2) + A6 * Math.Pow(K, 3);
        }

        // 含半椭圆表面裂纹（a*2c）的平板（板宽2W，板长2L，板厚B）
        public static double Ki(double a, double limit_m, double limit_b,double fm, double fb)
        {
            return Math.Sqrt(Math.PI * a) * (limit_m * fm + limit_b * fb);
        }
        public static double Calculate_Kr(double G,double KIP, double KIS, double Kp, double P)
        {
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
    }
}
