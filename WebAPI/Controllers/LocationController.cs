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
    public class LocationController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ILogger<LocationController> _logger;

        public LocationController(DataContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationDTO>>> Get()
        {
            var locationDtoList = new List<LocationDTO>();

            var locationList = await _context.Locations.ToListAsync();

            foreach (var c in locationList)
            {
                var location = new LocationDTO
                {
                    Id = c.Id,
                    LocName = c.LocName,
                    Longitude = c.Longitude,
                    Latitude = c.Latitude
                };

                locationDtoList.Add(location);
            }
            return locationDtoList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> Get(int? id)
        {
            if (id == null) return NotFound();

            var c = await _context.Locations.FirstOrDefaultAsync();

            if (c == null) return NotFound();

            var location = new LocationDTO
            {
                Id = c.Id,
                LocName = c.LocName,
                Longitude = c.Longitude,
                Latitude = c.Latitude
            };

            return location;
        }

        [HttpPut]
        public async Task<ActionResult> Put(LocationDTO locationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = _context.Locations.Any(x => x.Id == locationDto.Id);

                    if (isExist)
                    {
                        var location = new Location
                        {
                            Id = locationDto.Id,
                            LocName = locationDto.LocName,
                            Longitude = locationDto.Longitude,
                            Latitude = locationDto.Latitude
                        };

                        _context.Locations.Update(location);
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
                var locationToDelete = _context.Locations.FirstOrDefault(x => x.Id == id);
                if (locationToDelete != null)
                {
                    _context.Entry(locationToDelete).State = EntityState.Deleted;
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
