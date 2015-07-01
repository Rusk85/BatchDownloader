using System.Collections.Generic;

namespace BatchDownloaderCore.ApiClasses
{
    public class Stats
    {
        public int linkstotal { get; set; }

        public int sizetotal { get; set; }

        public int linksdone { get; set; }

        public int sizedone { get; set; }
    }

    public class PackageInfo : ApiClass
    {
        public string comment { get; set; }

        public int status { get; set; }

        public int added { get; set; }

        public Stats stats { get; set; }

        public string name { get; set; }

        public List<string> tags { get; set; }

        public List<int> fids { get; set; }

        public int pid { get; set; }

        public string site { get; set; }

        public int packageorder { get; set; }

        public int owner { get; set; }

        public int shared { get; set; }

        public string folder { get; set; }

        public string password { get; set; }

        public int root { get; set; }

        public List<object> pids { get; set; }

    }
}