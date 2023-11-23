using ManagementSystem.Models;

namespace ManagementSystem.Repository
{
    public interface IdeptRepo
    {
        List<Department>GetAllDepartmentsAsync();
    }
}
