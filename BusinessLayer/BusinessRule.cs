using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
        public class BusinessRule
        {
            public Predicate<BusinessObject> propertyOfError;
            public string errorMessage;

            public BusinessRule(Predicate<BusinessObject> property, string error)
            {
                propertyOfError = property;
                errorMessage = error;
            }
        }
    
}
