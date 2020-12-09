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
    public partial class rewards : Form
    {
        public rewards()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";//浏览表名

        private void rewards_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (textBox1.Text.Trim().Length == 0&&textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from rewards";
                tablename = "rewards";
                database.Show(dataGridView1, conn, tablename);
            }

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from rewards where studentid='" + textBox1.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }

            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from rewards where name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }

            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from rewards where studentid='" + textBox1.Text.Trim() + "' and name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int index = dataGridView1.CurrentCell.RowIndex;
            string studentid = dataGridView1.Rows[index].Cells["studentid"].Value.ToString();
            string strsql = "delete from rewards where studentid='" + studentid + "'";
            MySqlCommand cmd = new MySqlCommand(strsql, conn);
            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.Close();
                MessageBox.Show("删除成功");
                button1_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string[] message = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    message[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }

                registerrewards newregisterrewards = new registerrewards(message, false);
                newregisterrewards.ShowDialog();
            }
            catch
            {
                //MessageBox.Show("");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] message = new string[3];
            registerrewards newregisterrewards = new registerrewards(message, true);
            newregisterrewards.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tablename = "rewards";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "奖惩情况";
            //点击查询后，将奖惩信息表放入datagridview1中
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
