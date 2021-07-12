using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pocket.BOL.Methods
{
    public class Encrypt
    {
        public string EncryptPassword(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] encrypted = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(encrypted);
            }
        }
    }
}
