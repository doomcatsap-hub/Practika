using EntityFrameworkBD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections;
namespace EntityFramewordBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional : false, reloadOnChange: true)
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<PractikaBdContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // INSERT
            using (PractikaBdContext db = new PractikaBdContext(optionsBuilder.Options))
            {

                Player player = new Player { PlayerName = "Entity", DotaPlus = false, Mmr = 2000, CountryId = 1 };
                db.Add(player);
                db.SaveChanges();
                
            }
            // UPDATE
            using (PractikaBdContext db = new PractikaBdContext(optionsBuilder.Options))
            {
                Player? player = db.Players.FirstOrDefault();
                if(player != null)
                {
                    player.PlayerName = "EntityUpdate";
                    player.DotaPlus = true;
                    db.SaveChanges();

                }
            }
            //DELETE
            using (PractikaBdContext db = new PractikaBdContext(optionsBuilder.Options))
            {
                Player? player = db.Players.Find(4007);
                if (player != null)
                {
                    db.Players.Remove(player);
                    db.SaveChanges();
                }
            }
            // SELECT
            using (PractikaBdContext db = new PractikaBdContext(optionsBuilder.Options))
            {
                var players = db.Players.Where(x => x.PlayerName == "Entity").ToList();
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.Mmr}");
                }

            }

        }
    }

}
