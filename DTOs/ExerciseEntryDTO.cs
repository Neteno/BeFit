namespace BeFit.Models
{
    public class ExerciseEntryDTO
    {
        public int TrainingSessionId { get; set; }
        public int ExerciseTypeId { get; set; }
        public int Weight { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
