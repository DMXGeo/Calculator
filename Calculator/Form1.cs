﻿using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        String currentNumber; //The currently displayed number
        double numberOne, numberTwo; //stored numbers
        double result;

        bool equalsActive; //set true the equals button has already been clicked, used for clicking it more than once 
        bool additionState, subtractState, multiplyState, divideState; //current operation state the calculator is in
        bool calculationState; //determines if there is currently a calculation being stored
                               //for example, was the plus button pressed before any other operation

        public CalculatorForm()
        {
            InitializeComponent();
        }

        //-----The next 10 buttons simply display the number/decimal pressed and adds them to the currentNumber variable-----
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
        //-----End of number chain-----

        //-----The next 4 event methods handle when operands are pressed and activate the Operation state method-----
        
        //Plus operand
        private void plusButton_Click(object sender, EventArgs e)
        {
            try
            {
                calculateReset();
                OperatorSelected();
                additionState = true;
            }
            catch(FormatException ex)
            {
            }
        }
        
        //Minus operand
        private void minusButton_Click(object sender, EventArgs e)
        {
            try
            {
                calculateReset();
                OperatorSelected();
                subtractState = true;
            }
            catch(FormatException ex)
            {

            }
        }

        //Multiply operand
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                calculateReset();
                OperatorSelected();
                multiplyState = true;
            }
            catch(FormatException ex)
            {

            }
            
        }

        //Divide operand
        private void divideButton_Click(object sender, EventArgs e)
        {
            try
            {
                calculateReset();
                OperatorSelected();
                divideState = true;
            }
            catch
            {

            }
        }
        //----- End of operan event handlers -----

        //The equals button checks for the last operand button pressed,
        //the equalsActive boolean checks if the user is pressing it again
        //for the same calculation and acts accordingly
        private void equalsButton_Click(object sender, EventArgs e)
        {
            if(multiplyState)
            {
                if(equalsActive)
                {
                    result = numberTwo * double.Parse(display.Text);
                    display.Text = result.ToString();
                    currentNumber = display.Text;
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
            else if (divideState)
            {
                if(equalsActive)
                {
                    result = double.Parse(display.Text) / numberTwo;
                    display.Text = result.ToString();
                }
                else
                {
                    numberTwo = double.Parse(display.Text);
                    result = numberOne / double.Parse(currentNumber);
                    display.Text = result.ToString();
                }
            }
            
            equalsActive = true;

        }

        //Check that the number in the display isn't 0 before using the Math
        //class to get the square root of it
        private void squareRootButton_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {

            }
            else
            {
                numberOne = Math.Sqrt(double.Parse(currentNumber));
                display.Text = numberOne.ToString();
                currentNumber = display.Text;
            }
            

        }

        //Allows the user to delete the last integer on the display
        private void backspaceButton_Click(object sender, EventArgs e)
        {
            display.Text = display.Text.Remove(display.Text.Length - 1, 1);
            currentNumber = display.Text;

            //If there is only one number, reset it to 0
            if (display.Text.Length == 0)
            {
                display.Text = "0";
                currentNumber = "";
            }
        }

        //Clears the calculator display and resets its state
        private void clearButton_Click(object sender, EventArgs e)
        {
            currentNumber = "";
            display.Text = "0";
            calculateReset();
        }

        //Checks the operand state of the calculator and performs the appropriate calculation
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
            else if (divideState)
            {
                numberTwo = double.Parse(display.Text);
                result = numberOne / double.Parse(currentNumber);
                display.Text = result.ToString();
            }
        }

        //Method checks for an the current state of the calculator, then resets it
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

        //Method checks if the last button pressed was equals, if so
        //set it to false in case of new operation desired and reset
        //the current number
        private void equalsClicked()
        {
            if (equalsActive)
            {
                currentNumber = "";
                equalsActive = false;
            }
        }

        //Method resets the state of the calculator
        private void calculateReset()
        {
            multiplyState = false;
            additionState = false;
            subtractState = false;
            divideState = false;
        }

        

        //Closes application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
