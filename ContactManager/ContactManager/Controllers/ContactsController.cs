using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers;

// The ContactsController handles all CRUD operations and search functionality for contacts.
public class ContactsController : Controller
{
    private readonly AppDbContext _context;

    // Constructor to initialize the database context
    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Contacts
    // Displays a list of all contacts, with optional search functionality
    public async Task<IActionResult> Index(string searchString)
    {
        var contacts = from c in _context.Contacts
                       select c;

        if (!String.IsNullOrEmpty(searchString))
        {
            contacts = contacts.Where(s => s.Name.Contains(searchString));
        }

        return View(await contacts.ToListAsync());
    }

    // GET: Contacts/Create
    // Displays the form for creating a new contact
    public IActionResult Create()
    {
        return View();
    }

    // POST: Contacts/Create
    // Handles the form submission for creating a new contact
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Email,Phone,Address")] Contact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    // GET: Contacts/Edit/5
    // Displays the form for editing an existing contact
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Contacts == null)
        {
            return NotFound();
        }

        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: Contacts/Edit/5
    // Handles the form submission for editing an existing contact
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Address")] Contact contact)
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

    // GET: Contacts/Delete/5
    // Displays the confirmation page for deleting a contact
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Contacts == null)
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

    // GET: Contacts/View/5
    // Displays the details of a specific contact
    public async Task<IActionResult> View(int? id)
    {
        if (id == null || _context.Contacts == null)
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

    // POST: Contacts/Delete/5
    // Handles the form submission for deleting a contact
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Contacts == null)
        {
            return Problem("Entity set 'AppDbContext.Contacts' is null.");
        }
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Checks if a contact exists by ID
    private bool ContactExists(int id)
    {
        return _context.Contacts.Any(e => e.Id == id);
    }
}
