using System;
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
    public partial class Routine_assessment : Form
    {
        public static double lr, kr;
        // 连接mysql的变量
        private string SQL_ConnectStr = "server = 127.0.0.1; port = 3306; user = root ; password = root; database =rating_system";
        public MySqlConnection MySqlConnection;
        public static string Houguo;
        //创建绘制评定图所需要的横坐标
        List<double> X_Seriers = new List<double>();
        //创建绘制评定图所需的纵坐标
        List<double> Y_Seriers = new List<double>();
        public Routine_assessment()
        {
            InitializeComponent();
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

        private void Routine_assessment_Load(object sender, EventArgs e)
        {
            Database_connection();
            comboBox5.SelectedIndex = 0;
            DBHelper dBHelper = new DBHelper();
            dBHelper.Database_connection();
            Material_category.SelectedIndex = 0;
            component_type.SelectedIndex = 0;
            Failure.SelectedIndex = 0;
            this.draw();
        }
        //图片绘制
        public void draw()
        {
            for (double x = 0; x <= 2.0; x = x + 0.01)
            {
                double y = (1 - 0.14 * Math.Pow(x, 2)) * (0.3 + (0.7 * Math.Pow(Math.E, (-0.65 * Math.Pow(x, 6)))));
                chart1.Series[0].Points.AddXY(x, y);
            }
            chart1.ChartAreas[0].BorderWidth = 10;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1.2;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 2;
            chart1.ChartAreas[0].AxisX.Interval = 0.2;
            chart1.ChartAreas[0].AxisY.Interval = 0.2;
        }
        //设置Lr_Max的最大值
        public void Material_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Material_category.SelectedIndex == 0)
            {
                Lr_Ma.Lr_Max = 1.8;
            }
            if (Material_category.SelectedIndex == 1)
            {
                Lr_Ma.Lr_Max = 1.25;
            }
            if (Material_category.SelectedIndex == 2)
            {
                Lr_Ma.Lr_Max = 1.15;
            }
            if (Material_category.SelectedIndex == 3)
            {
                Lr_Ma.Lr_Max = 1.0;
            }
        }

        //获取材料参数
        public void Database_select_StellNumber(MySqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null)
                    mySqlConnection.Open(); //打开通道
                string sql_select = "SELECT * FROM MATERIAL_TB WHERE Steel_number= '" + comboBox5.GetItemText(comboBox5.SelectedItem).Trim() + " '";
                MySqlCommand mySqlCommand = new MySqlCommand(sql_select, mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Steel_number"); ;
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();
                Limit_Box.Text = reader.GetString("Limit_s");
                textBox9.Text = reader.GetString("Limit_b");
                //Fracture_Box.Text = reader.GetString("K1_c");
                //Poisson_Box.Text = reader.GetString("Labor_e");
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

        // 缺陷类型及页面布局的加载
        public void component_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flaw_Type.Items.Clear();
            if (component_type.SelectedIndex == 0)
            {
                Flaw_Type.Items.Add("含长2a穿透裂纹");
                Flaw_Type.Items.Add("半椭圆表面裂纹");
                Flaw_Type.Items.Add("椭圆形埋藏裂纹");
                Flaw_Type.SelectedIndex = 0;
            }
            if (component_type.SelectedIndex == 1)
            {
                Flaw_Type.Items.Add("半椭圆轴向内表面轴向裂纹");
                Flaw_Type.Items.Add("半椭圆轴向外表面轴向裂纹");
                Flaw_Type.Items.Add("半椭圆内表面环向裂纹");
                Flaw_Type.Items.Add("椭圆埋藏轴向裂纹");
                Flaw_Type.Items.Add("椭圆埋藏环向裂纹");
                Flaw_Type.Items.Add("长2a轴向穿透裂纹");
                Flaw_Type.Items.Add("整圈内表面环向裂纹");
                Flaw_Type.SelectedIndex = 0;
            }
            if (component_type.SelectedIndex == 2)
            {
                Flaw_Type.Items.Add("穿透裂纹");
                Flaw_Type.SelectedIndex = 0;
            }
        }

        public void Flaw_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择构件种类为平板的页面展示
            if (component_type.SelectedIndex == 0)
            {
                if (Flaw_Type.SelectedIndex == 0)
                {
                    Bitmap Img1_1 = Properties.Resources.Img1_1;
                    pictureBox1.Image = Img1_1;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "平板长度2W";
                    Defect_3.Text = "裂纹长度a";
                    //label及textbox控制
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = false;
                    c_Textbox.Visible = false;
                    Unit_label4.Visible = false;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 1)
                {
                    Bitmap Img1_2 = Properties.Resources.Img1_2;
                    pictureBox1.Image = Img1_2;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "平板长度2W";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 2)
                {
                    Bitmap Img1_3 = Properties.Resources.Img1_3;
                    pictureBox1.Image = Img1_3;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "平板长度2W";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_5.Text = "距离表面距离P1";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = true;
                    P1_Textbox.Visible = true;
                    Unit_label5.Visible = true;
                }
            }
            //选择构件种类内压圆筒的页面展示
            if (component_type.SelectedIndex == 1)
            {
                if (Flaw_Type.SelectedIndex == 0)
                {
                    Bitmap Img2_1 = Properties.Resources.Img2_1;
                    pictureBox1.Image = Img2_1;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                    WordHelper.Guizhe = "c=1/2.a=h的";
                }
                if (Flaw_Type.SelectedIndex == 1)
                {
                    Bitmap Img2_2 = Properties.Resources.Img2_2;
                    pictureBox1.Image = Img2_2;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 2)
                {
                    Bitmap Img2_3 = Properties.Resources.Img2_3;
                    pictureBox1.Image = Img2_3;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 3)
                {
                    Bitmap Img2_4 = Properties.Resources.Img2_4;
                    pictureBox1.Image = Img2_4;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_5.Text = "距表面距离p1";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = true;
                    P1_Textbox.Visible = true;
                    Unit_label5.Visible = true;
                }
                if (Flaw_Type.SelectedIndex == 4)
                {
                    Bitmap Img2_5 = Properties.Resources.Img2_5;
                    pictureBox1.Image = Img2_5;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_4.Text = "裂纹长度2c";
                    Defect_5.Text = "距表面距离p1";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = true;
                    c_Textbox.Visible = true;
                    Unit_label4.Visible = true;
                    Defect_5.Visible = true;
                    P1_Textbox.Visible = true;
                    Unit_label5.Visible = true;
                }
                if (Flaw_Type.SelectedIndex == 5)
                {
                    Bitmap Img2_6 = Properties.Resources.Img2_6;
                    pictureBox1.Image = Img2_6;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = false;
                    c_Textbox.Visible = false;
                    Unit_label4.Visible = false;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                }
                if (Flaw_Type.SelectedIndex == 6)
                {
                    Bitmap Img2_6 = Properties.Resources.Img2_6;
                    pictureBox1.Image = Img2_6;
                    Defect_1.Text = "壁厚B";
                    Defect_2.Text = "内径Ri";
                    Defect_3.Text = "裂纹深度a";
                    Defect_1.Visible = true;
                    B_Textbox.Visible = true;
                    Unit_label1.Visible = true;
                    Defect_2.Visible = true;
                    W_Textbox.Visible = true;
                    Unit_label2.Visible = true;
                    Defect_4.Visible = false;
                    c_Textbox.Visible = false;
                    Unit_label4.Visible = false;
                    Defect_5.Visible = false;
                    P1_Textbox.Visible = false;
                    Unit_label5.Visible = false;
                }
            }
            //选择构件种类为内压球壳的页面展示
            if(component_type.SelectedIndex == 2)
            {
                Bitmap Img3_1 = Properties.Resources.Img3_1;
                pictureBox1.Image = Img3_1;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Defect_1.Text = "壁厚B";
                Defect_2.Text = "内径Ri";
                Defect_3.Text = "裂纹长度a";
                //label及textbox控制
                Defect_1.Visible = true;
                B_Textbox.Visible = true;
                Unit_label1.Visible = true;
                Defect_2.Visible = true;
                W_Textbox.Visible = true;
                Unit_label2.Visible = true;
                Defect_4.Visible = false;
                c_Textbox.Visible = false;
                Unit_label4.Visible = false;
                Defect_5.Visible = false;
                P1_Textbox.Visible = false;
                Unit_label5.Visible = false;
            }
        }

        //安全系数的获取
        private void Failure_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (Failure.SelectedIndex == 0)
                {
                    Houguo = Failure.GetItemText(Failure.SelectedItem).Trim();
                    Safety_Factor.Charateristic = 1.0;
                    Safety_Factor.Fracture_toughness = 1.1;
                    Safety_Factor.Primary_stress = 1.1;
                    Safety_Factor.Secondary_stress = 1.0;
                    //通过断裂韧度计算Kp
                    Kr.Kp = double.Parse(Fracture_Box.Text) / Safety_Factor.Fracture_toughness;
                }
                else
                {
                    Houguo = Failure.GetItemText(Failure.SelectedItem).Trim();
                    Safety_Factor.Charateristic = 1.1;
                    Safety_Factor.Fracture_toughness = 1.2;
                    Safety_Factor.Primary_stress = 1.25;
                    Safety_Factor.Secondary_stress = 1.0;
                    //通过断裂韧度计算Kp
                    Kr.Kp = double.Parse(Fracture_Box.Text) / Safety_Factor.Fracture_toughness;
                }
            }
        }

        //计算Kr与Lr
        private void Compute_button_Click(object sender, EventArgs e)
        {
            double B = double.Parse(B_Textbox.Text);
            double a = double.Parse(a_Textbox.Text);
            double c = double.Parse(c_Textbox.Text);
            double p1 = double.Parse(P1_Textbox.Text);
            double Pm = double.Parse(Pm_Box.Text);
            double Pb = double.Parse(Pb_Box.Text);
            double Qm = double.Parse(Qm_box.Text);
            double Qb = double.Parse(Qb_Box.Text);
            double Limit_s = double.Parse(Limit_Box.Text);
            if (component_type.SelectedIndex == 0)
            {
                double W = double.Parse(W_Textbox.Text);
                if (Flaw_Type.SelectedIndex == 0)
                {
                    lr = Lr.Lr_0_0(Pb, Pm, a, W, Limit_s);
                    double Kip = Kr.FixKI_1(a, Pm, Pb);
                    double Kis = Kr.FixKI_1(a, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);

                }
                if (Flaw_Type.SelectedIndex == 1)
                {
                    lr = Lr.Lr_0_1(Pb, Pm, a, Limit_s, c, B,W);
                    double Kip = Kr.FixKI_2(a, c, B, Pm, Pb);
                    double Kis = Kr.FixKI_2(a, c, B, Qm, Qb);
                    double psil =Kr.Sx(a, Kis, Limit_s);
                    double p =Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                if (Flaw_Type.SelectedIndex == 2)
                {
                    lr = Lr.Lr_0_2(Pb, Pm, a, Limit_s, c, B, p1);
                    double Kip = Kr.FixKI_3(a, c, B, Pm, Pb);
                    double Kis = Kr.FixKI_3(a, c, B, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
            }
            if (component_type.SelectedIndex == 1)
            {
                double Ri = double.Parse(W_Textbox.Text);
                // 半椭圆轴向内表面轴向裂纹
                if (Flaw_Type.SelectedIndex == 0)
                {
                    lr = Lr.Lr_1_2(Pm, a, B, Ri, Pb, Limit_s, c);
                    double Kip = Kr.FixKI_6(a, B, c, Ri, Pm, Pb);
                    double Kis = Kr.FixKI_6(a, B, c, Ri, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                // 半椭圆轴向外表面轴向裂纹
                if (Flaw_Type.SelectedIndex == 1)
                {
                    lr = Lr.Lr_1_2(Pm, a, B, Ri, Pb, Limit_s, c);
                    double Kip = Kr.FixKI_6(a, B, c, Ri, Pm, Pb);
                    double Kis = Kr.FixKI_6(a, B, c, Ri, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                // 半椭圆内表面环向裂纹
                if (Flaw_Type.SelectedIndex == 2)
                {
                    lr = Lr.Lr_1_1(Pm, a, B, Ri, Pb, Limit_s);
                    double Kip = Kr.FixKI_7(a, B, c, Ri, Pm, Pb);
                    double Kis = Kr.FixKI_7(a, B, c, Ri, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                // 椭圆埋藏轴向裂纹
                if (Flaw_Type.SelectedIndex == 3)
                {
                    lr = Lr.Lr_0_2(Pb, Pm, a, Limit_s, c, B, p1);
                    double Kip = Kr.FixKI_3(a, c, B, Pm, Pb);
                    double Kis = Kr.FixKI_3(a, c, B, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                // 椭圆埋藏环向裂纹
                if (Flaw_Type.SelectedIndex == 4)
                {
                    lr = Lr.Lr_0_2(Pb, Pm, a, Limit_s, c, B, p1);
                    double Kip = Kr.FixKI_3(a, c, B, Pm, Pb);
                    double Kis = Kr.FixKI_3(a, c, B, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                // 长2a轴向穿透裂纹
                if (Flaw_Type.SelectedIndex == 5)
                {
                    lr = Lr.Lr_1_0(Pm, Limit_s, a, Ri, B);
                    Lr_Box.Text = lr.ToString("0.##");
                    double Kip = Kr.FixKI_4(a, Ri, B, Pm, Pb);
                    double Kis = Kr.FixKI_4(a, Ri, B, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);
                }
                // 整圈内表面环向裂纹
                if (Flaw_Type.SelectedIndex == 6)
                {
                    lr = Lr.Lr_1_1(Pm,a,B,Ri,Pb,Limit_s);
                    double Kip = Kr.FixKI_5(a, Ri, B, Pm, Pb);
                    double Kis = Kr.FixKI_5(a, Ri, B, Qm, Qb);
                    double psil = Kr.Sx(a, Kis, Limit_s);
                    double p = Kr.P(lr, psil);
                    kr = Kr.Calculate_Kr(1, Kip, Kis, Kr.Kp, p);

                }
            }
            if(component_type.SelectedIndex == 2)
            {
                double Ri = double.Parse(W_Textbox.Text);
                double lr = Lr.Lr_2_0(Pb, Pm, a, B, Ri, Limit_s);
                Lr_Box.Text = lr.ToString("0.##");
            }
            Kr_Box.Text = kr.ToString("0.##");
            Lr_Box.Text = lr.ToString("0.##");
            Safety_Box.Text = Kr.shixiao(lr, kr, Lr_Ma.Lr_Max);
            ChartHelper.DrawPoint(lr, kr, chart1, Lr_Ma.Lr_Max);

        }


        // 导出报告书
        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Safety_Box.Text);
            if (Safety_Box.Text != "")
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
            if(Safety_Box.Text == "")
            {
                MessageBox.Show("请先进行计算再完成生成报告书工作");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Safety_Box.Text);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database_select_StellNumber(MySqlConnection);
        }
    }
}

