using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EgbinInstrumentInfoApp
{
    class Utility
    {
        //to hash a text: very useful for passwords
        public static String GetMD5Hash(String text)
        {
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;
            sSourceData = text;
            //Create a byte array from source data.
            tmpSource = new UTF8Encoding().GetBytes(sSourceData);

            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in tmpHash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
