using BatchDownloaderCore.ApiClasses;
using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiMethods
{
    public interface IApiMethods
    {
        PackageInfo GetPackageInfo(long packageId);

        long AddPackage(params string[] links);

        long AddPackage(string relativeDestination, params string[] links);

        long GetFreeSpace();

        string Login(string username, string password);
    }
}
