using EventInviter.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(4000,MinimumLength = 1)]
        [Column(TypeName = "nvarchar(max)")]
        public string Name { get; set; }
        [Required]
        [StringLength(100000, MinimumLength = 1)]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime LastDateForParticipationSubmission { get; set; } = DateTime.Now;
        public virtual User User { get; set; }

    }
}
