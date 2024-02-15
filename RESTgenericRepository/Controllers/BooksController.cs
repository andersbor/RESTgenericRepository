using GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace RESTgenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get([FromQuery] string? titlestart = null)
        {

            if (titlestart != null)
            {
                Predicate<Book> predicate = (Book b) => b.Title != null && b.Title.StartsWith(titlestart);
                return _repository.Get(filter: predicate);
            }
            return _repository.Get();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book? Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public Book Post([FromBody] Book value)
        {
            return _repository.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public Book? Delete(int id)
        {
            return _repository.Remove(id);
        }
    }
}
