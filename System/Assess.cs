//////////////////using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace System
{
    public partial class Assess : Form
    {
        //创建绘制评定图所需要的横坐标
        List<double> X_Seriers = new List<double>();
        //创建绘制评定图所需的纵坐标
        List<double> Y_Seriers = new List<double>();
        //设置类级变量
        public string s;
        // 连接mysql的变量
        private string SQL_ConnectStr = "server = 127.0.0.1; port = 3306; user = root ; password = root; database =rating_system";
        public MySqlConnection MySqlConnection;
        public Assess()
        {
            InitializeComponent();
        }
        private void Assess_Load(object sender, EventArgs e) //窗体加载函数
        {
            Database_connection();
            Lr lr = new Lr();
            this.Component_Type.SelectedIndexChanged += new System.EventHandler(this.Type_BoxSelectedIndexChanged);
            this.Flaw_Type.SelectedIndexChanged += new System.EventHandler(this.Flaw_TypeSelectedIndexChanged);
            this.Material_Type.SelectedIndexChanged += new System.EventHandler(this.Material_TypeSelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2IndexChanged);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1IndexChanged);
            Component_Type.Items.Add("平板");
            Component_Type.Items.Add("内压圆筒");
            Component_Type.Items.Add("内压球壳");
            Component_Type.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            Material_Type.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0; 
        }
        //数据库连接函数
        public void Database_connection()
        {
            try
            {
                MySqlConnection = new MySqlConnection(SQL_ConnectStr);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("数据库连接成功");
            }
        }

        public void Database_select_StellNumber(MySqlConnection mySqlConnection, string s)
        {
            try
            {
                if (mySqlConnection != null)
                    mySqlConnection.Open(); //打开通道
                string sql_select = "SELECT * FROM MATERIAL_TB WHERE Steel_number= '" + s +" '";
                MySqlCommand mySqlCommand = new MySqlCommand(sql_select, mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet,"Limit_s");;
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();
                Limit_Box.Text = reader.GetString("Limit_s");
                Strength_Box.Text = reader.GetString("Limit_b");
                //Fracture_Box.Text = reader.GetString("K1_c");
                Poisson_Box.Text = reader.GetString("Labor_e");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        public void Database_select_Coefficient(MySqlConnection mySqlConnection,double B_Ri,string Gi)
        {
            try
            {
                if (mySqlConnection != null)
                    mySqlConnection.Open();
                string sql_select = "SELECT * FROM coefficient_2tb where ﻿B_Ri ='"+ B_Ri +"'"+"and Gi='"+Gi+"'";
                MySqlCommand mySqlCommand = new MySqlCommand(sql_select, mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    Kr.A0 = reader.GetDouble("A0");
                    Kr.A1 = reader.GetDouble("A1");
                    Kr.A2 = reader.GetDouble("A2"); 
                    Kr.A3 = reader.GetDouble("A3");
                    Kr.A4 = reader.GetDouble("A4");
                    Kr.A5 = reader.GetDouble("A5");
                    Kr.A6 = reader.GetDouble("A6");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        //lrMax的取值
        public void comboBox1IndexChanged(object sender,EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                Lr_Ma.Lr_Max = 1.8;
            }
            if(comboBox1.SelectedIndex == 1)
            {
                Lr_Ma.Lr_Max = 1.25;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Lr_Ma.Lr_Max = 1.15;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                Lr_Ma.Lr_Max = 1.0;
            }

        }
        // 安全系数的获取
        public void comboBox2IndexChanged(object sender,EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                Safety_Factor.Charateristic = 1.0;
                Safety_Factor.Fracture_toughness = 1.1;
                Safety_Factor.Primary_stress = 1.1;
                Safety_Factor.Secondary_stress = 1.0;
                Kr.Kp = Double.Parse(Fracture_Box.Text) / Safety_Factor.Fracture_toughness;
            }
            if(comboBox2.SelectedIndex == 1)
            {
                Safety_Factor.Charateristic = 1.1;
                Safety_Factor.Fracture_toughness = 1.2;
                Safety_Factor.Primary_stress = 1.25;
                Safety_Factor.Secondary_stress = 1.0;
                Kr.Kp = Double.Parse(Fracture_Box.Text) / Safety_Factor.Fracture_toughness;
            }
        }

        // 通过Material_Type来获取材料参数
        public void Material_TypeSelectedIndexChanged(object sender,EventArgs e)
        {
            string sel = (string) Material_Type.SelectedItem;
            Database_select_StellNumber(MySqlConnection, sel);
        }
        //缺陷类型的选择
        public void Type_BoxSelectedIndexChanged(object sender,EventArgs e)
        {
            Flaw_Type.Items.Clear();
            if (Component_Type.SelectedIndex == 0)
            {
                
                Flaw_Type.Items.Add("含长2a穿透裂纹");
                Flaw_Type.Items.Add("半椭圆表面裂纹");
                Flaw_Type.Items.Add("椭圆形埋藏裂纹");
                Flaw_Type.SelectedIndex = 0;
            }
            else if(Component_Type.SelectedIndex == 1)
            {
                Flaw_Type.Items.Add("半椭圆轴向内表面表面裂纹");
                Flaw_Type.Items.Add("半椭圆轴向外表面表面裂纹");
                Flaw_Type.Items.Add("半椭圆内表面环向裂纹");
                Flaw_Type.Items.Add("椭圆埋藏轴向裂纹");
                Flaw_Type.Items.Add("椭圆埋藏环向裂纹");
                Flaw_Type.Items.Add("长2a轴向穿透裂纹");
                Flaw_Type.Items.Add("整圈内表面环向裂纹");
                Flaw_Type.SelectedIndex = 0;
            }
            else if(Component_Type.SelectedIndex == 2)
            {
                Flaw_Type.Items.Add("穿透裂纹");
                Flaw_Type.SelectedIndex = 0;
            }
                
        }
        //页面加载
        public void Flaw_TypeSelectedIndexChanged(object sender,EventArgs e)
        {
            if(Component_Type.SelectedIndex == 0)
            {
                groupBox3.Visible = true;
                groupBox6.Visible = false;
               groupBox7.Visible = false;
                if (Flaw_Type.SelectedIndex == 0)
                {
                    Bitmap Img1_1 = Properties.Resources.Img1_1;
                    pictureBox1.Image = Img1_1;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    label16.Visible = false;
                    Flat_depth.Visible = false;
                    Flat_Distance.Visible = false;
                    label17.Visible = false;
                }
                if(Flaw_Type.SelectedIndex == 1)
                {
                    Bitmap Img1_2 = Properties.Resources.Img1_2;
                    pictureBox1.Image = Img1_2;
                    label16.Visible = true;
                    Flat_depth.Visible = true;
                    Flat_Distance.Visible = false;
                    label17.Visible = false;
                }
                if(Flaw_Type.SelectedIndex == 2)
                {
                    Bitmap Img1_3 = Properties.Resources.Img1_3;
                    pictureBox1.Image = Img1_3;
                    label16.Visible = true;
                    Flat_depth.Visible = true;
                    Flat_Distance.Visible = true;
                    label17.Visible = true;
                }
            }
            else if(Component_Type.SelectedIndex == 1)
            {
                groupBox3.Visible = false;
                groupBox6.Visible = true;
                groupBox7.Visible = false;
                if (Flaw_Type.SelectedIndex == 0)
                {
                    Bitmap Img2_1 = Properties.Resources.Img2_1;
                    pictureBox1.Image = Img2_1;
                    Cylinder_Distance.Visible = false;
                    label23.Visible = false;
                    Cylinder_Length.Visible = false;
                    label24.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 1)
                {
                    Bitmap Img2_2 = Properties.Resources.Img2_2;
                    pictureBox1.Image = Img2_2;
                    Cylinder_Distance.Visible = false;
                    label24.Visible = false;
                    Cylinder_Length.Visible = true;
                    label23.Visible = true;
                }
                if (Flaw_Type.SelectedIndex == 2)
                {
                    Bitmap Img2_3 = Properties.Resources.Img2_3;
                    pictureBox1.Image = Img2_3;
                    Cylinder_Distance.Visible = false;
                    label24.Visible = false;
                    Cylinder_Length.Visible = true;
                    label23.Visible = true;
                }
                if (Flaw_Type.SelectedIndex == 3)
                {
                    Bitmap Img2_4 = Properties.Resources.Img2_4;
                    pictureBox1.Image = Img2_4;
                    Cylinder_Distance.Visible = true;
                    label24.Visible = true;
                    Cylinder_Length.Visible = true;
                    label23.Visible = true;
                }
                if (Flaw_Type.SelectedIndex == 4)
                {
                    Bitmap Img2_5 = Properties.Resources.Img2_5;
                    pictureBox1.Image = Img2_5;
                    Cylinder_Distance.Visible = true;
                    label24.Visible = true;
                    Cylinder_Length.Visible = true;
                    label23.Visible = true;
                }
                if (Flaw_Type.SelectedIndex == 5)
                {
                    Bitmap Img2_6 = Properties.Resources.Img2_6;
                    pictureBox1.Image = Img2_6;
                    Cylinder_Distance.Visible = false;
                    label24.Visible = false;
                    Cylinder_Length.Visible = false;
                    label23.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 6)
                {
                    Bitmap Img2_7 = Properties.Resources.Img2_7;
                    pictureBox1.Image = Img2_7;
                    Cylinder_Distance.Visible = false;
                    label24.Visible = false;
                    Cylinder_Length.Visible = false;
                    label23.Visible = false;
                }
            }
            else if(Component_Type.SelectedIndex == 2)
            {
                groupBox3.Visible = false;
                groupBox6.Visible = false;
                groupBox7.Visible = true;
                Bitmap Img3_1 = Properties.Resources.Img3_1;
                pictureBox1.Image = Img3_1;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // 计算Lr与Kr
        private void button1_Click(object sender, EventArgs e)
        {
            if (Component_Type.SelectedIndex==0)
            {
                if(Flaw_Type.SelectedIndex==0)
                {
                    double lr = Lr.Lr_1(Double.Parse(Pb_Box.Text), Double.Parse(Pm_Box.Text),
                                        Double.Parse(Flat_Crack_Length.Text), Double.Parse(Flat_length.Text), 
                                        Double.Parse(Limit_Box.Text));
                    double Kip = FixKr_1(Double.Parse(Pm_Box.Text),Double.Parse(Pb_Box.Text));
                    double Kis = FixKr_1(Double.Parse(Qm_Box.Text), Double.Parse(Qm_Box.Text));
                    double Kd = Kip + Kis;
                    string ret1 = Kd.ToString("0.##");
                    string ret = lr.ToString("0.##");
                    Lr_Box.Text = ret;
                    Kr_box.Text = ret1;
                }
                if(Flaw_Type.SelectedIndex==1)
                {
                    double lr = Lr.Lr_2(Double.Parse(Pb_Box.Text), Double.Parse(Pm_Box.Text),
                                        Double.Parse(Flat_Crack_Length.Text), Double.Parse(Limit_Box.Text),
                                        Double.Parse(Flat_depth.Text), Double.Parse(Flat_Thickness.Text));
                    lr = lr * Safety_Factor.Charateristic;
                    string ret = lr.ToString("0.##");
                    Lr_Box.Text = ret;
                }
                if(Flaw_Type.SelectedIndex == 2)
                {
                    double lr = Lr.Lr_3(Double.Parse(Pb_Box.Text), Double.Parse(Pm_Box.Text),
                                        Double.Parse(Flat_depth.Text), Double.Parse(Limit_Box.Text) ,Double.Parse(Flat_Distance.Text),
                                        Double.Parse(Flat_length.Text), Double.Parse(Flat_Distance.Text) );
                    string ret = lr.ToString("0.##");
                    Lr_Box.Text = ret;

                }
            }
            if(Component_Type.SelectedIndex == 1)
            {
                if(Flaw_Type.SelectedIndex == 0)
                {
                    double lr = Fixlr_4();
                    string ret = lr.ToString("0.##");
                    Lr_Box.Text = ret;
                }
                if(Flaw_Type.SelectedIndex == 1)
                { 
                    Database_select_Coefficient(MySqlConnection, 0.2, "G1");
                    double G1 = Kr.Gi(Kr.A0, Kr.A1, Kr.A2, Kr.A3, Kr.A4, Kr.A5, Kr.A6, Double.Parse(Cylinder_Length.Text), Double.Parse(Cylinder_Radius.Text), Double.Parse(Cylinder_Thickness.Text));
                    Database_select_Coefficient(MySqlConnection, 0.2, "G0");
                    double G0 = Kr.Gi(Kr.A0, Kr.A1, Kr.A2, Kr.A3, Kr.A4, Kr.A5, Kr.A6, Double.Parse(Cylinder_Length.Text), Double.Parse(Cylinder_Radius.Text), Double.Parse(Cylinder_Thickness.Text));
                    double lr = Lr.Lr_5(Double.Parse(Pm_Box.Text),Double.Parse(Cylinder_Length.Text),Double.Parse(Cylinder_Thickness.Text),Double.Parse(Cylinder_Radius.Text),Double.Parse(Pb_Box.Text),Double.Parse(Limit_Box.Text));
                    double fm = G0;
                    double fb = G0 - 2 * G1;
                    double KIP = Kr.Ki(Double.Parse(Cylinder_Length.Text), Double.Parse(Pm_Box.Text), Double.Parse(Pb_Box.Text), fm, fb);
                    double KIS = Kr.Ki(Double.Parse(Cylinder_Length.Text), Double.Parse(Qb_Box.Text), Double.Parse(Qm_Box.Text), fm, fb);
                    double psil = Kr.Sx(Double.Parse(Cylinder_Length.Text), KIS, Double.Parse(Limit_Box.Text));
                    double p = Kr.P(lr, psil);
                    double kr = Kr.Calculate_Kr(1, KIP, KIS, Kr.Kp, p);
                    Console.WriteLine(kr);
                    Kr_box.Text = kr.ToString("0.##");
                    string ret = lr.ToString("0.##");
                    Lr_Box.Text = ret;
                    textBox1.Text = Kr.shixiao(lr, kr, Lr_Ma.Lr_Max);
                    for(double x = 0; x < 2.0; x = x + 0.05)
                    {
                        Console.WriteLine(x);
                        double y = (1 - 0.14 * Math.Pow(x, 2)) * (0.3 + (0.7 * Math.Pow(Math.E, (-0.65 * Math.Pow(x, 6)))));
                        Console.WriteLine(x);
                        X_Seriers.Add(x);
                        Y_Seriers.Add(y);
                    }
                    ChartHelper.DrawSpline(X_Seriers,Y_Seriers,chart1);
                }
                if (Flaw_Type.SelectedIndex == 2)
                {
                    double lr = Fixlr_6();
                    string ret = lr.ToString("0.##");
                    Lr_Box.Text = ret;
                }
            }
            
        }


        // 含长2a穿透裂纹的平板的Lr计算

        // 

        public double Fixlr_3()
        {
            double Pb, Pm, a, limit, lr, labor, c, B, p1, r;
            Pb = Double.Parse(Pb_Box.Text);
            Pm = Double.Parse(Pm_Box.Text);
            c = Double.Parse(Flat_Crack_Length.Text);
            B = Double.Parse(Flat_Thickness.Text);
            limit = Double.Parse(Limit_Box.Text);
            a = Double.Parse(Flat_depth.Text);
            p1 = Double.Parse(Flat_Distance.Text);
            r = p1 / B;
            labor = (2 * a * c) / (B* (c + B));
            lr = ((3 * labor * Pm + Pb) + Math.Sqrt(Math.Pow(3 * labor * Pm + Pb,2.0) + (9 * Math.Pow(1 - labor,2.0)  + (4 * labor * r)) * Math.Pow(Pm,2.0))) / (3 * ((1 - labor) * (1 - labor) + 4 * labor * r) * limit);
            return lr;
        }

        public double Fixlr_4()
        {
            double Pm, limit, a, Ri, B, Lr;
            Pm = Double.Parse(Pm_Box.Text);
            Ri = Double.Parse(Cylinder_Radius.Text);
            B = Double.Parse(Cylinder_Thickness.Text);
            a = Double.Parse(Cylinder_Length.Text);
            limit = Double.Parse(Limit_Box.Text);
            Lr = ((1.2 * Pm) / limit) * System.Math.Sqrt(1 + (1.6 * a * a) / (B * Ri));
            return Lr;
        }

        public double Fixlr_5()
        {
            double Pm, a, B, Ri, Pb, labor, limit, c, Lr;
            Pm = Double.Parse(Pm_Box.Text);
            a = Double.Parse(Cylinder_Depth.Text);
            B = Double.Parse(Cylinder_Thickness.Text);
            Ri = Double.Parse(Cylinder_Radius.Text);
            Pb = Double.Parse(Pb_Box.Text);
            limit = Double.Parse(Limit_Box.Text);
            labor = a / B;
            c = Math.PI * Ri;
            Lr = ((Pm*(Math.PI*(1-a/B))+2*(a/B)*Math.Sin(c/Ri))/(limit*(1-a/B)*(Math.PI - (c/Ri)*(a/B)))) + 2*Pb/(3*limit*Math.Pow(1-labor, 2));
            return Lr;

        }

        public double Fixlr_6()
        {
            double Pm, a, B, Ri, Pb, limit, c, Lr, Ms, Mt,labor;
            Pm = Double.Parse(Pm_Box.Text);
            a = Double.Parse(Cylinder_Depth.Text);
            B = Double.Parse(Cylinder_Thickness.Text);
            Ri = Double.Parse(Cylinder_Radius.Text);
            Pb = Double.Parse(Pb_Box.Text);
            c = Double.Parse(Cylinder_Length.Text);
            limit = Double.Parse(Limit_Box.Text);
            Mt = Math.Pow(1 + 1.6*((Math.Pow(c, 2)) / Ri * B), 0.5);
            Ms = 1 - (a / (B * Mt)) / (1 - (a / B));
            labor = (a / B) / (1 + B / c);
            Lr = (1.2*Ms*Pm+(2*Pb)/(3*Math.Pow((1-labor), 2))) / limit;
            return Lr;
        }

        //含长2a穿透裂纹的平板的Kr计算
        public double FixKr_1(double Limit_M,   double Limit_B)
        {
            double KI, a;
            a = Double.Parse(Flat_Crack_Length.Text);
            KI = Math.Sqrt(Math.PI * a) * (Limit_M + Limit_B);
            return KI;
        }

        // public double FixKr_2(double Limit_M, double Limit_B)
        // {
        //     double KI, a,fm,fb;
        //     a = Double.Parse(Flat_Crack_Length.Text);
        //     KI = Math.Sqrt((Math.PI * a) * ((Limit_B * fm) + (Limit_M * fb)));
        //     fm
        // }
        private void button2_Click(object sender, EventArgs e)
        {
        }

    }
}
