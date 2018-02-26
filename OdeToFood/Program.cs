using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        //quick and easy way to spin up a webhost via the CreateDefaultBuilder method.
        //A WebHostBuilder is a an object that knows how to set up our web server environment, and the default web host
        //builders sets up our environment in a specific way - we change by writing our own defaultbuidler code.
        //CreateDefaultBuilder does the following:
        //1. Use the Kestrel server, the cross platform web server. Listens for http connections.
        //2. Sets up IIS integration -- passes Windows credentials, important for if you are setting up Intranet apps inside fw.
        //3. Default Logging
        //4. IConfiguration service made available. This runs throughout the application and is the way to retreive configuration 
        // information through it. Can pass through appsettings.json. Create this file via the ASP.NET Configuration file template. bb
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
