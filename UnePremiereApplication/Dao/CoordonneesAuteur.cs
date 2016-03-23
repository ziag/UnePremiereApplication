namespace UnePremiereApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoordonneesAuteur")]
    public partial class CoordonneesAuteur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAuteur { get; set; }

        [StringLength(50)]
        public string Rue { get; set; }

        [StringLength(50)]
        public string Ville { get; set; }

        [StringLength(5)]
        public string CodePostal { get; set; }

        [StringLength(10)]
        public string TelephoneFixe { get; set; }

        [StringLength(10)]
        public string TelephoneMobile { get; set; }

        public virtual Auteur Auteur { get; set; }
    }
}
