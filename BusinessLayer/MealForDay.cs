using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MealForDay : BusinessObject
    {
        public MealForDay()
        {
            ListOfProducts = new List<Product>();
            BusinessRule rule1 = new BusinessRule(obj => (NameOfMeal.All(ch => char.IsLetter(ch)) && NameOfMeal.Length > 35), "Incorrect name of meal!!!");
            businessRules.Add(rule1);
        }

        public MealForDay(string str)
        {
            ListOfProducts = new List<Product>();
            BusinessRule rule1 = new BusinessRule(obj => (NameOfMeal.All(ch => char.IsLetter(ch)) && NameOfMeal.Length > 35), "Incorrect name of meal!!!");
            businessRules.Add(rule1);
            NameOfMeal = str;
        }
    


        public string NameOfMeal
        {
            get;
            set;
        }

        public List<Product> ListOfProducts
        {
            get;
            set;
        }

        public void AddProduct(Product prod)
        {
            ListOfProducts.Add(prod);

        }

        public void RemoveProduct(Product prod)
        {
            ListOfProducts.Remove(prod);
        }

        public double GetCalories
        {
            get
            {
                double summ = 0;
                if (ListOfProducts != null)
               { foreach (Product prod in ListOfProducts)
                        summ += (prod.Calories * prod.Gramms)/100; }
                return summ;
            }
        }

        public double GetCarbs
        {
            get
            {
                double summ = 0;
                foreach (Product prod in ListOfProducts)
                    summ += prod.Carbs * prod.Gramms;
                return summ;
            }
        }

        public double GetFats
        {
            get
            {
                double summ = 0;
                foreach (Product prod in ListOfProducts)
                    summ += prod.Fats * prod.Gramms;
                return summ;
            }
        }

        public double GetProteins
        {
            get
            {
                double summ = 0;
                foreach (Product prod in ListOfProducts)
                    summ += prod.Protein * prod.Gramms;
                return summ;
            }
        }
    }
}
