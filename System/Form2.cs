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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            //查询数据库中是否有与输入数据相同的数据列的SQL语句
            string sql = "SELECT count(*) FROM MATERIAL1_TB WHERE Stell_Number='" + textBox2.Text + "'AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() 
                                     + "'AND Tempreture = '" + textBox1.Text + "'AND Thickness ='" + textBox6.Text + "'AND State='" + textBox5.Text + "'AND Stress ='" + textBox7.Text + "'AND Rm='"
                                     + textBox9.Text + "'AND Rel='" + textBox8.Text + "'";
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            ThisSQLiteConnection.Open();
            //向数据库中添加数据的SQL的语句
            string sql_insert = "INSERT INTO material1_tb VALUES('" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "','" +
                                     textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','"
                                     + textBox9.Text + "','" + textBox8.Text + "');";
            SQLiteCommand sQLite = new SQLiteCommand(sql, ThisSQLiteConnection);
            //判断数据库中相同数据数量，若大于0，则弹出错误提示，否则则提示添加正确
            if(Convert.ToInt32(sQLite.ExecuteScalar())>0)
            {
                MessageBox.Show("当前材料参数已被添加，请重新输入");
            }
            else
            {
                Console.WriteLine(sQLite.ExecuteNonQuery());
                SQLiteCommand SQLiteCommand = new SQLiteCommand(sql_insert, ThisSQLiteConnection);
                SQLiteCommand.ExecuteNonQuery();
                MessageBox.Show("添加完成");
                this.Dispose();
                this.Close();
            }
            ThisSQLiteConnection.Close();
        }
    }
}
