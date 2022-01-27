using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace DotNetCoreConsoleAppBoilerPlate
{
    public class Startup
    {
        static IHost _host; 
        public static void Configure()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //setup configuration file and log 
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            //set up dependeny injection ,configure logger and load configuration 
            _host = Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           //Add services for dependecy injection here 
                           services.AddTransient<IHelloWorld,HelloWorld>();
                       })
                       .UseSerilog()
                       .Build();
           
        }
        public static IServiceProvider Services()
        {
            return _host.Services; 
        }

        //tells where is the configuration file 
        static void BuildConfig(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
