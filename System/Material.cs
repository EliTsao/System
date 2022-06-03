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
            comboBox1.SelectedIndex = 0;
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
            comboBox2.SelectedIndex = 0;

        }
        //获取设计温度
        public void Load_Combobox3()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            ThisSQLiteConnection.Open();
            Console.WriteLine(comboBox2.GetItemText(comboBox2.SelectedItem).Trim());
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
        }
        //进行查询
        public void Database_select_Stress()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
            string connectionString = "Data Source=" + path;
            var ThisSQLiteConnection = new SQLiteConnection(connectionString);
            ThisSQLiteConnection.Open();
            string sql_select1 = "SELECT * FROM MATERIAL1_TB WHERE Stell_Number='" +
                                       comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + "'" +
                                     "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'" + "AND Tempreture = '"
                                     + comboBox3.GetItemText(comboBox3.SelectedItem).Trim() + "'";
            SQLiteCommand SQLiteCommand = new SQLiteCommand(sql_select1, ThisSQLiteConnection);
            SQLiteCommand.ExecuteNonQuery();
            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(SQLiteCommand);
            DataSet dataSet = new DataSet();
            sQLiteDataAdapter.Fill(dataSet);
            SQLiteDataReader reader = SQLiteCommand.ExecuteReader();
            
            reader.Read();
            if (reader.HasRows)
            {
                textBox1.Text = reader["Stell_Number"].ToString();
                textBox3.Text = reader["Thickness"].ToString();
                textBox4.Text = reader["Tempreture"].ToString();
                textBox2.Text = reader["Stress"].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Combobox2();
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Combobox3();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database_select_Stress();
        }
    }
}
