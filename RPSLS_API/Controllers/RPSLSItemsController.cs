using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RPSLS_API.Models;
using RPSLS_API.Services;

namespace RPSLS_API.Controllers
{
	[EnableCors("localOrigin")]
	[Route("api/RPSLSItems")]
    [ApiController]
    public class RPSLSItemsController : ControllerBase
    {
        private readonly IRPSLSService _service;

        public RPSLSItemsController(IRPSLSService service)
        {
            _service = service;
        }

        // GET: api/RPSLSItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RPSLSItem>>> GetRPSLSItems()
        {
            IEnumerable<RPSLSItem> rpslsItems = await _service.GetRPSLSItems();
            return Ok(rpslsItems);
        }

        // GET: api/RPSLSItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RPSLSItem>> GetRPSLSItem(int id)
        {
            if (!_service.RPSLSItemExists(id))
            {
                return NotFound();
            }
            return Ok(await _service.GetRPSLSItem(id));
        }

		// PUT: api/RPSLSItems/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutRPSLSItem(int id, RPSLSItem rpslsItem)
		{
			if (id != rpslsItem.Id)
			{
				return BadRequest();
			}
            if (!_service.RPSLSItemExists(id))
            {
                return NotFound();
            }
            await _service.PutRPSLSItem(id, rpslsItem);
            return NoContent();
		}

		// POST: api/RPSLSItems
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<RPSLSItem>> PostRPSLSItem(RPSLSItem rpslsItem)
		{
			return Ok(await _service.CreateRPSLSItem(rpslsItem));
		}

		// DELETE: api/RPSLSItems/5
		[HttpDelete("{id}")]
        public async Task<ActionResult<RPSLSItem>> DeleteRPSLSItem(int id)
        {
            if (!_service.RPSLSItemExists(id))
            {
                return NotFound();
            }
            RPSLSItem rpslsItem = await _service.DeleteRPSLSItem(id);

            return Ok(rpslsItem);
        }

        //New Round
        [Route("newround")]
        [HttpPost]
		public async Task<ActionResult<RoundResult>> NewRound(PlayerRoundInfo playerRoundInfo)
		{
			return Ok(await _service.NewRound(playerRoundInfo));
		}

        [Route("aboutImage")]
        [HttpGet]
        public async Task<ActionResult<Uri>> GetSASUri()
        {
            return Ok(StorageService.getSASUri());
        }
	}
}
