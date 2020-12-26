using System.Collections.Generic;
using PortnoxNetworkEvents.ConsoleApp.Interfaces;
using PortnoxNetworkEvents.ConsoleApp.Models;

namespace PortnoxNetworkEvents.ConsoleApp.Analyzer
{
    public class Device : IDevice
    {
        public Dictionary<int, NetworkEvent> EventById = new Dictionary<int, NetworkEvent>();

        public string Mac { get; set; }

        public IEnumerable<NetworkEvent> Events => EventById.Values;
    }
}
