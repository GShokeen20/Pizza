﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrder
{
    class Pizza
    {
        string btnSauce;
        string btnCheeze;
        string toppings;
        string instructions;
        private int addedIndex;
        public Pizza()
        {
            btnSauce = "None";
            btnCheeze = "None";
            toppings = "";
            instructions = "N/A";
        }
        public Pizza(int index)
        {
            addedIndex = index;
        }
        public string GetInfo(string toppings)
        {
            return $"Pizza #{addedIndex}:\nToppings:   {btnSauce}\n   {toppings}\n   {btnCheeze}\nInstructions:{instructions}";
        }
    }
}