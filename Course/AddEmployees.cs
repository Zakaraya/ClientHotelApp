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
    public partial class AddEmployees : Form
    {
        public AddEmployees()
        {
            InitializeComponent();
        }
        ConnectionClass conn = new ConnectionClass();

        private void button1_Click(object sender, EventArgs e)
        {
            string FIO = textBox1.Text;
            string Age = numericUpDown1.Value.ToString();
            string Sex = comboBox1.SelectedItem.ToString();
            string Adress = textBox9.Text;
            string Phone = textBox5.Text;
            string Pasport = textBox3.Text;
            string IdPos = textBox4.Text;

            // MessageBox.Show(Age, Sex);
            AddEmployees add = new AddEmployees();

            try
            {
                conn.ConnectDB();
                string sql = "insert into employees(FIO, Age, Sex, Adress, Mobil_phone, Pasport, id_position) values('" + FIO + "','" + Age + "', '" + Sex + "', '" + Adress + "',  '" + Phone + "','" + Pasport + "', '" + IdPos + "');";

               conn.ModifyQuery(sql);
               // MessageBox.Show("Вы добавили сотрудника");
               // this.Hide();
               // add.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
