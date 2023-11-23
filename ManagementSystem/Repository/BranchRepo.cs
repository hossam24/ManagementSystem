using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Repository
{
    public class BranchRepo : IBranchRepo
    {
        private readonly EntityContext entityContext;

        public BranchRepo(EntityContext entityContext)
        {
            this.entityContext = entityContext;
        }

        public List<Branch> GetAllBranchsAsync()
        {

            return  entityContext.Branches
             .ToList();

        }
    }
}
