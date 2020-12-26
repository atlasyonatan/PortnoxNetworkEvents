using System.Collections.Generic;
using PortnoxNetworkEvents.ConsoleApp.Models;
using PortnoxNetworkEvents.ConsoleApp.Interfaces;

namespace PortnoxNetworkEvents.ConsoleApp.Analyzer
{
    public class NetworkAnalyzer : INetworkAnalyzer
    {
        private readonly IDictionary<string, Switch> _switchByIp = new Dictionary<string, Switch>();
        private readonly IDictionary<string, Port> _portByUniqueId = new Dictionary<string, Port>();
        private readonly IDictionary<string, Device> _deviceByMac = new Dictionary<string, Device>();

        public IEnumerable<ISwitch> Switches => _switchByIp.Values;
        public IEnumerable<IPort> Ports => _portByUniqueId.Values;
        public IEnumerable<IDevice> Devices => _deviceByMac.Values;

        public void Analyze(IEnumerable<NetworkEvent> events)
        {
            foreach (var e in events)
            {
                var portUID = e.UniquePortId();
                //get by object id or default
                Device device = null;
                if (e.Device_Mac != null && !_deviceByMac.TryGetValue(e.Device_Mac, out device))
                {
                    device = new Device() { Mac = e.Device_Mac };
                    _deviceByMac.TryAdd(device.Mac, device);
                }


                if (!_switchByIp.TryGetValue(e.Switch_Ip, out Switch switc))
                {
                    switc = new Switch() { Ip = e.Switch_Ip };
                    _switchByIp.TryAdd(switc.Ip, switc);
                }

                if (!_portByUniqueId.TryGetValue(portUID, out Port port))
                {
                    port = new Port() { Id = e.Port_Id, Switch = switc };
                    _portByUniqueId.TryAdd(portUID, port);
                }


                //update device info
                if (device != null)
                    device.EventById.TryAdd(e.Event_Id, e);

                //update switch info
                switc.EventById.TryAdd(e.Event_Id, e);
                switc.PortById.TryAdd(portUID, port);

                //update port info
                port.EventById.TryAdd(e.Event_Id, e);
                if (device != null)
                    port.DeviceByMac.TryAdd(e.Device_Mac, device);
            }
        }
    }
}
