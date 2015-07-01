using Flurl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore
{
    public static class SerializationHelper
    {

        public static string Serialize(IList<Url> urls)
        {
            var urlsAsStrings = urls.Select(u => u.ToString()).ToList();
            return JsonConvert.SerializeObject(urlsAsStrings);
        }


    }
}
