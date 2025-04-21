using Jevstafjev.Anecdotes.SubscriberApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Anecdotes.SubscriberApi.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Subscriber> Subscribers { get; set; }
}
