using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mPowerBitBucketAPI
{
    public class BitBucketData
    {
        private string _next = string.Empty;
        private JArray _values = new JArray();
        private Encoding _encoding = ASCIIEncoding.ASCII;
        private HttpWebResponse _metaData;
        private JObject _deserialisedObject;

        public BitBucketData(HttpWebResponse httpWebResponse)
        {
            if (httpWebResponse == null)
                throw new ArgumentNullException("HttpWebResponse parameter is null...");

            _metaData = httpWebResponse;

            using (var reader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), _encoding))
            {
                _deserialisedObject = JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd());
            }

            _values = _deserialisedObject["values"] == null ? null : _deserialisedObject["values"].ToObject<JArray>();

            _next = _deserialisedObject["next"] == null ? string.Empty : _deserialisedObject["next"].ToObject<string>();

        }

        public String Source
        {
            get { return _metaData.ResponseUri.AbsoluteUri; }
        }

        public JArray Values
        {
            get { return _values; }
        }

        public String NextPage
        {
            get { return _next; }
        }

        public HttpWebResponse MetaData
        {
            get { return _metaData; }
        }
    }
}
