namespace HuskeListe001
{
    internal sealed class GroceryList : TodoList
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Price { get; set; } = 0;
        public int Amount { get; set; } = 0;
        

    }
}
