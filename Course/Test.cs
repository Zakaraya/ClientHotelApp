using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=db_hotel;port=3306");
        ConnectionClass conn = new ConnectionClass();
        

        private void button1_Click(object sender, EventArgs e)
        {

            Test test = new Test();
            this.Hide();
            test.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectDB();
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                filePath=filePath.Replace(@"\", "\\\\");
              //  MessageBox.Show(filePath);
                string sql = "insert into test(photo) values('"+ filePath.Replace(@"\", "\\") +"');";
                conn.ModifyQuery(sql);
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            conn.ConnectDB();
            string sql = "SELECT * FROM test;";
            testadapter = conn.FillDataGridViewFromSQL(sql, dataGridView1);
            testtable = conn.GetTable(dataGridView1, testtable);
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "PhotoRoom";
            dataGridView1.Columns.Add(img);

            for (int i = 0; i < (dataGridView1.RowCount-1); i++)
            {
                string a = dataGridView1.Rows[i].Cells[1].Value.ToString();
                Image im = Image.FromFile(a);
                dataGridView1.Rows[i].Cells["PhotoRoom"].Value = im;
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Rows[i].Height = 400;
            }

            dataGridView1.Columns.RemoveAt(0);
            //dataGridView1.Columns.RemoveAt(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Auth = new Auth();
            this.Hide();
            Auth.Show();
        }

        DataTable testtable = new DataTable();
        MySqlCommandBuilder builder = new MySqlCommandBuilder();
        MySqlDataAdapter testadapter = new MySqlDataAdapter();

       

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            conn.ConnectDB();
            string sql = "SELECT * FROM test;";
            testadapter = conn.FillDataGridViewFromSQL(sql, dataGridView1);
            testtable = conn.GetTable(dataGridView1, testtable);
        
            //string s = dataGridView1.CurrentCell.Value.ToString();
            //string sql = "delete from test where id='"+ dataGridView1.CurrentCell.ColumnIndex.ToString() +"' ";
            ////DELETE FROM `table_name` WHERE `id`= 'id'
            //conn.ModifyQuery(sql);
            //MessageBox.Show(s);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.UpdateDataGridViewFromSQL(testadapter, testtable, builder);
        }
    }
}
