using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemolitionFalcons.Service.Front
{
    public class HeroFront
    {
        public HeroFront(string name, string label, string description, int hp, int armour)
        {
            this.Name = name;
            this.Label = label;
            this.Description = description;
            this.Hp = hp;
            this.Armour = armour;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public int Hp { get; set; }

        public int Armour { get; set; }
    }
}
