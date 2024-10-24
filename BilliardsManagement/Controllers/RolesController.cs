using BilliardsManagement.Models.Creates;
using BilliardsManagement.Models.Updates;
using BilliardsManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BilliardsManagement.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoles() {
          var roles =  roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRolesById([FromRoute]Guid id)
        {
            var role = roleService.GetRoleById(id);
            if (role  == null)
            {
                return NotFound("ditme may");
            }
            return Ok(role);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRole([FromRoute] Guid id)
        {
            roleService.DeleteRole(id);
            return NoContent();
        }

        [HttpPost]
        [Route("create-role")]
        public IActionResult CreateRole([FromForm]RoleCreateModel model)
        {
            var role = roleService.CreateRole(model);
            return role != null ? StatusCode(201, role) : StatusCode(400, "Tao moi that bai");
        }

        [HttpPatch]
        public IActionResult UpdateRole( Guid id ,RoleUpdateModel model)
        {
            var role = roleService.UpdateRoleProperties(id, model);
            if (role == null)
            {
                return StatusCode(400, "update that bai");
            }
            return StatusCode(201, role);
        }

        [HttpPut]
        public IActionResult UpdateRole([FromForm] RoleUpdateModel model)
        {
            var role = roleService.UpdateRole(model);
            if (role == null)
            {
                return StatusCode(400, "update that bai");
            }
            return StatusCode(201, role);
        }
        
    }
}
