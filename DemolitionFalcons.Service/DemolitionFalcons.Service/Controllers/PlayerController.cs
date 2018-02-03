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
    using DemolitionFalcons.App.Core.DTOs;

    public class PlayerController : BaseApiController
    {
        [HttpGet]
        public PlayerFront Get()
        {
            var weapons = new List<Weapon>();
            return new PlayerFront("test", 0, 0, 0, 0, new List<PlayerWeapon>());
        }

        // POST api/game
        [HttpPost]
        public IActionResult Post([FromBody]PlayerDto value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            Player player = new Player();
            player.Username = value.Username;
            player.Password = value.Password;
            player.GamesPlayed = value.GamesPlayed;
            player.Wins = value.Wins;
            player.Xp = value.Xp;
            player.Money = value.Money;
            dbContext.Players.Add(player);
            dbContext.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = player.Id }, player);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var player = dbContext.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return new ObjectResult(player);
        }
    }
}
