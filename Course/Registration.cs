using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        ConnectionClass conn = new ConnectionClass();
        private void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            string Name = textBox5.Text;
            string Surname = textBox3.Text;

            //Regex myReg = new Regex(@"^[a-z]\d[A-Z]\d[а-я]\d[А-Я],\-]+$");
            //if (myReg.IsMatch(Name) && myReg.IsMatch(Surname))
            //{
                if (Password != textBox4.Text)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else
                {
                    conn.ConnectDB();
                    string sql = "insert into users values('" + Login + "','" + GetHashString(Password) + "','" + Name + "','" + Surname + "', '" + 0 + "');";
                
               
                conn.ModifyQuery(sql);
                    MessageBox.Show("Пользователь успешно добавлен");
                    Form Auth = new Auth();
                    this.Hide();
                    Auth.Show();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Проверьте корректность введенных данных");
            //}
        }

        string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
    }
}
