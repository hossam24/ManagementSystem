using ManagementSystem.Models;

namespace ManagementSystem.Repository
{
    public interface IEmpRepo
    {
        IEnumerable<Employee> GetAllEmployeesAsync();
        Employee GetEmployeeByIdAsync(int id);
        void CreateEmployeeAsync(Employee employee);
        void UpdateEmployeeAsync(Employee employee);

    }
}
