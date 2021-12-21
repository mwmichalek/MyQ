﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mwm.MyQ.Application.Interfaces.Persistance;
using Mwm.MyQ.Application.Services;
using Mwm.MyQ.Application.Shared.Commands;
using Mwm.MyQ.Application.Shared.Workflows;
using Mwm.MyQ.Application.Tsks.Commands;
using Mwm.MyQ.Application.Initiatives.Commands;
using Mwm.MyQ.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mwm.MyQ.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : EntityController<Project,
                                                  AddNotSupportedEntityCommand<Project>,
                                                  UpdateNotSupportedEntityCommand<Project>,
                                                  DeleteNotSupportedEntityCommand<Project>> {

    public ProjectController(ILogger<IEntityController<Project>> logger, IRepository<Project> repository, IEntityService<Project> entityService)
        : base(logger, repository, entityService) { }

}

[Route("api/[controller]")]
[ApiController]
public class CompanyController : EntityController<Company,
                                                  AddNotSupportedEntityCommand<Company>,
                                                  UpdateNotSupportedEntityCommand<Company>,
                                                  DeleteNotSupportedEntityCommand<Company>> {

    public CompanyController(ILogger<IEntityController<Company>> logger, IRepository<Company> repository, IEntityService<Company> entityService)
        : base(logger, repository, entityService) { }

}

[Route("api/[controller]")]
[ApiController]
public class InitiativeController : EntityController<Initiative,
                                                     InitiativeAdd.Command,
                                                     InitiativeUpdate.Command,
                                                     InitiativeDelete.Command> {


    public InitiativeController(ILogger<IEntityController<Initiative>> logger, IRepository<Initiative> repository, IEntityService<Initiative> entityService)
        : base(logger, repository, entityService) { }

}

[Route("api/[controller]")]
[ApiController]
public class TskController : EntityController<Tsk,
                                              TskAdd.Command,
                                              TskUpdate.Command,
                                              TskDelete.Command> {

    public TskController(ILogger<IEntityController<Tsk>> logger, IRepository<Tsk> repository, IEntityService<Tsk> entityService)
        : base(logger, repository, entityService) { }

}
