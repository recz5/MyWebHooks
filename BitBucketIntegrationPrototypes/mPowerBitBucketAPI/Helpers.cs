using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mPowerBitBucketAPI
{
    public static class Helpers
    {
        public static string BitBucketGetURIBuilder(Repository repo_slug, DataSets type)
        {
            return string.Format("https://api.bitbucket.org/2.0/repositories/mpower-ondemand/{0}/{1}/", repo_slug.ToString().Replace('_','-'), type);
        }
    }
}