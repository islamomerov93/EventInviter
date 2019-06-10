using EventInviter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class InvitedUser
    {
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
