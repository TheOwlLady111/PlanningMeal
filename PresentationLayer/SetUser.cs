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


namespace PresentationLayer
{
    public partial class SetUser : Form
    {
        public SetUser()
        {
            InitializeComponent();
        }

        private User user = new User();
        private string str;

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            double weight=0;
            if (double.TryParse(textBox1.Text, out weight))
            {
            }
            user.Weight = weight;
            str = user.Validate(user.GetRules[1]);
            if (str != null)
            {
                e.Cancel = true;
                textBox1.Select(0, textBox1.Text.Length);

                this.errorProvider1.SetError(textBox1, str);
            }
            else
                this.errorProvider1.Clear();

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            int height = 0;
            if (int.TryParse(textBox2.Text, out height))
            {
            }
            user.Height = height;
            str = user.Validate(user.GetRules[0]);
            if (str != null)
            {
                e.Cancel = true;
                textBox2.Select(0, textBox2.Text.Length);

                this.errorProvider2.SetError(textBox2, str);
            }
            else
                this.errorProvider2.Clear();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            int age = 0;
            if (int.TryParse(textBox3.Text, out age))
            {
            }
            user.Age = age;
            str = user.Validate(user.GetRules[2]);
            if (str != null)
            {
                e.Cancel = true;
                textBox3.Select(0, textBox3.Text.Length);

                this.errorProvider3.SetError(textBox3, str);
            }
            else
                this.errorProvider3.Clear();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor= System.Drawing.Color.BurlyWood;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.NavajoWhite;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            user.Activity = radioButton1.Text;
            Console.WriteLine(user.Activity);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            user.Activity = radioButton2.Text;
            Console.WriteLine(user.Activity);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            user.Activity = radioButton3.Text;
            Console.WriteLine(user.Activity);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            user.Activity = radioButton4.Text;
            Console.WriteLine(user.Activity);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // str = user.Validate(user.GetRules[3]);
            if (!user.Validate())
            {
                MessageBox.Show("Incorrect user object!!!");
            }
            else
            {
                
                Planner planner = new Planner(user);
                this.Hide();
                planner.Show();

            }
            
        }
    }
}
