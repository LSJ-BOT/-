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
    public partial class querystudent : Form
    {
        public querystudent()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";//浏览表名

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Querystudent_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8;";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablename = "student";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "性别";
            dataGridView1.Columns[3].HeaderText = "院系";
            dataGridView1.Columns[4].HeaderText = "专业";
            dataGridView1.Columns[5].HeaderText = "班级名";
            dataGridView1.Columns[6].HeaderText = "出生日期";
            dataGridView1.Columns[7].HeaderText = "电话号码";
            dataGridView1.Columns[8].HeaderText = "民族";
            dataGridView1.Columns[9].HeaderText = "籍贯";
            dataGridView1.Columns[10].HeaderText = "政治面貌";
            dataGridView1.Columns[11].HeaderText = "身份证号码";
            dataGridView1.Columns[12].HeaderText = "入学时间";
            dataGridView1.Columns[13].HeaderText = "家庭地址";
            dataGridView1.Columns[14].HeaderText = "邮政编码";

            //点击查询后，将所有学生信息放入datagridview1中
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from student";
                tablename = "student";
                database.Show(dataGridView1, conn, tablename);
            }//没有输入内容时，点击查询显示全部学生信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from student where studentid='"+textBox1.Text.Trim()+"'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过学号查找学生信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from student where name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过姓名查找学生信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from student where major='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过专业查找学生信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length == 0)
            {
                sqlstr = "select * from student where studentid='" + textBox1.Text.Trim() + "' and name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过学号和姓名查找学生信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from student where studentid='" + textBox1.Text.Trim() + "' and major='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过学号和专业查找学生信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from student where name='" + textBox2.Text.Trim() + "' and major='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过姓名和专业查找学生信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0 && textBox3.Text.Trim().Length != 0)
            {
                sqlstr = "select * from student where studentid='" + textBox1.Text.Trim() + "' and name='" + textBox2.Text.Trim() + "' and major='" + textBox3.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过学号和姓名和专业查找学生信息
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int index = dataGridView1.CurrentCell.RowIndex;
            string studentid = dataGridView1.Rows[index].Cells["studentid"].Value.ToString();
            string strsql = "delete from student where studentid='" + studentid + "'";
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
                string[] message = new string[15];
                for (int i = 0; i < message.Length; i++)
                {
                    message[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }

                registerstudent newregisterstudent = new registerstudent(message, false);
                newregisterstudent.Show();
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
