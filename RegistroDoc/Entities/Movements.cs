using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Entities
{
    [Table("SYS_INASES_INV_MOVEMENTS")]
    public class Movements
    {
        [Column("SYS_INASES_INV_MOVEMENTS_MOVEMENT_ID")]
        public int MovementsId { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_MOVEMENT_TYPE")]
        [DisplayName("Tipo")]
        public string MovementType { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_MOVEMENT_DATE")]
        [DisplayName("Fecha")]
        public DateTime MovementDate { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_MOVEMENT_OBSERVATION")]
        [DisplayName("Observacion")]
        public string MovementObservation { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_INVENTORY_ID")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
