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

        double[,] M1_M2 = new double[2, 1];
        double[,] M2_M3 = new double[2, 1];
        double[,] M1_M3 = new double[2, 1];

        double[,] M1___M2 = new double[1, 2];
        double[,] M2___M3 = new double[1, 2];
        double[,] M1___M3 = new double[1, 2];

        double[,] b1 = new double[2, 1];
        double[,] b2 = new double[2, 1];
        double[,] b3 = new double[2, 1];

        double[,] vrm1 = new double[1, 2];
        double[,] vrm2 = new double[1, 2];
        double[,] vrm3 = new double[1, 2];

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
                chart1.Series["Линия 1"].Points.Clear();
                chart1.Series["Линия 2"].Points.Clear();
                chart1.Series["Линия 3"].Points.Clear();

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
            if (radioButton2.Checked)
            {
                bool point = true;
                for (int i = 1; i <= 200; i++)
                    if (panel1.Controls["textBox" + i].Text == "")
                        point = false;
                if (point == true)
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
                        x1[i] = Convert.ToInt32(panel1.Controls["textBox" + jx1].Text);
                        y1[i] = Convert.ToInt32(panel1.Controls["textBox" + jy1].Text);
                        chart1.Series["1 образ"].Points.AddXY(x1[i], y1[i]);

                        x2[i] = Convert.ToInt32(panel1.Controls["textBox" + jx2].Text);
                        y2[i] = Convert.ToInt32(panel1.Controls["textBox" + jy2].Text);
                        chart1.Series["2 образ"].Points.AddXY(x2[i], y2[i]);

                        x3[i] = Convert.ToInt32(panel1.Controls["textBox" + jx3].Text);
                        y3[i] = Convert.ToInt32(panel1.Controls["textBox" + jy3].Text);
                        chart1.Series["3 образ"].Points.AddXY(x3[i], y3[i]);

                        ex[i] = Convert.ToInt32(panel1.Controls["textBox" + jxex].Text);
                        ey[i] = Convert.ToInt32(panel1.Controls["textBox" + jyex].Text);
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
            else
            { }
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
            chart1.Series["Линия 1"].Points.Clear();
            chart1.Series["Линия 2"].Points.Clear();
            chart1.Series["Линия 3"].Points.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series["Линия 1"].Points.Clear();
            chart1.Series["Линия 2"].Points.Clear();
            chart1.Series["Линия 3"].Points.Clear();

            label8.Text = "";
            Mx1 = 0; Mx2 = 0; Mx3 = 0;
            My1 = 0; My2 = 0; My3 = 0;

            Dx1 = 0; Dx2 = 0; Dx3 = 0;
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

            label8.Text += ($"Mx1 = {Mx1:0.##} Mx2 = {Mx2:0.##} Mx3 = {Mx3:0.##}");
            label8.Text += ($"\nMy1 = {My1:0.##} My2 = {My2:0.##} Mx3 = {My3:0.##}");
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
            label8.Text += ($"\nDx1 = {Dx1:0.##} Dx2 = {Dx2:0.##} Dx3 = {Dx3:0.##}");
            label8.Text += ($"\nDy1 = {Dy1:0.##} Dy2 = {Dy2:0.##} Dy3 = {Dy3:0.##}");
            //


            //
            for (int i = 0; i < 25; i++)
            {
                Kxy1 += ((x1[i] - Mx1) * (y1[i] - My1));
                Kxy2 += ((x2[i] - Mx2) * (y2[i] - My2));
                Kxy3 += ((x3[i] - Mx3) * (y3[i] - My3));
            }
            Kxy1 /= 25; Kxy2 /= 25; Kxy3 /= 25;
            label8.Text += ($"\nKxy1 = {Kxy1:0.##} Kxy2 = {Kxy2:0.##} Kxy3 = {Kxy3:0.##}");
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

            label8.Text += "\nSigm1 \n";

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    label8.Text += ($"{Sigm1[i,j]:0.##} ");
                }
                label8.Text += ($"\n");
            }
            
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

            label8.Text += "\nSigmL1 \n";

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    label8.Text += ($"{SigmL1[i, j]:0.##} ");
                }
                label8.Text += ($"\n");
            }

            //


            //
            ObrSigmL1[0, 0] = SigmL1[1, 1] / (SigmL1[0, 0] * SigmL1[1, 1] - SigmL1[0, 1] * SigmL1[1, 0]);
            ObrSigmL1[0, 1] = SigmL1[0, 1] / (SigmL1[0, 1] * SigmL1[1, 0] - SigmL1[0, 0] * SigmL1[1, 1]);
            ObrSigmL1[1, 0] = SigmL1[1, 0] / (SigmL1[0, 1] * SigmL1[1, 0] - SigmL1[0, 0] * SigmL1[1, 1]);
            ObrSigmL1[1, 1] = SigmL1[0, 0] / (SigmL1[0, 0] * SigmL1[1, 1] - SigmL1[0, 1] * SigmL1[1, 0]);
            //------//
            ObrSigmL2[0, 0] = SigmL2[1, 1] / (SigmL2[0, 0] * SigmL2[1, 1] - SigmL2[0, 1] * SigmL2[1, 0]);
            ObrSigmL2[0, 1] = SigmL2[0, 1] / (SigmL2[0, 1] * SigmL2[1, 0] - SigmL2[0, 0] * SigmL2[1, 1]);
            ObrSigmL2[1, 0] = SigmL2[1, 0] / (SigmL2[0, 1] * SigmL2[1, 0] - SigmL2[0, 0] * SigmL2[1, 1]);
            ObrSigmL2[1, 1] = SigmL2[0, 0] / (SigmL2[0, 0] * SigmL2[1, 1] - SigmL2[0, 1] * SigmL2[1, 0]);
            //------//
            ObrSigmL3[0, 0] = SigmL3[1, 1] / (SigmL3[0, 0] * SigmL3[1, 1] - SigmL3[0, 1] * SigmL3[1, 0]);
            ObrSigmL3[0, 1] = SigmL3[0, 1] / (SigmL3[0, 1] * SigmL3[1, 0] - SigmL3[0, 0] * SigmL3[1, 1]);
            ObrSigmL3[1, 0] = SigmL3[1, 0] / (SigmL3[0, 1] * SigmL3[1, 0] - SigmL3[0, 0] * SigmL3[1, 1]);
            ObrSigmL3[1, 1] = SigmL3[0, 0] / (SigmL3[0, 0] * SigmL3[1, 1] - SigmL3[0, 1] * SigmL3[1, 0]);

            label8.Text += "\nObrSigmL1 \n";

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    label8.Text += ($"{ObrSigmL1[i, j]}   ");
                }
                label8.Text += ($"\n");
            }

            //


            //
            M1_M2[0, 0] = Mx1 - Mx2;
            M1_M2[1, 0] = My1 - My2;

            M2_M3[0, 0] = Mx2 - Mx3;
            M2_M3[1, 0] = My2 - My3;

            M1_M3[0, 0] = Mx1 - Mx3;
            M1_M3[1, 0] = My1 - My3;

            M1___M2[0, 0] = Mx1 + Mx2;
            M1___M2[0, 1] = My1 + My2;

            M2___M3[0, 0] = Mx2 + Mx3;
            M2___M3[0, 1] = My2 + My3;

            M1___M3[0, 0] = Mx1 + Mx3;
            M1___M3[0, 1] = My1 + My3;
            //


            //

            b1[0, 0] = ObrSigmL1[0, 0] * M1_M2[0, 0] + ObrSigmL1[0, 1] * M1_M2[1, 0];
            b1[1, 0] = ObrSigmL1[1, 0] * M1_M2[0, 0] + ObrSigmL1[1, 1] * M1_M2[1, 0];

            b2[0, 0] = ObrSigmL2[0, 0] * M2_M3[0, 0] + ObrSigmL2[0, 1] * M2_M3[1, 0];
            b2[1, 0] = ObrSigmL2[1, 0] * M2_M3[0, 0] + ObrSigmL2[1, 1] * M2_M3[1, 0];

            b3[0, 0] = ObrSigmL3[0, 0] * M1_M3[0, 0] + ObrSigmL3[0, 1] * M1_M3[1, 0];
            b3[1, 0] = ObrSigmL3[1, 0] * M1_M3[0, 0] + ObrSigmL3[1, 1] * M1_M3[1, 0];

            label8.Text += "\nb1 \n";

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    label8.Text += ($"{b1[i, j]}   ");
                }
                label8.Text += ($"\n");
            }
            //


            //
            vrm1[0, 0] = M1___M2[0, 0] * ObrSigmL1[0, 0] + M1___M2[0, 1] * ObrSigmL1[0, 1];
            vrm1[0, 1] = M1___M2[0, 0] * ObrSigmL1[0, 1] + M1___M2[0, 1] * ObrSigmL1[1, 1];

            vrm2[0, 0] = M2___M3[0, 0] * ObrSigmL2[0, 0] + M2___M3[0, 1] * ObrSigmL2[0, 1];
            vrm2[0, 1] = M2___M3[0, 0] * ObrSigmL2[0, 1] + M2___M3[0, 1] * ObrSigmL2[1, 1];

            vrm3[0, 0] = M1___M3[0, 0] * ObrSigmL3[0, 0] + M1___M3[0, 1] * ObrSigmL3[0, 1];
            vrm3[0, 1] = M1___M3[0, 0] * ObrSigmL3[0, 1] + M1___M3[0, 1] * ObrSigmL3[1, 1];


            vr1 = vrm1[0, 0] * M1_M2[0, 0] + vrm1[0, 1] * M1_M2[1, 0];
            vr2 = vrm2[0, 0] * M2_M3[0, 0] + vrm2[0, 1] * M2_M3[1, 0];
            vr3 = vrm3[0, 0] * M1_M3[0, 0] + vrm3[0, 1] * M1_M3[1, 0];

            p1 = vr1 * (-0.5); p2 = vr2 * (-0.5); p3 = vr3 * (-0.5);
            label8.Text += ($"\nvr1 = {vr1} vr2 = {vr2:0.##} vr3 = {vr3:0.##}");
            label8.Text += ($"\np1 = {p1:0.##} p2 = {p2:0.##} p3 = {p3:0.##}");
            //


            //
            xline1n = ex.Min(); xline2n = ex.Min(); xline3n = ex.Min();
            xline1k = ex.Max(); xline2k = ex.Max(); xline3k = ex.Max();

            yline1n = (-p1 - b1[0,0] * xline1n) / b1[1, 0];
            yline1k = (-p1 - b1[0, 0] * xline1k) / b1[1, 0];
            chart1.Series["Линия 1"].Points.AddXY(xline1n, yline1n);
            chart1.Series["Линия 1"].Points.AddXY(xline1k, yline1k);

            yline2n = (-p2 - b2[0, 0] * xline2n) / b2[1, 0];
            yline2k = (-p2 - b2[0, 0] * xline2k) / b2[1, 0];
            chart1.Series["Линия 2"].Points.AddXY(xline2n, yline2n);
            chart1.Series["Линия 2"].Points.AddXY(xline2k, yline2k);

            yline3n = (-p3 - b3[0, 0] * xline3n) / b3[1, 0];
            yline3k = (-p3 - b3[0, 0] * xline3k) / b3[1, 0];
            chart1.Series["Линия 3"].Points.AddXY(xline3n, yline3n);
            chart1.Series["Линия 3"].Points.AddXY(xline3k, yline3k);




            //

            label9.Text = "1 образ";
            int test = 0;
            for (int i = 0; i < 25; i++)
            {
                if ((b1[0, 0] * Convert.ToDouble(ex[i]) + b1[1, 0] * Convert.ToDouble(ey[i]) + p1) >= 0 && (b3[0, 0] * Convert.ToDouble(ex[i]) + b3[1, 0] * Convert.ToDouble(ey[i]) + p3) >= 0)
                {
                    test++;
                    label9.Text += ($"\n({ex[i]};{ey[i]})");
                }
            }
            label9.Text += ($"\nСум= {test}");

            label11.Text = "2 образ";
            int test1 = 0;
            for (int i = 0; i < 25; i++)
            {
                if ((b1[0, 0] * Convert.ToDouble(ex[i]) + b1[1, 0] * Convert.ToDouble(ey[i]) + p1) <= 0 && (b2[0, 0] * Convert.ToDouble(ex[i]) + b2[1, 0] * Convert.ToDouble(ey[i]) + p2) >= 0)
                {
                    test1++;
                    label11.Text += ($"\n({ex[i]};{ey[i]})");
                }
            }
            label11.Text += ($"\nСум= {test1}");

            label10.Text = "3 образ";
            int test2 = 0;
            for (int i = 0; i < 25; i++)
            {
                if ((b3[0, 0] * Convert.ToDouble(ex[i]) + b3[1, 0] * Convert.ToDouble(ey[i]) + p3) <= 0 && (b2[0, 0] * Convert.ToDouble(ex[i]) + b2[1, 0] * Convert.ToDouble(ey[i]) + p2) <= 0)
                {
                    test2++;
                    label10.Text += ($"\n({ex[i]};{ey[i]})");
                }
            }
            label10.Text += ($"\nСум= {test2}");
            //
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
