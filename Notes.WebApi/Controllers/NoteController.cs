using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;

namespace Notes.WebApi.Controllers
{
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                Id = id,
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
