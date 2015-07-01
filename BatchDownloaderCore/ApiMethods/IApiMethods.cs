using BatchDownloaderCore.ApiClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiMethods
{
    public interface IApiMethods
    {
        PackageInfo GetPackageInfo(GetPackageInfoMethod packageInfoMethod);

        /// <summary>
        /// Add a new Package for downloading.
        /// </summary>
        /// <param name="addPackageMethod"></param>
        /// <returns>The package id.</returns>
        long AddPackage(AddPackageMethod addPackageMethod);

        long GetFreeSpace(GetFreeSpaceMethod getFreeSpaceMethod);

        string Login(LoginMethod loginMethod);



    }
}
