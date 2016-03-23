namespace UnePremiereApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class monModele : DbContext
    {
        public monModele()
            : base("name=monModele")
        {
        }

        public virtual DbSet<Auteur> Auteur { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<CoordonneesAuteur> CoordonneesAuteur { get; set; }
        public virtual DbSet<Editeur> Editeur { get; set; }

        public virtual DbSet<EditeurBD> EditeurBD { get; set; }
        public virtual DbSet<EditeurInformatique> EditeurInformatique { get; set; }
        public virtual DbSet<EditeurPsychologie> EditeurPsychologie { get; set; }
        public virtual DbSet<Emprunt> Emprunt { get; set; }
        public virtual DbSet<Exemplaire> Exemplaire { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<VueLivres> VueLivres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteur>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Auteur>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Auteur>()
                .HasOptional(e => e.CoordonneesAuteur)
                .WithRequired(e => e.Auteur);

            modelBuilder.Entity<Auteur>()
                .HasMany(e => e.Publication)
                .WithMany(e => e.Auteur)
                .Map(m => m.ToTable("Publi_Auteur").MapLeftKey("IdAuteur").MapRightKey("IdPublication"));

            modelBuilder.Entity<Client>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Pays)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Rue)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CodePostal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Emprunt)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CoordonneesAuteur>()
                .Property(e => e.Rue)
                .IsUnicode(false);

            modelBuilder.Entity<CoordonneesAuteur>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<CoordonneesAuteur>()
                .Property(e => e.CodePostal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CoordonneesAuteur>()
                .Property(e => e.TelephoneFixe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CoordonneesAuteur>()
                .Property(e => e.TelephoneMobile)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Editeur>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Editeur>()
                .HasMany(e => e.Publication)
                .WithRequired(e => e.Editeur)
                .HasForeignKey(e => e.IdEditeur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exemplaire>()
                .HasMany(e => e.Emprunt)
                .WithRequired(e => e.Exemplaire)
                .HasForeignKey(e => e.IdExemplaire)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publication>()
                .Property(e => e.Titre)
                .IsUnicode(false);

            modelBuilder.Entity<Publication>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Publication>()
                .HasMany(e => e.Exemplaire)
                .WithRequired(e => e.Publication)
                .HasForeignKey(e => e.IdPublication)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VueLivres>()
                .Property(e => e.Titre_Livre)
                .IsUnicode(false);

            modelBuilder.Entity<VueLivres>()
                .Property(e => e.Editeur)
                .IsUnicode(false);
        }
    }
}
