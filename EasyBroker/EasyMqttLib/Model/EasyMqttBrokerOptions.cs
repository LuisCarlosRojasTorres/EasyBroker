namespace EasyMqttLib.Model;

using EasyMqttLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EasyMqttBrokerOptions : IEasyMqttBrokerOptions
{
    public bool IsTLS { get; set; } = false;

    public string TLSCertificate { get; set; } = string.Empty;
    public string LogsPath { get; set; } = "logs/";
    public List<int> Ports { get; set; } = new List<int>() { 1883, 1409,  2402, 2801, 7390};
    public int TimeoutInMs { get; set; } = 1000;
}
