using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading.Tasks;

namespace BeFit.Models
{
    public class ExerciseEntry
    {
        public int Id { get; set; }

        // Relacja do TrainingSession
        [Display(Name = "Sesja treningowa")]
        public int TrainingSessionId { get; set; }
        [Display(Name = "Sesja treningowa")]
        public virtual TrainingSession? TrainingSession { get; set; }

        // Relacja do ExerciseType
        [Display(Name = "Typ ćwiczenia")]
        public int ExerciseTypeId { get; set; }
        [Display(Name = "Typ ćwiczenia")]
        public virtual ExerciseType? ExerciseType { get; set; }

        // Obciążenie w kg (może być 0 jeśli ćwiczenie bez obciążenia)
        [Range(0, 10000)]
        [Display(Name = "Obciążenie (kg)")]
        public int Weight { get; set; }

        [Range(1, 100)]
        [Display(Name = "Serie")]
        public int Sets { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Powtórzenia")]
        public int Reps { get; set; }

        [Display(Name = "Created by")]
        public string CreatedById { get; set; } = string.Empty;
        [Display(Name = "Created by")]
        public virtual AppUser? CreatedBy { get; set; }
    }
}
