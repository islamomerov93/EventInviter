using EventInviter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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
        [StringLength(500,MinimumLength = 1)]
        [Column(TypeName = "nvarchar(max)")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastDateForParticipationSubmission { get; set; }
        public User User { get; set; }
    }
}
