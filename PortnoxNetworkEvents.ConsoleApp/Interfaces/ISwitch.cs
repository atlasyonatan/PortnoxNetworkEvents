using System.Collections.Generic;
using PortnoxNetworkEvents.ConsoleApp.Models;

namespace PortnoxNetworkEvents.ConsoleApp.Interfaces
{
    public interface ISwitch
    {
        public string Ip { get; }
        public IEnumerable<IPort> Ports { get; }
        public IEnumerable<NetworkEvent> Events { get; }
    }
}
