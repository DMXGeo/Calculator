using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        String currentNumber; //The currently displayed number
        double numberOne, numberTwo; //stored numbers
        double result;

        bool equalsActive; //set true the equals button has already been clicked, used for clicking it more than once 
        bool additionState, subtractState, multiplyState, divideState; //current operation state the calculator is in
        bool calculationState; //determines if there is currently a calculation being stored
                               //for example, was the plus button pressed before any other operation

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void number0_Click(object sender, EventArgs e)
        {
            equalsClicked();
            if(display.Text == "0")
            {
                //Do nothing
            }
            else
            {
                currentNumber += "0";
                display.Text = currentNumber;
            }
            
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += ".";
            display.Text = currentNumber;
        }

        private void number1_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "1";
            display.Text = currentNumber;
        }

        private void number2_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "2";
            display.Text = currentNumber;
        }

        private void number3_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "3";
            display.Text = currentNumber;
        }

        private void number4_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "4";
            display.Text = currentNumber;
        }

        private void number5_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "5";
            display.Text = currentNumber;
        }

        private void number6_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "6";
            display.Text = currentNumber;
        }

        private void number7_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "7";
            display.Text = currentNumber;
        }

        private void number8_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "8";
            display.Text = currentNumber;
        }

        private void number9_Click(object sender, EventArgs e)
        {
            equalsClicked();
            currentNumber += "9";
            display.Text = currentNumber;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            OperatorSelected();
            additionState = true;
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            OperatorSelected();
            subtractState = true;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            OperatorSelected();
            multiplyState = true;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if(multiplyState)
            {
                if(equalsActive)
                {
                    result = numberTwo * double.Parse(display.Text);
                    display.Text = result.ToString();
                }
                else
                {
                    numberTwo = double.Parse(display.Text);
                    result = numberOne * double.Parse(currentNumber);
                    display.Text = result.ToString();
                }
            }
            else if (subtractState)
            {
                if (equalsActive)
                {  
                    result = double.Parse(display.Text) - numberTwo;
                    display.Text = result.ToString();
                }
                else
                {
                    numberTwo = double.Parse(display.Text);
                    result = numberOne - double.Parse(currentNumber);
                    display.Text = result.ToString();
                }
            }
            else if (additionState)
            {
                if(equalsActive)
                {
                    result = numberTwo + double.Parse(display.Text);
                    display.Text = result.ToString();
                }
                else
                {
                    numberTwo = double.Parse(display.Text);
                    result = numberOne + double.Parse(currentNumber);
                    display.Text = result.ToString();
                }
            }
            
            equalsActive = true;

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            currentNumber = "";
            display.Text = "0";
            calculateReset();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void equalsClicked()
        {
            if(equalsActive)
            {
                currentNumber = "";
                equalsActive = false;
            }
        }

        private void OperatorSelected()
        {
            equalsActive = false;

            if (calculationState)
            {
                Calculation();
            }

            calculateReset();

            numberOne = double.Parse(display.Text);
            currentNumber = "";
            calculationState = true;
        }

        private void calculateReset()
        {
            multiplyState = false;
            additionState = false;
            subtractState = false;
        }

        private void Calculation()
        {
            if (multiplyState)
            {
                numberTwo = double.Parse(display.Text);
                result = numberOne * double.Parse(currentNumber);
                display.Text = result.ToString(); 
            }
            else if (additionState)
            {
                numberTwo = double.Parse(display.Text);
                result = numberOne + double.Parse(currentNumber);
                display.Text = result.ToString();
            }
            else if (subtractState)
            {
                numberTwo = double.Parse(display.Text);
                result = numberOne - double.Parse(currentNumber);
                display.Text = result.ToString();
            }
        }

        

    }
}
