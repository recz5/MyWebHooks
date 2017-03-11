using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace mPowerBitBucketAPI.API
{
    public static class GetRequests
    {
        public static bool ValidateCredentials(BitBucketUser account)
        {
            try
            {
                WebRequest request = WebRequest.Create("https://api.bitbucket.org/2.0/user");

                request.Headers.Add("Authorization", "Basic " + account.BasicAuthAPIHeader);

                if (request.GetResponse() == null)
                    return false;

                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public static HttpWebResponse CallAPIUsingURL(BitBucketUser account, string url)
        {
            WebRequest request = WebRequest.Create(url);

            request.Headers.Add("Authorization", "Basic " + account.BasicAuthAPIHeader);

            return (HttpWebResponse)request.GetResponse();
        }
    
    }
}
