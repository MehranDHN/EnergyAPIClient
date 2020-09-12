using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyAPIClient.CQRS.PowerCounter.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnergyAPIClient.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerCounter : ControllerBase
    {
        private readonly IMediator _mediator;
        public PowerCounter(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("GetPowerCounters")]
        public async Task<IActionResult> GetPowerCounters()
        {
            var counters = await _mediator.Send(new GetPowerCounterListQuery());
            return Ok(counters);
        }
    }
}
