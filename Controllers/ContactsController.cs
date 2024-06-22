using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagement.Data;
using ContactManagement.Models;

namespace ContactManagement.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactManagerDBContext _context;

        public ContactsController(ContactManagerDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Contacts.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(new Contact() { Id = id.Value });
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View(new Contact() { Id = id.Value });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Address")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            return View(contact);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Json(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> GetContactDetails(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Json(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var existingContact = _context.Contacts.FirstOrDefault(c => c.Id == contact.Id);
                if (existingContact == null)
                {
                    return NotFound();
                }

                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.Address = contact.Address;

                _context.Update(existingContact);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
