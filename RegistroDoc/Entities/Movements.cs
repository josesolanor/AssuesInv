using System;
using System.Collections.Generic;
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
        public string MovementType { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_MOVEMENT_DATE")]
        public DateTime MovementDate { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_MOVEMENT_OBSERVATION")]
        public string MovementObservation { get; set; }
        [Column("SYS_INASES_INV_MOVEMENTS_INVENTORY_ID")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
