namespace BeFit.Models
{
    public class ExerciseStats
    {
        public string ExerciseName { get; set; }
        public int Count { get; set; }
        public int TotalReps { get; set; }
        public decimal AvgWeight { get; set; }
        public decimal MaxWeight { get; set; }
    }
}
