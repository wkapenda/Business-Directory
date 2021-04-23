using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessDirectoryApp.Data;
using BusinessDirectoryApp.Models;
using Microsoft.AspNetCore.Http;

namespace BusinessDirectoryApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {

            var clients = from x in _context.ClientModel select x;

            clients = clients.OrderBy(x => x.Name);

            return View(await clients.ToListAsync());

            //return View();
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,Name,clientCode,linkedContacts,Contacts")] ClientModel clientModel)
        {
            // Use session for counter state management
            if(HttpContext.Session.GetInt32("Counter") == null)
            {
                HttpContext.Session.SetInt32("Counter", 1);
                HttpContext.Session.SetInt32("AlphaCounter", 0);
            }
            int numCounter = HttpContext.Session.GetInt32("Counter").Value;
            int alphaCounter = HttpContext.Session.GetInt32("AlphaCounter").Value;




            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string numString = numCounter.ToString();

            int numLength = numString.Length;


            // Add 0's to numerical part of client code
            if (numLength == 1)
            {
                numString = "00" + numString;
            }
            else if (numLength == 2)
            {
                numString = "0" + numString;
            }


            string clientName = clientModel.Name.ToUpper();
            int nullPosition = clientName.IndexOf(" ");

            string acronym = "";

            string[] splitName;

            if(nullPosition > -1)
            {
                splitName = clientName.Split(" ");

                foreach (string word in splitName)
                {
                    acronym += word[0];
                }

                if(acronym.Length >= 3)
                {
                    acronym = acronym.Substring(0, 3);
                }else
                {
                    acronym = acronym + alphabet[alphaCounter];
                    alphaCounter += 1;
                }
            }
            else if (nullPosition == -1 & clientName.Length > 3)
            {
                acronym = clientName.Substring(0,3);

            }else if (nullPosition == -1 & clientName.Length < 3)
            {
                acronym = clientName.ToString();
                acronym = acronym + alphabet[alphaCounter];
                alphaCounter += 1;
            }

            clientName = acronym + numString;

            clientModel.clientCode = clientName;


            
            numCounter += 1;
            
            HttpContext.Session.SetInt32("Counter", numCounter);
            HttpContext.Session.SetInt32("AlphaCounter", alphaCounter);



            if (ModelState.IsValid)
            {
                _context.Add(clientModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientModel);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }
            return View(clientModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,Name,clientCode,linkedContacts,Contacts")] ClientModel clientModel)
        {
            if (id != clientModel.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.ClientID))
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
            return View(clientModel);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientModel = await _context.ClientModel.FindAsync(id);
            _context.ClientModel.Remove(clientModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return _context.ClientModel.Any(e => e.ClientID == id);
        }
    }
}
