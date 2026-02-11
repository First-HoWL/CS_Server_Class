namespace C__Server_Class.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool Delivery { get; set; } = false;
        public string Adress { get; set; } = string.Empty;
        public Bucket Bucket { get; set; } = new Bucket();
        public double Price { get; set; } = 0;
    }
}
