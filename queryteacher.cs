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
    public partial class queryteacher : Form
    {
        public queryteacher()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";//浏览表名

        private void queryteacher_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablename = "teacher";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "职工号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "性别";
            dataGridView1.Columns[3].HeaderText = "职称";
            dataGridView1.Columns[4].HeaderText = "院系";
            dataGridView1.Columns[5].HeaderText = "电话号码";
            //点击查询后，将所有教师信息放入datagridview1中
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from teacher";
                tablename = "teacher";
                database.Show(dataGridView1, conn, tablename);
            }//没有输入内容时，点击查询显示全部教师信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from teacher where teacherid='" + textBox1.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过职工号查询教师信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from teacher where name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过姓名查询教师信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from teacher where faculty='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过学院查询教师信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from teacher where teacherid='" + textBox1.Text.Trim() + "'and name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过职工号和姓名查询教师信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from teacher where teacherid='" + textBox1.Text.Trim() + "'and faculty='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过职工号和学院查询教师信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from teacher where name='" + textBox2.Text.Trim() + "' and faculty='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过姓名和学院查询教师信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from teacher where teacherid='" + textBox1.Text.Trim() + "'and name='" + textBox2.Text.Trim() + "' and faculty='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过职工号和姓名和学院查询教师信息

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int index = dataGridView1.CurrentCell.RowIndex;
            string teacherid = dataGridView1.Rows[index].Cells["teacherid"].Value.ToString();
            string strsql = "delete from teacher where teacherid='" + teacherid + "'";
            MySqlCommand cmd = new MySqlCommand(strsql, conn);
            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.Close();
                MessageBox.Show("删除成功");
                button1_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string[] message = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    message[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }

                registerteacher Registerteacher = new registerteacher(message, false);
                Registerteacher.Show();
            }
            catch
            {
                //MessageBox.Show("");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
