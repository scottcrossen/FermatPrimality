using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fermat_Primality_Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void solve_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(input.Text); // Takes the input and number of test
            int numtests = Convert.ToInt32(kvalue.Text); // And Stores them as ints, constant time complexity
            if (number < 0)
            {// If statements look for bad inputs, constant time
                output.Text = "Please select a positive integer";
            }
            else if (numtests > number - 1)
            {
                output.Text = "K value should be less than n-1";
            }
            else
            { // Begins valid input code
                Boolean prime = true;
                Random random = new Random(); // Generate random numbers for use as the base
                for (int i = 1; i <= numtests; i++)
                { // Primality checker, if we checked all numbers its O(n) time
                    if (modexp(random.Next(2, number - 1), number - 1, number) != 1) prime = false;
                }
                if (prime == true)
                {
                    double p = 1.0;
                    for (int i = 1; i <= numtests; i++)
                    { // Calculates probability using
                        p = (1.0 / 2.0) * p;
                    }
                    p = 100 * (1 - p);
                    output.Text = "yes with probability " + p + "%";
                }
                else
                { // Yes and no output given in the if/else
                    output.Text = "no";
                }
            }
        }
        private long modexp(int x, int y, int N)
        { // Modular Exponentiation O(n^3)
            if (y == 0) return 1;
            long z = modexp(x, Convert.ToInt32(Math.Floor(y / 2.0)), N);
            if (y % 2 == 0) return (z * z) % N;
            else return ((x % N) * ((z * z) % N)) % N;
        }
    }
}
