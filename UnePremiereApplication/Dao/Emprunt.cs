namespace UnePremiereApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emprunt")]
    public partial class Emprunt
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        public int IdExemplaire { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public virtual Client Client { get; set; }

        public virtual Exemplaire Exemplaire { get; set; }
    }
}
