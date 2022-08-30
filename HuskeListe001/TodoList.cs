namespace HuskeListe001
{
    internal abstract class TodoList
    {
        public string? ListName { get; set; }
        public string? Where { get; set; }
        public List<string?> WithWho { get; set; } = new();
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;
    }
}
