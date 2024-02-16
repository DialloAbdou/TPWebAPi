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
        /// <summary>
        /// Elle renvoie la liste des taches
        /// </summary>
        /// <returns></returns>
        public List<Todo> getAllToDo()
        {
            return TodoList;
        }

        public Todo GetTodoById(int id)
        {
            var todo = TodoList.Find(t=>t.Id == id);
            return todo;
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

        /// <summary>
        /// elle permet de supprimer 
        /// un todo dans la liste
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteTodo(int id)
        {
            var todo = TodoList.Find(t => t.Id == id);
            if (todo is not null)
            {
                TodoList.Remove(todo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Todo Update( int id, Todo todoNew)
        {
           var isDeleted = DeleteTodo(id);
            if (isDeleted)
            {
                TodoList.Add(todoNew);
                return todoNew;
            }
            else
            {
                return todoNew;
            }
            
        

        }


    }
}
