using Application.Dto;
using Application.Models;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Respository
{
    public interface IRoleRepo : IRepository<tbl_Role>
    {
        Task<string> CreateAsync(RoleRequest role);
        Task<List<RoleDto>> GetAllRole();
        Task<bool> CreateUserRole(CreateUserRoleRequest request);

    }
}
