using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    internal class Lr
    {
        // 含长2a穿透裂纹的平板
        public static double Lr_1(double Pb, double Pm, double a, double W,double limit)
        {
            return (Pb + Math.Sqrt(Pb * Pb + Pm * Pm * 9)) / (3 * (1 - 2 * a / W) * limit);
        }

        // 含半椭圆表面裂纹的平板
        public static double Lr_2(double Pb, double Pm, double a, double limit,double c, double B)
        {
            double labor = a * c / B * (c + B);
            double mid = Math.Sqrt((Pb * Pb) + 9 * (1 - labor) * (1 - labor) * Pm * Pm);
            return (Pb + mid) / (3 * (1 - labor) * (1 - labor) * limit);
        }

        // 含椭圆形埋藏裂纹的平板
        public static double Lr_3(double Pb, double Pm, double a,double limit, double c ,double B,double p1)
        {
            double r = p1 / B;
            double labor = (2 * a * c) / (B * (c + B));
            return ((3 * labor * Pm + Pb) + Math.Sqrt(Math.Pow(3 * labor * Pm + Pb, 2.0) + (9 * Math.Pow(1 - labor, 2.0) + (4 * labor * r)) * Math.Pow(Pm, 2.0))) / (3 * ((1 - labor) * (1 - labor) + 4 * labor * r) * limit);
        }

        // 含长2a轴向穿透裂纹的内压圆筒
        public static double Lr_4(double Pm, double limit, double a, double Ri, double B)
        {
            return ((1.2 * Pm) / limit) * System.Math.Sqrt(1 + (1.6 * a * a) / (B * Ri));
        }

        // 含整圈内表面环向裂纹的内压圆筒
        public static double Lr_5(double Pm, double a, double B, double Ri, double Pb, double limit)
        {
            double labor = a / B;
            double c = Math.PI * Ri;
            return ((Pm * (Math.PI * (1 - a / B)) + 2 * (a / B) * Math.Sin(c / Ri)) / (limit * (1 - a / B) * (Math.PI - (c / Ri) * (a / B)))) + 2 * Pb / (3 * limit * Math.Pow(1 - labor, 2));
        }

        // 含半椭圆表面轴向裂纹（a*2c）的内压圆筒
        public static double Lr_6(double Pm, double a, double B, double Ri, double Pb, double limit, double c)
        {
            double Mt = Math.Pow(1 + 1.6 * ((Math.Pow(c, 2)) / Ri * B), 0.5);
            double Ms = 1 - (a / (B * Mt)) / (1 - (a / B));
            double labor = (a / B) / (1 + B / c);
            return (1.2 * Ms * Pm + (2 * Pb) / (3 * Math.Pow((1 - labor), 2))) / limit;
        }

        // 含半椭圆内表面环向裂纹（a*2c）的内压圆筒
        
        //内压球壳
        public static double Lr_7(double Pb,double Pm, double a, double B, double Ri, double limit)
        {
            return (Pm/limit)*(1+Math.Sqrt(1+8*Math.Pow(a, 2)));
        }
    }
}
