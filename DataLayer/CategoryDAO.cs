using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
   public class CategoryDAO
    {
        private Db db;
        private List<Category> data;
        private Category category;

        public CategoryDAO()
        {
            db = new Db();
            data = new List<Category>();
            db = db.GetInstance();
            data = db.GetData;

        }
       public List<Category> GetCategories
        {
            get
            {
                return data;
            }
        }

        public Category GetCategory(string name)
        {
            foreach (Category cat in data)
            {
                if (cat.CategoryName == name) category = cat;

            }
            return category;
        }

        public void Add(Category cat)
        {
            data.Add(cat);
        }

        public void Remove(Category cat)
        {
            data.Remove(cat);
        }

        public void AddProduct(Product prod)
        {
            category.Add(prod);
        }

        public void RemoveProduct(Product prod)
        {
            category.Remove(prod);
        }
    }
}
