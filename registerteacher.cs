﻿using System;
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
    public partial class registerteacher : Form
    {
        private MySqlConnection conn = null;
        private MySqlCommand oleCommand1 = null;
        bool c;

        public registerteacher(string[] message, bool a)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" ||
                textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
                MessageBox.Show("请输入完整信息");
            else
            {
                if (c == true)
                {
                    conn.Open();
                    string sql;
                    sql = "select * from teacher where teacherid='" + textBox1.Text.Trim() + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (null == cmd.ExecuteScalar())
                    {
                        sql = "insert into teacher (teacherid,name,sex,rank,faculty,telephone) values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "')";
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
                    sql = "select * from teacher where teacherid='" + textBox1.Text.Trim() + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (null != cmd.ExecuteScalar())
                    {
                        sql = string.Format("update teacher set name='{1}',sex='{2}',rank='{3}',faculty='{4}',telephone='{5}' where teacherid='{0}'", textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim());
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
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerteacher_Load(object sender, EventArgs e)
        {

        }
    }
}
