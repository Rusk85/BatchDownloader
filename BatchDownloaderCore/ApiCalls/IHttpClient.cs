using Flurl;
using RestSharp;
using System.Collections.Generic;

namespace BatchDownloaderCore.ApiCalls
{
    public interface IHttpClient
    {
        T Execute<T>(RequestContainer request);
    }

    public class RequestContainer
    {
        public RequestContainer()
        {
            Parameters = new List<Parameter>();
        }

        public Url BaseUrl { get; set; }

        public Url ResourceUrl { get; set; }

        public Url MethodUrl { get; set; }

        public IList<Parameter> Parameters { get; set; }

        public Method Method { get; set; }
    }
}