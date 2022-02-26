﻿using Microsoft.AspNetCore.Components;
using Mwm.MyQ.Client.Service.Facades;
using Mwm.MyQ.Client.Service.Models;
using Mwm.MyQ.Application.Tsks.Commands;
using Mwm.MyQ.Domain;
using System;
using System.Threading.Tasks;

namespace Mwm.MyQ.Client.Mud.Components;

public partial class TskCard : ComponentBase {

    [Parameter]
    public TskModel TskModel { get; set; }

    [Inject]
    public EntityStateFacade EntityStateFacade { get; set; }

    [Parameter]
    public bool IncludeCompanyName { get; set; }

    public string HeaderStyles => TskModel.IsInFocus ? $"background-color: {TskModel.ProjectColor}; background-image: linear-gradient(rgba(0, 0, 0, 0.3) 0 0);" :
                                                       $"background-color: {TskModel.ProjectColor}; background-image: linear-gradient(rgba(0, 0, 0, 0.7) 0 0);";

    public string HeaderClasses => TskModel.IsInFocus ? "bg-primary" : "bg-dark";

    public string HourProgressDisplay => (TskModel.DurationCompleted.HasValue && TskModel.DurationEstimate.HasValue) ?
                    $"{TskModel.DurationCompleted} / ~{TskModel.DurationEstimate}" :
                        TskModel.DurationCompleted.HasValue ? TskModel.DurationCompleted.ToString() :
                        TskModel.DurationEstimate.HasValue ? $"~{TskModel.DurationEstimate}" : "";

    public string DueDateDisplay {
        get {
            var daysTillDueDate = DaysTillDueDate();
            return (daysTillDueDate.HasValue) ? $"{TskModel.DueDate.Value.ToString("MM/dd/yyyy")} ({Math.Abs(daysTillDueDate.Value)})" : string.Empty;
        }
    }
    public string DueDateDisplayClass {
        get {
            var daysTillDueDate = DaysTillDueDate();
            return (!daysTillDueDate.HasValue) ? string.Empty :
                   (daysTillDueDate > 0) ? "text-light" :
                   (daysTillDueDate == 0) ? "text-warning" :
                                            "text-danger";
        }
    }

    public int? DaysTillDueDate() {
        if (TskModel.DueDate.HasValue && !TskModel.CompletedDate.HasValue) {
            var daysTillDueDate = -1 * (int)(DateTime.Now - TskModel.DueDate.Value).TotalDays;
            return daysTillDueDate;
        }
        return null;
    }

    public async Task ToggleInFocus() {
        TskModel.IsInFocus = !TskModel.IsInFocus;
        await Task.Run(() => EntityStateFacade.Update<Tsk, TskUpdate.Command>(new TskUpdate.Command {
            Id = TskModel.Id,
            IsInFocus = TskModel.IsInFocus
        }));
    }

    public async Task ToggleIsArchived() {
        TskModel.IsArchived = !TskModel.IsArchived;
        await Task.Run(() => EntityStateFacade.Update<Tsk, TskUpdate.Command>(new TskUpdate.Command {
            Id = TskModel.Id,
            IsArchived = TskModel.IsArchived
        }));
    }


}