using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Course;
using System.Text;
using System.Security.Cryptography;

namespace Connection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Connect_true()
        {
            bool connect = true;
            ConnectionClass conn = new ConnectionClass();
            bool ex= conn.ConnectDB();
            Assert.AreEqual(connect, ex);
        }
        [TestMethod]
        public void RoleCheck_true()
        {
            ConnectionClass conn = new ConnectionClass();
            conn.ConnectDB();
            string Login = "12";
            string Password = "12";
            Password = GetHashString(Password);
            bool connect = true;
          
            bool ex = conn.RoleCheck(Login,Password,"Admin");
            Assert.AreEqual(connect, ex);
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
    }
}
