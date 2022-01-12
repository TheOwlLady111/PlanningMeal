using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Product : BusinessObject
    {

        public double Carbs
        {
            get;
            set;
        }

        public double Fats
        {
            get;
            set;
        }

        public double Protein
        {
            get;
            set;
        }

        public double Calories
        {
            get;
            set;
        }

        public double Gramms
        {
            get;
            set;
        }
        public double Count(double gramms, double thing)
        {
            return (thing * gramms) / 100;
        }
        public string Name
        {
            get;
            set;
        }


        public Product()
        {
            BusinessRule ruleName = new(obj => (Name.Length < 50), "Incorrect name of product!!!");
            businessRules.Add(ruleName);

            BusinessRule ruleGramms = new(obj => (Gramms > 0), "Incorrect gramms!!!");
            businessRules.Add(ruleGramms);

            BusinessRule ruleProteins = new(obj => (Protein >= 0), "Incorrect proteins!!!");
            businessRules.Add(ruleProteins);

            BusinessRule ruleCarbs = new(obj => (Carbs >= 0), "Incorrect carbs!!!");
            businessRules.Add(ruleCarbs);

            BusinessRule ruleFats = new(obj => (Fats >= 0), "Incorrect fats!!!");
            businessRules.Add(ruleFats);

            BusinessRule ruleCalories = new(obj => (Calories >= 0), "Incorrect calories!!!");
            businessRules.Add(ruleCalories);
        }

        public override string ToString()
        {
            return Name + "-" + Calories + "/" + Protein + "/" + Fats + "/" + Carbs;
        }

    }
}


