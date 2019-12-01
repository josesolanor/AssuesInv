using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Models
{
    public class MovementsViewModels
    {
        public int MovementsId { get; set; }
        public string MovementType { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementDateString { get; set; }
        public string MovementObservation { get; set; }
        public int InventoryId { get; set; }
    }
}
