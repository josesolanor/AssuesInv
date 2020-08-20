using RegistroDoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Models
{
    public class InventoryViewModels
    {
        public int InventoryId { get; set; }
        public int Number { get; set; }
        public string ReferenceCode { get; set; }
        public string DocumentTitle { get; set; }
        public string Series { get; set; }
        public string Volume { get; set; }
        public string SecondNumber { get; set; }
        public string ExtremeDates { get; set; }
        public string InstallationUnit { get; set; }
        public string NumberSheets { get; set; }
        public string ProducerName { get; set; }
        public string StateConservation { get; set; }
        public string DocumentObservation { get; set; }
        public string Shelf { get; set; }
        public string Bald { get; set; }
        public string Box { get; set; }
        public List<MovementsViewModels> Movements { get; set; }
    }
}
