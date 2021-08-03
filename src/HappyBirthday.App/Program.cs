using HappyBirthday.App.Application;
using HappyBirthday.App.Facades;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace HappyBirthday.App
{
    static class Program
    {       
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            SingHappyBirthday(host.Services, GetName(args));

            return host.RunAsync();
        }

        static string GetName(string[] args)
        {
            return args.Length > 0 ? args[0] : Environment.UserName;
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IConsoleFacade, ConsoleFacade>()
                .AddTransient<ISongGenerator, BirthdaySongGenerator>());

        static void SingHappyBirthday(IServiceProvider services, string name)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var console = provider.GetRequiredService<IConsoleFacade>();
            var generator = provider.GetRequiredService<ISongGenerator>();

            foreach(var line in generator.GetBirthdaySong(name))
            {
                console.WriteLine(line);
            }
        }
    }
}
