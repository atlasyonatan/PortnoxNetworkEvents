using PortnoxNetworkEvents.ConsoleApp.Models;

namespace PortnoxNetworkEvents.ConsoleApp.Analyzer
{
    public static class Extensions
    {
        public static string UniquePortId(this NetworkEvent networkEvent) =>
            networkEvent.Switch_Ip + ':' + networkEvent.Port_Id.ToString();
    }
}
