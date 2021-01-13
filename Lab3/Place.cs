namespace Lab3
{
    public class Place
    {
        public readonly int Id;
        public string Name;
        public string Description;
        public float TableArea;
        public float Price;

        public Place(int id, string name, string description, float tableArea, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            TableArea = tableArea;
            Price = price;
        }
    }
}