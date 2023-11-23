using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Repository
{
    public class deptRepo : IdeptRepo

    {
        private readonly EntityContext entityContext;

        public deptRepo(EntityContext entityContext)
        {
            this.entityContext = entityContext;
        }

        public List<Department> GetAllDepartmentsAsync()
        {
            return  entityContext.departments
             .ToList();
        }
    }
}
