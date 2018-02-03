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
    public class LeaderboardController : BaseApiController
    {
        // GET api/players
        [HttpGet]
        public List<PlayerFront> Get()
        {
            Player[] dbPlayers = this.dbContext.Players.ToArray();

            //HeroFront[] outcome = new HeroFront[dbCharacters.Length];
            List<PlayerFront> outcome = new List<PlayerFront>();

            foreach (var dbPlayer in dbPlayers)
            {
                outcome.Add(new PlayerFront(dbPlayer.Username, dbPlayer.GamesPlayed, dbPlayer.Wins, dbPlayer.Xp, dbPlayer.Money,dbPlayer.Weapons));
            }
            outcome.OrderByDescending(p => p.Wins).ThenByDescending(p => p.GamesPlayed).ThenBy(p => p.Username);

            return outcome;

        }
    }
}
