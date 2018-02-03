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
        //[HttpGet]
        //public CharacterFront Get()
        //{
        //    var map = new DemoMap("map1");

        //    CharacterFront character = this.dbContext.GameCharacters
        //        .Select(c => new CharacterFront
        //        {
        //            Map = map.Name,
        //            Name = c.Game.Name,
        //            NumberOfPlayers = c.Game.Characters.Count(),
        //            Players = c.Game.Characters.Select(st => new CharacterDto
        //            {
        //                Type = st.Type,
        //                Nickname = this.dbContext.Players.FirstOrDefault(p => p.Id == st.PlayerId).Username,
        //                Name = st.Character.Name
        //            })
        //        })
        //        .FirstOrDefault();

        //    return character;

        //}

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
