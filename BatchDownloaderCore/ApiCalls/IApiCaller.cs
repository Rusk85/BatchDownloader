using BatchDownloaderCore.ApiMethods;
using Flurl;

namespace BatchDownloaderCore.ApiCalls
{
    public interface IApiCaller
    {
        void Configuration(string host, int port);

        T CallApi<T>(ApiMethod apiMethod);

        T CallApi<T>(ParameterizedApiMethod apiMethod);

        void CallApi(ApiMethod apiMethod);

        void CallApi(ParameterizedApiMethod apiMethod);
    }
}