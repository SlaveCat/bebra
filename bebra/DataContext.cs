using bebra.models;
using Microsoft.EntityFrameworkCore;
namespace bebra
{
    public class DataContext : DbContext
    {
        public DbSet<Retake> retakes { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Student> students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
