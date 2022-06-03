using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Characterization : Form
    {
        public Characterization()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1IndexChanged);
        }
        private void Characterization_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        public void comboBox1IndexChanged(object sender,EventArgs e)
        {
            //表面缺陷表征处理
            if(comboBox1.SelectedIndex == 0)
            {
                label3.Text = "距壳表面距离h";
                label10.Visible = false;
                textBox4.Visible = false;
                label12.Visible = false;
                label11.Visible = false;
                textBox5.Visible = false;
                label13.Visible = false;
            }
            //埋藏缺陷表征处理
            if(comboBox1.SelectedIndex == 1)
            {
                label3.Text = "缺陷最大自身高度h";
                label10.Visible = true;
                textBox4.Visible = true;
                label12.Visible = true;
                label11.Visible = true;
                textBox5.Visible = true;
                label13.Visible = true;
            }
            //穿透裂纹表征处理
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = double.Parse(textBox1.Text);
            double B = double.Parse(textBox3.Text);
            double l = double.Parse(textBox2.Text);
            double p1 = double.Parse(textBox4.Text);
            double p2 = double.Parse(textBox5.Text);
            if (comboBox1.SelectedIndex == 0)
            {
                if(h > 0.7 * B)
                {
                    MessageBox.Show("该裂纹为穿透裂纹");
                    //Bitmap img1_1 = Properties.Resources.feature1_1;
                    //pictureBox1.Image = img1_1;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap img1_2 = Properties.Resources.feature1_2;
                    pictureBox2.Image = img1_2;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    if(h < l/2)
                    {
                        MessageBox.Show("该裂纹为半椭圆表面裂纹");
                        Bitmap img1_3 = Properties.Resources.feature1_3;
                        pictureBox1.Image = img1_3;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap img1_4 = Properties.Resources.feature1_4;
                        pictureBox2.Image = img1_4;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("该裂纹为半椭圆表面裂纹");
                        Bitmap img1_5 = Properties.Resources.feature1_5;
                        pictureBox1.Image = img1_5;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap img1_6 = Properties.Resources.feature1_6;
                        pictureBox2.Image = img1_6;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            if(comboBox1.SelectedIndex == 1)
            {
                if(p1 > p2)
                {
                    MessageBox.Show("输入参数有误，请重新输入");
                }
                else
                {
                    if(p1 < 0.4 * h & p2 < 0.4 * h)
                    {
                        MessageBox.Show("该裂纹为穿透裂纹");
                    }
                    if(p1 <= 0.4 * h & p2 >= 0.4 *h)
                    {
                        MessageBox.Show("该裂纹为半椭圆表面裂纹");
                    }
                    if(p1 > 0.4 * h)
                    {
                        if(h <l)
                        {
                            MessageBox.Show("该裂纹为椭圆形埋藏裂纹");
                        }
                        if(h >= l)
                        {
                            MessageBox.Show("该裂纹为椭圆埋藏裂纹");
                        }
                    }
                }
            }
        }
    }
}
