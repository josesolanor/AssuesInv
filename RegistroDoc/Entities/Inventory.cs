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
        [DisplayName("Nº")]
        public int Number { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_REFERENCE_CODE")]
        [DisplayName("Código de Referencia")]
        public string ReferenceCode { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_DOCUMENT_TITLE")]
        [DisplayName("Título del Documento")]
        public string DocumentTitle { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_SERIES")]
        [DisplayName("Serie")]
        public string Series { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_VOLUMEN")]
        [DisplayName("Tomo y/o")]
        public string Volume { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_SECOND_NUMBER")]
        [DisplayName("Nº")]
        public string SecondNumber { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_EXTREME_DATE")]
        [DisplayName("Fechas Extremas")]
        public string ExtremeDates { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_INSTALLATION_UNIT")]        
        [DisplayName("Unidad de Instalacion")]
        public string InstallationUnit { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_NUMBER_SHEETS")]
        [DisplayName("Nº de Folios")]
        public string NumberSheets { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_PRODUCER_NAME")]
        [DisplayName("Nombre del Productor")]
        public string ProducerName { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_STATE_CONVERSATION")]
        [DisplayName("Estado de Conservación (Referencia cruzada)")]
        public string StateConservation { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_DOCUMENT_OBSERVATION")]
        [DisplayName("Observación del Documento")]
        public string DocumentObservation { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_SHELF")]
        [DisplayName("Estante")]
        public string Shelf { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_BALD")]
        [DisplayName("Balda")]
        public string Bald { get; set; }
        [Column("SYS_INASES_INV_INVENTORY_BOX")]
        [DisplayName("Nº Caja")]
        public int Box { get; set; }        
        public ICollection<Movements> Movements { get; set; }
    }
}
