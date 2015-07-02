using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiClasses
{
    public class PluginConfig
    {
        public string category { get; set; }
        public bool user_context { get; set; }
        public string description { get; set; }
        public bool? activated { get; set; }
        public string label { get; set; }
        public string name { get; set; }
    }
}
