using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InventorySystem
{
    public class Product
    {
        public BindingList<PartObject> AssociatedParts = new BindingList<PartObject>();

        //Property
        public Product(int productID, string name, int inStock, decimal price,
            int max, int min)
        {
            ProductID = productID;
            Name = name;
            InStock = inStock;
            Price = price;
            Max = max;
            Min = min;

        }

        public Product() { }

            public int ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int InStock { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }


        //METHODS

        //Add Associated Part
        //public void AddAssociatedPart(PartObject)
        //{
        //    AssociatedParts.Add(PartObject);
        //}

        //Remove Associated Part
        public bool RemoveAssociatedPart(int partID)
        {
           
        }
        
        //Lookup Associated Part
        public PartObject LookupAssociatedPart(int PartID)
        {

        }
    }
}

