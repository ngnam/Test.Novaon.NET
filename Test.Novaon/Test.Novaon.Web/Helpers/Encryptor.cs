using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test.Novaon.Web.Helpers
{
    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            string password = string.Empty;
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();

                //compute hash from the bytes of text  
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

                //get hash result after compute it  
                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits  
                    //for each byte  
                    strBuilder.Append(result[i].ToString("x2"));
                }
                password = strBuilder.ToString();
            }
            catch
            {
            }
            return password;
        }
    }
}
