﻿using FluentResults;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Mwm.Asanate.Application.Interfaces.Persistance;
using Mwm.Asanate.Application.Shared.Commands;
using Mwm.Asanate.Application.Shared.Workflows;
using Mwm.Asanate.Application.Utils;
using Mwm.Asanate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Mwm.Asanate.Application.Initiatives.Commands {

    public partial class InitiativeDelete {

        public class Command : IDeleteEntityCommand<Initiative> {  

            public int Id {  get; set; }    
        
        }

    }
}