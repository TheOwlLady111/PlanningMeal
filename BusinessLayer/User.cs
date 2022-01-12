using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User : BusinessObject
    {


        private static List<String> activities = new List<String>() { "Low", "Normal", "Average", "High" };
        //private static List<double> activities = new List<double>(){ 1.2, 1.375, 1.55, 1.725 };

        private double koef = 0;

        public double GetKoef
        {
            get
            {
                if (Activity == "Low") koef = 1.2;
                else
                {
                    if (Activity == "Normal") koef = 1.375;
                    else
                    {
                        if (Activity == "Average") koef = 1.55;
                        else
                        {
                            if (Activity == "High") koef = 1.725;
                        }
                    }

                }
                return koef;
            }
        }
        public int Height
        {
            get;
            set;
        }

        public double Weight
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public string Activity
        {
            get;
            set;
        }

        public double GetCalories
        {
            get
            {
                double cal=( 447.593 + 9.247 * Weight + 3.098 * Height - 4.330 * Age) * GetKoef;
                return cal;
            }
        }

        public User()
        {
            BusinessRule ruleHeight = new BusinessRule(obj => (Height > 50 && Height < 270), "Incorrect height!!!");
            BusinessRule ruleWeight = new BusinessRule(obj => (Weight > 10 && Weight < 700), "Incorrect weight!!!");
            BusinessRule ruleAge = new BusinessRule(obj => (Age > 1 && Age < 150), "Incorrect age!!!");
            BusinessRule ruleActivity = new BusinessRule(obj => (activities.Contains(Activity)), "Incorrect activity!!!");

            businessRules.Add(ruleHeight);
            businessRules.Add(ruleWeight);
            businessRules.Add(ruleAge);
            businessRules.Add(ruleActivity);
        }
        //public User (int age,int height, double weight, double activity)
        //{

        //}
    }
}


