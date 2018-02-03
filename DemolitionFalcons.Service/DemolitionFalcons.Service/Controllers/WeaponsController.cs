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
            Weapon[] dbWeapons = this.dbContext.Weapons.ToArray();

            //HeroFront[] outcome = new HeroFront[dbCharacters.Length];
            List<WeaponFront> outcome = new List<WeaponFront>();

            foreach (var dbWeapon in dbWeapons)
            {
                outcome.Add(new WeaponFront(dbWeapon.Name, dbWeapon.Damage, dbWeapon.Core));
            }

            return outcome;

        }
    }
}
