using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class tbl_Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<tbl_UserRoleDetail> tblUserRoleDetail { get; set; } = new List<tbl_UserRoleDetail>();
    }
}
