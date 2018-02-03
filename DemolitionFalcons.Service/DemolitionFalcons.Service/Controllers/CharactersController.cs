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
    public class CharactersController : BaseApiController
    {
        //print all characters, not just a specific one like the CharacterController
        // GET api/characters
        [HttpGet]
        public List<HeroFront> Get()
        {
            Character[] dbCharacters = this.dbContext.Characters.ToArray();

            //HeroFront[] outcome = new HeroFront[dbCharacters.Length];
            List<HeroFront> outcome = new List<HeroFront>();
            
            foreach (var dbChar in dbCharacters)
            {
                outcome.Add(new HeroFront(dbChar.Name, dbChar.Label, dbChar.Description, dbChar.Hp, dbChar.Armour));
            }

            return outcome;

        }
    }
}
