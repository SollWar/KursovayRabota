using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovayRabota
{
    public partial class Form1 : Form
    {
        int[] x1 = new int[25];
        int[] y1 = new int[25];
        int[] x2 = new int[25];
        int[] y2 = new int[25];
        int[] x3 = new int[25];
        int[] y3 = new int[25];

        int[] ex = new int[25];
        int[] ey = new int[25];

        double Mx1 = 0;
        double My1 = 0;

        double Mx2 = 0;
        double My2 = 0;

        double Mx3 = 0;
        double My3 = 0;

        double Dx1 = 0; double Dy1 = 0;
        double Dx2 = 0; double Dy2 = 0;
        double Dx3 = 0; double Dy3 = 0;

        double Kxy1 = 0;
        double Kxy2 = 0;
        double Kxy3 = 0;

        double[,] Sigm1 = new double[2,2];
        double[,] Sigm2 = new double[2, 2];
        double[,] Sigm3 = new double[2, 2];

        double[,] SigmL1 = new double[2, 2];
        double[,] SigmL2 = new double[2, 2];
        double[,] SigmL3 = new double[2, 2];

        double[,] ObrSigmL1 = new double[2, 2];
        double[,] ObrSigmL2 = new double[2, 2];
        double[,] ObrSigmL3 = new double[2, 2];

        double[,] M1_M2 = new double[0, 2];
        double[,] M2_M3 = new double[0, 2];
        double[,] M1_M3 = new double[0, 2];

        double[,] M1___M2 = new double[2, 0];
        double[,] M2___M3 = new double[2, 0];
        double[,] M1___M3 = new double[2, 0];

        double[,] b1 = new double[0, 2];
        double[,] b2 = new double[0, 2];
        double[,] b3 = new double[0, 2];

        double[,] vrm1 = new double[2, 0];
        double[,] vrm2 = new double[2, 0];
        double[,] vrm3 = new double[2, 0];

        double vr1 = 0;
        double vr2 = 0;
        double vr3 = 0;

        double p1 = 0;
        double p2 = 0;
        double p3 = 0;

        double xline1n = 0;
        double xline1k = 0;
        double yline1n = 0;
        double yline1k = 0;

        double xline2n = 0;
        double xline2k = 0;
        double yline2n = 0;
        double yline2k = 0;

        double xline3n = 0;
        double xline3k = 0;
        double yline3n = 0;
        double yline3k = 0;

        int avrx1 = 0; int avry1 = 0;
        int sigmax1 = 0; int sigmay1 = 0;

        int avrx2 = 0; int avry2 = 0;
        int sigmax2 = 0; int sigmay2 = 0;

        int avrx3 = 0; int avry3 = 0;
        int sigmax3 = 0; int sigmay3 = 0;

        int avrxE = 0; int avryE = 0;
        int sigmaxE = 0; int sigmayE = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                chart1.Series["1 образ"].Points.Clear();
                chart1.Series["2 образ"].Points.Clear();
                chart1.Series["3 образ"].Points.Clear();
                chart1.Series["Материал экзамена"].Points.Clear();

                Random rnd = new Random();
                int jx1 = 1;
                int jy1 = 26;

                int jx2 = 51;
                int jy2 = 76;

                int jx3 = 101;
                int jy3 = 126;

                int jxex = 151;
                int jyex = 176;


                for (int i = 0; i < 25; i++)
                {
                    x1[i] = Convert.ToInt32(rnd.NextDouble() * (65 - 55) + 55);
                    panel1.Controls["textBox" + jx1].Text = Convert.ToString(x1[i]);
                    y1[i] = Convert.ToInt32(rnd.NextDouble() * (55 - 45) + 45);
                    panel1.Controls["textBox" + jy1].Text = Convert.ToString(y1[i]);
                    chart1.Series["1 образ"].Points.AddXY(x1[i], y1[i]);

                    x2[i] = Convert.ToInt32(rnd.NextDouble() * (75 - 65) + 65);
                    panel1.Controls["textBox" + jx2].Text = Convert.ToString(x2[i]);
                    y2[i] = Convert.ToInt32(rnd.NextDouble() * (65 - 55) + 55);
                    panel1.Controls["textBox" + jy2].Text = Convert.ToString(y2[i]);
                    chart1.Series["2 образ"].Points.AddXY(x2[i], y2[i]);

                    x3[i] = Convert.ToInt32(rnd.NextDouble() * (65 - 55) + 55);
                    panel1.Controls["textBox" + jx3].Text = Convert.ToString(x3[i]);
                    y3[i] = Convert.ToInt32(rnd.NextDouble() * (75 - 65) + 65);
                    panel1.Controls["textBox" + jy3].Text = Convert.ToString(y3[i]);
                    chart1.Series["3 образ"].Points.AddXY(x3[i], y3[i]);

                    ex[i] = Convert.ToInt32(rnd.NextDouble() * (75 - 54) + 54);
                    panel1.Controls["textBox" + jxex].Text = Convert.ToString(ex[i]);
                    ey[i] = Convert.ToInt32(rnd.NextDouble() * (75 - 45) + 45);
                    panel1.Controls["textBox" + jyex].Text = Convert.ToString(ey[i]);
                    chart1.Series["Материал экзамена"].Points.AddXY(ex[i], ey[i]);

                    jx1++;
                    jy1++;
                    jx2++;
                    jy2++;
                    jx3++;
                    jy3++;
                    jxex++;
                    jyex++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int jx1 = 1;
            int jy1 = 26;

            int jx2 = 51;
            int jy2 = 76;

            int jx3 = 101;
            int jy3 = 126;

            int jxex = 151;
            int jyex = 176;

            for (int i = 0; i < 25; i++)
            {
                panel1.Controls["textBox" + jx1].Text = "";
                panel1.Controls["textBox" + jy1].Text = "";
                panel1.Controls["textBox" + jx2].Text = "";
                panel1.Controls["textBox" + jy2].Text = "";
                panel1.Controls["textBox" + jx3].Text = "";
                panel1.Controls["textBox" + jy3].Text = "";
                panel1.Controls["textBox" + jxex].Text = "";
                panel1.Controls["textBox" + jyex].Text = "";
                jx1++;
                jy1++;
                jx2++;
                jy2++;
                jx3++;
                jy3++;
                jxex++;
                jyex++;
            }

            chart1.Series["1 образ"].Points.Clear();
            chart1.Series["2 образ"].Points.Clear();
            chart1.Series["3 образ"].Points.Clear();
            chart1.Series["Материал экзамена"].Points.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
