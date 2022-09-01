namespace HuskeListe001
{
    internal class GroceryList : TodoList
    {


        public List<Groceries> groceries { get; set; } = new();
    }
    internal sealed class Groceries : GroceryList
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Price { get; set; } = 0;
        public int Amount { get; set; }
    }
}
