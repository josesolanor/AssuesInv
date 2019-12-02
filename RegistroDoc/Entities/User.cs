using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Entities
{
    [Table("SYS_INASES_INV_USER")]
    public class User
    {
        [Column("SYS_INASES_INV_USER_USER_ID")]
        public int UserId { get; set; }
        [Column("SYS_INASES_INV_USER_FIRST_NAME")]
        [DisplayName("Nombre")]
        public string FirstName { get; set; }
        [Column("SYS_INASES_INV_USER_LAST_NAME")]
        [DisplayName("Apellido Paterno")]
        public string LastName { get; set; }
        [Column("SYS_INASES_INV_USER_SECOND_LAST_NAME")]
        [DisplayName("Apellido Materno")]
        public string SecondLastName { get; set; }
        [Column("SYS_INASES_INV_USER_EMAIL")]
        [DisplayName("Correo Electronico")]
        public string Email { get; set; }
        [Column("SYS_INASES_INV_USER_ACCOUNT")]
        [DisplayName("Usuario")]
        public string Account { get; set; }
        [Column("SYS_INASES_INV_USER_PASSWORD")]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        [Column("SYS_INASES_INV_USER_ROLE_ID")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
