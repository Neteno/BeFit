using BeFit.Models;

namespace BeFit.DTOs
{
    public class ExerciseEntryDTO
    {
        public int Id { get; set; }
        public int TrainingSessionId { get; set; }
        public virtual TrainingSession? TrainingSession { get; set; }
        public int ExerciseTypeId { get; set; }
        public virtual ExerciseType? ExerciseType { get; set; }
        public int Weight { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public ExerciseEntryDTO() { }
        public ExerciseEntryDTO(ExerciseEntry exerciseEntry)
        {
            Id = exerciseEntry.Id;
            Weight = exerciseEntry.Weight;
            Sets = exerciseEntry.Sets;
            Reps = exerciseEntry.Reps;
        }

    }
}
