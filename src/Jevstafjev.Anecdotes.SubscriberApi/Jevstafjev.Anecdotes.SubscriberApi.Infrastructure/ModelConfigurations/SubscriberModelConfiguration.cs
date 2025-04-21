using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Jevstafjev.Anecdotes.SubscriberApi.Domain;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Infrastructure.ModelConfigurations;

public class SubscriberModelConfiguration : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(EntityTypeBuilder<Subscriber> builder)
    {
        builder.ToTable("Subscribers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(128).IsRequired();

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
