using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;

namespace Course
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        //  const string LoginAdmin = "admin";
        //  const string PasswordAdmin = "0000";

        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=db_hotel;port=3306");
        MySqlCommand command;
        MySqlDataAdapter da;


        string str = "server=localhost;user=root;database=db_hotel;port=3306";
        ConnectionClass conn = new ConnectionClass();

        private void button1_Click(object sender, EventArgs e)
        {
            
          //  MySqlConnection connection = new MySqlConnection(str);
            try
            {
               // connection.Open();
                conn.ConnectDB();

                string TableClean = "SELECT * FROM clean_view;";
                CleanAdapter = conn.FillDataGridViewFromSQL(TableClean, dataGridView1);
                DataCleanTable = conn.GetTable(dataGridView1, DataCleanTable);

                string TableBreakfast = "SELECT * FROM breakfast_view;";
                BreakfastAdapter = conn.FillDataGridViewFromSQL(TableBreakfast, dataGridView2);
                DataBreakfastTable = conn.GetTable(dataGridView2, DataBreakfastTable);

                string TableCustomers = "SELECT * FROM customers_view;";
                CustomersAdapter = conn.FillDataGridViewFromSQL(TableCustomers, dataGridView3);
                DataCustomersTable = conn.GetTable(dataGridView3, DataCustomersTable);

                string TableEmployees = "SELECT * FROM employees_view;";
                EmployeesAdapter = conn.FillDataGridViewFromSQL(TableEmployees, dataGridView4);
                DataEmployeesTable = conn.GetTable(dataGridView4, DataEmployeesTable);

                string TableHistory = "SELECT * FROM history_view;";
                HistoryAdapter = conn.FillDataGridViewFromSQL(TableHistory, dataGridView5);
                DataHistoryTable = conn.GetTable(dataGridView5, DataHistoryTable);

                string TableNumbers = "SELECT * FROM numbers_view;";
                NumbersAdapter = conn.FillDataGridViewFromSQL(TableNumbers, dataGridView6);
                DataNumbersTable = conn.GetTable(dataGridView6, DataNumbersTable);

                string TableNumbersCategory = "SELECT * FROM numbers_category;";
                NumbersCategoryAdapter = conn.FillDataGridViewFromSQL(TableNumbersCategory, dataGridView7);
                DataNumbersCategoryTable = conn.GetTable(dataGridView7, DataNumbersCategoryTable);

                string TableNumbersStatus = "SELECT * FROM numbers_status_view;";
                NumbersStatusAdapter = conn.FillDataGridViewFromSQL(TableNumbersStatus, dataGridView8);
                DataNumbersStatusTable = conn.GetTable(dataGridView8, DataNumbersStatusTable);

                string TablePositions = "SELECT * FROM positions;";
                PositionsAdapter = conn.FillDataGridViewFromSQL(TablePositions, dataGridView9);
                DataPositionsTable = conn.GetTable(dataGridView9, DataPositionsTable);

                string TableReservation = "SELECT * FROM reservation_view;";
                ReservationAdapter = conn.FillDataGridViewFromSQL(TableReservation, dataGridView10);
                DataReservationTable = conn.GetTable(dataGridView10, DataReservationTable);

                string TableServices = "SELECT * FROM services;";
                ServicesAdapter = conn.FillDataGridViewFromSQL(TableServices , dataGridView11);
                DataServicesTable = conn.GetTable(dataGridView11, DataServicesTable);

                string TableUsers = "SELECT * FROM users;";
                UsersAdapter = conn.FillDataGridViewFromSQL(TableUsers, dataGridView12);
                DataUsersTable = conn.GetTable(dataGridView12, DataUsersTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form AddCus = new AddCustomer();
                AddCus.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Auth = new Auth();
            this.Hide();
            Auth.Show();
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            conn.ConnectDB();
            conn.UpdateDataGridViewFromSQL(CleanAdapter, DataCleanTable, builder);
            conn.UpdateDataGridViewFromSQL(BreakfastAdapter, DataBreakfastTable, builder);
            conn.UpdateDataGridViewFromSQL(CustomersAdapter, DataCustomersTable, builder);
            conn.UpdateDataGridViewFromSQL(EmployeesAdapter, DataEmployeesTable, builder);
            conn.UpdateDataGridViewFromSQL(HistoryAdapter, DataHistoryTable, builder);
            conn.UpdateDataGridViewFromSQL(NumbersAdapter, DataNumbersTable, builder);
            conn.UpdateDataGridViewFromSQL(NumbersCategoryAdapter, DataNumbersCategoryTable, builder);
            conn.UpdateDataGridViewFromSQL(NumbersStatusAdapter, DataNumbersStatusTable, builder);
            conn.UpdateDataGridViewFromSQL(PositionsAdapter, DataPositionsTable, builder);
            conn.UpdateDataGridViewFromSQL(ReservationAdapter, DataReservationTable, builder);
            conn.UpdateDataGridViewFromSQL(ServicesAdapter, DataServicesTable, builder);
        }


        MySqlDataAdapter CleanAdapter = new MySqlDataAdapter();
        MySqlDataAdapter BreakfastAdapter = new MySqlDataAdapter();
        MySqlDataAdapter CustomersAdapter = new MySqlDataAdapter();
        MySqlDataAdapter EmployeesAdapter = new MySqlDataAdapter();
        MySqlDataAdapter HistoryAdapter = new MySqlDataAdapter();
        MySqlDataAdapter NumbersAdapter = new MySqlDataAdapter();
        MySqlDataAdapter NumbersCategoryAdapter = new MySqlDataAdapter();
        MySqlDataAdapter NumbersStatusAdapter = new MySqlDataAdapter();
        MySqlDataAdapter PositionsAdapter = new MySqlDataAdapter();
        MySqlDataAdapter ReservationAdapter = new MySqlDataAdapter();
        MySqlDataAdapter ServicesAdapter = new MySqlDataAdapter();
        MySqlDataAdapter UsersAdapter = new MySqlDataAdapter();
        MySqlDataAdapter testadapter = new MySqlDataAdapter();

        DataTable DataCleanTable = new DataTable();
        DataTable DataBreakfastTable = new DataTable();
        DataTable DataCustomersTable = new DataTable();
        DataTable DataEmployeesTable = new DataTable();
        DataTable DataHistoryTable = new DataTable();
        DataTable DataNumbersTable = new DataTable();
        DataTable DataNumbersCategoryTable = new DataTable();
        DataTable DataNumbersStatusTable = new DataTable();
        DataTable DataPositionsTable = new DataTable();
        DataTable DataReservationTable = new DataTable();
        DataTable DataServicesTable = new DataTable();
        DataTable DataUsersTable = new DataTable();
        DataTable testtable = new DataTable();

        MySqlCommandBuilder builder = new MySqlCommandBuilder();

        private void Stored_Procedures_Click(object sender, EventArgs e)
        {
            Form StoredProcedures = new StoredProcedures();
            this.Hide();
            StoredProcedures.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //if (conn.RoleCheck() == true)
            //{
            //    Update_Button.Visible = false;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form AddEm = new AddEmployees();
                AddEm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Test Photo = new Test();
            try
            {
                if (Update_Button.Visible == false)
                {
                    Photo.button2.Visible = false;
                    Photo.button4.Visible = false;
                    Photo.Show();
                    this.Hide();
                }
                else
                {
                    Photo.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    adapter = new MySqlDataAdapter("SELECT * FROM clean;", con);
        //    table = new DataTable();
        //    adapter.Fill(table);
        //    dataGridView1.DataSource = table;
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    builder = new MySqlCommandBuilder(adapter);
        //    adapter.Update(table);
        //}


    }
}
