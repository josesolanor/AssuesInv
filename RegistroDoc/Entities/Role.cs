using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Entities
{
    [Table("SYS_INASES_INV_ROLE")]
    public class Role
    {
        [Column("SYS_INASES_INV_ROLE_ROLE_ID")]
        public int RoleId { get; set; }
        [Column("SYS_INASES_INV_ROLE_ROLE_VALUE")]
        public string RoleValue { get; set; }
        [Column("SYS_INASES_INV_ROLE_ROLE_DESCRIPTION")]
        public string RoleDescription { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
