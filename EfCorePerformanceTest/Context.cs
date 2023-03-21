using Microsoft.EntityFrameworkCore;

namespace Persons;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    
    public DbSet<Person> Persons { get; set; }
}

