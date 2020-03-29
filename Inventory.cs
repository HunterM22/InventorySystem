using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace InventorySystem
{
    public class Inventory
    {
        //Properties
        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<Part> AllParts = new BindingList<Part>();

        //PRODUCT METHODS

        //Add Product
        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        //Remove Product
        public static bool RemoveProduct(int ProductID)
        {
            bool success = false;
            foreach (Product prod in Products)
            {
                if (ProductID == prod.ProductID)
                {
                    Products.Remove(prod);
                    return success = true;
                }
                else
                {
                    MessageBox.Show("Removal failed.");
                    return false;
                }
            }
            return success;

        }
        //Lookup Product
        public static Product LookupProduct(int productID)
        {
            foreach (Product prod in Products)
            {
                if (prod.ProductID == productID)
                {
                    return prod;
                }
            }
            Product emptyProd = new Product();
            return emptyProd;
        }

        //Update Product
        public static void UpdateProduct(int productID, Product updatedProduct)
        {
            foreach (Product currentProd in Products)
            {
                if (currentProd.ProductID == productID)
                {//*************************************************************************
                    //currentProd.Name = updatedProd.Name;
                    //currentProd.InStock = updatedProd.InStock;
                    //currentProd.Price = updatedProd.Price;
                    //currentProd.Max = updatedProd.Max;
                    //currentProd.Min = updatedProd.Min;
                    //currentProd.AssociatedParts = updatedProd.AssociatedParts;
                    //return;
                }

            }
        }

        //PARTS METHODS-----------------

        //Add Part
        public static void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        //Remove Part
        public static bool DeletePart(Part part)
        {
            try
            {
                AllParts.Remove(part);
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Lookup Part
        public static Part LookupPart(int partID)
        {
            foreach (Part part in AllParts)
            {
                if (part.PartID == partID)
                {
                    return part;
                }
            }
            Part emptyPart = null;//new InHousePart();
            return emptyPart;

        }

        public static void UpdateInHousePart(int partID, InhousePart inPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].GetType() == typeof(InhousePart))
                {
                    InhousePart newPart = (InhousePart)AllParts[i];

                    if (newPart.PartID == partID)
                    {
                        newPart.Name = inPart.Name;
                        newPart.InStock = inPart.InStock;
                        newPart.Price = inPart.Price;
                        newPart.Max = inPart.Max;
                        newPart.Min = inPart.Min;
                        newPart.MachineID = inPart.MachineID;
                    }
                }
            }
        }

        public static void UpdateOutsourcedPart(int partID, OutsourcedPart outPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (AllParts[i].GetType() == typeof(OutsourcedPart))
                {
                    OutsourcedPart newPart = (OutsourcedPart)AllParts[i];

                    if (newPart.PartID == partID)
                    {
                        newPart.Name = outPart.Name;
                        newPart.InStock = outPart.InStock;
                        newPart.Price = outPart.Price;
                        newPart.Max = outPart.Max;
                        newPart.Min = outPart.Min;
                        newPart.CompanyName = outPart.CompanyName;
                    }
                }
            }
        }

    }
}
