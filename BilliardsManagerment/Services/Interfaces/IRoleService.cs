using BilliardsManagerment.Entities; 

namespace BilliardsManagerment.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<Role>GetRoles();
    }
}
