using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;
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
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        public static void vis()
        {
        }

        private void 生成报告书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 材料数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fm3 = new Material();
            Fm3.MdiParent = this;
            Fm3.Show();
        }

        private void 表征类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fm4 = new Characterization();
            Fm4.MdiParent = this;
            Fm4.Show();
        }

        private void 常规评定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fm2 = new Routine_assessment();
            Fm2.MdiParent = this;
            Fm2.Show();
        }

        private void 简化评定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fm5 = new Simplify_assessment();
            Fm5.MdiParent = this;
            Fm5.Show();
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
}
