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
    public class PHIController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ILogger<PHIController> _logger;

        public PHIController(DataContext context, ILogger<PHIController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<PHI>>> Get()
        {
            var phiList = await _context.PHIs.ToListAsync();

            return phiList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> Get(int? id)
        {
            if (id == null) return NotFound();

            var phi = await _context.Citizens.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (phi == null) return NotFound();

            return phi;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(PHIDTO phiDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = _context.PHIs.Any(x => x.Id == phiDto.Id);

                    if (isExist)
                    {
                        var phi = new PHI
                        {
                            Id = phiDto.Id,
                            FirstName = phiDto.FirstName,
                            LastName = phiDto.LastName,
                            Dob = phiDto.Dob,
                            Type = phiDto.Type
                        };

                        _context.PHIs.Update(phi);
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
                var phiToDelete = _context.PHIs.Any(x => x.Id == id);
                if (phiToDelete)
                {
                    _context.Entry(phiToDelete).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }  
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
