using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchDownloaderCore.ApiClasses
{
    public class Input
    {
        public object default_value { get; set; }

        public object data { get; set; }

        public int type { get; set; }
    }

    public class Item
    {
        public string description { get; set; }

        public string value { get; set; }

        public string label { get; set; }

        public Input input { get; set; }

        public string name { get; set; }
    }

    public class Log
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class Permission
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class General
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class Ssl
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class WebUI
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class Reconnect
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class Download
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class DownloadTime
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class Proxy
    {
        public object info { get; set; }

        public string description { get; set; }

        public List<Item> items { get; set; }

        public string explanation { get; set; }

        public string label { get; set; }

        public string name { get; set; }
    }

    public class Config
    {
        public Log log { get; set; }

        public Permission permission { get; set; }

        public General general { get; set; }

        public Ssl ssl { get; set; }

        public WebUI webUI { get; set; }

        public Reconnect reconnect { get; set; }

        public Download download { get; set; }

        public DownloadTime downloadTime { get; set; }

        public Proxy proxy { get; set; }
    }
}