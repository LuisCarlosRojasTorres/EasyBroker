namespace EasyMqttLib.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IEasyMqttBrokerOptions
{
    public List<int> Ports { get; set; }
    public int TimeoutInMs { get; set; }
}
