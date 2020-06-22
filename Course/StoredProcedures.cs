using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course
{
    public partial class StoredProcedures : Form
    {
        public StoredProcedures()
        {
            InitializeComponent();
        }
        ConnectionClass conn = new ConnectionClass();
        private void button1_Click(object sender, EventArgs e)
        {
            string InNumberCustomer = "call number_customers('" + comboBox3.SelectedItem+ "');";
            conn.ConnectDB();
            conn.StoredProcedureQuery(InNumberCustomer, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string InCustomerNumber = "call customers_number('" + comboBox1.SelectedItem + "');";
            conn.ConnectDB();
            conn.StoredProcedureQuery(InCustomerNumber, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string InEmpoyeesPosition = "call employees_position('" + comboBox2.SelectedItem + "');";
            conn.ConnectDB();
            conn.StoredProcedureQuery(InEmpoyeesPosition, dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            string TimeInput = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string InDateInput = "call date_input_customers('" + TimeInput + "');";
            conn.ConnectDB();
            conn.StoredProcedureQuery(InDateInput, dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string InInput = "call Check_output_customers_in_family('" + comboBox4.SelectedItem + "');";
            conn.ConnectDB();
            conn.StoredProcedureQuery(InInput, dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form Auth = new Auth();
            Auth.Show();
            this.Hide();
        }

        private void StoredProcedures_Load(object sender, EventArgs e)
        {
            conn.ConnectDB();
            DataTable dt = new DataTable();
            dt = conn.Test("SELECT numbers_room FROM numbers_category;");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["numbers_room"]);
            }


            DataTable dt1 = new DataTable();
            dt1 = conn.Test("SELECT name_position FROM positions;");

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt1.Rows[i]["name_position"]);
            }

            DataTable dt2 = new DataTable();
            dt2 = conn.Test("SELECT FIO FROM customers;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox3.Items.Add(dt2.Rows[i]["FIO"]);
            }
            DataTable dt3 = new DataTable();
            dt3 = conn.Test("SELECT FIO FROM customers;");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox4.Items.Add(dt3.Rows[i]["FIO"]);
            }


        }
    }
}
