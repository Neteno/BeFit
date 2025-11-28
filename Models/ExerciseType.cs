using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class ExerciseType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa ćwiczenia")]
        [MaxLength(100, ErrorMessage = "Nazwa nie może przekraczać 100 znaków")]
        public string Name { get; set; }
    }
}
