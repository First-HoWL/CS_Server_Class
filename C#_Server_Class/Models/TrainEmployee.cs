namespace C__Server_Class.Models
{
    public class TrainEmployee
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Surname { get; set; } = ""; // побатькові
        public string Lastname { get; set; } = ""; // прізвище
        public string Brigade { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Height { get; set; } = 0;
        public string Position { get; set; } = "";
        public string Department { get; set; } = "";
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public DateTime Hired { get; set; } = DateTime.MinValue;
        public double Salary { get; set; } = 0;
        public int Children { get; set; } = 0;
    }
}
