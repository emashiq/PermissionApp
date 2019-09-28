using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermissionApp.DbItems;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionApp.Controllers
{
    public class ModuleUicontrolsController : Controller
    {
        private readonly UIControlDatabaseContext _context;

        public ModuleUicontrolsController(UIControlDatabaseContext context)
        {
            _context = context;
        }

        // GET: ModuleUicontrols
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModuleUicontrols.ToListAsync());
        }

        // GET: ModuleUicontrols/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModuleUicontrols moduleUicontrols = await _context.ModuleUicontrols
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moduleUicontrols == null)
            {
                return NotFound();
            }

            return View(moduleUicontrols);
        }

        // GET: ModuleUicontrols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModuleUicontrols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuleUiid,ControlName,IsActive,IsOpen,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy")] ModuleUicontrols moduleUicontrols)
        {
            if (ModelState.IsValid)
            {
                moduleUicontrols.Id = Guid.NewGuid();
                _context.Add(moduleUicontrols);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moduleUicontrols);
        }

        // GET: ModuleUicontrols/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModuleUicontrols moduleUicontrols = await _context.ModuleUicontrols.FindAsync(id);
            if (moduleUicontrols == null)
            {
                return NotFound();
            }
            return View(moduleUicontrols);
        }

        // POST: ModuleUicontrols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ModuleUiid,ControlName,IsActive,IsOpen,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy")] ModuleUicontrols moduleUicontrols)
        {
            if (id != moduleUicontrols.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moduleUicontrols);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleUicontrolsExists(moduleUicontrols.Id))
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
            return View(moduleUicontrols);
        }

        // GET: ModuleUicontrols/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModuleUicontrols moduleUicontrols = await _context.ModuleUicontrols
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moduleUicontrols == null)
            {
                return NotFound();
            }

            return View(moduleUicontrols);
        }

        // POST: ModuleUicontrols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            ModuleUicontrols moduleUicontrols = await _context.ModuleUicontrols.FindAsync(id);
            _context.ModuleUicontrols.Remove(moduleUicontrols);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleUicontrolsExists(Guid id)
        {
            return _context.ModuleUicontrols.Any(e => e.Id == id);
        }
    }
}
