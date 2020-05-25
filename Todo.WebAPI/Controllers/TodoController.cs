

namespace Todo.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController: ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "batman";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
        {
            return repository.GetAll("batman");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x=>x.Type == "user")?.Value;
            return repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x=>x.Type == "user")?.Value;
            return repository.GetAllUndone(user);
        }
 
    }
}