using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TemporalTables
{

    public class MyContext : DbContext
    {
        private const string ConnectionString = "";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString);
            options.LogTo(Console.WriteLine);
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);
        }
        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", b => b.IsTemporal().UseHistoryTable("HistoricalUsers"));
        }
    }
}