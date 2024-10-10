using BilliardsManagement.Entities;
using BilliardsManagement.Services.Interfaces;

namespace BilliardsManagement.Services.Implementations
{
    public class RoleService(BilliardsManagementContext context) : IRoleService
    {
        public ICollection<Role> GetRoles()
        {
            var roles = context.Roles.ToList();
            return roles;   
        }
        public Role? GetRoleById(Guid id)
        {
            var role = context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            return role ;
        }

        public void DeleteRole(Guid id)
        {
            var role = context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return;
            }
            context.Roles.Remove(role);
            context.SaveChanges();
        }
        public Role CreateRole(string name)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),  
                Name = name,
              
            };
            
            context.Roles.Add(role); 
            context.SaveChanges();   

            return role;  
        }
    }
}
