namespace C__Server_Class.Models
{
    
    public class Sushi
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
        public int Weight { get; set; } = 0;
        public double Price { get; set; } = 0;
        public string Img { get; set; } = string.Empty;

    }
    public class SushiSet : Sushi
    {
        public List<Sushi> ContainsSushi { get; set; } = new List<Sushi>();
    }
}
