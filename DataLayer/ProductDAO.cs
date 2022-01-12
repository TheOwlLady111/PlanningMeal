using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class ProductDAO
    {
        private Product prod;
        private Db db;
        private List<Category> data;
        public ProductDAO()
        {
            db = new Db();
            data = new List<Category>();
            db = db.GetInstance();
            data = db.GetData;
        }
        public Product GetProduct(string name)
        {
            foreach (Category cat in data)
            {
                foreach (Product prod in cat.ListOfProducts)
                    if (prod.Name == name) return prod;
            }
            return prod;
        }

        public Product GetProduct(string nameCat, string nameProd)
        {
            foreach(Category cat in data)
            {
                if (cat.CategoryName==nameCat)
                {
                    foreach(Product prod in cat.ListOfProducts)
                    {
                        if (prod.Name == nameProd) this.prod = prod;
                    }
                }
            }

            return prod;
        }


    }
}
