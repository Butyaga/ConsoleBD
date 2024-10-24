using Microsoft.EntityFrameworkCore;

namespace EFStorage.Model;
internal class StorageContext(string connectionString) : DbContext
{
    public DbSet<Employee> Employees  => Set<Employee>();

    /*
    public StorageContext()
    {
        Database.EnsureCreated();
    }
    */

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
