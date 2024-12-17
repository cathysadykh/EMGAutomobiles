using System.ComponentModel.DataAnnotations;
namespace EMG.API.Modeles
{
    public class Marque
    {
        public int Id { get; set; }
        
        [Required]
        public string Nom { get; set; }
        
        public virtual ICollection<ModeleVoiture> Modeles { get; set; }
    }
}
