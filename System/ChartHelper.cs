using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Threading.Tasks;

namespace System
{
    public class ChartHelper
    {
        /// <summary>
        　　　　/// 绘制曲线函数
        /// </summary>
        /// <param name="listX">X值集合</param>
        /// <param name="listY">Y值集合</param>
        /// <param name="chart">Chart控件</param>
        public static void DrawPoint(double lr,double kr, Chart chart,double Lr_Max)
        {
            chart.Series[2].Points.Clear();
            chart.Series[1].Points.Clear();
            double y =(1-0.14*Math.Pow(Lr_Max,2))*(0.3+0.7*Math.Exp(-0.65*Math.Pow(Lr_Max,6)));
            chart.Series[0].Enabled = true;

            chart.Series[2].Points.AddXY(lr, kr);
            chart.Series[1].Points.AddXY(Lr_Max, 0);
            chart.Series[1].Points.AddXY(Lr_Max, y);

            chart.Series[1].Color = Color.Red;

            chart.Series[1].BorderWidth = 5;
            string fileName;
            ChartImageFormat format;
            format = ChartImageFormat.Emf;
            IO.Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Pictrue");
            fileName = System.Windows.Forms.Application.StartupPath + "\\Pictrue\\Firgure 1.emf";
            chart.SaveImage(fileName, format);
        }
    }

}