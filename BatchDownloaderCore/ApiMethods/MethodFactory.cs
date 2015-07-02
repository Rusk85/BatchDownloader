//using Flurl;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BatchDownloaderCore.ApiMethods
//{

//    public interface IMethodFactoy
//    {
//        IMethodUrl GetMethod(PyloadMethods method);
//        IParameterizedMethod GetMethod<T>(params object[] parameters) 
//            where T : IParameterizedMethod;
//    }

//    public enum PyloadMethods
//    {
//        getFreeSpace = 1,
//        getAccountTypes = 2,
//        getAllInfo = 3,
//        getAllUserData = 4,
//        getConfig = 5,
//        getPluginConfig = 6,
//        getServerVersion = 7,
//        pauseServer = 8,
//        restart = 9,
//        restartFailed = 10,
//        stopAllDownloads = 11,
//        togglePause = 12,
//        toggleReconnect = 13,
//        unpauseServer = 14,
//    }


//    internal enum ParametrizedMethods
//    {
//        AddPackage = 1,
//        GetPackageInfo = 2,
//    }

//    public class MethodFactory : IMethodFactoy
//    {

//        private Dictionary<PyloadMethods, Url> _parameterlessMethodDictionary =
//            new Dictionary<PyloadMethods, Url>()
//            {
//                {PyloadMethods.getFreeSpace, new Url("freeSpace")},
//                {PyloadMethods.getAccountTypes, new Url("getAccountTypes")},
//                {PyloadMethods.getAllInfo, new Url("getAllInfo")},
//                {PyloadMethods.getAllUserData, new Url("getAllUserData")},
//                {PyloadMethods.getConfig, new Url("getConfig")},
//                {PyloadMethods.getPluginConfig, new Url("getPluginConfig")},
//                {PyloadMethods.getServerVersion, new Url("getServerVersion")},
//                {PyloadMethods.pauseServer, new Url("pauseServer")},
//                {PyloadMethods.restart, new Url("restart")},
//                {PyloadMethods.restartFailed, new Url("restartFailed")},
//                {PyloadMethods.stopAllDownloads, new Url("stopAllDownloads")},
//                {PyloadMethods.togglePause, new Url("togglePause")},
//                {PyloadMethods.toggleReconnect, new Url("toggleReconnect")},
//                {PyloadMethods.unpauseServer, new Url("unpauseServer")},
//            };

//        private Dictionary<ParametrizedMethods, Url> _parametrizedMethodDictionary =
//            new Dictionary<ParametrizedMethods, Url>()
//            {
//                {ParametrizedMethods.AddPackage, new Url("addPackage")},
//                {ParametrizedMethods.GetPackageInfo, new Url("getPackageInfo")},
//            };

//        public IMethodUrl GetMethod(PyloadMethods method)
//        {
//            var m = new ParameterlessMethod();
//            m.SetMethod(getMethodUrl(method));
//            return m;
//        }


//        private Url getMethodUrl(PyloadMethods method)
//        {
//            return _parameterlessMethodDictionary[method];
//        }

//        private Url getMethodUrl(ParametrizedMethods method)
//        {
//            return _parametrizedMethodDictionary[method];
//        }

//        public IParameterizedMethod GetMethod<T>(params object[] parameterList) 
//            where T : IParameterizedMethod
//        {
//            if (typeof(T) == typeof(AddPackage))
//            {
//                var links = (parameterList[0] as List<Url>);
//                var path = parameterList.Length == 2 ? (parameterList[1] as string) : null;
//                //var m = new AddPackage(links, path);
//            }
//            return null;
//        }

//    }


//}
