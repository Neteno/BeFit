using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }

        [Display(Name = "Data i godzina rozpoczęcia")]
        [Required]
        public DateTime Start { get; set; }

        [Display(Name = "Data i godzina zakończenia")]
        [Required]
        public DateTime End { get; set; }
        public List<ExerciseEntry> ExerciseEntries { get; set; } = new();
        [Display(Name = "Stworzone przez")]
        public string CreatedById { get; set; } = string.Empty;
        [Display(Name = "Stworzone przez")]
        public virtual AppUser? CreatedBy { get; set; }
    }
}
