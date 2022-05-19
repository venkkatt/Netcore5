using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using netCore5.Models;
using Netcore5.Models;

namespace Netcore5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }

    }
}