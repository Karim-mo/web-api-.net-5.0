using Microsoft.EntityFrameworkCore;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}