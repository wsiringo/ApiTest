using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Models;
using ApiTest.Repositories;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<Person> Get()
        {
            using (PeopleRepository repository = new PeopleRepository())
            {
                return repository.AllPersons();
            }
        }

        [HttpGet("{searchText}")]
        public IEnumerable<Person> SearchPerson(string searchText)
        {
            using (PeopleRepository repository = new PeopleRepository())
            {
                return repository.MatchingPersons(searchText);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            using (PeopleRepository repository = new PeopleRepository())
            {
                await repository.AddPerson(person);
            }
            return CreatedAtAction(nameof(PostPerson), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(long id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            using (PeopleRepository repository = new PeopleRepository())
            {
                try
                {

                    await repository.ModifyPerson(person);
                }
                catch
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(long id)
        {
            using (PeopleRepository repository = new PeopleRepository())
            {
                Person person = repository.FindPerson((int)id);
                if (person == null) return NotFound();
                await repository.DeletePerson(person);
            }


            return NoContent();
        }
    }
}
