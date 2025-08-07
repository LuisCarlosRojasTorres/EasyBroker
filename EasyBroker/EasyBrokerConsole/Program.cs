namespace EasyBrokerConsole;
using EasyMqttLib.Model;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        EasyMqttBroker broker = new EasyMqttBroker();

        await broker.Start();
    }
}
