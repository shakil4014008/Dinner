namespace Dinner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dinner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dinner()
        {
            RSVPs = new HashSet<RSVP>();
        }

        public int DinnerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime EventDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string HostedBy { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSVP> RSVPs { get; set; }
    }
}
