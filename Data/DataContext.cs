using Microsoft.EntityFrameworkCore;
using netCore5.Models;

namespace Netcore5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }

    }
}