using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class tbl_User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string Nationality { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<tbl_UserRoleDetail> tblUserRoleDetail { get; set; } = new List<tbl_UserRoleDetail>();
    }
}
