
using Microsoft.Extensions.DependencyInjection;


namespace DotNetCoreConsoleAppBoilerPlate
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Configure();
            var serv = ActivatorUtilities.CreateInstance<HelloWorld>(Startup.Services());
            serv.WriteToConsole();
           
        }     
    }
}
