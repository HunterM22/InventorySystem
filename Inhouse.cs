using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public class InhousePart : Part
    {
        private int machineID;

        public new int MachineID { get; set; }

        public InhousePart() { }

        public InhousePart(int partID, string name, int inStock, decimal price,
            int max, int min, int machineID)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Max = max;
            Min = min;
            MachineID = machineID;
        }
    }
}
