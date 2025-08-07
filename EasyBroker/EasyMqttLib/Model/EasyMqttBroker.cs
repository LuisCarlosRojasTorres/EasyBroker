namespace EasyMqttLib.Model;

using EasyMqttLib.Interfaces;
using MQTTnet;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class EasyMqttBroker : IEasyMqttBroker
{
    private MqttFactory? mqttFactory;
    private MqttServerOptions? mqttServerOptions;
    private MqttServer? mqttServer;

    public EasyMqttBroker() 
    {
        this.mqttFactory = new MqttFactory();
        this.mqttServerOptions =null;
        this.mqttServer = null;
    }


    public async Task Start(int port = 1883)
    {
        try
        {
            this.mqttServerOptions = this.mqttFactory!.CreateServerOptionsBuilder().WithDefaultEndpoint().WithDefaultEndpointPort(port).Build();
            this.mqttServer = this.mqttFactory.CreateMqttServer(this.mqttServerOptions);

            this.mqttServer.InterceptingPublishAsync += this.PublishPostProcessingAsync;
            this.mqttServer.InterceptingSubscriptionAsync += this.SubscriptionPostProcessingAsync;
            this.mqttServer.InterceptingUnsubscriptionAsync += this.UnsubscriptionPostProcessingAsync;
            
            await this.mqttServer.StartAsync();
            Console.WriteLine($"EasyMqttBroker: Started NO TLS broker at port {port}");

        }
        catch (Exception ex) 
        {
                throw new Exception($"EasyMqttBroker: Error trying to use port {port}. More details at: {ex}");
        }
        
    }

    public async Task PublishPostProcessingAsync(InterceptingPublishEventArgs e)
    {
        await Task.Delay(10);
    }

    public async Task SubscriptionPostProcessingAsync(InterceptingSubscriptionEventArgs e)
    { 
        await Task.Delay(10);
    }

    public async Task UnsubscriptionPostProcessingAsync(InterceptingUnsubscriptionEventArgs e)
    {
        await Task.Delay(10);
    }

}
