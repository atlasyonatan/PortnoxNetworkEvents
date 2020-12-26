using System.Collections.Generic;
using PortnoxNetworkEvents.ConsoleApp.Interfaces;
using PortnoxNetworkEvents.ConsoleApp.Models;

namespace PortnoxNetworkEvents.ConsoleApp.Analyzer
{
    public class Port : IPort
    {
        public Dictionary<int, NetworkEvent> EventById = new Dictionary<int, NetworkEvent>();
        public Dictionary<string, IDevice> DeviceByMac = new Dictionary<string, IDevice>();

        public int Id { get; set; }
        public ISwitch Switch { get; set; }
        public IEnumerable<IDevice> Devices => DeviceByMac.Values;
        public IEnumerable<NetworkEvent> Events => EventById.Values;


    }
}
