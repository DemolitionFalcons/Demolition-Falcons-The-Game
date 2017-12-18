namespace DemolitionFalcons.Data.Controllers
{
    using DemolitionFalcons.Services;
    using Microsoft.AspNetCore.Mvc;

    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult NewGame()
        {
            return View();
        }
    }
}