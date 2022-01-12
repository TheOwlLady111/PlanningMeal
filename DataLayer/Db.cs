using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using System.Xml;

namespace DataLayer
{
    public class Db
    {
        public Db() { }

        private static Db instance;
        private List<Category> data;
        public List<Category> GetData
        {
            get
            {
                return data;
            }
        }

        private Db(string path)
        {
            data = new List<Category>();
            XmlDocument document = new XmlDocument();
            document.Load(path);

            XmlElement roots = document.DocumentElement;

            foreach (XmlNode node in roots)
            {
                Category category = new();
                bool flag = false;

                if (node.Attributes.Count > 0)
                {
                    XmlNode attr = node.Attributes.GetNamedItem("name");
                    XmlNode attr1 = node.Attributes.GetNamedItem("description");

                    category.CategoryName = attr.Value;
                    category.Description = attr1.Value;

                    if (category.Validate())
                    {
                        flag = true;


                        foreach (XmlNode categoryNode in node.ChildNodes)
                        {Product product = new();
                            foreach (XmlNode prodNode in categoryNode.ChildNodes)
                            {
                                
                                if (prodNode.Name == "Name")
                                {
                                    product.Name = prodNode.InnerText;
                                }
                            
                                if (prodNode.Name == "Gramms")
                                    {
                                        product.Gramms = double.Parse(prodNode.InnerText);
                                    }
                                    
                                        if (prodNode.Name == "Protein")
                                        {
                                            product.Protein = double.Parse(prodNode.InnerText);
                                        }
                                       
                                            if (prodNode.Name == "Fats")
                                            {
                                                product.Fats = double.Parse(prodNode.InnerText);
                                            }
                                           
                                                if (prodNode.Name == "Carbs")
                                                {
                                                    product.Carbs = double.Parse(prodNode.InnerText);
                                                }
                                                
                                                    if (prodNode.Name == "Calories")
                                                    {
                                                        product.Calories = double.Parse(prodNode.InnerText);
                                                    }
                                                
                                            
                                        
                                    
                                
                                

                            }
                            if (product.Validate())
                            {
                                category.Add(product);
                            }
                        }
                    }
                }

                if (flag) data.Add(category);

            }
        }


        public Db GetInstance()
        {
            if (instance == null)
            {
                instance = new("FoodProducts.xml");
                return instance;
            }
            else return instance;
        }

    }
}
