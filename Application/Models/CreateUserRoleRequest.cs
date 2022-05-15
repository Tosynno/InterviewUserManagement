using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateUserRoleRequest
    {
        public int RoleId { get; set; }
        public string UserId { get; set; }
    }
}
