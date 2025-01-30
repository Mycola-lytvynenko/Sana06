using Microsoft.EntityFrameworkCore;

namespace Sana06.Models
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<deer> Deers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
