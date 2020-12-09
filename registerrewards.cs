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
    public partial class registerrewards : Form
    {
        private MySqlConnection conn = null;
        private MySqlCommand oleCommand1 = null;
        bool c;

        public registerrewards(string[] message, bool a)
        {
            c = a;
            InitializeComponent();
            this.conn = new MySqlConnection(school.database.connection);
            this.oleCommand1 = new MySqlCommand();
            this.oleCommand1.Connection = this.conn;

            textBox1.Text = message[0];
            textBox2.Text = message[1];
            textBox3.Text = message[2];
        }

        private void registerrewards_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == ""||textBox3.Text.Trim() == "")
                MessageBox.Show("请输入完整信息");
            else
            {
                if (c == true)
                {
                    conn.Open();
                    string sql;
                    sql = "select * from rewards where studentid='" + textBox1.Text.Trim() + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (null == cmd.ExecuteScalar())
                    {
                        sql = "insert into rewards (studentid,name,situation) values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "')";
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
                    sql = "select * from rewards where studentid='" + textBox1.Text.Trim() + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    if (null != cmd.ExecuteScalar())
                    {
                        sql = string.Format("update rewards set name='{1}',situation='{2}' where studentid='{0}'", textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim());
                        cmd.CommandText = sql;
                        int x = cmd.ExecuteNonQuery();
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
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
