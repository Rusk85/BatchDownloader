using BatchDownloaderCore.ApiClasses;
using BatchDownloaderCore.ApiMethods;
using Flurl;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiCalls
{
    public class ApiCaller : IApiCaller, IApiMethods
    {

        private Url _host;
        private Url _apiEndpont;

        private IHttpClient _httpClient;

        public ApiCaller(string host, int port)
        {
            Configuration(host, port);
            _httpClient = new HttpClient();
        }

        public void Configuration(string host, int port)
        {
            _host = new Url(String.Format("http://{0}:{1}",
                host, Convert.ToString(port)));
            _apiEndpont = new Url("api");
        }

        public T CallApi<T>(ApiMethod apiMethod)
        {
            var request = prepareRequest(apiMethod);
            return _httpClient.Execute<T>(request);
        }

        public T CallApi<T>(ParameterizedApiMethod apiMethod)
        {
            var request = prepareRequest(apiMethod);
            return _httpClient.Execute<T>(request);
        }

        public void CallApi(ApiMethod apiMethod)
        {
            var request = prepareRequest(apiMethod);
            _httpClient.Execute(request);
        }

        public void CallApi(ParameterizedApiMethod apiMethod)
        {
            var request = prepareRequest(apiMethod);
            _httpClient.Execute(request);
        }

        private RequestContainer prepareRequest(ApiMethod apiMethod)
        {
            return new RequestContainer
            {
                BaseUrl = _host,
                ResourceUrl = _apiEndpont,
                MethodUrl = apiMethod.GetMethodUrl(),
                Method = Method.POST
            };
        }

        private RequestContainer prepareRequest(ParameterizedApiMethod apiMethod)
        {
            return new RequestContainer
            {
                BaseUrl = _host,
                ResourceUrl = _apiEndpont,
                MethodUrl = apiMethod.GetMethodUrl(),
                Parameters = apiMethod.GetParameters(),
                Method = Method.POST
            };
        }

        public long AddPackage(params string[] links)
        {
            return AddPackage(null, links);
        }

        public long AddPackage(string relativeDestination, params string[] links)
        {
            var ap = new AddPackage(links.Select(l => new Url(l)).ToList(), relativeDestination);
            return CallApi<long>(ap);
        }

        public PackageInfo GetPackageInfo(long packageId)
        {
            return CallApi<PackageInfo>(new GetPackageInfo(packageId));
        }

        public long GetFreeSpace()
        {
            return CallApi<long>(new GetFreeSpaceMethod());
        }

        public string Login(string username, string password)
        {
            return CallApi<string>(new Login(username, password));
        }


        public List<string> GetAccountTypes()
        {
            return CallApi<List<string>>(new GetAccountTypes());
        }

        public string GetAllInfo()
        {
            return CallApi<string>(new GetAllInfo());
        }

        public string GetAllUserData()
        {
            return CallApi<string>(new GetAllUserData());
        }

        public Config GetConfig()
        {
            return CallApi<Config>(new GetConfig());
        }

        public IList<PluginConfig> GetPluginConfig()
        {
            return CallApi<IList<PluginConfig>>(new GetPluginConfig());
        }

        public string GetServerVersion()
        {
            return CallApi<string>(new GetServerVersion());
        }

        public void PauseServer()
        {
            CallApi(new PauseServer());
        }

        public void Restart()
        {
            CallApi(new Restart());
        }

        public void RestartFailed()
        {
            CallApi(new RestartFailed());
        }

        public void StopAllDownloads()
        {
            CallApi(new StopAllDownloads());
        }

        public bool TogglePause()
        {
            return CallApi<bool>(new TogglePause());
        }

        public bool ToggleReconnect()
        {
            return CallApi<bool>(new ToggleReconnect());
        }

        public void UnpauseServer()
        {
            CallApi(new UnpauseServer());
        }
    }
}
