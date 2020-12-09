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
    public partial class studentgrade : Form
    {
        public studentgrade()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        string tablename = "";

        private void studentgrade_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;user=root;database=school;password=root;port=3306;charset=utf8";
            conn = new MySqlConnection(connString);//连接数据库
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablename = "grade";
            database.Show(dataGridView1, conn, tablename);

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "课程号";
            dataGridView1.Columns[3].HeaderText = "成绩";
            
            //点击查询后，将所有人成绩表放入datagridview1中
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from grade";
                tablename = "grade";
                database.Show(dataGridView1, conn, tablename);
            }
            else if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length == 0)
            {
                sqlstr = "select * from grade where studentid='" + textBox1.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }
            else if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length != 0)
            {
                sqlstr = "select * from grade where name='" + textBox2.Text.Trim() + "'";
                dataGridView1.DataSource = database.Connect(sqlstr, conn).Tables["table"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] message = new string[4];
            registergrade newregistergrade = new registergrade(message, true);
            newregistergrade.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                string[] message = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    message[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                }

                registergrade newregistergrade = new registergrade(message, false);
                newregistergrade.ShowDialog();
            }
            catch
            {
                //MessageBox.Show("");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            int index = dataGridView1.CurrentCell.RowIndex;
            string studentid = dataGridView1.Rows[index].Cells["studentid"].Value.ToString();
            string courseno = dataGridView1.Rows[index].Cells["courseno"].Value.ToString();
            string strsql = "delete from grade where studentid='" + studentid + "' and courseno='" + courseno + "'";
            MySqlCommand cmd = new MySqlCommand(strsql, conn);
            if (cmd.ExecuteNonQuery() == 1)
            {
                conn.Close();
                MessageBox.Show("删除成功");
                button1_Click(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
