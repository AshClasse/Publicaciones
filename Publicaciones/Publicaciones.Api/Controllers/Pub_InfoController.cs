﻿using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Pub_Info;

namespace Publicaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pub_InfoController : ControllerBase
    {
        private readonly IPub_InfoService _pub_infoService;

        public Pub_InfoController(IPub_InfoService pub_InfoService)
        {
            this._pub_infoService = pub_InfoService;
        }

        [HttpGet("GetPub_Infos")]
        public IActionResult GetPub_Infos()
        {
			var result = this._pub_infoService.GetAll();

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

        [HttpGet("GetPub_InfoByID")]
        public IActionResult GetPub_InfoByID(int ID)
        {
			var existsResult = this._pub_infoService.Exists(ID);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var result = this._pub_infoService.GetByID(ID);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("GetPub_InfoByPublisherID")]
		public IActionResult GetInfoByPublisherID(int pubId)
		{
			var existsInPubsResult = this._pub_infoService.ExistsInPublishers(pubId);

			if (!existsInPubsResult.Success)
			{
				return BadRequest(existsInPubsResult.Message);
			}

			var result = this._pub_infoService.GetPub_InfosByPublisherID(pubId);

			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpPost("SavePub_Info")]
        public IActionResult Post([FromBody] Pub_InfoDtoAdd pub_InfoDtoAdd)
        {
			var existsInPubsResult = this._pub_infoService.ExistsInPublishers(pub_InfoDtoAdd.PubId);

			if (!existsInPubsResult.Success)
			{
				return BadRequest(existsInPubsResult.Message);
			}

			var result = this._pub_infoService.Save(pub_InfoDtoAdd);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPut("UpdatePub_Info")]
		public IActionResult Put([FromBody] Pub_InfoDtoUpdate pub_InfoDtoUpdate)
        {
			var existsResult = this._pub_infoService.Exists(pub_InfoDtoUpdate.PubInfoID);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var existsInPubsResult = this._pub_infoService.ExistsInPublishers(pub_InfoDtoUpdate.PubId);

			if (!existsInPubsResult.Success)
			{
				return BadRequest(existsInPubsResult.Message);
			}

			var result = this._pub_infoService.Update(pub_InfoDtoUpdate);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpPost("RemovePub_Info")]
		public IActionResult Remove([FromBody] Pub_InfoDtoRemove pub_InfoDtoRemove)
		{
			var existsResult = this._pub_infoService.Exists(pub_InfoDtoRemove.Id);

			if (!existsResult.Success)
			{
				return BadRequest(existsResult.Message);
			}

			var result = this._pub_infoService.Remove(pub_InfoDtoRemove);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

	}
}
