using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class Service
    {
        static private ProductDAO product = new ProductDAO();
        static private CategoryDAO category = new CategoryDAO();
        static private DailyMeal dailyMeal = new DailyMeal();

        static public List<Category> GetListOfCategories
        {
            get
            {
                return category.GetCategories;
            }
        }

        static public Category GetCategory(string name)
        {
            return category.GetCategory(name);
        }

        static public List<Product> GetProductsInCategory(string categoryName)
        {
            foreach (Category cat in category.GetCategories)
            {
                if (cat.CategoryName == categoryName)
                {
                    return cat.ListOfProducts;
                }
            }
            return null;
        }

        static public Product GetProduct(string name)
        {
            return product.GetProduct(name);
        }

        static public Product GetProduct(string nameCat, string nameProd)
        {
            return product.GetProduct(nameCat, nameProd);
        }

        static public void AddProduct(List<Product> list, Product prod)
        {
            list.Add(prod);
        }

        static public void RemoveProduct(List<Product> list, Product prod)
        {
            list.Remove(prod);
        }

        static public void AddCategory(List<Category> list, Category cat)
        {
            list.Add(cat);
        }


        static public void RemoveCategory(List<Category> list, Category cat)
        {
            list.Remove(cat);
        }

        static public DailyMeal GetDailyMeal()
        {
            dailyMeal.Add(new MealForDay("Breakfast"));
            dailyMeal.Add(new MealForDay("Lunch"));
            dailyMeal.Add(new MealForDay("Dinner"));
            return dailyMeal;
        }

        static public void AddProductToMeal(MealForDay meal, Product prod)
        {
            meal.AddProduct(prod);
        }

        static public void DeleteMeal (DailyMeal meals, MealForDay meal)
        {
            meals.DeleteMeal(meal);
        }

        static public MealForDay FindMeal(DailyMeal meals, string mealName)
        {
            return meals.FindMeal(mealName);
        }

        static public void ChangeNameOfMeal(DailyMeal meals,string mealName, string nameToChange)
        {
            meals.FindMeal(mealName).NameOfMeal = nameToChange;
        }

    }
}

