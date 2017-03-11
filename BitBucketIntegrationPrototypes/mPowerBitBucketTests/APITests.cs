using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mPowerBitBucketAPI.API;
using mPowerBitBucketAPI;
using System.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.Serialization;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;

namespace mPowerBitBucketTests
{
    [TestClass]
    public class APITests
    {

        [TestMethod]
        public void BitBucketGetURIBuilder_Test()
        {
            string uri = "https://api.bitbucket.org/2.0/repositories/mpower-ondemand/mto-issues/commits/";

            string helper = Helpers.BitBucketGetURIBuilder(Repository.mto_issues, DataSets.commits);

            Assert.AreEqual(uri, helper);

        }

        [TestMethod]
        public void ValidateBitbucketUser()
        {
            BitBucketUser user = new BitBucketUser();

            SecureString pwd = new SecureString();

            user.BitBucketUsername = "rvizconde";

            string userPwd = new Func<string>(() =>
            {
                string stringPwd = "";

                string path = Directory.GetCurrentDirectory() + "\\userpwd.txt";

                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            stringPwd = s;
                        }
                    }
                }
                else
                {
                    using (FileStream fs = File.Create(path))
                    {
                        stringPwd = "enter password";
                    }
                }

                return stringPwd;
            })();

            user.BitBucketPassword = new Func<SecureString>(() =>
            {
                foreach (char c in (userPwd).ToCharArray())
                    pwd.AppendChar(c);
                return pwd;
            })();

            bool test = GetRequests.ValidateCredentials(user);

            Assert.AreEqual(true, test);
        }


        [TestMethod]
        public void RunWorkFlow()
        {
            BitBucketUser user = new BitBucketUser();

            SecureString pwd = new SecureString();

            user.BitBucketUsername = "rvizconde";

            string userPwd = new Func<string>(() =>
            {
                string stringPwd = "";

                string path = Directory.GetCurrentDirectory() + "\\userpwd.txt";

                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            stringPwd = s;
                        }
                    }
                }
                else 
                {
                    using (FileStream fs = File.Create(path))
                    {
                        stringPwd = "enter password";
                    }
                }

                return stringPwd;
            })();
                
            user.BitBucketPassword = new Func<SecureString>(() =>
            {
                foreach (char c in (userPwd).ToCharArray())
                    pwd.AppendChar(c);
                return pwd;
            })();

            string uri = Helpers.BitBucketGetURIBuilder(Repository.mto_issues, DataSets.issues);

            string done = "";

            int index = 1;

            while (done != uri)
            {
                BitBucketData data = new BitBucketData(GetRequests.CallAPIUsingURL(user, uri));

                uri = data.NextPage;

                EndPoints.ToFile(string.Format("{0}_MTOIssues_Issues", index.ToString()), data);

                index++;
            }

            return;
        }
    }
}


