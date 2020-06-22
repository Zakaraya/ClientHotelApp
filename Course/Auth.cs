using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Course
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
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

        private void Auth_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }
        private string text = String.Empty;
        const string Login_Admin = "admin";
        const string Password_Admin = "12";
        ConnectionClass conn = new ConnectionClass();


        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = Width / 5;
            int Ypos = Height / 3;

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Заливаем фон
            this.pictureBox1.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            //Сгенерируем текст
            text = String.Empty;
            Regex reg4 = new Regex("[a-z][A-Z][0-9]");
            string AlfSym = "abcdefghiklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        search:

            string rezult = "";

            for (int i = 0; i < 4; ++i)
            {
                rezult += AlfSym[rnd.Next(AlfSym.Length)];
            }
            if (reg4.IsMatch(rezult))
            {
                text = rezult;
            }
            else
            {
                goto search;
            }

            //Нарисуем сгенирируемый текст
            g.DrawString(text, new Font("Arial", 23, System.Drawing.FontStyle.Italic), Brushes.Black, new PointF(Xpos, Ypos));

            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);
            return result;
        }
        MainForm form1 = new MainForm();
        Test test = new Test();
        private void button1_Click(object sender, EventArgs e)
        {
            string Login_Check = textBox1.Text;
            string Password_Check = textBox2.Text;
            Password_Check = GetHashString(Password_Check);
            conn.ConnectDB();
            try
            {
                if (textBox3.Text == null || textBox1.Text == null || textBox2.Text == null)
                {
                    MessageBox.Show("Ошибка при вводе данных!!!");
                }
                else
                {
                    if (conn.RoleCheck(Login_Check, Password_Check, "Admin") == true)
                    {
                        if (textBox3.Text == this.text)
                        {
                            MessageBox.Show("Вы зашли как Админ");
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Проверьте капчу");
                        }
                    }

                    else if  (conn.RoleCheck(Login_Check, Password_Check, "User") == true)
                    {
                        if (textBox3.Text == this.text)
                        {
                            form1.Show();
                            form1.Update_Button.Visible = false;
                            //TabControl1.TabPages(0).Enabled = false
                            form1.button2.Visible = false;
                            form1.tabPage12.Parent = null;
                            form1.button4.Visible = false;
                            //test.button2.Visible = false;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Проверьте капчу");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
            }
            else
            {
                textBox2.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Registration = new Registration();
            this.Hide();
            Registration.Show();
        }
    }
}
