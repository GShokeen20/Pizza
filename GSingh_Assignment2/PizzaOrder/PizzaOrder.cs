/*
 * File Name: PizzaOrder.cs
 * Assignment2 for PROG1815-20S-Sec2-Programming Concepts II
 * 
 * Revision History
 *      Garima Singh, 2020-07-05 : Created
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class PizzaOrder : Form
    {
        string[] toppingsList = new string[11] {
                                                    "","","","","","","","","","",""
                                               };
        public PizzaOrder()
        {
            InitializeComponent();
            lblForButtons.Enabled = false;
            txtBoxCount.Enabled = true;
            txtSpecialInstructions.Enabled = false;
            pnlCheckOut.Enabled = false;
            lblForButtons.Enabled = false;
            grpSauce.Enabled = false;
            grpToppings.Enabled = false;
            grpCheese.Enabled = false;
            btnCheckOut.Enabled = false;
            lblSpecialInstructions.Enabled = false;
            btnStartNewOrder.Enabled = false;
            pnlOrder.Visible = false;
        }

        //private Pizza pizza;
        //RadioButton box;
        string toppings = "";
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblForButtons.Enabled = true;
            txtBoxCount.Enabled = false;
            txtSpecialInstructions.Enabled = true;
            pnlCheckOut.Enabled = true;
            lblForButtons.Enabled = true;
            grpSauce.Enabled = true;
            grpToppings.Enabled = true;
            grpCheese.Enabled = true;
            btnCheckOut.Enabled = true;
            lblSpecialInstructions.Enabled = true;
            btnStartNewOrder.Enabled = true;
            pnlOrder.Visible = false;
            if (int.TryParse(txtBoxCount.Text, out int totalNumberOfPizzas))
            {
                if (totalNumberOfPizzas >= 1 && totalNumberOfPizzas <= 9)
                {
                    int locationRow = 30;
                    int nameForRadioButton = 0;

                    for (int i = 0; i < totalNumberOfPizzas; i++)
                    {
                        RadioButton box = new RadioButton();
                        box.Name = nameForRadioButton.ToString();
                        nameForRadioButton++;

                        box.Appearance = Appearance.Button;
                        box.Width = 130;
                        box.Height = 130;
                        box.Location = new Point(locationRow, locationRow * (i + 1));

                        Pizza pizza = new Pizza(i+1);
                        box.Tag = pizza;
                        box.Click += new EventHandler(DynamicRadioBox_Click);
                        box.TextChanged += new EventHandler(DynamicRadioBox_Change);

                        lblForButtons.Controls.Add(box);
                    }                   
                }
                    lblForButtons.Enabled = true;
                }
                else
                {
                    MessageBox.Show("You entered more than 9 pizza pies at a time!");
                    Environment.Exit(1);
                }
        }

        private void DynamicRadioBox_Change(object sender, EventArgs e)
        {
            RadioButton box = (RadioButton)sender;
            Pizza pizza = (Pizza)box.Tag; 
            pnlTotalOrder.Text = pizza.GetInfo(toppings);
        }

        private void DynamicBox_Change(object sender, EventArgs e)
        {
            RadioButton box = (RadioButton)sender;
            Pizza pizza = (Pizza)box.Tag;            
        }

        private void DynamicRadioBox_Click(object sender, EventArgs e)
        {
            RadioButton box = (RadioButton)sender;
            Pizza pizza = (Pizza)box.Tag;
            if (box.Checked == true)
            {
                if (chk0.Name.Substring(3)=="0")
                {
                    toppingsList[0] = "Pepperoni";
                }
                
                if (chk1.Name.Substring(3) == "1")
                {
                    toppingsList[1] = "Bacon";
                }
                
                if (chk2.Name.Substring(3) == "2")
                {
                    toppingsList[2] = "Ham";
                }

                if (chk3.Name.Substring(3) == "3")
                {
                    toppingsList[3] = "Mushrooms";
                }
                
                if (chk4.Name.Substring(3) == "4")
                {
                    toppingsList[4] = "Pineapple";
                }

                if (chk5.Name.Substring(3) == "5")
                {
                    toppingsList[5] = "Tomato";
                }

                if (chk6.Name.Substring(3) == "6")
                {
                    toppingsList[6] = "Green Peppers";
                }

                if (chk7.Name.Substring(3) == "7")
                {
                    toppingsList[7] = "Onion";
                }
                
                if (chk8.Name.Substring(3) == "8")
                {
                    toppingsList[8] = "Spinach";
                }

                if (chk9.Name.Substring(3) == "9")
                {
                    toppingsList[9] = "Olives, Black";
                }
                
                if (chk10.Name.Substring(3) == "10")
                {
                    toppingsList[10] = "Olives, Green";
                }
            }
        }

        private void btnStartNewOrder_Click(object sender, EventArgs e)
        {
            txtSpecialInstructions.Clear();
            txtBoxCount.Clear();
            txtBoxCount.Enabled = true;
            txtSpecialInstructions.Enabled = false;
            pnlCheckOut.Enabled = false;
            lblForButtons.Enabled = false;
            grpSauce.Enabled = false;
            grpToppings.Enabled = false;
            grpCheese.Enabled = false;
            btnCheckOut.Enabled = false;
            lblSpecialInstructions.Enabled = false;
            btnStartNewOrder.Enabled = false;
            pnlOrder.Visible = false;
            pnlTotalOrder.Text = "";
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Button box = (Button)sender;
            Pizza pizza = (Pizza)box.Tag;
            pnlOrder.Visible = true;
            for(int i = 0; i < 11; i++)
            {
                toppings += toppingsList[i] + Environment.NewLine;
            }
            pnlTotalOrder.Text = pizza.GetInfo(toppings);
        }
    }
}