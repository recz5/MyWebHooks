using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace mPowerBitBucketAPI
{
    public class BitBucketUser
    {
        private string _userName = string.Empty;

        private SecureString _securePwd = new SecureString();

        public string BitBucketUsername 
        {
            get { return _userName; }

            set { _userName = value; }
        }

        public SecureString BitBucketPassword
        {
            get { return _securePwd; }

            set { _securePwd = value; }
        }

        public string BasicAuthAPIHeader
        {
            get 
            {
                string pairedValues = BitBucketUsername + ":" + Marshal.PtrToStringUni(Marshal.SecureStringToGlobalAllocUnicode(BitBucketPassword));

                return System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(pairedValues));
            }
        }
    }
}
