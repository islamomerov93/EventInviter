using EventInviter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class EventInvitedUser
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key]
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool? UserAcceptOrReject { get; set; }
        [StringLength(100000, MinimumLength = 1)]
        [Column(TypeName = "text")]
        public string InvitationText { get; set; }


    }
}
