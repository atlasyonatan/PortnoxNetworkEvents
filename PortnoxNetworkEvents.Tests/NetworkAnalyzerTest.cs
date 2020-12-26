using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortnoxNetworkEvents.ConsoleApp.Analyzer;
using PortnoxNetworkEvents.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortnoxNetworkEvents.Tests
{
    [TestClass]
    public class NetworkAnalyzerTest
    {
        private readonly INetworkAnalyzer _analyzer = new NetworkAnalyzer();
        [TestMethod]
        public void AnalyzerTest()
        {
            var count = 10;
            var macs = new string[] { "A", "B", "C", "D", null };
            var ips = new string[] { "A", "B", "C", "D" };
            var portIds = new int[] { 1, 2, 3, 4, 5};
            var events = PrepareData(count, macs, ips, portIds);
            
            _analyzer.Analyze(events);

            //Devices
            Assert.AreEqual(_analyzer.Devices.Count(), macs.Where(s => s != null).Count());
            var device1 = _analyzer.Devices.First(d => d.Mac == macs[0]);
            Assert.AreEqual(device1.Events.Count(), 2);

            //Switches
            Assert.AreEqual(_analyzer.Switches.Count(), ips.Length);
            var switch1 = _analyzer.Switches.First(s => s.Ip == ips[0]);
            Assert.AreEqual(switch1.Events.Count(), 3);
            Assert.AreEqual(switch1.Ports.Count(), 3);

            //Ports
            Assert.AreEqual(_analyzer.Ports.Count(), Math.Min(count, ips.Length*portIds.Length));
            var port1 = _analyzer.Ports.First(p => p.Id == portIds[0]);
            Assert.AreEqual(port1.Devices.Count(), 1);
        }

        private IEnumerable<NetworkEvent> PrepareData(int count, string[] macs, string[] ips, int[] portIds)
        {
            for (var i = 0; i < count; i++) yield return new NetworkEvent()
            {
                Device_Mac = macs[i % macs.Length],
                Port_Id = portIds[i % portIds.Length],
                Switch_Ip = ips[i % ips.Length],
                Event_Id = i
            };
        }
    }
}
