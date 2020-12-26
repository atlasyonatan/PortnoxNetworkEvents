using System.Collections.Generic;
using PortnoxNetworkEvents.ConsoleApp.Models;

namespace PortnoxNetworkEvents.ConsoleApp.Interfaces
{
    public interface IPort
    {
        public int Id { get; }
        public ISwitch Switch { get; }
        public IEnumerable<IDevice> Devices { get; }
        public IEnumerable<NetworkEvent> Events { get; }
    }
}
