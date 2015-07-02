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

        public long AddPackage(params string[] links)
        {
            return AddPackage(null, links);
        }

        public long AddPackage(string relativeDestination, params string[] links)
        {
            var ap = new AddPackageMethod(links.Select(l => new Url(l)).ToList(), relativeDestination);
            return CallApi<long>(ap);
        }

        public PackageInfo GetPackageInfo(long packageId)
        {
            return CallApi<PackageInfo>(new GetPackageInfoMethod(packageId));
        }

        public long GetFreeSpace()
        {
            return CallApi<long>(new GetFreeSpaceMethod());
        }

        public string Login(string username, string password)
        {
            return CallApi<string>(new LoginMethod(username, password));
        }
    }
}
