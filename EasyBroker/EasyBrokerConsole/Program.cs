using EasyMqttLib.Model;
using EasyMqttLib.Model.Enums;
using System.Text.Json;

namespace EasyBrokerConsole;

public class Program
{
    static async Task Main(string[] args)
    {
        EasyMqttBrokerOptions options;
        EasyMqttBroker broker = new EasyMqttBroker();

        MqttStates state = MqttStates.Initializing;
        

        using (StreamReader file = File.OpenText(Path.Combine("BrokerConfig.json")))
        {
            options = JsonSerializer.Deserialize<EasyMqttBrokerOptions>(file.ReadToEnd())!;
        }

        CancellationTokenSource cts = new();

        while (!cts.Token.IsCancellationRequested)
        {
            switch (state)
            {
                case MqttStates.Initializing:
                    Console.WriteLine("Server Initializing");
                    state = MqttStates.CreatingBroker;
                    break;

                case MqttStates.CreatingBroker:
                    await broker.Start(4888);
                    Console.WriteLine("Server Running");
                    break;
                case MqttStates.Running:                  
                    
                    break;

                default:
                    cts.Cancel();
                    break;

            }

            await Task.Delay(1000);
        }
    }
}
