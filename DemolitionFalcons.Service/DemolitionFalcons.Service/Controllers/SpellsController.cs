namespace DemolitionFalcons.Service.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using App.Commands.DataProcessor;
    using App.Commands.DataProcessor.Export.Dto;
    using App.Maps;
    using DemolitionFalcons.Models;
    using Front;

    public class SpellsController : BaseApiController
    {
        // GET api/weapons
        [HttpGet]
        public List<SpellFront> Get()
        {
            Spell[] dbSpells = this.dbContext.Spells.ToArray();

            //HeroFront[] outcome = new HeroFront[dbCharacters.Length];
            List<SpellFront> outcome = new List<SpellFront>();

            foreach (var dbSpell in dbSpells)
            {
                outcome.Add(new SpellFront(dbSpell.Name, dbSpell.DamageBonus, dbSpell.SpellRange, dbSpell.Description));
            }

            return outcome;

        }
    }
}
