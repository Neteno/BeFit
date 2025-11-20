using BeFit.Models;

namespace BeFit.DTOs
{
    public class TrainingSessionDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<ExerciseEntry> ExerciseEntries { get; set; } = new();
        public string CreatedById { get; set; }
        public virtual AppUser? CreatedBy { get; set; }


        public TrainingSessionDTO() { }
        public TrainingSessionDTO(TrainingSession trainingSession) 
        { 
            Id = trainingSession.Id;
            Start = trainingSession.Start;
            End = trainingSession.End;
            ExerciseEntries = trainingSession.ExerciseEntries;
        }
    }
}
