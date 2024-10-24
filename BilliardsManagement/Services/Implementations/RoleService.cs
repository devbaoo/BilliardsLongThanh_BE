using BilliardsManagement.Entities;
using BilliardsManagement.Models.Creates;
using BilliardsManagement.Models.Updates;
using BilliardsManagement.Models.Views;
using BilliardsManagement.Services.Interfaces;

namespace BilliardsManagement.Services.Implementations
{
    public class RoleService(BilliardsManagementContext context) : IRoleService
    {
        public List<RoleViewModel> GetRoles()
        {
            var roles = context.Roles
                .Select(role => new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name
                })
                .ToList();
        
            return roles; ;
        }

        public Role? GetRoleById(Guid id)
        {
            var role = context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            return role;
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
        // tao moi thanh cong tra ve doi tuong va tra ve doi tuong vua duoc tao voi status 201
        public Role? CreateRole(RoleCreateModel model)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CreateAt = DateTime.UtcNow //lay mui gio 00
            };
            context.Roles.Add(role);
            context.SaveChanges();
            
            return GetRoleById(role.Id);
        }
        //cach tao ngu sidan
        public Role CreateRole2(string name)
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

        public Role? UpdateRoleProperties(Guid id, RoleUpdateModel model)
        {
            var role = context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return null;
            }

            if (model.Name != null)
            {
                role.Name = model.Name;
            }
            
            context.Roles.Update(role);
            var result = context.SaveChanges();
            return result ==1 ? role : null;
        }

        public Role? UpdateRole( RoleUpdateModel model)
        {
            var role = context.Roles.FirstOrDefault(x => x.Id.Equals(model.Id));
            if (role == null)
            {
                return null;
            }
            role.Name = model.Name;
            role.CreateAt = model.CreatedAt;
            
            context.Roles.Update(role);
            var result = context.SaveChanges();
            return result == 1 ? role : null;
        }
    }
}

