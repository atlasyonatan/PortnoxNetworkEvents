using System;
using System.Linq;
using PortnoxNetworkEvents.ConsoleApp.Analyzer;
using PortnoxNetworkEvents.ConsoleApp.Data;

namespace PortnoxNetworkEvents.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //connect to db
            using (var dbContext = new DbContext())
            {
                //ensure initial data
                dbContext.Database.EnsureCreated();
                if (!dbContext.NetworkEvents.Any())
                {
                    dbContext.AddRange(DataGeneration.GenerateInitial());
                    dbContext.SaveChanges();
                }

                //query data
                var events = dbContext.NetworkEvents.ToList();

                //analyze data
                var networkAnalyzer = new NetworkAnalyzer();
                networkAnalyzer.Analyze(events);
                Console.WriteLine("Finished analyzing");
            }
        }
    }
}
