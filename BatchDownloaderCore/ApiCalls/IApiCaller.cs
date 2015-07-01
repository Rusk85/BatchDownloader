using BatchDownloaderCore.ApiMethods;
using Flurl;

namespace BatchDownloaderCore.ApiCalls
{
    public interface IApiCaller
    {
        void Configuration(Url host, Url apiEndpoint);

        T CallApi<T>(ApiMethod apiMethod);

        T CallApi<T>(ParameterizedApiMethod apiMethod);
    }
}