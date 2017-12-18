namespace DemolitionFalcons.Services.Implementations
{
    using DemolitionFalcons.Data;

    public class GameService : IGameService
    {
        private readonly DemolitionFalconsDbContext db;

        public GameService(DemolitionFalconsDbContext db)
        {
            this.db = db;
        }
    }
}
