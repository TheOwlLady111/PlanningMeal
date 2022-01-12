using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Category : BusinessObject
    {
        public List<Product> ListOfProducts
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public void Add(Product prod)
        {
            ListOfProducts.Add(prod);
        }

        public void Remove(Product prod)
        {
            ListOfProducts.Remove(prod);
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj.GetType(), this.GetType()))
            {
                Category item = obj as Category;
                if (this.CategoryName != item.CategoryName) return false;
                if (this.Description != item.Description) return false;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return CategoryName;
        }
        public Category()
        {
            ListOfProducts = new();
            BusinessRule rule = new BusinessRule(obj =>!(string.IsNullOrEmpty(CategoryName)), "Incorrect category name!!!");
            businessRules.Add(rule);
            
        }
    }
}
