using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DailyMeal
    {
        public DailyMeal()
        {
            Meals = new List<MealForDay>();
        }
        public List<MealForDay> Meals
        {
            get;
            set;
        }

        public double GetCarbs
        {
            get
            {
                double sum = 0;
                foreach (MealForDay meal in Meals)
                    sum += meal.GetCarbs;
                return sum;
            }
        }

        public double GetCalories
        {
            get
            {
                double sum = 0;
                foreach (MealForDay meal in Meals)
                    sum += meal.GetCalories;
                return sum;
            }
        }

        public double GetFats
        {
            get
            {
                double sum = 0;
                foreach (MealForDay meal in Meals)
                    sum += meal.GetFats;
                return sum;
            }
        }

        public double GetProteins
        {
            get
            {
                double sum = 0;
                foreach (MealForDay meal in Meals)
                    sum += meal.GetProteins;
                return sum;
            }
        }

        public void Add(MealForDay meal)
        {
            Meals.Add(meal);
        }

        public void DeleteMeal(MealForDay meal)
        {
            Meals.Remove(meal);
        }

        public MealForDay FindMeal(string name)
        {
            foreach(MealForDay meal in Meals)
            {
                if (meal.NameOfMeal == name)
                    return meal;
            }
            return null;
        }
    }
}

