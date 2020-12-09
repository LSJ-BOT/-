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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void 学生信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            querystudent frm = new querystudent();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击查询学生信息后进入学生信息界面
        }

        private void 添加新学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] message = new string[15];
            registerstudent frm = new registerstudent(message,true);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击添加学生后进入添加学生信息界面
        }

        private void 学生奖惩信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rewards frm = new rewards();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击学生奖惩信息后进入学生奖惩信息界面
        }

        private void 教师信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queryteacher frm = new queryteacher();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击查询教师信息后进入教师信息界面
        }

        private void 添加新教师ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] message = new string[6];
            registerteacher frm = new registerteacher(message, true);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击添加教师后进入添加教师信息界面
        }

        private void 课程信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            querycourse frm = new querycourse();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击查询课程信息后进入课程信息界面
        }

        private void 添加新课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] message = new string[6];
            registercourse frm = new registercourse(message, true);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击添加课程后进入添加课程界面
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

        private void admin_Load(object sender, EventArgs e)
        {
            
        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 班级信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classes frm = new classes();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();//点击查询班级信息后，进入班级信息界面
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

        private void 用户注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registeruser frm = new registeruser();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        
    }
}
