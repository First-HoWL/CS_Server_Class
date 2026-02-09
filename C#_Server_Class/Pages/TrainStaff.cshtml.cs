using C__Server_Class.Models;
using C__Server_Class.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace C__Server_Class.Pages
{
    public class TrainStaffModel : PageModel
    {
        private readonly EmployeeService _TrainEmployees;

        public List<TrainEmployee> TrainEmployees => _TrainEmployees.GetAll();
        [BindProperty]
        public TrainEmployee CurrentEmployee { get; set; } = new TrainEmployee();
        public TrainStaffModel(EmployeeService EmployeeService)
        {
            _TrainEmployees = EmployeeService;
        }
        public void OnGet()
        {

        }

        private List<string> Validation(TrainEmployee TrainEmployee)
        {
            List<string> errors = new List<string>();

            if (TrainEmployee == null)
            {
                errors.Add("Employee is empty");
            }
            else
            {
                if (TrainEmployee.Name == null) errors.Add("Name is undefined");
                else if (TrainEmployee.Name == string.Empty || TrainEmployee.Name == " ") errors.Add("Name is uncorrect");
                if (TrainEmployee.Surname == null) errors.Add("Surname is undefined");
                else if (TrainEmployee.Surname == string.Empty || TrainEmployee.Surname == " ") errors.Add("Surname is uncorrect");
                if (TrainEmployee.Lastname == null) errors.Add("Lastname is undefined");
                else if (TrainEmployee.Lastname == string.Empty || TrainEmployee.Lastname == " ") errors.Add("Lastname is uncorrect");
                if (TrainEmployee.Brigade == null) errors.Add("Brigade is undefined");
                else if (TrainEmployee.Brigade == string.Empty || TrainEmployee.Brigade == " ") errors.Add("Brigade is uncorrect");
                if (TrainEmployee.Gender == null) errors.Add("Gender is undefined");
                else if (TrainEmployee.Gender == string.Empty || TrainEmployee.Gender == " ") errors.Add("Gender is uncorrect");
                if (TrainEmployee.Height <= 0) errors.Add("Height is uncorrect");
                if (TrainEmployee.Position == null) errors.Add("Position is undefined");
                else if (TrainEmployee.Position == string.Empty || TrainEmployee.Position == " ") errors.Add("Position is uncorrect");
                if (TrainEmployee.Department == null) errors.Add("Department is undefined");
                else if (TrainEmployee.Department == string.Empty || TrainEmployee.Department == " ") errors.Add("Department is uncorrect");
                if (TrainEmployee.Salary <= 0) errors.Add("Salary is uncorrect");
                if (TrainEmployee.Children < 0) errors.Add("Children is uncorrect");

                if (TrainEmployee.Birthday > DateTime.Now || TrainEmployee.Birthday > TrainEmployee.Hired) { errors.Add("Birthday is uncorrect"); }
                if (TrainEmployee.Birthday > TrainEmployee.Hired) errors.Add("Hired is uncorrect");
                if (TrainEmployee.Hired > DateTime.Now) errors.Add("Hired is uncorrect");

            }
            return errors;
        }

        public IActionResult OnPostAdd()
        {
            int result = -1;
            List<string> errors = Validation(CurrentEmployee);
            if (errors.Count == 0)
            {
                result = _TrainEmployees.Add(CurrentEmployee);
            }
            return new JsonResult(new
            {
                error = errors,
                success = result != -1 ? true : false
            });
        }
        public async Task<IActionResult> OnPostUpdate(int id)
        {
            bool result = false;
            var Employee = await Request.ReadFromJsonAsync<TrainEmployee>();
            Console.WriteLine(JsonSerializer.Serialize(Employee));
            Employee.Id = id;
            List<string> errors = Validation(Employee);
            if (errors.Count == 0)
            {
                result = _TrainEmployees.Update(Employee);
            }
            return new JsonResult(new
            {
                error = errors,
                success = result
            });
        }
        public IActionResult OnPostDelete(int id)
        {
            string? errorMSG = null;
            bool result = _TrainEmployees.Delete(id);
            if (!result)
            {
                TrainEmployee? E = _TrainEmployees.GetProductById(id);
                if (E != null || E.Id == 0)
                {
                    errorMSG = "Не вдалося знайти вказаного співробітника";
                }
            }
            // errorMSG = "Some errors on backend :(";
            return new JsonResult(new
            {
                success = result,
                error = errorMSG
            });
        }
    }
}
