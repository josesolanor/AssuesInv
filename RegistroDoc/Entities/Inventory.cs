using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Entities
{
    [Table("SYS_INASES_INV_INVENTORY")]
    public class Inventory
    {
        [Column("SYS_INASES_INV_INVENTORY_INVENTORY_ID")]
        public int InventoryId { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_NUMBER")]
        [DisplayName("N°")]
        public int Number { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_REFERENCE_CODE")]
        public string ReferenceCode { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_DOCUMENT_TITLE")]
        public string DocumentTitle { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_SERIES")]
        public string Series { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_VOLUMEN")]
        public string Volume { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_SECOND_NUMBER")]
        public string SecondNumber { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_EXTREME_DATE")]
        public string ExtremeDates { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_INSTALLATION_UNIT")]
        public string InstallationUnit { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_NUMBER_SHEETS")]
        public string NumberSheets { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_PRODUCER_NAME")]
        public string ProducerName { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_STATE_CONVERSATION")]
        public string StateConservation { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_DOCUMENT_OBSERVATION")]
        public string DocumentObservation { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_SHELF")]
        public string Shelf { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_BALD")]
        public string Bald { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_BOX")]
        public int Box { get; set; }        
        public ICollection<Movements> Movements { get; set; }
    }
}
