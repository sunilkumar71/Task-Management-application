using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Database;
using Project.Interface;
using Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITaskRepository _taskRepository;

        public TasksController(ApplicationDbContext context, ITaskRepository taskRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
        }

        public async Task<IActionResult> Index(string searchString)
        {            
            var tasks = _context.TaskItems.
                Include(t => t.CreatedBy)
                .Include(t => t.LastUpdatedBy)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                tasks = tasks
                       .Where(t =>
                       t.Id.ToString().Contains(searchString) ||
                       t.Title.Contains(searchString) ||
                       t.CreatedBy.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Select(t => new
                {
                    Task = t,
                    MatchScore =
                        (t.Id.ToString().Contains(searchString) ? searchString.Length : 0) +
                        (t.Title.Contains(searchString) ? searchString.Length : 0) +
                        (t.CreatedBy.Name.Contains(searchString) ? searchString.Length : 0)
                })
                .OrderByDescending(t => t.MatchScore)
                .Select(t => t.Task); 
            }


            ViewData["SearchString"] = searchString;


            return View(await tasks.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            await DropdownsAsync();

            var task = new TaskItem
            {
                DueDate = DateTime.Today.AddDays(7),
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
            };
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,Status,Remarks,CreatedOn,LastUpdatedOn,CreatedById,LastUpdatedById")] TaskItem task)
        {
            await _taskRepository.AddTaskAsync(task);
            return RedirectToAction(nameof(Index));

        }

        private async Task DropdownsAsync()
        {
            var user = await _context.Users.ToListAsync();
            ViewBag.Users = new SelectList(user,
                "Id",
                "Name"
             );

            ViewBag.Statuses = new SelectList(new List<string>
            {
                "Not Started",
                "In Progress",
                "Completed"
            });

            ViewBag.RemarksOptions = new SelectList(new List<string>
            {
                "Yes",
                "No"
            });
        }


        public async Task<IActionResult> Edit(int id)
        {

            await DropdownsAsync();
            if (id == null)
            {
                return NotFound();
            }
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Title,Description,DueDate,Status,Remarks,CreatedOn,LastUpdatedOn,CreatedById,LastUpdatedById")] TaskItem taks)
        {
            await _taskRepository.UpdateTaskAsync(taks);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();
            var task = await _context.TaskItems
                .Include(t => t.CreatedBy)
                .Include(t => t.LastUpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

            var task = await _context.TaskItems.FindAsync(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            var task = await _context.TaskItems
                .Include(t => t.CreatedBy)
                .Include(t => t.LastUpdatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }
    }
}
