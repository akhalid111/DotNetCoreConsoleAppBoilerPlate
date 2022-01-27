using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreConsoleAppBoilerPlate
{
    public class HelloWorld : IHelloWorld
    {
        private readonly ILogger<HelloWorld> _logger;

        private readonly IConfiguration _configuration;

        public HelloWorld(ILogger<HelloWorld> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void WriteToConsole()
        {
            _logger.LogInformation("Hello World !");
        }

    }
}
