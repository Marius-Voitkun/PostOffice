using Microsoft.AspNetCore.Mvc;
using PostOfficeBackend.Models;
using PostOfficeBackend.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostOfficeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelLockersController : ControllerBase
    {
        private readonly ParcelLockersService _parcelLockersService;

        public ParcelLockersController(ParcelLockersService parcelLockersService)
        {
            _parcelLockersService = parcelLockersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParcelLocker>>> GetAll()
        {
            return Ok(await _parcelLockersService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelLocker>> Get(int id)
        {
            return Ok(await _parcelLockersService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ParcelLocker>> Add(ParcelLocker parcelLocker)
        {
            await _parcelLockersService.AddAsync(parcelLocker);
            return CreatedAtAction(nameof(Get), new { id = parcelLocker.Id }, parcelLocker);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ParcelLocker parcelLocker)
        {
            if (parcelLocker.Id != id)
                return BadRequest();

            await _parcelLockersService.UpdateAsync(parcelLocker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _parcelLockersService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong...");
            }
        }
    }
}
