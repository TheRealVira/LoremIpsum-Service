using System;
using System.Collections.Generic;
using System.Linq;
using LoremIpsum.API.Service;
using LoremIpsumService.Generators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoremIpsumService.Controllers
{
    [Route("api/lipsum_generator")]
    [ApiController]
    [Produces("application/json")]
    public class LoremIpsumController : ControllerBase
    {
        private readonly ILoremIpsumService _service;
 
        public LoremIpsumController(ILoremIpsumService service)
        {
            _service = service;
        }

        // GET api/values/5
        [HttpGet("{generatorType}/{count}/{length}")]
        public ActionResult<string> Get(string generatorType,int count, int length)
        {
            if (!Enum.TryParse(generatorType, true, out LoremIpsumGeneratorType currentGeneratorType))
                return BadRequest();

            return Ok(JsonConvert.SerializeObject(_service.GenerateText(currentGeneratorType, length, count)));
        }
    }
}
