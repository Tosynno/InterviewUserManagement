using Application.Dto;
using Application.Models;
using Application.Respository;
using AutoMapper;
using Domain.Entity;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : BaseRepository<tbl_Role>, IRoleRepo
    {
        private readonly IMapper _mapper;
        private readonly IRepository<tbl_UserRoleDetail> _repositoryRoles;
        private readonly IRepository<tbl_User> _repositoryUser;
        public RoleService(AppDbContext dbContext, IMapper mapper, IRepository<tbl_UserRoleDetail> repositoryRole, IRepository<tbl_User> repositoryUser) : base(dbContext)
        {
            _mapper = mapper;
            _repositoryRoles = repositoryRole;
            _repositoryUser = repositoryUser;
        }

        public async Task<string> CreateAsync(RoleRequest role)
        {
            var sa = _mapper.Map<tbl_Role>(role);
            await AddAsync(sa);
            return "New Role Have been Created";
        }

        public async Task<bool> CreateUserRole(CreateUserRoleRequest request)
        {
            var role  = await GetByIdAsync(request.RoleId);
            Guid Userid = Guid.Parse(request.UserId);
            var user = await  _repositoryUser.GetByIdAsync(Userid);
            if (user != null)
            {
                tbl_UserRoleDetail sa = new tbl_UserRoleDetail();
                sa.UserId = user.Id;
                sa.RoleId = role.Id;
                await _repositoryRoles.AddAsync(sa);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<RoleDto>> GetAllRole()
        {
            var roles = await GetAllAsync();
            var result = _mapper.Map<List<RoleDto>>(roles.ToList());
            return result;  
        }
    }
}
