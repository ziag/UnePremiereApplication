namespace UnePremiereApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publication")]
    public partial class Publication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publication()
        {
            Exemplaire = new HashSet<Exemplaire>();
            Auteur = new HashSet<Auteur>();
        }

        public int Id { get; set; }

        public int IdEditeur { get; set; }

        [StringLength(50)]
        public string Titre { get; set; }

        public int Type { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public virtual Editeur Editeur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exemplaire> Exemplaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auteur> Auteur { get; set; }
    }
}
