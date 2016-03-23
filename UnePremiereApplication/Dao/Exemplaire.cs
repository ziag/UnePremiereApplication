namespace UnePremiereApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exemplaire")]
    public partial class Exemplaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exemplaire()
        {
            Emprunt = new HashSet<Emprunt>();
        }

        public int Id { get; set; }

        public int IdPublication { get; set; }

        public DateTime DateAchat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprunt> Emprunt { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
