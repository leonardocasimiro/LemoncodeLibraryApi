using LibraryApi.Contracts;
using LibraryApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        //EndPoint
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            return _authorRepository.GetAuthors();
        }
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id) { 
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
                return NotFound();  
            else 
                return Ok(author);
        }
        [HttpPost]
        public ActionResult PostCreateActor(Author author)
        {
            try
            {
                _authorRepository.AddAuthor(author);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error al añadir Author: " + ex.Message);
            }
        }
        [HttpPut]
        public ActionResult PutUpdateAuthor(Author author) {
            try
            {
                _authorRepository.UpdateAuthor(author);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorRepository.DeleteAuthor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
