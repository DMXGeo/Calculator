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
        String currentNumber;
        double numberOne;
        double numberTwo;
        double result;

        bool clickedOnce;
        bool additionState, subtractState, multiplyState, divideState;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void number1_Click(object sender, EventArgs e)
        {
            EqualsClicked();
            currentNumber += "1";
            display.Text = currentNumber;
        }

        private void number2_Click(object sender, EventArgs e)
        {
            EqualsClicked();
            currentNumber += "2";
            display.Text = currentNumber;
        }

        private void number3_Click(object sender, EventArgs e)
        {
            EqualsClicked();
            currentNumber += "3";
            display.Text = currentNumber;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            calculateReset();
            
            numberOne = double.Parse(display.Text);
            currentNumber = "";
            clickedOnce = false;

            additionState = true;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            calculateReset();
            
            numberOne = double.Parse(display.Text);
            currentNumber = "";
            clickedOnce = false;

            multiplyState = true;

        }


        private void equalsButton_Click(object sender, EventArgs e)
        {
            if(multiplyState)
            {
                if(clickedOnce)
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
            else if (additionState)
            {
                if(clickedOnce)
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
            
            clickedOnce = true;

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            currentNumber = "";
            display.Text = "0";
            numberOne = 0;
            numberTwo = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EqualsClicked()
        {
            if(clickedOnce)
            {
                currentNumber = "";
            }
        }

        private void calculateReset()
        {
            multiplyState = false;
            additionState = false;
        }

        
    }
}
