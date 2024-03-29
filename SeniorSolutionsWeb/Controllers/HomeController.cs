﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;
using System.Diagnostics;

namespace SeniorSolutionsWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeniorSolutionsWebContext _context;


        public HomeController(ILogger<HomeController> logger, SeniorSolutionsWebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var residentId = User.Claims.Single(user => user.Type == "residentId").Value;
            HomeViewModel modelCollection = new HomeViewModel();
            modelCollection.CommunityIssues = await _context.CommunityIssue.ToListAsync();
            modelCollection.Polls = await _context.Poll.ToListAsync();
            modelCollection.Votes = await _context.PollVote.ToListAsync();
            _context.Events.Include(ev => ev.Residents).ToList();
            modelCollection.Events = await _context.Events.ToListAsync();
            modelCollection.Questionnaires = await _context.Questionnaire.Include(q => q.Questions).ThenInclude(q => q.Responses).ToListAsync();
            modelCollection.Fees = await _context.Fees.Where(p => p.ResidentId == int.Parse(residentId)).ToListAsync();
            var orientations = _context.Orientations.ToList();
            if (orientations.Count > 0)
            {
                var oDate = (from orientation in orientations where orientation.Date >= DateTime.Now orderby orientation.Date select orientation).Take(1).First();
                ViewData["NextOrientationDate"] = oDate.Date;
            }
            
            return View(modelCollection);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("Poll")]
        public async Task<IActionResult> Poll(string id, string vote, int residentId)
        {
            int ID = int.Parse(id);
            Poll? poll = await _context.Poll.FindAsync(ID);
            PollVote? pollVote = await _context.PollVote.Where(p => p.Id == ID).SingleOrDefaultAsync(p => p.ResidentId == residentId);

            if(pollVote == null)
            {
                if (vote == poll.Answer)
                {
                    poll.Answer1Votes++;
                }else if (vote == poll.Answer2)
                {
                    poll.Answer2Votes++;
                }else if (vote == poll.Answer3)
                {
                    poll.Answer3Votes++;
                }else if (vote == poll.Answer4)
                {
                    poll.Answer4Votes++;
                }
                pollVote = new PollVote();
                pollVote.VotedFor = vote;
                pollVote.PollId = ID;
                pollVote.ResidentId = residentId; 
                _context.PollVote.Add(pollVote);
                _context.Poll.Update(poll);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet, ActionName("EventSignup")]
        public async Task<IActionResult> EventSignup(int? residentId,int? eventId)
        {
            if(residentId == null || eventId == null)
            {
                return NotFound();
            }
            var eventToJoin = await _context.Events.FindAsync(eventId);
            var residentToJoin = await _context.Resident.FindAsync(residentId);
            //var timesRegistered = _context.Events
            //    .Include(ev => ev.Residents)
            //    .Where(ev => ev.Id == eventId && ev.Residents.Contains(residentToJoin))
            //    .ToList()
            //    .Count();
            //if (timesRegistered > 0)
            //{
            //    RedirectToAction(nameof(Index));
            //}
            if (eventToJoin == null || residentToJoin == null)
            {
                return NotFound();
            }
            residentToJoin.Events = new List<Event>();
            residentToJoin.Events.Add(eventToJoin);
            eventToJoin.Residents = new List<Resident>();
            eventToJoin.Residents.Add(residentToJoin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AnswerQuestionnaire(string? questionnaireId, string? questionTotal, string? questionIdTotal)
        {
            if (questionnaireId == null || questionTotal == null || questionIdTotal == null) return NotFound();
            string[] questionsSplit = questionTotal.Split("////", StringSplitOptions.RemoveEmptyEntries);
            string[] questionIdArr = questionIdTotal.Split("////", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < questionIdArr.Length; i++)
            {
                var response = new QuestionResponse();
                response.ResidentId = int.Parse(User.Claims.Single(user => user.Type == "residentId").Value);
                response.QuestionId = int.Parse(questionIdArr[i]);
                response.Response = questionsSplit[i];
                await _context.QuestionResponse.AddAsync(response);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}