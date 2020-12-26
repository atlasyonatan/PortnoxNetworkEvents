using PortnoxNetworkEvents.ConsoleApp.Models;
using System.Collections.Generic;

namespace PortnoxNetworkEvents.ConsoleApp
{
    public static class DataGeneration
    {
        public static IEnumerable<NetworkEvent> GenerateInitial()
        {
            return new NetworkEvent[]
            {
                new NetworkEvent()
                {
                    Switch_Ip = "1.1.1.1",
                    Port_Id = 12,
                    Device_Mac = "AABBCC000001"
                },
                new NetworkEvent()
                {
                    Switch_Ip = "1.1.1.1",
                    Port_Id = 11,
                    Device_Mac = "AABBCC000009"
                },
                new NetworkEvent()
                {
                    Switch_Ip = "192.168.1.1",
                    Port_Id = 48,
                    Device_Mac = null
                },
                new NetworkEvent()
                {
                    Switch_Ip = "1.1.1.1",
                    Port_Id = 12,
                    Device_Mac = null
                },
                new NetworkEvent()
                {
                    Switch_Ip = "192.168.1.1",
                    Port_Id = 47,
                    Device_Mac = "AABBCC000001"
                }
            };
        }
    }
}
