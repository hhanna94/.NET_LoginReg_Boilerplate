using LoginReg.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginReg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<User> Users {get;set;}
    }
}