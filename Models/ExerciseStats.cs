namespace BeFit.Models
{
    public class ExerciseStats
    {
        public string ExerciseName { get; set; }
        public int Count { get; set; }
        public int TotalReps { get; set; }
        public double AvgWeight { get; set; }
        public int MaxWeight { get; set; }
    }
}
