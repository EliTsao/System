using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Sunny.UI;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Login : UIForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            User_Textbox.Text = null;
            Password_Textbox.Text = null;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //获取密码与用户名的具体值
            var user = User_Textbox.Text;
            var password = Password_Textbox.Text;

            if (user.Equals("") || password.Equals(""))
            {
                UIMessageTip.ShowWarning("账号或密码不能为空");
            }
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "rating_system.db";
                string connectionString = "Data Source=" + path;
                var ThisSQLiteConnection = new SQLiteConnection(connectionString);
                //打开数据库
                ThisSQLiteConnection.Open();
                string SQL = "Select COUNT(1) FROM User_tb WHERE User='" + user + "'and Password ='" + password + "'";
                SQLiteCommand SQLiteCommand = new SQLiteCommand(SQL, ThisSQLiteConnection);
                int result = Convert.ToInt32(SQLiteCommand.ExecuteScalar());
                if (result > 0)
                {
                    UIMessageTip.ShowOk("登录成功");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    UIMessageTip.ShowError("账号或密码错误,登录失败");
                }
                //关闭数据库连接
                ThisSQLiteConnection.Close();
            }
        }
    }
}
