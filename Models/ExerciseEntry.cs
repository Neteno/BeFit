using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class ExerciseEntry
    {
        public int Id { get; set; }

        // Relacja do TrainingSession
        [Required]
        [Display(Name = "Sesja treningowa")]
        public int TrainingSessionId { get; set; }
        public TrainingSession? TrainingSession { get; set; }

        // Relacja do ExerciseType
        [Required]
        [Display(Name = "Typ ćwiczenia")]
        public int ExerciseTypeId { get; set; }
        public ExerciseType? ExerciseType { get; set; }

        // Obciążenie w kg (może być 0 jeśli ćwiczenie bez obciążenia)
        [Range(0, 10000)]
        [Column(TypeName = "decimal(8,2)")]
        [Display(Name = "Obciążenie (kg)")]
        public decimal Weight { get; set; }

        [Range(1, 100)]
        [Display(Name = "Serie")]
        public int Sets { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Powtórzenia")]
        public int Reps { get; set; }
    }
}
