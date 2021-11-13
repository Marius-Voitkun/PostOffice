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
    public class ParcelsController : ControllerBase
    {
        private readonly ParcelsService _parcelsService;

        public ParcelsController(ParcelsService parcelsService)
        {
            _parcelsService = parcelsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Parcel>>> GetAll(int? parcelLockerId)
        {
            return Ok(await _parcelsService.GetAllAsync(parcelLockerId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> Get(int id)
        {
            return Ok(await _parcelsService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Parcel>> Add(Parcel parcel)
        {
            await _parcelsService.AddAsync(parcel);
            return CreatedAtAction(nameof(Get), new { id = parcel.Id }, parcel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Parcel parcel)
        {
            if (parcel.Id != id)
                return BadRequest();

            await _parcelsService.UpdateAsync(parcel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _parcelsService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong...");
            }
        }
    }
}
