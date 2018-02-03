namespace DemolitionFalcons.Service.Front
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class GameFront
    {
        public GameFront(string name, string map, int capacity, int xp, decimal money)
        {
            this.Name = name;
            this.Map = map;
            this.Capacity = capacity;
            this.Xp = xp;
            this.Money = money;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Map { get; set; }

        public int? WinnerId { get; set; }

        public int Xp { get; set; }

        public decimal Money { get; set; }

        public TimeSpan? Time { get; set; }

        public ICollection<GameCharacter> Characters { get; set; }

        public int Capacity { get; set; }
    }
}