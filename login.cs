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

namespace school
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        MySqlConnection conn;

        private void login_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        public static string studentid = "";
        public static string teacherid = "";

        public static string username = "";
        public static string password1 = "";
        
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string strsql = string.Format("select * from user where username='{0}' and password='{1}'", name.Text, password.Text);
            DataSet dataset = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(strsql,conn);
            conn.Close();
            da.Fill(dataset,"123");

            if (dataset.Tables[0].Rows.Count > 0)
            {
                username = dataset.Tables[0].Rows[0]["username"].ToString();
                password1 = dataset.Tables[0].Rows[0]["password"].ToString();

                if(dataset.Tables[0].Rows[0]["power"].ToString() == "管理员")
                {
                    if (radioButton1.Checked)
                    {
                        admin Admin = new admin();
                        Admin.Show();
                        this.Hide();
                        //this.DialogResult = DialogResult.OK; //返回一个登录成功的对话框状态
                        //this.Close(); //关闭登录窗口
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在或未按照要求参加教学活动！！");
                    }
                }
                if (dataset.Tables[0].Rows[0]["power"].ToString() == "老师")
                {
                    if (radioButton2.Checked)
                    {
                        teacherid = dataset.Tables[0].Rows[0]["username"].ToString();
                        teacher Teacher = new teacher();
                        Teacher.Show();
                        this.Hide();
                        //this.DialogResult = DialogResult.OK;//返回一个登陆成功的对话框状态
                        //this.Close();//关闭登陆窗口
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在或未按照要求参加教学活动！！");
                    }
                }
                if (dataset.Tables[0].Rows[0]["power"].ToString() == "学生")
                {
                    if (radioButton3.Checked)
                    {
                        studentid = dataset.Tables[0].Rows[0]["username"].ToString();
                        student Student = new student();
                        //this.DialogResult = DialogResult.OK;//返回一个登陆成功的对话框状态
                        Student.Show();
                        this.Hide();
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户名不存在或未按照要求参加教学活动！！");
                    }
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误！！！");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
