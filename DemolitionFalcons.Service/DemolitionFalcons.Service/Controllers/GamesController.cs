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

    public class GamesController : BaseApiController
    {
        // GET api/games
        [HttpGet]
        public List<GameFront> Get()
        {
            Game[] dbGames = this.dbContext.Games.ToArray();

            //HeroFront[] outcome = new HeroFront[dbCharacters.Length];
            List<GameFront> outcome = new List<GameFront>();

            foreach (var dbGame in dbGames)
            {
                outcome.Add(new GameFront(dbGame.Name, dbGame.Map, dbGame.Capacity, dbGame.Xp, dbGame.Money));
            }

            return outcome;

        }
    }
}
