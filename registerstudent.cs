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
    public partial class registerstudent : Form
    {
        private MySqlConnection conn = null;
        private MySqlCommand oleCommand1 = null;
        bool c;

        public registerstudent(string[] message,bool a)
        {
            c = a;

            InitializeComponent();
            this.conn = new MySqlConnection(school.database.connection);
            this.oleCommand1 = new MySqlCommand();
            this.oleCommand1.Connection = this.conn;

            textBox1.Text = message[0];
            textBox2.Text = message[1];
            textBox3.Text = message[2];
            textBox4.Text = message[3];
            textBox5.Text = message[4];
            textBox6.Text = message[5];
            textBox7.Text = message[6];
            textBox8.Text = message[7];
            textBox9.Text = message[8];
            textBox10.Text = message[9];
            textBox11.Text = message[10];
            textBox12.Text = message[11];
            textBox13.Text = message[12];
            textBox14.Text = message[13];
            textBox15.Text = message[14];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" ||
                textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox8.Text.Trim() == "" ||
                textBox9.Text.Trim() == "" || textBox10.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox12.Text.Trim() == "" ||
                textBox13.Text.Trim() == "" || textBox14.Text.Trim() == ""||textBox15.Text.Trim() == "")
                MessageBox.Show("请填写完整信息！");
            else
            {
                if (c == true)
                {
                    conn.Open();
                    string sql;
                    sql = "select * from student where studentid='" + textBox1.Text.Trim() + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (null == cmd.ExecuteScalar())
                    {
                        sql = "insert into student (studentid,name,sex,college,major,classname,birthday,telephone,nation,origo,politics,idnumber,admissiondate,homeadd,zipcode) values ('" + textBox1.Text.Trim() + "'，'" + textBox2.Text.Trim() +
                            "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() +
                            "','" + textBox10.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox12.Text.Trim() + "','" + textBox13.Text.Trim() + "','" + textBox14.Text.Trim() + "','" + textBox15.Text.Trim() + "')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("确认信息完成!");
                        conn.Close();
                        button2_Click(sender, e);
                    }
                    else
                    {
                        conn.Close();
                    }
                }
                else if (c == false)
                {
                    conn.Open();
                    string sql;
                    sql = "select * from student where studentid='" + textBox1.Text.Trim() + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (null != cmd.ExecuteScalar())
                    {
                        sql = string.Format("update student set name='{1}',sex='{2}',college='{3}',major='{4}',classname='{5}',birthday='{6}',telephone='{7}',nation='{8}',origo='{9}',politics='{10}',idnumber='{11}',admissiondate='{12}',homeadd='{13}',zipcode='{14}' where studentid='{0}'", textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim(), textBox10.Text.Trim(), textBox11.Text.Trim(), textBox12.Text.Trim(), textBox13.Text.Trim(), textBox14.Text.Trim(), textBox15.Text.Trim());
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("确认信息完成!");
                        conn.Close();
                        //button2_Click(sender, e);
                    }
                    else
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text="";
        }

        private void registerstudent_Load(object sender, EventArgs e)
        {
            if (c == false)
            {
                textBox1.ReadOnly = true;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
