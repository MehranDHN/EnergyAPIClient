using EnergyApiClient.DomainModels.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyAPIClient.CQRS.PowerCounter.Queries
{
    public class FindPowerCounterQuery : IRequest<PowerSrcInfoDto>
    {
        public FindPowerCounterQuery(string tagid)
        {
            TagIdentity = tagid;
        }
        public string TagIdentity { get; set; }
    }
}
