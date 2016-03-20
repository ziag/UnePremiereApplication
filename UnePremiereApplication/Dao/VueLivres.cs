namespace UnePremiereApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VueLivres
    {
        [Key]
        [Column("Id Publication")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Publication { get; set; }

        [Column("Titre Livre")]
        [StringLength(50)]
        public string Titre_Livre { get; set; }

        [StringLength(50)]
        public string Editeur { get; set; }

        public int? Exemplaires { get; set; }
    }
}
