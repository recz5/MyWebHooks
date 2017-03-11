using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mPowerBitBucketAPI
{
    public static class EndPoints
    {
        public static void ToFile(string fileName, BitBucketData data)
        {
            string path = string.Format("{0}\\{1}.json", Directory.GetCurrentDirectory(), fileName);

            if (File.Exists(path))
                File.Delete(path);

            using (FileStream fs = File.Create(path))
            {
                fs.Close();

                File.WriteAllText(path, JsonConvert.SerializeObject(data.Values, Formatting.Indented));
            }
        }
    }
}
