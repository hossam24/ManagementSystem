using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Repository
{
    public class EmpRepo : IEmpRepo
    {
        private readonly EntityContext entityContext;

        public EmpRepo(EntityContext entityContext)
        {
            this.entityContext = entityContext;
        }
        public void CreateEmployeeAsync(Employee employee)
        {
            entityContext.Add(employee);
             entityContext.SaveChanges();

        }

        public IEnumerable<Employee>GetAllEmployeesAsync()
        {
            return  entityContext.Employees
              .Include(e => e.Dept)
              .Include(e => e.bran)
              .ToList();
        }

        public Employee GetEmployeeByIdAsync(int id)
        {
            return  entityContext.Employees
                .Include(e => e.Dept)
                .Include(e => e.bran)
                .FirstOrDefault(m => m.Id == id);
        }

        public void UpdateEmployeeAsync(Employee employee)
        {
            entityContext.Update(employee);
             entityContext.SaveChanges();
        }
    }
}
