using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Entities
{
    [Table("SYS_INASES_INV_ROLE")]
    public class Role
    {
        [Column("SYS_INASES_INV_ROLE_ROLE_ID")]
        [DisplayName("Id del Rol")]
        public int RoleId { get; set; }
        [Column("SYS_INASES_INV_ROLE_ROLE_VALUE")]
        [DisplayName("Rol")]
        public string RoleValue { get; set; }
        [Column("SYS_INASES_INV_ROLE_ROLE_DESCRIPTION")]
        [DisplayName("Descripcion del Rol")]
        public string RoleDescription { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
