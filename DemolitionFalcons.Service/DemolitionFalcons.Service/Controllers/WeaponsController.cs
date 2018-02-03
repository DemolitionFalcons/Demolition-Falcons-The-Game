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

    public class WeaponsController : BaseApiController
    {
        // GET api/weapons
        [HttpGet]
        public List<WeaponFront> Get()
        {
            Weapon[] dbPlayers = this.dbContext.Weapons.ToArray();

            //HeroFront[] outcome = new HeroFront[dbCharacters.Length];
            List<WeaponFront> outcome = new List<WeaponFront>();

            foreach (var dbPlayer in dbPlayers)
            {
                outcome.Add(new WeaponFront(dbPlayer.Name, dbPlayer.Damage, dbPlayer.Core));
            }

            return outcome;

        }
    }
}
