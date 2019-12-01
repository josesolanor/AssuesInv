using RegistroDoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDoc.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<Inventory> Inventaries { get; set; }
        public Movements Movement { get; set; }
    }
}
