using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessDirectoryApp.Data;
using BusinessDirectoryApp.Models;

namespace BusinessDirectoryApp.Controllers
{
    public class CCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CC
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClientContact.Include(c => c.Client).Include(c => c.Contact);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientContact = await _context.ClientContact
                .Include(c => c.Client)
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clientContact == null)
            {
                return NotFound();
            }

            return View(clientContact);
        }

        // GET: CC/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.ClientModel, "ClientID", "Name");
            ViewData["ContactID"] = new SelectList(_context.ContactModel, "ContactID", "Email");
            return View();
        }

        // POST: CC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,ContactID")] ClientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.ClientModel, "ClientID", "Name", clientContact.ClientID);
            ViewData["ContactID"] = new SelectList(_context.ContactModel, "ContactID", "Email", clientContact.ContactID);
            return View(clientContact);
        }

        // GET: CC/Edit/5
        public async Task<IActionResult> Edit(int? id1,int? id2)
        {
            if (id1 == null)
            {
                return NotFound();
            }
            if (id2 == null)
            {
                return NotFound();
            }

            var clientContact = await _context.ClientContact.FindAsync(id1, id2);
            if (clientContact == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.ClientModel, "ClientID", "Name", clientContact.ClientID);
            ViewData["ContactID"] = new SelectList(_context.ContactModel, "ContactID", "Email", clientContact.ContactID);
            return View(clientContact);
        }

        // POST: CC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id1, int id2, [Bind("ClientID,ContactID")] ClientContact clientContact)
        {
            if (id1 != clientContact.ContactID)
            {
                return NotFound();
            }

            if (id2 != clientContact.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientContactExists(clientContact.ClientID))
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
            ViewData["ClientID"] = new SelectList(_context.ClientModel, "ClientID", "Name", clientContact.ClientID);
            ViewData["ContactID"] = new SelectList(_context.ContactModel, "ContactID", "Email", clientContact.ContactID);
            return View(clientContact);
        }

        // GET: CC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientContact = await _context.ClientContact
                .Include(c => c.Client)
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.ClientID == id);



            if (clientContact == null)
            {
                return NotFound();
            }

            return View(clientContact);
        }

        // POST: CC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            //var clientContact = await _context.ClientContact.FindAsync(id);
            //_context.ClientContact.Remove(clientContact);
            var clientContact = await _context.ClientContact.Include(a => a.Client)
               .Where(a => a.ClientID == id)
                .FirstOrDefaultAsync();
            _context.ClientContact.Remove(clientContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientContactExists(int id)
        {

            return _context.ClientContact.Any(e => e.ClientID == id);
        }
    }
}
