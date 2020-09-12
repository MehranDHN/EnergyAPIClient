using EnergyAPIClient.Model.DTO;
using EnergyAPIClient.Model.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyAPIClient.CQRS.PowerCounter.Queries
{
    public class GetPowerCounterWhereQuery : IRequest<IEnumerable<PowerSrcInfoDto>>
    {
        public GetPowerCounterWhereQuery(Func<PowerSrcInfo, bool> condition)
        {
            Condition = condition;
        }
        public Func<PowerSrcInfo, bool> Condition { get; set; }
    }
}

