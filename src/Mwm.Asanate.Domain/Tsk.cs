﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mwm.Asanate.Domain {
    public class Tsk : NamedEntity {

        public Tsk() { }

        //Jira
        public string ExternalId { get; set; }

        public Status Status { get; set; }

        public bool IsArchived { get; set; }

        public bool IsCompleted { get; set; }

        public int? DurationEstimate { get; set; }

        public int? DuractionCompleted { get; set; }

        public int PercentageCompleted { get; set; }

        public string Notes { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? StartedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [JsonIgnore]
        public User? AssignedTo { get; set; }

        public int? AssignedToId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public User? CreatedBy { get; set; }

        public int? CreatedById { get; set; } = User.MeId;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public User? ModifiedBy { get; set; }

        public int? ModifiedById { get; set; } = User.MeId;

        [JsonIgnore]
        public Initiative Initiative { get; set; }

        public int InitiativeId { get; set; }

        [JsonIgnore]
        public string ProjectName => Initiative?.Project?.Name ?? string.Empty;

        [JsonIgnore]
        public string CompanyName => Initiative?.Project?.Company?.Name ?? string.Empty;

    }
}
