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

        public ApiCaller(Url host, Url apiEndpoint)
        {
            Configuration(host, apiEndpoint);
            _httpClient = new HttpClient();
        }

        public void Configuration(Url host, Url apiEndpoint)
        {
            _host = host;
            _apiEndpont = apiEndpoint;
        }

        public T CallApi<T>(ApiMethod apiMethod)
        {
            var request = new RequestContainer
            {
                BaseUrl = _host,
                ResourceUrl = _apiEndpont,
                MethodUrl = apiMethod.GetMethodUrl(),
                Method = Method.POST
            };
            return _httpClient.Execute<T>(request);
        }

        public T CallApi<T>(ParameterizedApiMethod apiMethod)
        {
            var request = new RequestContainer
            {
                BaseUrl = _host,
                ResourceUrl = _apiEndpont,
                MethodUrl = apiMethod.GetMethodUrl(),
                Parameters = apiMethod.GetParameters(),
                Method = Method.POST
            };
            return _httpClient.Execute<T>(request);
        }

        public PackageInfo GetPackageInfo(GetPackageInfoMethod packageInfo)
        {
            return CallApi<PackageInfo>(packageInfo);
        }

        public long AddPackage(AddPackageMethod addPackageMethod)
        {
            return CallApi<long>(addPackageMethod);
        }

        public long GetFreeSpace(GetFreeSpaceMethod getFreeSpaceMethod)
        {
            return CallApi<long>(getFreeSpaceMethod);
        }

        public string Login(LoginMethod loginMethod)
        {
            return CallApi<string>(loginMethod);
        }

    }
}
