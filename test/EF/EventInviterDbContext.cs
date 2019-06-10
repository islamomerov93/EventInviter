using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventInviter.Models;
using test.Models;

namespace EventInviter.EF
{
    public class EventInviterDbContext:DbContext
    {
        public EventInviterDbContext(DbContextOptions<EventInviterDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<InvitedUser> InvitedUsers { get; set; }
    }
}
