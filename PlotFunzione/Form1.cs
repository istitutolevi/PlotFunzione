using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlotFunzione
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            double xMin = double.Parse(txtXMin.Text);
            double xMax = double.Parse(txtXMax.Text);

            double rangeDominio = xMax - xMin;
            const double rangeCodominio = 2;

            int widthSchermo = ClientSize.Width - 20;
            int heightSchermo = ClientSize.Height - 10;

            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            int xSchermoPrecedente = int.MinValue;
            int ySchermoPrecedente = int.MinValue;

            for (double x = xMin; x < xMax; x += rangeDominio / 3 / widthSchermo)
            {
                double y = Function(x);
                int xSchermo = (int)((x - xMin) * widthSchermo / rangeDominio);
                int ySchermo = (int)((y + 1) * heightSchermo / rangeCodominio);

                if (ySchermoPrecedente != int.MinValue)
                {
                    g.DrawLine(Pens.Black, xSchermoPrecedente, ySchermoPrecedente, xSchermo, ySchermo);
                }

                xSchermoPrecedente = xSchermo;
                ySchermoPrecedente = ySchermo;
                // g.FillEllipse(Brushes.Black, xSchermo, ySchermo, 2, 2);
            }
        }

        private static double Function(double x)
        {
            return x * x*x * Math.Sin(10 * x);
        }

    }
}
