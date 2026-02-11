
namespace C__Server_Class.Models
{
    public class Bucket
    {
        public int Id { get; set; }
        public List<Sushi> Sushies { get; set; } = new List<Sushi>();
        public int PublicId { get; set; } = -1;

        public void GeneratePublicId(int numb)
        {
            PublicId = numb;
        }
    }
}
