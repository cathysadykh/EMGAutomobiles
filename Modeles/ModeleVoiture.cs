using System.ComponentModel.DataAnnotations;
namespace EMG.API.Modeles
{
    public class ModeleVoiture
    {
        public int Id { get; set; }
        
        [Required]
        public string Nom { get; set; }
        
        public int MarqueId { get; set; }
        public virtual Marque Marque { get; set; }
    }
}