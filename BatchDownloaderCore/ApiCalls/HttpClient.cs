using Flurl;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiCalls
{
    public class HttpClient : IHttpClient
    {
        private IList<RestResponseCookie> _cookies;

        private RestClient _client;

        public T Execute<T>(RequestContainer request)
        {
            var response = execute(request);
            return deserializeReponse<T>(response);
        }

        public string Execute(RequestContainer request)
        {
            var response = execute(request);
            return response.Content;
        }

        private IRestResponse execute(RequestContainer request)
        {
            _client = _client ?? new RestClient(request.BaseUrl);

            var fullResourcePath = new Url(request.ResourceUrl.Path).AppendPathSegment(request.MethodUrl.Path);

            var restReq = new RestRequest(fullResourcePath, request.Method);

            if (_cookies != null)
            {
                _cookies.ToList().ForEach(c => restReq.AddCookie(c.Name, c.Value));
            }

            restReq.RequestFormat = DataFormat.Json;

            if (request.Parameters.Any())
            {
                request.Parameters.ToList().ForEach(p =>
                    restReq.AddParameter(p));
            }

            var response = _client.Execute(restReq);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (_cookies == null && response.Cookies.Any())
                {
                    _cookies = new List<RestResponseCookie>();
                    response.Cookies.ToList().ForEach(c => _cookies.Add(c));
                }
                return response;
            }
            throw new ApplicationException(String.Format("HttpRequest failed with StatusCode {0} and ErrorMessage: '{1}'",
                Enum.GetName(typeof(HttpStatusCode), response.StatusCode), response.Content));
        }

        private T deserializeReponse<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

    }
}
