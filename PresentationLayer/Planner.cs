using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;


namespace PlanningMeal.PresentationLayer
{
    public partial class Planner : Form
    {

        public Planner()
        {
            
            InitializeComponent();
            treeCategories = new TreeView();
        }

        public Planner(User user)
        {
            InitializeComponent();
            this.user = user;
            treeCategories = treeView1;
            Console.WriteLine("constructor");
            
        }

        private User user;
        private List<TreeNode> selectedNodes;
        private TreeView treeCategories;

        private void CreateProductsTree()
        {
            treeCategories.BeginUpdate();
            treeCategories.Nodes.Clear();
            int i = 0;

            foreach (Category category in Service.GetListOfCategories)
            {
                treeCategories.Nodes.Add(new TreeNode(category.CategoryName));
                treeCategories.Nodes[i].Name = category.CategoryName;
                Console.WriteLine(category.CategoryName);

                foreach (Product product in Service.GetProductsInCategory(category.CategoryName))
                {
                    TreeNode node = new TreeNode(product.Name);
                    node.Name = product.Name;
                    treeCategories.Nodes[i].Nodes.Add(node);
                    Console.WriteLine(product.Name);
                }
                i++;
            }
           
           treeCategories.EndUpdate();
           //this.treeCategories.Update();
         
        }

        //private void CreateRatioTree()
        //{
        //    treeView2.BeginUpdate();
        //    treeView2.Nodes.Clear();
        //    int i = 0;
            
        //    foreach(Meal meal in)
        //    {
        //        treeView2.Nodes.Add(new TreeNode());
        //        treeView2.Nodes[i].Name =;
        //    }
        //    treeView2.EndUpdate();
        //}

        private void SearchInTree(TreeView tree,string word)
        {
            selectedNodes = new List<TreeNode>();

            foreach(TreeNode parentNode in tree.Nodes)
            {
                if (parentNode.Text.ToLower().Contains(word.ToLower()))
                {
                    tree.SelectedNode = parentNode;
                    selectedNodes.Add(parentNode);
                    parentNode.BackColor = Color.DarkCyan;
                }
                foreach(TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.Text.ToLower().Contains(word.ToLower()))
                    {
                        tree.SelectedNode = childNode;
                        selectedNodes.Add(childNode);
                        childNode.BackColor = Color.LightCyan;
                    }
                }
            }
        }

        private void UpdateTree(List<TreeNode> nodes)
        {
            if (nodes!=null)
            {
                foreach(TreeNode node in nodes)
                {
                    node.BackColor = Color.NavajoWhite;
                    node.Collapse();
                }
                nodes.Clear();
            }
        }


        private void Planner_Load(object sender, EventArgs e)
        {
            Console.WriteLine("planer");
            this.CreateProductsTree();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            treeCategories.CollapseAll();
            UpdateTree(selectedNodes);
            if (e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                if(!string.IsNullOrEmpty(this.textBox1.Text))
                {
                    this.SearchInTree(treeCategories,textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Enter information in searchline!!!");
                }
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            treeCategories.CollapseAll();
            UpdateTree(selectedNodes);
            if (e.Button == MouseButtons.Left)
            {
                
                if (!string.IsNullOrEmpty(this.textBox1.Text))
                {
                    this.SearchInTree(treeCategories,textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Enter information in searchline!!!");
                }
            }
        }
    }
}
