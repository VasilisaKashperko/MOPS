using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            double[] x = { 14, 16, 17, 19, 18, 15, 14, 18, 17, 15, 13, 16, 17, 19, 18, 20, 12, 13, 12, 14 };
            double[] y = { 222, 241, 243, 285, 253, 247, 246, 276, 261, 254, 229, 249, 252, 279, 262, 275, 211, 220, 218, 232 };
            double[] powX = new double[20];
            double[] differenceX = new double[20];
            double[] differenceY = new double[20];
            double[] powDifferenceX = new double[20];
            double[] powDifferenceY = new double[20];
            double[] differenceXY = new double[20];
            double[] yt = new double[20];
            double[] et = new double[20];
            double[] powEt = new double[20];
            double[] powSt = new double[20];
            double sumX = 0, sumY = 0, avgX = 0, avgY = 0;
            double sumPowX = 0;
            double avgPowX = 0;
            double sumDifferenceX = 0;
            double avgDifferenceX = 0;
            double sumPowDifferenceX = 0;
            double avgPowDifferenceX = 0;
            double sumDifferenceY = 0;
            double avgDifferenceY = 0;
            double sumPowDifferenceY = 0;
            double avgPowDifferenceY = 0;
            double sumDifferenceXY = 0;
            double avgDifferenceXY = 0;
            double sumYt = 0;
            double avgYt = 0;
            double sumEt = 0;
            double avgEt = 0;
            double sumPowEt = 0;
            double avgPowEt = 0;
            double sumPowSt = 0;
            double avgPowSt = 0;
            double t = 20;





            this.chart1.Series[0].Points.Clear();
  
            this.chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
            for (int i = 0; i < t; i++)
            {
                this.chart1.Series[0].Points.AddXY(x[i], y[i]);
                powX[i] = Math.Pow(x[i], 2);
                sumX += x[i];
                sumY += y[i];
                sumPowX += powX[i];
            }
            avgX = sumX / t;
            avgY = sumY / t;
            avgPowX = sumPowX / t;
            double _x = Math.Round(1 / t * sumX, 3);
            double _y = Math.Round((1 / t) * sumY, 4);
            for (int i = 0; i < t; i++)
            {
                differenceX[i] = x[i] - _x;
                differenceY[i] = y[i] - _y;
                powDifferenceX[i] = Math.Round(Math.Pow(differenceX[i], 2), 4);
                powDifferenceY[i] = Math.Round(Math.Pow(differenceY[i], 2), 4);
                differenceXY[i] = differenceX[i] * differenceY[i];
                sumDifferenceX += differenceX[i];
                sumDifferenceY += differenceY[i];
                sumPowDifferenceX += powDifferenceX[i];
                sumPowDifferenceY += powDifferenceY[i];
                sumDifferenceXY += differenceXY[i];
            }
            avgDifferenceX = sumDifferenceX / t;
            avgDifferenceY = sumDifferenceY / t;
            avgPowDifferenceX = sumPowDifferenceX / t;
            avgPowDifferenceY = sumPowDifferenceY / t;
            avgDifferenceXY = sumDifferenceXY / t;

            double a1 = sumDifferenceXY / sumPowDifferenceX;
            double a0 = a1 * _x;
            for (int i = 0; i < t; i++)
            {
                yt[i] =a0 + x[i] * a1;
                Math.Round(yt[i], 4);
                et[i] = y[i] - yt[i];
                powEt[i] = Math.Round(Math.Pow(et[i], 2),4);
                powSt[i] = Math.Round(powEt[i] / (t - 2),4);
                sumYt += yt[i];
                sumEt += et[i];
                sumPowEt += powEt[i];
                sumPowSt += powSt[i];
            }
            avgYt = sumYt / t;
            avgEt = sumEt / t;
            avgPowEt = sumPowEt / t;
            avgPowSt = sumPowSt / t;
            double powR;
            powR = 1 - (sumPowEt / sumPowDifferenceY);
            MessageBox.Show(powR.ToString());
            dataGridView1.RowCount= 23;
            dataGridView1.ColumnCount = 13;
            for(int i=0;i<dataGridView1.RowCount-3;i++)
            {
                dataGridView1.Rows[i+1].Cells[0].Value = i + 1;
                dataGridView1.Rows[i + 1].Cells[1].Value = x[i];
                dataGridView1.Rows[i + 1].Cells[2].Value = x[i];
                dataGridView1.Rows[i + 1].Cells[3].Value = y[i];
                dataGridView1.Rows[i + 1].Cells[4].Value = powX[i];
                dataGridView1.Rows[i + 1].Cells[5].Value = differenceX[i];
                dataGridView1.Rows[i + 1].Cells[6].Value = powDifferenceX[i];
                dataGridView1.Rows[i + 1].Cells[7].Value = differenceY[i];
                dataGridView1.Rows[i + 1].Cells[8].Value = powDifferenceY[i];
                dataGridView1.Rows[i + 1].Cells[9].Value = differenceXY[i];
                dataGridView1.Rows[i + 1].Cells[10].Value = yt[i];
                dataGridView1.Rows[i + 1].Cells[11].Value = et[i];
                dataGridView1.Rows[i + 1].Cells[11].Value = powEt[i];
                dataGridView1.Rows[i + 1].Cells[12].Value = powSt[i];
            }
            dataGridView1.Rows[0].Cells[0].Value = 't';
            dataGridView1.Rows[0].Cells[1].Value = 'x';
            dataGridView1.Rows[0].Cells[2].Value = 'y';
            dataGridView1.Rows[0].Cells[3].Value = "x2";
            dataGridView1.Rows[0].Cells[4].Value = "x-x_";
            dataGridView1.Rows[0].Cells[5].Value ="(x-x_)2";
            dataGridView1.Rows[0].Cells[6].Value = "y-y_";
            dataGridView1.Rows[0].Cells[7].Value = "(y-y_)2";
            dataGridView1.Rows[0].Cells[8].Value = "(x-x_)(y-y_)";
            dataGridView1.Rows[0].Cells[9].Value = "yt";
            dataGridView1.Rows[0].Cells[10].Value = "et";
            dataGridView1.Rows[0].Cells[11].Value = "et2";
            dataGridView1.Rows[0].Cells[12].Value = "st2";
            dataGridView1.Rows[21].Cells[0].Value="Сумма";
            dataGridView1.Rows[21].Cells[1].Value = sumX;
            dataGridView1.Rows[21].Cells[2].Value = sumY;
            dataGridView1.Rows[21].Cells[3].Value = sumPowX;
            dataGridView1.Rows[21].Cells[4].Value = sumDifferenceX;
            dataGridView1.Rows[21].Cells[5].Value = sumPowDifferenceX;
            dataGridView1.Rows[21].Cells[6].Value = sumDifferenceY;
            dataGridView1.Rows[21].Cells[7].Value = sumPowDifferenceY;
            dataGridView1.Rows[21].Cells[8].Value = sumDifferenceXY;
            dataGridView1.Rows[21].Cells[9].Value = sumYt;
            dataGridView1.Rows[21].Cells[10].Value = sumEt;
            dataGridView1.Rows[21].Cells[11].Value = sumPowEt;
            dataGridView1.Rows[21].Cells[12].Value = sumPowSt;
            dataGridView1.Rows[22].Cells[0].Value = "Средняя";
            dataGridView1.Rows[22].Cells[1].Value =avgX;
            dataGridView1.Rows[22].Cells[2].Value =avgY;
            dataGridView1.Rows[22].Cells[3].Value =avgPowX;
            dataGridView1.Rows[22].Cells[4].Value =avgDifferenceX;
            dataGridView1.Rows[22].Cells[5].Value =avgPowDifferenceX;
            dataGridView1.Rows[22].Cells[6].Value =avgDifferenceY;
            dataGridView1.Rows[22].Cells[7].Value =avgPowDifferenceY;
            dataGridView1.Rows[22].Cells[8].Value =avgDifferenceXY;
            dataGridView1.Rows[22].Cells[9].Value =avgYt;
            dataGridView1.Rows[22].Cells[10].Value =avgEt;
            dataGridView1.Rows[22].Cells[11].Value =avgPowEt;
            dataGridView1.Rows[22].Cells[12].Value =avgPowSt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
