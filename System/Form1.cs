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
            Form Fm2 = new Assess();
            Fm2.Show();

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void 生成报告书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("T{0}.doc",
             DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "word文档|*.doc";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                string filePath = sfd.FileName;
                WordHelper.CreateWordFile(filePath);
            }
        }
    }
}
