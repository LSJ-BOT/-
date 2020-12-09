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
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";//浏览表名

        private void teacher_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.Width = 600; dataGridView1.Height = 100;
            dataGridView1.Location = new Point(0, 0);
            this.panel1.Controls.Add(dataGridView1);

            string sql = "";
            sql = "select * from teacher  where teacherid='" + login.teacherid + "'";
            dataGridView1.DataSource = database.Connect(sql, conn).Tables["table"];

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "职工号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "性别";
            dataGridView1.Columns[3].HeaderText = "职称";
            dataGridView1.Columns[4].HeaderText = "院系";
            dataGridView1.Columns[5].HeaderText = "电话号码";
            //点击查询个人信息后，将个人信息放入datagridview1中
        }

        private void 查询课程信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.Width = 600; dataGridView1.Height = 200;
            dataGridView1.Location = new Point(0, 0);
            this.panel1.Controls.Add(dataGridView1);

            tablename = "course";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "课程号";
            dataGridView1.Columns[1].HeaderText = "课程名";
            dataGridView1.Columns[2].HeaderText = "课程类型";
            dataGridView1.Columns[3].HeaderText = "学分";
            dataGridView1.Columns[4].HeaderText = "学时";
            dataGridView1.Columns[5].HeaderText = "考核方式";
            //点击查询课程信息后，将课程信息放入datagridview1中
        }
        private void 学生成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentgrade frm = new studentgrade();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();
            

            //点击学生成绩按钮后，进入学生成绩界面
        }
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifypassword frm = new modifypassword();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击修改密码后跳转到修改密码界面
        }

        private void teacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 账号切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            login newlogin = new login();
            newlogin.StartPosition = FormStartPosition.CenterParent;
            newlogin.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
