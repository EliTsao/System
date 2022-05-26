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
    public partial class Material : Form
    {
        private string SQL_ConnectStr = "server = 127.0.0.1; port = 3306; user = root ; password = root; database =rating_system";
        public MySqlConnection MySqlConnection;
        public Material()
        {
            InitializeComponent();  
        }

        private void Material_Load(object sender, EventArgs e)
        {
            Database_connection();
            comboBox1.SelectedIndex = 0;
            //Database_Matrial(MySqlConnection);
        }
        // 数据库连接
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


        //获取钢号
        public void Load_Comvobox2(MySqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null)
                    mySqlConnection.Open(); //打开通道
                string sql_select = "SELECT DISTINCT Stell_Number FROM MATERIAL1_TB WHERE TYPE = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim()+"'";
                MySqlCommand mySqlCommand = new MySqlCommand(sql_select, mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Stell_Number");
                comboBox2.DataSource = dataSet.Tables[0];
                comboBox2.DisplayMember = "Stell_Number";
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

        //获取温度状态
        public void Load_Combobx3(MySqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null)
                    mySqlConnection.Open(); //打开通道
                string sql_select = "SELECT * FROM MATERIAL1_TB WHERE Stell_Number ='" + comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + "'" + 
                "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(sql_select, mySqlConnection);
                //将查询结果绑定到dataview
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Tempreture");
                comboBox3.DataSource = dataSet.Tables[0];
                comboBox3.DisplayMember = "Tempreture";
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

        // 进行查询

        public void Database_select_Stress(MySqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null)
                    mySqlConnection.Open(); //打开通道
                string sql_select = "SELECT * FROM MATERIAL1_TB WHERE Stell_Number= '" +
                                       comboBox2.GetItemText(comboBox2.SelectedItem).Trim() + " '" +
                                     "AND Type = '" + comboBox1.GetItemText(comboBox1.SelectedItem).Trim() + "'" + "AND Tempreture = '"
                                     + comboBox3.GetItemText(comboBox3.SelectedItem).Trim() + "'";
                Console.WriteLine(sql_select);
                MySqlCommand mySqlCommand = new MySqlCommand(sql_select, mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "Stress"); 
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();
                textBox1.Text = reader.GetString("Stell_Number");
                textBox2.Text = reader.GetString("Thickness");
                textBox3.Text = reader.GetString("Tempreture");
                textBox4.Text = reader.GetString("Stress");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Comvobox2(MySqlConnection);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Combobx3(MySqlConnection);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Database_select_Stress(MySqlConnection);
        }
    }
}
