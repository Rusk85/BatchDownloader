# BatchDownloader

<b>Introduction</b>

C# library for accessing pyLoad's Http-API in a strongly typed fashion.
The intention for writing this library was the fact that the current beta of pyLoad (0.5) automatically 
groups lists of links in a way that makes adding large numbers of links via the frontend very tiresome.
With this library its very easy to add large amounts of unrelated links to pyLoad in a way that they end up in the same package
and potentially the same output directory. 
For that reason this project comes with a simple GUI in the shape of a C# Forms Application.

<b>Usage</b>

```c#
var apiCaller = new ApiCaller("192.168.1.35", 8000);

apiCaller.Login("username", "password");

// relative to pyLoad's defined download directory
// creates/adds downloads to : <download_dir>/links/today
var destination = @"links/today";

var pid = apiCaller.AddPackage(destination, @"http://link.com/1.rar", @"http://link.com/2.rar");

var package = apiCaller.GetPackageInfo(pid);

Console.WriteLine(String.Format("Folder: {0} | {1} of {2} links downloaded", 
    package.folder, package.stats.linksdone, package.stats.linkstotal));
```

**Dependencies**

* [Flurl](https://www.nuget.org/packages/Flurl/)
* [RestSharp](https://www.nuget.org/packages/RestSharp/)


<b>Roadmap</b>

* Adding the remaining API-Methods (all working, parameterless methods added)
* Refactoring API-Calls to make each API-Call more conveniant [done]
* Add more functionality to the GUI
