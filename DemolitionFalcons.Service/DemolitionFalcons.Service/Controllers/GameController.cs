namespace DemolitionFalcons.Service.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using DemolitionFalcons.App.Maps;
    using DemolitionFalcons.Data;
    using DemolitionFalcons.Data.Support;
    using Front;
    using Models;
    using DemolitionFalcons.App.Core.DTOs;

    public class GameController : BaseApiController
    {
        [HttpGet]
        public IEnumerable<CharacterFront> Get()
        {       
            var map = new DemoMap("map1");

            var character = this.dbContext.GameCharacters
                .Select(c => new CharacterFront(c.Game.Name, map.Name, c.Game.Characters.Count()))
                .ToArray();

            return character;
        }

        // GET api/game/5
        [HttpGet("{id}")]
        public GameFront Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Game, GameFront>());

            Game result = this.dbContext.Games
                .Where(game => game.Id == id)
                .ToArray()
                .FirstOrDefault();

            return Mapper.Map<GameFront>(result);
        }

        //GET api/game/5/players
        [HttpGet("{id}/players")]
        public IEnumerable<PlayerFront> GetPlayers(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Game, PlayerFront>());
            var res = new List<PlayerFront>();
            var gameChars = this.dbContext.Players.Where(pl => this.dbContext.GameCharacters.Any(g => g.GameId == id));

            foreach (var player in gameChars)
            {
                var playerFront = new PlayerFront(player.Username, player.GamesPlayed, player.Wins, player.Xp, player.Money, player.Weapons);
                res.Add(playerFront);
            }

            #region
            //not working properly
            //var result = this.dbContext.Players
            //    .Where(pl => this.dbContext.GameCharacters.Any(g => g.GameId == id))
            //    .Select(pf => new PlayerFront(pf.Id, pf.Username, pf.GamesPlayed, pf.Wins, pf.Xp, pf.Money, pf.Weapons))
            //    .ToArray();
            //return result;
            #endregion

            return Mapper.Map<PlayerFront[]>(res);
        }

        // POST api/game
        [HttpPost]
        public IActionResult Post([FromBody]GameDto value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Game game = new Game();
            game.Name = value.Name;
            game.Map = value.Map;
            game.Capacity = value.Capacity;
            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            //    dbContext.

            return CreatedAtRoute("GetoTodo", new { id = game.Id }, game);
        }

        [HttpGet("{id}", Name = "GetoTodo")]
        public IActionResult GetById(long id)
        {
            var game = dbContext.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return new ObjectResult(game);
        }

        // PUT api/game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/game/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
