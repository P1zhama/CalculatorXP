using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorXP
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
        }


        private decimal firstNum = 0.0m;
        private decimal secondNum = 0.0m;
        private decimal result = 0.0m;
        private int operatorType = (int)MathOperations.NoOperator;

        public enum MathOperations
        {
            NoOperator = 0,
            Add = 1,
            Minus = 2,
            Divide = 3,
            Multiply = 4,
            Percentage = 5
        }


        private void DigitBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (DisplayTextBox.Text == "0")
            {
                DisplayTextBox.Clear();
            }
            DisplayTextBox.Text += btn.Text;
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if (!DisplayTextBox.Text.Contains("."))
            {
                DisplayTextBox.Text += ".";
            }
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            if (!DisplayTextBox.Text.Contains("-"))
            {
                DisplayTextBox.Text = "-" + DisplayTextBox.Text;
            }
            else
            {
                DisplayTextBox.Text = DisplayTextBox.Text.Trim('-');
            }

        }

        private void SaveValueAndOperatorType(int operation)
        {
            operatorType = operation;
            firstNum = Convert.ToDecimal(DisplayTextBox.Text);
            DisplayTextBox.Text = "0";
        }
        private void EqualButton_Click(object sender, EventArgs e)
        {
            secondNum = Convert.ToDecimal(DisplayTextBox.Text);

            switch (operatorType)
            {
                case (int)MathOperations.Add:
                    result = firstNum + secondNum;
                    break;
                case (int)MathOperations.Minus:
                    result = firstNum - secondNum;
                    break;
                case (int)MathOperations.Divide:
                    result = firstNum / secondNum;
                    break;
                case (int)MathOperations.Multiply:
                    result = firstNum * secondNum;
                    break;
                case (int)MathOperations.Percentage:
                    result = firstNum % secondNum;
                    break;
                default:
                    break;
            }

            DisplayTextBox.Text = result.ToString();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            SaveValueAndOperatorType((int)MathOperations.Add);
        }
        private void MinusButton_Click(object sender, EventArgs e)
        {
            SaveValueAndOperatorType((int)MathOperations.Minus);
        }
        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            SaveValueAndOperatorType((int)MathOperations.Multiply);
        }
        private void DivideButton_Click(object sender, EventArgs e)
        {
            SaveValueAndOperatorType((int)MathOperations.Divide);
        }
        private void PercentButton_Click(object sender, EventArgs e)
        {
            SaveValueAndOperatorType((int)MathOperations.Percentage);
        }

        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = "0";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = "0";
            firstNum = 0.0m;
            secondNum = 0.0m;
            result = 0;
            operatorType = (int)MathOperations.NoOperator;
        }
    }
}
