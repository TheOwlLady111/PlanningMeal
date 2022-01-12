using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    abstract public class BusinessObject
    {
        protected List<BusinessRule> businessRules;

        public List<BusinessRule> GetRules
        {
            get
            {
                return businessRules;
            }
        }

        public BusinessObject()
        {
            businessRules = new();
        }
        public void Add(BusinessRule rule)
        {
            businessRules.Add(rule);
        }

        public bool Validate()
        {
            if (businessRules.Count > 0)
            {
                foreach (BusinessRule rule in businessRules)
                {
                    if (!rule.propertyOfError(this))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string Validate(BusinessRule rule)
        {
            string str = null;
            if (!rule.propertyOfError(this))
                str = rule.errorMessage;
            return str;
        }
      
    }
}

