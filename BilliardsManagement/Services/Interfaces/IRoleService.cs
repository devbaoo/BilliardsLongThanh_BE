using BilliardsManagement.Entities;

namespace BilliardsManagement.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<Role>GetRoles();
        Role? GetRoleById(Guid id);
        void DeleteRole(Guid id);
        Role CreateRole(string name);
    }
}
