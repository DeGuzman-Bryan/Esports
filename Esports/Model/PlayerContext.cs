using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace Esports.Model
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }


        public DbSet<Model1> model1 { get; set; }
    }
}
