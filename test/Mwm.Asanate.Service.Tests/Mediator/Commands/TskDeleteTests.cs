﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Mwm.Asanate.Application.Tsks.Commands;
using Mwm.Asanate.Application.Utils;
using Mwm.Asanate.Data;
using Mwm.Asanate.Domain;
using Mwm.Asanate.Persistance.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Mwm.Asanate.Service.Tests.Mediator.Commands {

    [Collection("Generic")]
    public class TskDeleteTests {
        private readonly IMediator _mediator;
        private readonly IDatabaseContext _databaseContext;
        private readonly ITestOutputHelper _output;

        public TskDeleteTests(IMediator mediator, IDatabaseContext databaseContext, ITestOutputHelper output) {
            _databaseContext = databaseContext;
            _mediator = mediator;
            _output = output;
        }

        [Fact]
        public async Task DeleteTsk() {
            var lastId = _databaseContext.Set<Tsk>().OrderByDescending(t => t.Id).Select(t => t.Id).FirstOrDefault();
            var command = new TskDelete.Command {
                Id = lastId
            };

            var result = await _mediator.Send(command);
            Assert.True(result.IsSuccess, $"DeleteTsk failed: {result}");
            Assert.Equal(result.Value, lastId);

            _output.WriteLine(result.ToString());
        }

    }
}
