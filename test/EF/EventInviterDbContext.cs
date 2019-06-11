using Microsoft.EntityFrameworkCore;
using EventInviter.Models;
using test.Models;

namespace EventInviter.EF
{
    public class EventInviterDbContext:DbContext
    {
        public EventInviterDbContext(DbContextOptions<EventInviterDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventInvitedUser> InvitedUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventInvitedUser>()
                .HasKey(c => new { c.UserId, c.EventId });
            modelBuilder.Entity<User>()
               .HasIndex(u => u.Email)
               .IsUnique();
        }
    }
}
