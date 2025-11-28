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
        [Range(0, 10000, ErrorMessage = "Obciążenie musi być w zakresie od 0 do 10 000 kg.")]
        [Display(Name = "Obciążenie (kg)")]
        public int Weight { get; set; }

        [Range(1, 100, ErrorMessage = "Liczba serii musi być w zakresie od 1 do 100.")]
        [Display(Name = "Serie")]
        public int Sets { get; set; }

        [Range(1, 1000, ErrorMessage = "Liczba powtórzeń musi być w zakresie od 1 do 1000.")]
        [Display(Name = "Powtórzenia")]
        public int Reps { get; set; }

        [Display(Name = "Stworzone przez")]
        public string CreatedById { get; set; } = string.Empty;
        [Display(Name = "Stworzone przez")]
        public virtual AppUser? CreatedBy { get; set; }
    }
}
