using ManagementSystem.Models;

namespace ManagementSystem.Repository
{
    public interface IBranchRepo
    {
        List<Branch> GetAllBranchsAsync();

    }
}
