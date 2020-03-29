﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public class InhousePart : PartObject
    {
        private int machineID;

        public new int MachineID { get; set; }

        //Constructors
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
