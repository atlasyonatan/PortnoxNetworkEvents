using PortnoxNetworkEvents.ConsoleApp.Interfaces;
using PortnoxNetworkEvents.ConsoleApp.Models;
using System.Collections.Generic;

namespace PortnoxNetworkEvents.ConsoleApp.Analyzer
{
    public interface INetworkAnalyzer
    {
        public IEnumerable<ISwitch> Switches { get; }
        public IEnumerable<IPort> Ports { get; }
        public IEnumerable<IDevice> Devices { get; }

        public void Analyze(IEnumerable<NetworkEvent> events) { }
    }
}
