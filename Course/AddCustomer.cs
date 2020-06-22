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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        ConnectionClass conn = new ConnectionClass();
        private void button1_Click(object sender, EventArgs e)
        {
            string FIO = textBox1.Text;
            string Passport = textBox2.Text;
            string IdNumber = textBox3.Text;
            string IdService1 = textBox4.Text;
            string IdService2 = textBox5.Text;
            string IdService3 = textBox6.Text;
            string IdEmployees = textBox7.Text;
            string IdReservation = textBox8.Text;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            string TimeInput = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string TimeOutput = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            try
            {
                conn.ConnectDB();
                string sql = "insert into customers(FIO, Passport, Date_input, Date_output, idNumbers, idServ1, idServ2, idServ3, id_employees, id_reserv) values('" + FIO + "','" + Passport + "', '" + TimeInput + "', '" + TimeOutput + "',  '" + IdNumber + "','" + IdService1 + "', '" + IdService2 + "', '" + IdService3 + "', '" + IdEmployees + "', '" + IdReservation + "');";
                conn.ModifyQuery(sql);
                MessageBox.Show("Вы добавили клиента");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
