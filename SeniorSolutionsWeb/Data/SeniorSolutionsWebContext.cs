﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Models;

namespace SeniorSolutionsWeb.Data
{
    public class SeniorSolutionsWebContext : DbContext
    {
        public SeniorSolutionsWebContext (DbContextOptions<SeniorSolutionsWebContext> options)
            : base(options)
        {
        }

        public DbSet<SeniorSolutionsWeb.Models.Resident> Resident { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.ServiceRequest> ServiceRequest { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Club> Club { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.ClubMembership> ClubMembership { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.ClubMeeting> ClubMeeting { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.ClubRoles> ClubRoles { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.CommunityIssue> CommunityIssue { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.CommunityIssueReply> CommunityIssueReplies { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.CommunityIssueVote> CommunityIssueVote { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Event> Events { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.EventRoles> EventRoles { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Fee> Fees { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Locations> Locations { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Orientation> Orientations { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.OrientationAttendee> OrientationAttendees { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Poll> Poll { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.PollVote> PollVote { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Employee> Employee { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Invite> Invite { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Questionnaire> Questionnaire { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.Question> Question { get; set; }
        public DbSet<SeniorSolutionsWeb.Models.QuestionResponse> QuestionResponse { get; set; }
        
        public DbSet<SeniorSolutionsWeb.Models.EventMembership> EventMembership { get; set; }

    }
}
