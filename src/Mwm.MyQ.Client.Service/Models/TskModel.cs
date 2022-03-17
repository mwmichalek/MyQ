﻿using Mwm.MyQ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwm.MyQ.Client.Service.Models {
    public class TskModel : EntityModel<Tsk> {

        public int RankId { get; set; }

        public Status Status { get; set; }

        public int StatusId => (int)Status;

        public string StatusName {
            get {
                return Status.ToStr();
            }
            set {
                Status = value.ToStatus();
            }
        }

        public bool IsArchived { get; set; }

        // IsCompleted

        //public int? PercentCompleted { get; set; }

        public float? DurationEstimate { get; set; }

        public float? DurationCompleted => ActivityModels.Sum(am => am.Duration);

        public string Notes { get; set; }

        public DateTime? CreatedDate { get; set; }  

        public DateTime? DueDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? StartedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int? InitiativeId { get; set; }

        public string InitiativeName { get; set; }

        public string InitiativeExternalId { get; set; }

        public string InitiativeExternalLink { get; set; }

        public int? ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectAbbreviation { get; set; }

        public string ProjectColor { get; set; }

        public string CompanyName { get; set; }

        public string CompanyNameAndProjectName => $"{CompanyName} - {ProjectName}";

        public bool IsInFocus { get; set; }

        public List<ActivityModel> ActivityModels { get; set; } = new List<ActivityModel>();    

    }
}
