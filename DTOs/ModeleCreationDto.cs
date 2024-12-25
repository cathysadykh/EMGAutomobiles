using System;
using System.ComponentModel.DataAnnotations;
public class ModeleCreationDto
{
    [Required]
    public string Nom { get; set; }

    [Required]
    public int MarqueId { get; set; }
}