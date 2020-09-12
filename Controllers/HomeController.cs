using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EnergyAPIClient.Models;
using EnergyAPIClient.ORM;
using AutoMapper;
using EnergyAPIClient.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace EnergyAPIClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EnergyDbContext _context;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, EnergyDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.PowerSrcInfo.Include(p => p.TargetCounter).ToList();
            List<PowerSrcInfoDto> dtoList = _mapper.Map<List<PowerSrcInfoDto>>(data);
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
