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

        double[,] Sigm1 = new double[2, 2];
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
            label8.Text = "";
            Mx1 = 0; Mx2 = 0; Mx3 = 0;
            My1 = 0; My2 = 0; My3 = 0;

            Dx1 = 0; Dx2 = 0; Dx2 = 0;
            Dy1 = 0; Dy2 = 0; Dy3 = 0;

            Kxy1 = 0; Kxy2 = 0; Kxy3 = 0;

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    Sigm1[i, j] = 0;
                    Sigm2[i, j] = 0;
                    Sigm3[i, j] = 0;
                }

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    SigmL1[i, j] = 0;
                    SigmL2[i, j] = 0;
                    SigmL3[i, j] = 0;
                }

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    ObrSigmL1[i, j] = 0;
                    ObrSigmL2[i, j] = 0;
                    ObrSigmL3[i, j] = 0;
                }

            //
            for (int i = 0; i < 25; i ++)
            {
                Mx1 += x1[i]; Mx2 += x2[i]; Mx3 += x3[i];
                My1 += y1[i]; My2 += y2[i]; My3 += y3[i];
            }
            Mx1 /= 25; Mx2 /= 25; Mx3 /= 25;
            My1 /= 25; My2 /= 25; My3 /= 25;

            label8.Text += ($"Mx1 = {Mx1} Mx2 = {Mx2} Mx3 = {Mx3}");
            label8.Text += ($"\nMy1 = {My1} My2 = {My2} Mx3 = {My3}");
            //


            //
            for (int i = 0; i < 25; i++)
            {
                Dx1 += ((x1[i] - Mx1) * (x1[i] - Mx1));
                Dx2 += ((x2[i] - Mx2) * (x2[i] - Mx2));
                Dx3 += ((x3[i] - Mx3) * (x3[i] - Mx3));

                Dy1 += ((y1[i] - My1) * (y1[i] - My1));
                Dy2 += ((y2[i] - My2) * (y2[i] - My2));
                Dy3 += ((y3[i] - My3) * (y3[i] - My3));
            }
            Dx1 /= 24; Dx2 /= 24; Dx3 /= 24;
            Dy1 /= 24; Dy2 /= 24; Dy3 /= 24;
            label8.Text += ($"\nDx1 = {Dx1} Dx2 = {Dx2} Dx3 = {Dx3}");
            label8.Text += ($"\nDy1 = {Dy1} Dy2 = {Dy2} Dy3 = {Dy3}");
            //


            //
            for (int i = 0; i < 25; i++)
            {
                Kxy1 += ((x1[i] - Mx1) * (y1[i] - My1));
                Kxy2 += ((x2[i] - Mx2) * (y2[i] - My2));
                Kxy3 += ((x3[i] - Mx3) * (y3[i] - My3));
            }
            Kxy1 /= 25; Kxy2 /= 25; Kxy3 /= 25;
            label8.Text += ($"\nKxy1 = {Kxy1} Kxy2 = {Kxy2} Kxy3 = {Kxy3}");
            //


            //
            Sigm1[0, 0] = Dx1;
            Sigm1[0, 1] = Kxy1;
            Sigm1[1, 0] = Kxy1;
            Sigm1[1, 1] = Dy1;
            //------//
            Sigm2[0, 0] = Dx2;
            Sigm2[0, 1] = Kxy2;
            Sigm2[1, 0] = Kxy2;
            Sigm2[1, 1] = Dy2;
            //------//
            Sigm3[0, 0] = Dx3;
            Sigm3[0, 1] = Kxy3;
            Sigm3[1, 0] = Kxy3;
            Sigm3[1, 1] = Dy3;
            //



            //
            SigmL1[0, 0] = (Sigm1[0, 0] * 25 + Sigm2[0, 0] * 25) / 50;
            SigmL1[0, 1] = (Sigm1[0, 1] * 25 + Sigm1[0, 1] * 25) / 50;
            SigmL1[1, 0] = (Sigm1[1, 0] * 25 + Sigm1[1, 0] * 25) / 50;
            SigmL1[1, 1] = (Sigm1[1, 1] * 25 + Sigm1[1, 1] * 25) / 50;
            //------//
            SigmL2[0, 0] = (Sigm2[0, 0] * 25 + Sigm2[0, 0] * 25) / 50;
            SigmL2[0, 1] = (Sigm2[0, 1] * 25 + Sigm2[0, 1] * 25) / 50;
            SigmL2[1, 0] = (Sigm2[1, 0] * 25 + Sigm2[1, 0] * 25) / 50;
            SigmL2[1, 1] = (Sigm2[1, 1] * 25 + Sigm2[1, 1] * 25) / 50;
            //------//
            SigmL3[0, 0] = (Sigm3[0, 0] * 25 + Sigm3[0, 0] * 25) / 50;
            SigmL3[0, 1] = (Sigm3[0, 1] * 25 + Sigm3[0, 1] * 25) / 50;
            SigmL3[1, 0] = (Sigm3[1, 0] * 25 + Sigm3[1, 0] * 25) / 50;
            SigmL3[1, 1] = (Sigm3[1, 1] * 25 + Sigm3[1, 1] * 25) / 50;
            //


            //
            ObrSigmL1[0, 0] = SigmL1[1, 1] / (SigmL1[0, 0] * SigmL1[0, 1] - SigmL1[0, 1] * SigmL1[1, 0]);
            ObrSigmL1[0, 1] = SigmL1[0, 1] / (SigmL1[0, 1] * SigmL1[1, 0] - SigmL1[0, 0] * SigmL1[1, 1]);
            ObrSigmL1[1, 0] = SigmL1[1, 0] / (SigmL1[0, 1] * SigmL1[1, 0] - SigmL1[0, 0] * SigmL1[1, 1]);
            ObrSigmL1[1, 1] = SigmL1[0, 0] / (SigmL1[0, 0] * SigmL1[0, 1] - SigmL1[0, 1] * SigmL1[1, 0]);
            //------//
            ObrSigmL2[0, 0] = SigmL2[1, 1] / (SigmL2[0, 0] * SigmL2[0, 1] - SigmL2[0, 1] * SigmL2[1, 0]);
            ObrSigmL2[0, 1] = SigmL2[0, 1] / (SigmL2[0, 1] * SigmL2[1, 0] - SigmL2[0, 0] * SigmL2[1, 1]);
            ObrSigmL2[1, 0] = SigmL2[1, 0] / (SigmL2[0, 1] * SigmL2[1, 0] - SigmL2[0, 0] * SigmL2[1, 1]);
            ObrSigmL2[1, 1] = SigmL2[0, 0] / (SigmL2[0, 0] * SigmL2[0, 1] - SigmL2[0, 1] * SigmL2[1, 0]);
            //------//
            ObrSigmL3[0, 0] = SigmL3[1, 1] / (SigmL3[0, 0] * SigmL3[0, 1] - SigmL3[0, 1] * SigmL3[1, 0]);
            ObrSigmL3[0, 1] = SigmL3[0, 1] / (SigmL3[0, 1] * SigmL3[1, 0] - SigmL3[0, 0] * SigmL3[1, 1]);
            ObrSigmL3[1, 0] = SigmL3[1, 0] / (SigmL3[0, 1] * SigmL3[1, 0] - SigmL3[0, 0] * SigmL3[1, 1]);
            ObrSigmL3[1, 1] = SigmL3[0, 0] / (SigmL3[0, 0] * SigmL3[0, 1] - SigmL3[0, 1] * SigmL3[1, 0]);
            //
        }
    }
}
