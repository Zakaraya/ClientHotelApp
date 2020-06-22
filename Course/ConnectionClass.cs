using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace Course
{
   public class ConnectionClass
    {
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        public DataSet ds1 = new DataSet();
        public DataTable table = new DataTable();
        public static MySqlConnection connection { get; set; }

        public bool ConnectDB()
        {

            StreamReader sr = new StreamReader(@"C:\Users\Борис\Desktop\БД 4 курс\Логика клиентского приложения через класс/connectionInfo.txt");
            connection = new MySqlConnection(sr.ReadLine());
            sr.Close();
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool RoleCheck(string Login,string Pass, string Role)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("select Role from users where Login='" + Login + "' and Password='"+Pass+"'", connection);
                if (command.ExecuteScalar().ToString() == Role)
                {
                    return true;
                }
                else
                {
              //  MessageBox.Show("Ошибка при вводе данных");
                return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вводе данных");
                return false;
            }
        }


        //public bool Enter(string Login, string Password)
        //{
        //    try
        //    {
        //        MySqlCommand command = new MySqlCommand("select Login from users where Login='" + Login + "'", connection);
        //        MySqlCommand command1 = new MySqlCommand("select Password from users where Password='" + Password + "'", connection);

        //            if (command.ExecuteScalar().ToString() == Login && command1.ExecuteScalar().ToString() == Password)
        //                return true;
        //            else
        //                return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        public MySqlDataAdapter FillDataGridViewFromSQL(string sql, DataGridView dataGridView)
        {
            try
            {
                adapter = new MySqlDataAdapter(sql, connection);
                table = new DataTable();
               // BindingSource bs = new BindingSource();
                adapter.Fill(table);
              //  bs.DataSource = table;
               // bindingNavigator.BindingSource = bs;
                dataGridView.DataSource = table;
                connection.Close();
                return adapter;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                return adapter;
            }
        }


        public DataTable GetTable(DataGridView dataGridView, DataTable table)
        {
            try
            {
                table = new DataTable();
               // BindingSource bs = new BindingSource();
                adapter.Fill(table);
               // bs.DataSource = table;
               // binding.BindingSource = bs;
                dataGridView.DataSource = table;
                return table;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                return table;
            }
        }
        public void UpdateDataGridViewFromSQL(MySqlDataAdapter adapter, DataTable table, MySqlCommandBuilder builder)
        {
            try
            {
                // MySqlCommandBuilder builder = new MySqlCommandBuilder();
              //  DataTableReader reader = new DataTableReader(GetTable(dataGridView,table));
              //  table.Load(reader);
                builder = new MySqlCommandBuilder(adapter);
                adapter.Update(table);
              
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
               // return table;
            }
        }

        public void ModifyQuery(string sql)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Успешно");
                //  return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // return false;
            }
        }
        public DataTable Test(string sql)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);//запрос выполянет
            DataTable ds = new DataTable(); // данные запроса записываются в переменную
            try
            {
               
                adapter.Fill(ds);//записывает в дату сет(невидимая таблица)     

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                  return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // return false;
                return ds;
            }
        }

        public void StoredProcedureQuery(string sql, DataGridView dataGridView)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                
                dataGridView.DataSource = ds.Tables[0];
                connection.Close();
                //  return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // return false;
            }
        }
    }
}
