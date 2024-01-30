namespace tpWebminiAPi.Todo
{
    public class TodoService
    {

        IEnumerable<Todo> TodoList = new List<Todo>()
        {
            new Todo{ Id = 1, Titre = "Formation WebApi", StartDate = DateTime.Today },
            new Todo{ Id = 1, Titre = "Formation WebApi", StartDate = DateTime.Today.AddDays(1) },
            new Todo{ Id = 1, Titre = "Formation WebApi", StartDate = DateTime.Today .AddDays(2)},

        };

        public IEnumerable<Todo> getAllToDo()
        {
            return TodoList;
        }
    }
}
