using System.Collections.Generic;
using PortnoxNetworkEvents.ConsoleApp.Models;

namespace PortnoxNetworkEvents.ConsoleApp.Interfaces
{
    public interface IDevice
    {
        public string Mac { get; }
        public IEnumerable<NetworkEvent> Events { get; }
    }
}
