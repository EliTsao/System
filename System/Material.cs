using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace System
{
    public partial class Material : Form
    {
        public Material()
        {
            InitializeComponent();
        }
        //获取钢号
        public void Load_Combobox2()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            ThisSQLiteConnection.Open();
            string sql_select = "SELECT DISTINCT Stell_Number FROM MATERIAL1_TB WHERE TYPE = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'";
            SQLiteCommand SQLiteCommand = new SQLiteCommand(sql_select, ThisSQLiteConnection);
            SQLiteCommand.ExecuteNonQuery();
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(SQLiteCommand);
            DataSet dataSet = new DataSet();
            sQLiteDataAdapter.Fill(dataSet);
            comboBox2.DataSource = dataSet.Tables[0];
            comboBox2.DisplayMember = "Stell_Number";
            comboBox2.ValueMember = "Stell_Number";
            ThisSQLiteConnection.Close();

        }
        //获取设计温度
        public void Load_Combobox3()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            ThisSQLiteConnection.Open();
            string sql_select = "SELECT * FROM MATERIAL1_TB WHERE Stell_Number ='" + comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + "'" +
                "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'";
            SQLiteCommand SQLiteCommand = new SQLiteCommand(sql_select, ThisSQLiteConnection);
            SQLiteCommand.ExecuteNonQuery();
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(SQLiteCommand);
            DataSet dataSet = new DataSet();
            sQLiteDataAdapter.Fill(dataSet);
            comboBox3.DataSource = dataSet.Tables[0];
            comboBox3.DisplayMember = "Tempreture";
            comboBox3.ValueMember = "Tempreture";
            ThisSQLiteConnection.Close();
        }
        //获取厚度
        public void Load_Combobox4()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            ThisSQLiteConnection.Open();
            string sql_select = "SELECT * FROM MATERIAL1_TB WHERE Stell_Number ='" + comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + "'" +
                "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'" + "AND Tempreture = '" + comboBox3.GetItemText(comboBox3.SelectedItem).Trim() + "'";
            SQLiteCommand SQLiteCommand = new SQLiteCommand(sql_select, ThisSQLiteConnection);
            SQLiteCommand.ExecuteNonQuery();
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(SQLiteCommand);
            DataSet dataSet = new DataSet();
            sQLiteDataAdapter.Fill(dataSet);
            comboBox4.DataSource = dataSet.Tables[0];
            comboBox4.DisplayMember = "Thickness";
            comboBox4.ValueMember = "Thickness";
            ThisSQLiteConnection.Close();
        }
        //进行查询
        public void Database_select_Stress()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            //打开数据库
            ThisSQLiteConnection.Open();
            //sql语句拼接
            string sql_select1 = "SELECT * FROM MATERIAL1_TB WHERE Stell_Number='" +
                                       comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + "'" +
                                     "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'" + "AND Tempreture = '"
                                     + comboBox3.GetItemText(comboBox3.SelectedItem).Trim() + "'" + "AND Thickness ='" + comboBox4.GetItemText(comboBox4.SelectedItem).Trim() + "'";
            //执行SQLite命令操作
            SQLiteCommand SQLiteCommand = new SQLiteCommand(sql_select1, ThisSQLiteConnection);
            //更新数据库
            SQLiteCommand.ExecuteNonQuery();
            //将获取的值放置于dataset中
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(SQLiteCommand);
            DataSet dataSet = new DataSet();
            sQLiteDataAdapter.Fill(dataSet);
            //设置数据库的读取操作
            SQLiteDataReader reader = SQLiteCommand.ExecuteReader();
            //将dataset的值展示到控件上
            reader.Read();
            if (reader.HasRows)
            {
                textBox2.Text = reader["Stress"].ToString();
                textBox3.Text = reader["Rm"].ToString();
                textBox1.Text = reader["Rel"].ToString();
            }
            //关闭数据库
            reader.Close();
            ThisSQLiteConnection.Close();

        }

        public void tempreture()
        {

            string s;
            s = textBox4.Text;
            if(double.Parse(s)<=20)
            {
                Console.WriteLine(22);
            }
            else
            {
                if (double.Parse(s) < 100)
                {
                    Console.WriteLine(s);
                }
                if (double.Parse(s) >= 100)
                {
                    if(double.Parse(s) % 50 == 0)
                    {

                    }
                    else
                    {
                        double T = double.Parse(s) / 50;
                        Console.WriteLine(T);
                        Console.WriteLine("jj");
                        Console.WriteLine(Math.Ceiling(T) * 50);
                        Console.WriteLine(Math.Floor(T) * 50);
                    }
                }
            }
        }

        public static double linearInter(double x1, double x2, double y1, double y2, double x)
        {
            double y = (y1 - y2) / (x1 - x2) * x;
            return y;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Combobox2();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Combobox3();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Combobox4();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Material_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Fm = new Form2();
            Fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database_select_Stress();
            tempreture();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您确定删除当前现在材料吗？", "确认框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
                string connectionString = "Data Source=" + path;
                var ThisSQLiteConnection = new SQLiteConnection(connectionString);
                //打开数据库
                ThisSQLiteConnection.Open();
                //sql语句拼接
                string Sql_delete = "DELETE FROM MATERIAL1_TB WHERE Stell_Number='" +
                                           comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + "'" +
                                         "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'" + "AND Tempreture = '"
                                         + comboBox3.GetItemText(comboBox3.SelectedItem).Trim() + "'" + "AND Thickness ='" + comboBox4.GetItemText(comboBox4.SelectedItem).Trim() + "'";
                //执行SQLite命令操作
                SQLiteCommand SQLiteCommand = new SQLiteCommand(Sql_delete, ThisSQLiteConnection);
                //更新数据库
                SQLiteCommand.ExecuteNonQuery();
                ThisSQLiteConnection.Close();
                MessageBox.Show("材料删除成功");
                Load_Combobox2();
            }
            else
            {

            }

        }
    }
}
