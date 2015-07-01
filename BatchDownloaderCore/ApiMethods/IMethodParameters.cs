using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiMethods
{
    public interface IMethodParameters
    {
        IList<Parameter> GetParameters();
    }
}
