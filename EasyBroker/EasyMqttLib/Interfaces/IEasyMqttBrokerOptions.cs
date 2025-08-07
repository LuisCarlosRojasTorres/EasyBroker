namespace EasyMqttLib.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEasyMqttBrokerOptions
{
    public bool IsTLS { get; set; }
    public string TLSCertificate { get; set; }
    public List<int> Ports { get; set; }
    public int TimeoutInMs { get; set; }
}
