﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mwm.Asanate.Application.Interfaces.Persistance;
using Mwm.Asanate.Application.Shared.Commands;
using Mwm.Asanate.Application.Tsks.Commands;
using Mwm.Asanate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwm.Asanate.Server.Controllers {

    public interface IEntityController<TEntity> where TEntity : INamedEntity { }

    public abstract class EntityController<TEntity, TAddEntityCommand, TUpdateEntityCommand, TDeleteEntityCommand> : 
                          ControllerBase, IEntityController<TEntity>
                          where TEntity : NamedEntity 
                          where TAddEntityCommand : IAddEntityCommand<TEntity>
                          where TUpdateEntityCommand : IUpdateEntityCommand<TEntity>
                          where TDeleteEntityCommand : IDeleteEntityCommand<TEntity> {

        protected readonly IRepository<TEntity> _repository;
        protected readonly ILogger<IEntityController<TEntity>> _logger;
        protected readonly IMediator _mediator;

        public EntityController(ILogger<IEntityController<TEntity>> logger,
                                IMediator mediator,
                                IRepository<TEntity> repository) {
            _repository = repository;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<TEntity>> All() {
            return await _repository.GetAll().ToListAsync();
        }

        [HttpPost("[controller]/Add")]
        public async Task<IActionResult> Add(TAddEntityCommand command) {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpPost("[controller]/Update")]
        public async Task<IActionResult> Update(TUpdateEntityCommand command) {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpPost("[controller]/Delete")]
        public async Task<IActionResult> Delete(TDeleteEntityCommand command) {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }
    }


    [ApiController]
    [Route("[controller]")]
    public class ProjectController : EntityController<Project, 
                                                      AddNotSupportedEntityCommand<Project>,
                                                      UpdateNotSupportedEntityCommand<Project>,
                                                      DeleteNotSupportedEntityCommand<Project>> {

        public ProjectController(ILogger<IEntityController<Project>> logger, IMediator mediator, IRepository<Project> repository) : base(logger, mediator, repository) { }

    }

    [ApiController]
    [Route("[controller]")]
    public class CompanyController : EntityController<Company,
                                                      AddNotSupportedEntityCommand<Company>,
                                                      UpdateNotSupportedEntityCommand<Company>,
                                                      DeleteNotSupportedEntityCommand<Company>> {

        public CompanyController(ILogger<IEntityController<Company>> logger, IMediator mediator, IRepository<Company> repository) : base(logger, mediator, repository) { }

    }

    [ApiController]
    [Route("[controller]")]
    public class InitiativeController : EntityController<Initiative, 
                                                         AddNotSupportedEntityCommand<Initiative>,
                                                         UpdateNotSupportedEntityCommand<Initiative>,
                                                         DeleteNotSupportedEntityCommand<Initiative>> {


        public InitiativeController(ILogger<IEntityController<Initiative>> logger, IMediator mediator, IRepository<Initiative> repository) : base(logger, mediator, repository) { }

    }

    [ApiController]
    [Route("[controller]")]
    public class TskController : EntityController<Tsk, 
                                                  TskAdd.Command,
                                                  UpdateNotSupportedEntityCommand<Tsk>,
                                                  DeleteNotSupportedEntityCommand<Tsk>> {

        public TskController(ILogger<IEntityController<Tsk>> logger, IMediator mediator, IRepository<Tsk> repository) : base(logger, mediator, repository) { }

        //[HttpPost]
        //public async Task<IActionResult> Create(AddTsk.Command command) {
        //    var result = await _mediator.Send(command);

        //    if (result.IsSuccess)
        //        return Ok();
        //    return BadRequest();
        //}

     

    }

    //    [HttpGet("people/all")]
    //public ActionResult<IEnumerable<Person>> GetAll() {
    //        return new[]
    //        {
    //        new Person { Name = "Ana" },
    //        new Person { Name = "Felipe" },
    //        new Person { Name = "Emillia" }
    //    };

}
