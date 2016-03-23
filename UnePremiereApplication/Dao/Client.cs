namespace UnePremiereApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Emprunt = new HashSet<Emprunt>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        [StringLength(50)]
        public string Pays { get; set; }

        [StringLength(100)]
        public string Rue { get; set; }

        [StringLength(5)]
        public string CodePostal { get; set; }

        [StringLength(10)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Ville { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprunt> Emprunt { get; set; }
    }
}
