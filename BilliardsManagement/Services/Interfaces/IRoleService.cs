using BilliardsManagement.Entities;
using BilliardsManagement.Models.Creates;
using BilliardsManagement.Models.Updates;
using BilliardsManagement.Models.Views;

namespace BilliardsManagement.Services.Interfaces
{
    public interface IRoleService
    {
        List<RoleViewModel> GetRoles();
        Role? GetRoleById(Guid id);
        void DeleteRole(Guid id);
        Role? CreateRole(RoleCreateModel model);
        Role? UpdateRoleProperties(Guid id, RoleUpdateModel model);
        Role? UpdateRole(RoleUpdateModel model);
    }
}
