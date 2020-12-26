using PortnoxNetworkEvents.ConsoleApp.Interfaces;
using PortnoxNetworkEvents.ConsoleApp.Models;
using System.Collections.Generic;

namespace PortnoxNetworkEvents.ConsoleApp.Analyzer
{
    public class Switch : ISwitch
    {
        public Dictionary<int, NetworkEvent> EventById = new Dictionary<int, NetworkEvent>();
        public Dictionary<string, IPort> PortById = new Dictionary<string, IPort>();

        public string Ip { get; set; }
        public IEnumerable<IPort> Ports => PortById.Values;
        public IEnumerable<NetworkEvent> Events => EventById.Values;
    }
}
