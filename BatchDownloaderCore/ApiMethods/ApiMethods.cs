using BatchDownloaderCore.ApiClasses;
using Flurl;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiMethods
{

    #region Abstract Methods

    public abstract class ApiMethod : IMethodUrl
    {
        protected abstract Url methodUrl { get; }
        public Url GetMethodUrl()
        {
            return methodUrl;
        }
    }

    public abstract class ParameterizedApiMethod : IMethodUrl, IMethodParameters
    {
        protected abstract Url methodUrl { get; }
        public Url GetMethodUrl()
        {
            return methodUrl;
        }

        protected IList<Parameter> parameters;

        public IList<Parameter> GetParameters()
        {
            return parameters;
        }

        protected void addParameter(string key, object value)
        {
            parameters = parameters ?? new List<Parameter>();
            parameters.Add(new Parameter
            {
                Name = key,
                Value = value,
                Type = ParameterType.GetOrPost
            });
        }

    }

    #endregion


    #region Parameterized Api Methods

    public sealed class GetPackageInfoMethod : ParameterizedApiMethod
    {
        public GetPackageInfoMethod(long packageId)
        {
            addParameter("pid", packageId);
        }

        protected override Url methodUrl
        {
            get { return new Url("getPackageInfo"); }
        }
    }

    public sealed class AddPackageMethod : ParameterizedApiMethod
    {
        public AddPackageMethod(IList<Url> links, string relativeDestinationPath = null)
        {
            Func<string, string> trimDestination =
                dest => dest.Trim(Path.PathSeparator, '/', '\\');

            Func<IList<Url>, string> serializeList =
                l => JsonConvert.SerializeObject(l.Select(u => u.ToString()).ToList());

            Func<string, string> generatePackageName = dest => 
                JsonConvert.SerializeObject(dest != null 
                ? trimDestination(dest)
                : String.Format("{0}_{1}",
                "UnnamedPackage",
                DateTime.Now.ToString("ddMMyyyyHHmmssfff")));

            addParameter("links", serializeList(links));
            addParameter("name", generatePackageName(relativeDestinationPath));
        }

        protected override Url methodUrl
        {
            get { return new Url("addPackage"); }
        }
    }

    public sealed class LoginMethod : ParameterizedApiMethod
    {
        public LoginMethod(string username, string password)
        {
            addParameter("username", username);
            addParameter("password", password);
        }

        protected override Url methodUrl
        {
            get { return new Url("login"); }
        }
    }

    #endregion


    #region Parameterless Api Methods

    public sealed class GetServerVersionMethod : ApiMethod
    {
        protected override Url methodUrl
        {
            get { return new Url("getServerVersion"); }
        }
    }

    public sealed class GetFreeSpaceMethod : ApiMethod
    {
        protected override Url methodUrl
        {
            get { return new Url("freeSpace"); }
        }
    }


    #endregion 
}
