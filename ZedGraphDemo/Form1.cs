using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateGraphs();
        }

        double[] X = new double[100];
        double[] Y = new double[100];

        List<PointPairList> points = new List<PointPairList>();
        
        
        void CreateGraphs()
        {

            Random rand = new Random();

            int i = 0;
            for (i = 0; i < 27; i++)
            {
                points.Add(new PointPairList());
                Color c = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255));
                zedGraphControl1.GraphPane.AddCurve("Freq" + (2400 + i), points[i], c, SymbolType.None);
            }

            double A = 1221.2;
            double B = 133;
            double C = 112;

            int j = 0;
            for (j = 0; j < 27; j++)
            {
                for (i = 0; i < 100; i++)
                {

                    double y = A * Math.Pow(i* j, 2) + B * i* j + C;
                    points[j].Add(new PointPair(i, y));
                    zedGraphControl1.GraphPane.CurveList[j].AddPoint(points[j][i].X, points[j][i].Y);
                }
            }

            zedGraphControl1.GraphPane.Title.Text = "Example for line graph" ;
            zedGraphControl1.GraphPane.Legend.Position = ZedGraph.LegendPos.Right;

            zedGraphControl1.GraphPane.Legend.FontSpec.Size = 8.0f;
            zedGraphControl1.GraphPane.Legend.FontSpec.Family = "Arial, Narrow";

            zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Size = 10.0f;
            zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Family = "Arial, Narrow";

            zedGraphControl1.GraphPane.XAxis.Title.FontSpec.Size = 10.0f;
            zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Family = "Arial, Narrow";

            zedGraphControl1.GraphPane.Chart.Fill.Color = System.Drawing.Color.White;
            zedGraphControl1.GraphPane.Legend.IsVisible = false;

            zedGraphControl1.GraphPane.YAxis.Title.Text = "Y";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "X";

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();


        }         
    }
}
