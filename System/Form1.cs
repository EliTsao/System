using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 常规缺陷评定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Routine_assessment FM2 = GenericSingleton<Routine_assessment>.CreateInstrance();
            FM2.MdiParent = this;
            FM2.Show();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void 材料数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Material FM1 = GenericSingleton<Material>.CreateInstrance();
            FM1.MdiParent = this;
            FM1.Show();
        }

        private void 表征类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Characterization FM3 = GenericSingleton<Characterization>.CreateInstrance();
            FM3.MdiParent = this;
            FM3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = Application.StartupPath + @"\helpDoc\Help.chm";
            Console.WriteLine(helpProvider1.HelpNamespace);
            helpProvider1.SetShowHelp(this, true);
            //int w = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
            //int h = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
            //Console.WriteLine(w);

            //设置最大尺寸  和  最小尺寸  （如果没有修改默认值，则不用设置）
            //this.MaximumSize = new Size(w, h);
            //this.MinimumSize = new Size(w, h);

            //设置窗口位置
            //this.Location = new Point(0, 0);

            //设置窗口大小
            //this.Width = w;
            //this.Height = h;

            //置顶显示

            //this.TopMost = true;
        }

        private void 内容CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(helpProvider1.HelpNamespace);
        }
    }
    public class GenericSingleton<T> where T : Form, new()
    {
        private static T t = null;
        public static T CreateInstrance()
        {
            if (t == null || t.IsDisposed)
            {
                t = new T();
            }
            else
            {
                t.Activate(); //如果已经打开过就让其获得焦点  
                t.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
            return t;
        }
    }
}
