using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermissionApp.DbItems;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionApp.Controllers
{
    public class ModuleUisController : Controller
    {
        private readonly UIControlDatabaseContext _context;

        public ModuleUisController(UIControlDatabaseContext context)
        {
            _context = context;
        }

        // GET: ModuleUis
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModuleUi.ToListAsync());
        }

        // GET: ModuleUis/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModuleUi moduleUi = await _context.ModuleUi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moduleUi == null)
            {
                return NotFound();
            }

            return View(moduleUi);
        }

        // GET: ModuleUis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModuleUis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuleId,Uiname,Url,IsActive,IsOpen,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy")] ModuleUi moduleUi)
        {
            if (ModelState.IsValid)
            {
                moduleUi.Id = Guid.NewGuid();
                _context.Add(moduleUi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moduleUi);
        }

        // GET: ModuleUis/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModuleUi moduleUi = await _context.ModuleUi.FindAsync(id);
            if (moduleUi == null)
            {
                return NotFound();
            }
            return View(moduleUi);
        }

        // POST: ModuleUis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ModuleId,Uiname,Url,IsActive,IsOpen,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy")] ModuleUi moduleUi)
        {
            if (id != moduleUi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moduleUi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleUiExists(moduleUi.Id))
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
            return View(moduleUi);
        }

        // GET: ModuleUis/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModuleUi moduleUi = await _context.ModuleUi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moduleUi == null)
            {
                return NotFound();
            }

            return View(moduleUi);
        }

        // POST: ModuleUis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            ModuleUi moduleUi = await _context.ModuleUi.FindAsync(id);
            _context.ModuleUi.Remove(moduleUi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleUiExists(Guid id)
        {
            return _context.ModuleUi.Any(e => e.Id == id);
        }
    }
}
