using Microsoft.EntityFrameworkCore;

namespace RPSLS_API.Models
{
    public class RPSLSContext : DbContext
    {
        public RPSLSContext(DbContextOptions<RPSLSContext> options)
            : base(options)
        {
        }

        public DbSet<RPSLSItem> RPSLSItems { get; set; }
    }
}
