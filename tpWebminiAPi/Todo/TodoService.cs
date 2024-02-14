namespace tpWebminiAPi.Todo
{
    public class TodoService
    {

        List<Todo> TodoList = new List<Todo>()
        {
            new Todo{ Id = 1, Titre = "Formation WebApi", StartDate = DateTime.Today },
            new Todo{ Id = 2, Titre = "Formation Fondamenteau", StartDate = DateTime.Today.AddDays(1) },
            new Todo{ Id = 3, Titre = "Formation WebApi", StartDate = DateTime.Today .AddDays(2)},
            new Todo{ Id = 4, Titre = "Formation WebApi", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(2)},


        };

        public List<Todo> getAllToDo()
        {
            return TodoList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public Todo AddToDo(string titre)
        {
            var idMax = TodoList.Max(t => t.Id) + 1;
            Todo todo = new Todo
            {
                Id = idMax,
                Titre = titre,
                StartDate = DateTime.Today,
            };
            return todo;

        }

    }
}
