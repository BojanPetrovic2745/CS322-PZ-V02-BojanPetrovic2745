using System.Data.Entity;

namespace CS322_PZ_V02_BojanPetrovic2745
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=CS322PZMODEL")
        {
        }

        public virtual DbSet<Kontrola> Kontrolas { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Patient_Kontrola> Patient_Kontrola { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontrola>()
                .HasMany(e => e.Patient_Kontrola)
                .WithRequired(e => e.Kontrola)
                .HasForeignKey(e => e.KontroalD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.ime)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.jmbg)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.simptomi)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.terapija)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Patient_Kontrola)
                .WithRequired(e => e.Patient)
                .HasForeignKey(e => e.PatientID)
                .WillCascadeOnDelete(false);
        }
    }
}
