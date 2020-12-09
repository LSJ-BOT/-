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
    public partial class querycourse : Form
    {
        public querycourse()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";//浏览表名

        private void querycourse_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablename = "course";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "课程号";
            dataGridView1.Columns[1].HeaderText = "课程名";
            dataGridView1.Columns[2].HeaderText = "课程类型";
            dataGridView1.Columns[3].HeaderText = "学分";
            dataGridView1.Columns[4].HeaderText = "学时";
            dataGridView1.Columns[5].HeaderText = "考核方式";
            //点击查询后，将所有课程信息放入datagridview1中
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from course";
                tablename = "course";
                database.Show(dataGridView1, conn, tablename);
            }//没有输入内容时，点击查询显示全部课程信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from course where courseno='" + textBox1.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过课程查询课程信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from course where coursename='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过课程名查询课程信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from course where courseno='" + textBox1.Text.Trim() + "' and coursename='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过课程名和课程号查询课程信息

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int index = dataGridView1.CurrentCell.RowIndex;
            string courseno = dataGridView1.Rows[index].Cells["courseno"].Value.ToString();
            string strsql = "delete from course where courseno='" + courseno + "'";
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

                registercourse Registercourse = new registercourse(message, false);
                Registercourse.Show();
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
