namespace System
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.承压设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本参数数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常规缺陷评定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.生成报告书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.承压设备ToolStripMenuItem,
            this.常规缺陷评定ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.生成报告书ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1245, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 承压设备ToolStripMenuItem
            // 
            this.承压设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本参数数据ToolStripMenuItem});
            this.承压设备ToolStripMenuItem.Name = "承压设备ToolStripMenuItem";
            this.承压设备ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.承压设备ToolStripMenuItem.Text = "文件";
            // 
            // 基本参数数据ToolStripMenuItem
            // 
            this.基本参数数据ToolStripMenuItem.Name = "基本参数数据ToolStripMenuItem";
            this.基本参数数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.基本参数数据ToolStripMenuItem.Text = "基本参数数据";
            // 
            // 常规缺陷评定ToolStripMenuItem
            // 
            this.常规缺陷评定ToolStripMenuItem.Name = "常规缺陷评定ToolStripMenuItem";
            this.常规缺陷评定ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.常规缺陷评定ToolStripMenuItem.Text = "常规缺陷评定";
            this.常规缺陷评定ToolStripMenuItem.Click += new System.EventHandler(this.常规缺陷评定ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // 生成报告书ToolStripMenuItem
            // 
            this.生成报告书ToolStripMenuItem.Name = "生成报告书ToolStripMenuItem";
            this.生成报告书ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.生成报告书ToolStripMenuItem.Text = "生成报告书";
            this.生成报告书ToolStripMenuItem.Click += new System.EventHandler(this.生成报告书ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 732);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.MenuStrip menuStrip1;
        private Windows.Forms.ToolStripMenuItem 承压设备ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 基本参数数据ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 常规缺陷评定ToolStripMenuItem;
        private Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private Windows.Forms.ToolStripMenuItem 生成报告书ToolStripMenuItem;
    }
}

