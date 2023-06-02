using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class JediFullStacAppDbContext : DbContext
    {
        public JediFullStacAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Jedi> Jedi { get; set; }
    }
}
