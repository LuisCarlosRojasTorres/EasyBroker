namespace EasyMqttLib.Interfaces;

using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Interface for MqttBroker
/// </summary>
public interface IEasyMqttBroker
{
    /// <summary>
    /// Starts the MQTT Broker.
    /// </summary>
    /// <param name="port"> Use 1883 if for unencrypted MQTT communication. But 8883 for encrypted.</param>
    /// <returns></returns>
    public Task Start(int port = 1883);


    public Task PublishPostProcessingAsync(InterceptingPublishEventArgs e);

    public Task SubscriptionPostProcessingAsync(InterceptingSubscriptionEventArgs e);

    public Task UnsubscriptionPostProcessingAsync(InterceptingUnsubscriptionEventArgs e);    

    /// <summary>
    /// Action where topic is the argument.
    /// </summary>
    public Action<string>? PublishPostProcessCallback { get; set; }
    public Action<string>? SubscriptionPostProcessCallback { get; set; }
    public Action<string>? UnsubscriptionPostProcessCallback { get; set; }

}
