using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnePremiereApplication.DTO
{
    class AuteurDTO
    {
        /// <summary>
        /// Retourne l'id de l'auteur
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Retourne le nom de l'auteur
        /// </summary>
        public int Nom { get; set; }

        /// <summary>
        /// Retourne le prenom de l'auteur
        /// </summary>
        public string Prenom { get; set; }
    }
}
