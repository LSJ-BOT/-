using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace school
{
    class database
    {
        static public DataSet Connect(string strsql, MySqlConnection conn)  //执行sql语句
        {
            conn.Open();
            DataSet dataSet = new DataSet();
            MySqlDataAdapter da;
            MySqlCommand comm = new MySqlCommand(strsql, conn);
            da = new MySqlDataAdapter(strsql, conn);
            da.Fill(dataSet, "table");
            conn.Close();
            return dataSet;
        }

        static public void Show(DataGridView dataGridView, MySqlConnection conn, string tablename)  //显示表(tablename)
        {
            string strsql = "select * from " + tablename;
            dataGridView.DataSource = database.Connect(strsql, conn).Tables["table"];
        }

        public static string connection
        {
            get
            {
                return "server=localhost;user=root;database=school;port=3306;password=root;charset=utf8";
            }
        }
    }
}
