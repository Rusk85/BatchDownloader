using BatchDownloaderCore.ApiClasses;
using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiMethods
{
    /// <summary>
    /// API-Documentation: http://docs.pyload.org/module/module.Api.Api.html
    /// Tested with current beta version of pyload (0.5).
    /// Some methods are not supported by the API even though they are documented.
    /// Those were not included in this library.
    /// </summary>
    public interface IApiMethods
    {
        PackageInfo GetPackageInfo(long packageId);

        long AddPackage(params string[] links);

        long AddPackage(string relativeDestination, params string[] links);

        string Login(string username, string password);

        long GetFreeSpace();

        List<string> GetAccountTypes();

        string GetAllInfo();

        string GetAllUserData();

        Config GetConfig();

        IList<PluginConfig> GetPluginConfig();

        string GetServerVersion();

        void PauseServer();

        void Restart();

        void RestartFailed();

        void StopAllDownloads();

        bool TogglePause();

        bool ToggleReconnect();

        void UnpauseServer();
    }
}
