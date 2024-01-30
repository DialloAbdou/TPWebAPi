namespace tpWebminiAPi.Todo
{
    public class Todo
    {
        public int Id { get; set; }
        public string Titre { get; set; }  = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
    }
}
