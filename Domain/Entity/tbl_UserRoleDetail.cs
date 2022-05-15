using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class tbl_UserRoleDetail
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public tbl_Role tblRole { get; set; }
        public Guid UserId { get; set; }
        public tbl_User tblUser { get; set; }
    }
}
