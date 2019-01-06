namespace Dinner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RSVP")]
    public partial class RSVP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RsvpID { get; set; }

        public int DinnerID { get; set; }

        [Required]
        [StringLength(30)]
        public string AttendeeName { get; set; }

        public virtual Dinner Dinner { get; set; }
    }
}
