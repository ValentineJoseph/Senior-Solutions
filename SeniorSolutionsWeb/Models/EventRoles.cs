﻿using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class EventRoles
    {
        [Key]
        [Display(Name = "Event Role ID")]
        public int EventRoleID { get; set; }

        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Display(Name = "Role Rank")]
        public int RoleRank { get; set; }

        [Display(Name = "Role Name")]
        public String RoleName { get; set; }

        [Display(Name = "Role Permissions")]
        public int RoleEval { get; set; }
        public List<Invite>? Invites { get; set; }
        //public List<EventMembership>? EventMemberships { get; set; }
    }
}
