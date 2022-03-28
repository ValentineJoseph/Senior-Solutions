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
        public DbSet<SeniorSolutionsWeb.Models.Locations> Locations { get; set; }
    }
}
