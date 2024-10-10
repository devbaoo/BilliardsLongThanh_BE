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
        public IActionResult CreateRole(string name)
        {
            var role = roleService.CreateRole(name);
            return Ok(role);
        }
    }
}
