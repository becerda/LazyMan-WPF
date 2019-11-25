using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyManWPF.Util
{
    class Encryption
    {

        private static readonly string key = "99lhkj";

        public static string Encrypt(string str)
        {
            StringBuilder sb = new StringBuilder();

            int lenstr = str.Length;
            int lenkey = key.Length;

            int i = 0;
            for (int j = 0; i < lenstr; j++)
            {
                if(j >= lenkey)
                {
                    j = 0;
                }
                sb[i] = (char)(str[i] ^ key[j]);
                i++;
            }

            return sb.ToString();
        }

        public static string Decrypt(string str)
        {
            return Encrypt(str);
        }

        private static string Randomize(string chars)
        {
            StringBuilder salt = new StringBuilder();
            Random r = new Random();
            while(salt.Length < chars.Length)
            {
                int idx = (int)(r.NextDouble() * chars.Length);
                salt.Append(chars[idx]);
            }

            return salt.ToString();
        }

        public static string GetSaltString()
        {
            string SALTCHARS = Randomize("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
            StringBuilder salt = new StringBuilder();
            Random r = new Random();
            while(salt.Length < 241)
            {
                int idx = (int)(r.NextDouble() * SALTCHARS.Length);
                salt.Append(SALTCHARS[idx]);
            }

            return salt.ToString();
        }

    }
}
