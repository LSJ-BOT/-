using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace school
{
    public partial class modifypassword : Form
    {
        private MySqlConnection conn = null;
        private MySqlCommand oleCommand1 = null;

        public modifypassword()
        {
            InitializeComponent();
            this.conn = new MySqlConnection(school.database.connection);
            this.oleCommand1 = new MySqlCommand();
            this.oleCommand1.Connection = this.conn;
        }

        private void modifypassword_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0)
                MessageBox.Show("不能为空");
            else
            {
                if (textBox1.Text.Trim() == login.password1)
                {
                    conn.Open();
                    string sql = "";
                    if (textBox2.Text.Trim() == textBox3.Text.Trim())
                    {
                        sql = string.Format("update user set password='{0}' where username='{1}'", textBox2.Text.Trim(), login.username);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("密码修改成功!");
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("两次密码不相同！");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
