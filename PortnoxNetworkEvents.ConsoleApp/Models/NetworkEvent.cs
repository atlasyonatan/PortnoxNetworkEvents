using System.ComponentModel.DataAnnotations;

namespace PortnoxNetworkEvents.ConsoleApp.Models
{
    public class NetworkEvent
    {
        [Key]
        public int Event_Id { get; set; }
        public string Switch_Ip { get; set; }
        public int Port_Id { get; set; }
        public string Device_Mac { get; set; }
    }
}
