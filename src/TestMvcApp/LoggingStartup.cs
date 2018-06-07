using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: HostingStartup(typeof(TestMvcApp.LoggingStartup))]

namespace TestMvcApp
{
    public class LoggingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.AddEventSourceLogger()
                    .AddFilter((name, cat, level) =>
                    {
                        if (string.Equals("Microsoft.Extensions.Logging.EventSource.EventSourceLoggerProvider", name))
                        {
                            return level >= LogLevel.Information;
                        }
                        return false;
                    });
            });
        }
    }
}
