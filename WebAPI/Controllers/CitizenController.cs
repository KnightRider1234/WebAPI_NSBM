using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CitizenController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ILogger<CitizenController> _logger;

        public CitizenController(DataContext context, ILogger<CitizenController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<CitizenDTO>>> Get()
        {
            var citizenDtoList = new List<CitizenDTO>();

            var citizenList = await _context.Citizens.Include(x => x.Locations).ToListAsync();

            foreach (var c in citizenList)
            {
                var citizen = new CitizenDTO
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Dob = c.Dob,
                    Type = c.Type,
                    UserName = c.UserName,
                    HealthStatus = c.HealthStatus,
                    Address = c.Address,
                    Telephone = c.Telephone,
                    Locations = c.Locations.ToList()
                };

                citizenDtoList.Add(citizen);
            }
            return citizenDtoList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitizenDTO>> Get(int? id)
        {
            if (id == null) return NotFound();

            var c = await _context.Citizens.Include(x => x.Locations).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (c == null) return NotFound();

            var citizenDto = new CitizenDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Dob = c.Dob,
                Type = c.Type,
                UserName = c.UserName,
                HealthStatus = c.HealthStatus,
                Address = c.Address,
                Telephone = c.Telephone,
                Locations = c.Locations.ToList()
            };

            return citizenDto;
        }

        [HttpPut]
        public async Task<ActionResult> Put(CitizenDTO citizenDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = _context.Citizens.Any(x => x.Id == citizenDto.Id);

                    if (isExist)
                    {
                        var citizen = new Citizen
                        {
                            Id = citizenDto.Id,
                            FirstName = citizenDto.FirstName,
                            LastName = citizenDto.LastName,
                            Dob = citizenDto.Dob,
                            Type = citizenDto.Type,
                            HealthStatus = citizenDto.HealthStatus,
                            Address = citizenDto.Address,
                            Telephone = citizenDto.Telephone
                        };

                        _context.Citizens.Update(citizen);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists, " + "see your system administrator.");
                _logger.LogInformation(this.GetType().Name + "\n" + ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var citizenToDelete = _context.Citizens.FirstOrDefault(x => x.Id == id);
                if (citizenToDelete.HealthStatus == Models.Enums.HealthStatus.Deceased)
                {
                    _context.Entry(citizenToDelete).State = EntityState.Deleted;
                }
                else
                {
                    return BadRequest();
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists, " + "see your system administrator.");
                _logger.LogInformation(this.GetType().Name + "\n" + ex);
            }

            return Ok();
        }
    }
}
