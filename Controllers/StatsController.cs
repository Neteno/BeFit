using BeFit.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            DateTime fromDate = DateTime.Now.AddDays(-28);

            var stats = await _context.ExerciseEntries
                .Where(e => e.TrainingSession.Start >= fromDate)
                .GroupBy(e => e.ExerciseType.Name)
                .Select(g => new ExerciseStats
                {
                    ExerciseName = g.Key,
                    Count = g.Count(),
                    TotalReps = g.Sum(x => x.Sets * x.Reps),
                    AvgWeight = g.Average(x => x.Weight),
                    MaxWeight = g.Max(x => x.Weight)
                })
                .ToListAsync();

            return View(stats);
        }
    }
}
