using Microsoft.EntityFrameworkCore;

namespace PortnoxNetworkEvents.ConsoleApp.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private const string connectionString = "Data Source=DESKTOP-0DUOP5K;Initial Catalog=AtlasDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Models.NetworkEvent> NetworkEvents { get; set; }
    }
}

