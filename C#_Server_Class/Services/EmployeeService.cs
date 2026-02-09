using C__Server_Class.Models;

namespace C__Server_Class.Services
{
    public class EmployeeService
    {
        private List<TrainEmployee> _TrainEmployees = new();
        private int _lastId = 0;

        public EmployeeService()
        {
            //Add(new Product()
            //{
            //    Id = 0,
            //    Name = "Чайник",
            //    Description = "Якісний електрочайник",
            //    Price = 205.0
            //});
            //Add(new Product()
            //{
            //    Id = 0,
            //    Name = "Пательня",
            //    Description = "Якісний пательня",
            //    Price = 130.0
            //});
        }

        public List<TrainEmployee> GetAll() => _TrainEmployees;
        public TrainEmployee? GetProductById(int id) =>
            _TrainEmployees.FirstOrDefault(p => p.Id == id);

        


        public int Add(TrainEmployee TrainEmployee)
        {
            TrainEmployee.Id = GetLastId();
            _TrainEmployees.Add(TrainEmployee);
            return TrainEmployee.Id;
        }

        public int GetLastId() => ++_lastId;

    
        public bool Update(TrainEmployee TrainEmployee)
        {
            TrainEmployee? foundEmployee = GetProductById(TrainEmployee.Id);
            if (foundEmployee == null || foundEmployee.Id == 0)
                return false;
            foundEmployee.Name = TrainEmployee.Name;
            foundEmployee.Surname = TrainEmployee.Surname;
            foundEmployee.Lastname = TrainEmployee.Lastname;
            foundEmployee.Brigade = TrainEmployee.Brigade;
            foundEmployee.Gender = TrainEmployee.Gender;
            foundEmployee.Height = TrainEmployee.Height;
            foundEmployee.Position = TrainEmployee.Position;
            foundEmployee.Department = TrainEmployee.Department;
            foundEmployee.Birthday = TrainEmployee.Birthday;
            foundEmployee.Hired = TrainEmployee.Hired;
            foundEmployee.Salary = TrainEmployee.Salary;
            foundEmployee.Children = TrainEmployee.Children;
            return true;
        }

        public bool Delete(int id)
        {
            TrainEmployee? foundEmployee = GetProductById(id);
            if (foundEmployee == null || foundEmployee.Id == 0)
                return false;
            _TrainEmployees.Remove(foundEmployee);
            return true;
        }
    }
}
