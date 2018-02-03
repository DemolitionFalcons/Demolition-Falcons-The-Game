using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemolitionFalcons.Service.Front
{
    public class SpellFront
    {
        public SpellFront(string name, int damageBonus, int spellRange,string description)
        {
            this.Name = name;
            this.DamageBonus = damageBonus;
            this.SpellRange = spellRange;
            this.Description = description;
        }

        //public int Id { get; set; }
        
        public string Name { get; set; }

        public int DamageBonus { get; set; } // adds a bonus dmg to the dmg that the char already possesses

        public int SpellRange { get; set; }

        public string Description { get; set; }
    }
}
