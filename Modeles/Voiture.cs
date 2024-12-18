
using System;
using System.ComponentModel.DataAnnotations;
namespace EMG.API.Modeles
{
    public class Voiture
    {
        public int Id { get; set; }

        [Required]
        public int MarqueId { get; set; }
        public Marque Marque { get; set; }

        [Required]
        public int ModeleId { get; set; }
        public ModeleVoiture Modele { get; set; }

        [Required]
        [Range(2010, 2025)]
        public int Annee { get; set; }

        [Required]
        public decimal Prix { get; set; }

        [Required]
        public string Description { get; set; }

        public string UrlImage { get; set; }

        public bool EstDisponible { get; set; } = true;

        public DateTime DateAjout { get; set; } = DateTime.Now;
    }
}

