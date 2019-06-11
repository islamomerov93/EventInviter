using EventInviter.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class EventInvitedUser
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public bool? UserAcceptOrReject { get; set; }
        [StringLength(100000, MinimumLength = 1)]
        [Column(TypeName = "text")]
        public string InvitationText { get; set; }

    }
}
