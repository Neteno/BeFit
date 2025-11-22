using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;
using System.Security.Claims;
using BeFit.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace BeFit.Controllers
{
    [Authorize]
    public class TrainingSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
        public TrainingSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainingSessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainingSessions
                .Where(e => e.CreatedById == GetUserId())
                .Include(e => e.ExerciseEntries)
                .Select(e => new TrainingSessionDTO(e)).ToListAsync();

            return View(await applicationDbContext);

        }
        // GET: TrainingSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSession = await _context.TrainingSessions
                .Where(e => e.CreatedById == GetUserId())
                .Include(e => e.ExerciseEntries)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingSession == null)
            {
                return NotFound();
            }

            return View(trainingSession);
        }


        // GET: TrainingSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingSessionDTO trainingSessionDTO)
        {
            TrainingSession trainingSession = new TrainingSession()
            {
                Start = trainingSessionDTO.Start,
                End = trainingSessionDTO.End,
                CreatedById = GetUserId()
            };

            if (ModelState.IsValid)
            {
                _context.Add(trainingSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingSession);
        }

        // GET: TrainingSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingSession = await _context.TrainingSessions
                .Where(e => e.CreatedById == GetUserId())
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingSession == null)
            {
                return NotFound();
            }
            return View(trainingSession);
        }

        // POST: TrainingSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start,End")] TrainingSessionDTO trainingSessionDTO)
        {
            if (id != trainingSessionDTO.Id)
            {
                return NotFound();
            }

            TrainingSession trainingSession = new TrainingSession()
            {
                Start = trainingSessionDTO.Start,
                End = trainingSessionDTO.End,
                ExerciseEntries =new List<ExerciseEntry>(),
                CreatedById = GetUserId()
            };

            if (!TrainingSessionExists(trainingSession.Id, GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingSessionExists(trainingSession.Id,GetUserId()))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trainingSession);
        }

        // POST: TrainingSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession != null)
            {
                _context.TrainingSessions.Remove(trainingSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingSessionExists(int id,string userId)
        {
            return _context.TrainingSessions.Any(e => e.Id == id && e.CreatedById == userId);
        }
    }
}
