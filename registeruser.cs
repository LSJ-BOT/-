using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace school
{
    public partial class registeruser : Form
    {
        public registeruser()
        {
            InitializeComponent();
        }
        MySqlConnection conn;

        private void registeruser_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0)
                MessageBox.Show("请输入完整信息！");
            else
            {
                if (textBox1.Text.Trim().Length != 0 || textBox2.Text.Trim().Length != 0 || textBox3.Text.Trim().Length != 0)
                {
                    conn.Open();
                    string sql = "";
                    sql = string.Format("insert into user (username,password,power) values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "')");
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("用户注册成功!");
                        conn.Close();
                    }
                    button3_Click(sender, e);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }
    }
}
