namespace EasyMqttLib.Interfaces;

using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Interface for MqttClient
/// </summary>
public interface IEasyMqttClient
{    
    public Task ConnectToBroker();
    public Task DisconnectToBroker();

    public Task SubscribeToTopics(List<string> Topics);
    public Task UnsubscribeToTopics(List<string> Topics);

    public Task PublishTopic(string topic, string message, bool isRetainedMessage);
}
