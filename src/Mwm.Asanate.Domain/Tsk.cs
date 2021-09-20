﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwm.Asanate.Domain {
    public class Tsk : NamedEntity {

        //Jira
        public string ExternalId { get; set; }

        public Status Status { get; set; }

        public bool IsArchived { get; set; }

        public string Notes { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? StartedDate { get; set; }

        public Initiative Initiative { get; set; }

        public int InitiativeId { get; set; }

        public User? AssignedTo { get; set; }

        public int AssignedToId { get; set; }

        public string ProjectName => Initiative?.Project?.Name ?? string.Empty;

        public string CompanyName => Initiative?.Project?.Company?.Name ?? string.Empty;

    }
}
