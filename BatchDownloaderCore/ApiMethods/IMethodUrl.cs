using BatchDownloaderCore.ApiClasses;
using Flurl;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace BatchDownloaderCore.ApiMethods
{
    public interface IMethodUrl
    {
        Url GetMethodUrl();
    }
}