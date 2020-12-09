using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace school
{
    public partial class classes : Form
    {
        public classes()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";//浏览表名

        private void classes_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8;";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from classes";
                tablename = "classes";
                database.Show(dataGridView1, conn, tablename);
            }//没有输入内容时，点击查询显示全部班级信息
            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from classes where college='" + textBox1.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过学院查找班级信息

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from classes where classname='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过班级查找班级信息

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from classes where college='" + textBox1.Text.Trim() + "' and classname='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }//通过班级和学院查找班级信息
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablename = "classes";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "班级名";
            dataGridView1.Columns[1].HeaderText = "院系";
            dataGridView1.Columns[2].HeaderText = "辅导员";
            dataGridView1.Columns[3].HeaderText = "人数";
            //点击查询后，将所有班级信息放入datagridview1中
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
