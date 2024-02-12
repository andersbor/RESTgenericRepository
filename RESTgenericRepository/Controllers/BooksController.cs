using GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace RESTgenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Repository<Book> _repository;

        public BooksController(Repository<Book> repository)
        {
            _repository = repository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book? Get(int id)
        {
            return _repository.Get(id);
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
