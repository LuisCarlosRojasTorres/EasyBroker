using EasyMqttLib.Model;
using EasyMqttLib.Model.Enums;
using Serilog;
using System.Text.Json;

namespace EasyBrokerConsole;

public class Program
{
    static async Task Main(string[] args)
    {
        EasyMqttBrokerOptions options;

        using (StreamReader file = File.OpenText(Path.Combine("BrokerConfig.json")))
        {
            options = JsonSerializer.Deserialize<EasyMqttBrokerOptions>(file.ReadToEnd())!;
        }

        

        
        EasyMqttBroker broker = new EasyMqttBroker();

        MqttStates state = MqttStates.Initializing;

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console() // Log to console
            .WriteTo.File(options.LogsPath + "log.txt", rollingInterval: RollingInterval.Day) // Log to file
            .CreateLogger();


        CancellationTokenSource cts = new();

        int portCounter = 0;
        

        while (!cts.Token.IsCancellationRequested)
        {
            switch (state)
            {
                case MqttStates.Initializing:
                    Log.Information("Server Initializing");
                    state = MqttStates.CreatingBroker;
                    break;

                case MqttStates.CreatingBroker:
                    try
                    {
                        await broker.Start(options.Ports[portCounter]);
                        Log.Information("Server Running at port: {port}", options.Ports[portCounter]);
                        state = MqttStates.Running;
                    }
                    catch (Exception ex) 
                    {
                        Log.Error("Error starting broker at port {port}. More details at: {ex}", options.Ports[portCounter],ex);
                        portCounter = portCounter++% options.Ports.Count;                        
                    }
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

