﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;
using System.Net;
using System.Net.Mail;

namespace SeniorSolutionsWeb.Controllers
{
    [Authorize(Roles="Manager")]
    public class ManagerController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public ManagerController(SeniorSolutionsWebContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Schedule()
        {
            return View();
        }
        public IActionResult Transportation()
        {
            return View();
        }

        public IActionResult clubs()
        {
            return View();
        }

        public IActionResult events()
        {
            return View();
        }

        public IActionResult create_clubs()
        {
            return View();
        }

        public IActionResult create_events()
        {
            return View();
        }

        public IActionResult post()
        {
            return View();
        }

        public IActionResult Poll()
        {
            return View();
        }
        
        public async Task<IActionResult> CreatePoll([Bind("Question, Answer, Answer2, Answer3, Answer4")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Poll", poll);
        }

        //public async Task<IActionResult> ListResidents() //Initial view
        //{
        //    return View(await _context.Resident.ToListAsync());
        //}

        //public async Task<IActionResult> EditResidents(int id) //Clicked edit button on resident
        //{
            
        //    return View("EditResidents", await _context.Resident.FindAsync(id));
        //}




        //[HttpPost, ActionName("Edit")]
        //public async Task<IActionResult> EditResidents(int id, [Bind("Id,FirstName,MiddleName,LastName,ResidencyStatus,ResidentLeaseNumber,DateAccountCreated")] Resident resident)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _context.Resident.Update(resident);
        //    }
        //    return View("Index");
        //}


        // GET: Residents
        public async Task<IActionResult> ListResidents()
        {
            return View(await _context.Resident.ToListAsync());
        }

        // GET: Residents/Details/5
        public async Task<IActionResult> DetailsResidents(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // GET: Residents/Create
        public IActionResult CreateResidents()
        {
            return View();
        }
        public IActionResult AdvancedCreateResident()
        {
            return View();
        }
        public IActionResult CheckClub()
        {
            //Once the Add Club Button is pressed,
            //a partial view asking for the Club ID
            //will be given.
            //If the ID is valid, the Manager may press
            //the search button and a new partial
            //view will poulate this view.
            //The remove button will remove the 
            //input
            return PartialView("_AddClub");
        }
        public IActionResult PopulateRoles(int ClubID)
        {
            Console.WriteLine("--------------------------\n");
            var FindClub = _context.Club.Where(m => m.ClubId == ClubID);
            if (!FindClub.Any())
            {
                this.ControllerContext.HttpContext.Response.StatusCode = 404;
                return new EmptyResult();
            }
            foreach(var club in FindClub)
            {
                ViewData["Man-Club_Name"] = club.ClubName;
                ViewData["Man-Club_ID"] = club.ClubId;
            } 

            var FindEval = from Club in _context.ClubRoles
                           where Club.ClubId == ClubID
                           select Club;
            var give = from a in FindEval
                              select new SelectListItem
                              {
                                  Text = a.RoleName,
                                  Value = a.RoleID.ToString(),
                                  Selected = false
                              };
            var NewFindEval = give.AsNoTracking().ToList();

            //This view has a readonly input box
            //containing the Club Name, a
            //select box containg all the roles
            //for the given Club,
            //and a table with the permisions
            //associated with it.
            //The submit button will remove 
            //the table and make all elements readonly
            //except the remove button
            return PartialView("_AddRole", FindEval);
        }

        // POST: Residents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResidents([Bind("Id,Email,Password,FirstName,MiddleName,LastName,ResidencyStatus,ResidentLeaseNumber,DateAccountCreated")] Resident resident)
        {
            resident.Password = AccountController.HashPassword(resident.Password);
            if (ModelState.IsValid)
            {
                _context.Add(resident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resident);
        }

        // GET: Residents/Edit/5
        public async Task<IActionResult> EditResidents(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }
            return View(resident);
        }

        // POST: Residents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResidents(int id, [Bind("Id,Password,Email,FirstName,MiddleName,LastName,ResidencyStatus,ResidentLeaseNumber,DateAccountCreated")] Resident resident)
        {
            if (id != resident.Id)
            {
                return NotFound();
            }
            resident.Password = _context.Resident.AsNoTracking().First(res => res.Id == id).Password;
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidentExists(resident.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListResidents));
            }
            return View(resident);
        }

        // GET: Residents/Delete/5
        public async Task<IActionResult> DeleteResidents(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resident == null)
            {
                return NotFound();
            }

            return View(resident);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("DeleteResidents")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedResidents(int id)
        {
            var resident = await _context.Resident.FindAsync(id);
            _context.Resident.Remove(resident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListResidents));
        }

        private bool ResidentExists(int id)
        {
            return _context.Resident.Any(e => e.Id == id);
        }
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }

        // This is a test for submitting a key to a user || System.Net
        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("", "Community");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "";
                    var sub = "Your Account is Ready";
                    var body = "Your Community Account is ready for creation using the following:\n Username:" + receiver 
                        + "Key:"+ message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}
