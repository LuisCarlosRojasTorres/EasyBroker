namespace EasyBrokerConsole;
using EasyMqttLib.Interfaces;
using EasyMqttLib.Model;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Set up the DI container
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var broker = serviceProvider.GetRequiredService<IEasyMqttBroker>();

        await broker.Start();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register services
        services.AddSingleton<IEasyMqttBroker, EasyMqttBroker>();
    }
}
