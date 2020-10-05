using DILifeTimeSample.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Authentication.ExtendedProtection;

namespace DILifeTimeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITransient, Implementation>()
                .AddScoped<IScoped, Implementation>()
                .AddSingleton<ISingleton, Implementation>()
                .AddSingleton<ISingletonInstance>(new Implementation(Guid.Empty))
                .AddTransient<ILogger, ConsoleLogger>()
                .BuildServiceProvider();            

            int i = 0;
            foreach (var logger in GetLoggerInstances(serviceProvider))
            {
                Console.WriteLine($"Aufruf {i++}:");
                logger.Log(Console.WriteLine);
                Console.WriteLine();
            }
            
            Console.ReadLine();
        }

        private static IEnumerable<ILogger> GetLoggerInstances(ServiceProvider serviceProvider)
        {
            for (int i = 0; i < 4; i++)
            {
                //Workaraound um in einer ConsolenApp einen Scope zu erzeugen
                using (var scope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<ILogger>();
                    yield return scopedService;
                }
            }
        }
    }
}
