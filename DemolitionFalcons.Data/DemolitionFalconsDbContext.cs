namespace DemolitionFalcons.Web
{
    using DemolitionFalcons.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DemolitionFalconsDbContext : IdentityDbContext<User>
    {
        public DemolitionFalconsDbContext(DbContextOptions<DemolitionFalconsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
