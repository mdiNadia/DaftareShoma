
using Application.Dtos.Person;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaftareShoma.Controllers
{
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPerson _person;

        public PersonController(ILogger<PersonController> logger, IPerson person)
        {
            this._logger = logger;
            this._person = person;
        }
        [HttpPost("InsertPeople")]
        public async Task<IActionResult> InsertPeopleAsync([FromBody]List<PersonDto> person)
        {
            var result = await _person.InsertPeople(person);
            return Ok();
        }
    }
}
