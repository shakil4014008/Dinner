namespace Dinner.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBDinnerModel : DbContext
    {
        public DBDinnerModel()
            : base("name=DBDinnerModel")
        {
        }

        public virtual DbSet<Dinner> Dinners { get; set; }
        public virtual DbSet<RSVP> RSVPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dinner>()
                .HasMany(e => e.RSVPs)
                .WithRequired(e => e.Dinner)
                .WillCascadeOnDelete(false);
        }

        public void Insert(Dinner entity)
        {
            Dinners.Add(entity);
        }

    }
}
