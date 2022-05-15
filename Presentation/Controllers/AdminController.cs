using Application.Dto;
using Application.Models;
using Application.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        protected IRoleRepo _roleRepo;

        public AdminController(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        [HttpGet("GetAllRole")]
        public async Task<ActionResult<List<RoleDto>>> GetAllRole()
        {
            var role = await _roleRepo.GetAllRole();
            if (role.Count() > 0)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRole(RoleRequest role)
        {
            return Ok(await _roleRepo.CreateAsync(role));
        }

        [HttpPost("CreateUserRole")]
        public async Task<ActionResult> CreateUserRole(CreateUserRoleRequest role)
        {
            var result = await _roleRepo.CreateUserRole(role);
            if (result == true)
            {
                return Ok("Role has been Assign to a User");
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
