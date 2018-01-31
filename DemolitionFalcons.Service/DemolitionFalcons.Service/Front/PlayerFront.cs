using DemolitionFalcons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemolitionFalcons.Service.Front
{
    public class PlayerFront
    {
        public PlayerFront(int id, string username, int gamesPlayed, int wins, int xp, decimal money, ICollection<PlayerWeapon> weapons)
        {
            this.Id = id;
            this.Username = username;
            this.GamesPlayed = gamesPlayed;
            this.Wins = wins;
            this.Xp = xp;
            this.Weapons = weapons;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public int GamesPlayed { get; set; }

        public int Wins { get; set; }

        public int Xp { get; set; }

        public decimal Money { get; set; }

        public ICollection<PlayerWeapon> Weapons { get; set; }
    }
}
