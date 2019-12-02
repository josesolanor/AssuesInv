using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Models
{
    public class MovementCreateViewModel
    {        
        public string MovementType { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementObservation { get; set; }
        public string RegisterDateString { get; set; }
        public int InventoryId { get; set; }
    }
}
